namespace VSPRBase.Forms
{
    using System;
    using System.Reflection;
    using Common;
    using ComponentFactory.Krypton.Toolkit;
    using VSPRCommon;
    using VSPRInterfaces;

    internal sealed partial class AboutBox : KryptonForm, ILocalizable
    {
        public AboutBox()
        {
            InitializeComponent();
            LocalizationService = ServiceLocator.GetInstance<ILocalizationService>();
            Localize();
        }

        public string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof (AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }

                return ((AssemblyCompanyAttribute) attributes[0]).Company;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof (AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }

                return ((AssemblyCopyrightAttribute) attributes[0]).Copyright;
            }
        }

        public string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof (AssemblyDescriptionAttribute), false);

                if (attributes.Length == 0)
                {
                    return "";
                }

                return ((AssemblyDescriptionAttribute) attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof (AssemblyProductAttribute), false);

                if (attributes.Length == 0)
                {
                    return "";
                }

                return ((AssemblyProductAttribute) attributes[0]).Product;
            }
        }

        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof (AssemblyTitleAttribute), false);

                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute) attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }

                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion
        {
            get { return Assembly.GetExecutingAssembly().GetName().Version.ToString(); }
        }

        public ILocalizationService LocalizationService { get; private set; }

        public void Localize()
        {
            lblProductName.Text = LocalizationService.GetString(LocalizationResourceNames.AboutBoxProduct);
            lblProductVersion.Text = string.Format(LocalizationService.GetString(LocalizationResourceNames.AboutBoxProductVersion), AssemblyVersion);
            lblCopyright.Text = string.Format(LocalizationService.GetString(LocalizationResourceNames.AboutBoxCopyRight), "2011 by Norman Kosmal");
            lblCompanyName.Text = string.Format(LocalizationService.GetString(LocalizationResourceNames.AboutBoxCompany), AssemblyCompany);
        }

        private void KryptonButtonOkClick(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }

        private void LinkLabelLinkClicked(object sender, EventArgs eventArgs)
        {
            System.Diagnostics.Process.Start(linkLabel.Text);
        }
    }
}