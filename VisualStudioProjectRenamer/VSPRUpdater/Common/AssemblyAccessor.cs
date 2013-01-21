namespace VSPRUpdater.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using VSPRInterfaces;

    internal sealed class AssemblyAccessor : IAssemblyAccessor
    {
        private readonly Assembly assembly;
        private readonly List<Attribute> assemblyAttributes;

        public AssemblyAccessor()
        {
            assemblyAttributes = new List<Attribute>();
            assembly = Assembly.GetEntryAssembly();

            foreach (CustomAttributeData data in assembly.GetCustomAttributesData())
            {
                assemblyAttributes.Add(CreateAttribute(data));
            }

            if (assemblyAttributes == null || assemblyAttributes.Count == 0)
            {
                throw new Exception(string.Format("Unable to load assembly attributes from {0}", assembly.FullName));
            }
        }

        public string AssemblyCompany
        {
            get
            {
                AssemblyCompanyAttribute assemblyCompanyAttribute = FindAttribute(typeof (AssemblyCompanyAttribute)) as AssemblyCompanyAttribute;

                return assemblyCompanyAttribute != null ? assemblyCompanyAttribute.Company : string.Empty;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                AssemblyCopyrightAttribute assemblyCopyrightAttribute = FindAttribute(typeof (AssemblyCopyrightAttribute)) as AssemblyCopyrightAttribute;

                return assemblyCopyrightAttribute != null ? assemblyCopyrightAttribute.Copyright : string.Empty;
            }
        }

        public string AssemblyDescription
        {
            get
            {
                AssemblyDescriptionAttribute assemblyDescriptionAttribute = FindAttribute(typeof (AssemblyDescriptionAttribute)) as AssemblyDescriptionAttribute;
                return assemblyDescriptionAttribute != null ? assemblyDescriptionAttribute.Description : string.Empty;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                AssemblyProductAttribute assemblyProductAttribute = FindAttribute(typeof (AssemblyProductAttribute)) as AssemblyProductAttribute;

                return assemblyProductAttribute != null ? assemblyProductAttribute.Product : string.Empty;
            }
        }

        public string AssemblyTitle
        {
            get
            {
                AssemblyTitleAttribute assemblyTitleAttribute = FindAttribute(typeof (AssemblyTitleAttribute)) as AssemblyTitleAttribute;
                return assemblyTitleAttribute != null ? assemblyTitleAttribute.Title : string.Empty;
            }
        }

        public string AssemblyVersion
        {
            get { return assembly.GetName().Version.ToString(); }
        }

        /// <summary>
        /// This methods creates an attribute instance from the attribute data 
        /// information
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private Attribute CreateAttribute(CustomAttributeData data)
        {
            IEnumerable<object> arguments = from arg in data.ConstructorArguments select arg.Value;
            Attribute attribute = (Attribute) data.Constructor.Invoke(arguments.ToArray());

            if (data.NamedArguments != null)
            {
                foreach (CustomAttributeNamedArgument namedArgument in data.NamedArguments)
                {
                    PropertyInfo propertyInfo = namedArgument.MemberInfo as PropertyInfo;
                    if (propertyInfo != null)
                    {
                        propertyInfo.SetValue(attribute, namedArgument.TypedValue.Value, null);
                    }
                    else
                    {
                        FieldInfo fieldInfo = namedArgument.MemberInfo as FieldInfo;
                        if (fieldInfo != null)
                        {
                            fieldInfo.SetValue(attribute, namedArgument.TypedValue.Value);
                        }
                    }
                }
            }

            return attribute;
        }

        private Attribute FindAttribute(Type AttributeType)
        {
            foreach (Attribute attribute in assemblyAttributes)
            {
                if (attribute.GetType() == AttributeType)
                {
                    return attribute;
                }
            }

            throw new Exception(string.Format("Attribute of type {0} does not exists in the assembly {1}", AttributeType, assembly.FullName));
        }
    }
}