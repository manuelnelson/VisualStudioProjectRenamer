namespace VSPRUpdater.Common
{
    using System;
    using VSPRInterfaces;

    internal sealed class Configuration : IConfiguration
    {
        public Configuration(IAssemblyAccessor assemblyAccessor)
        {
            try
            {
                ApplicationName = assemblyAccessor.AssemblyProduct;
                InstalledVersion = assemblyAccessor.AssemblyVersion;
            }
            catch(Exception exception)
            {
                // TODO NKO WTF IS THIS? 
                if(exception.Message.Contains("STOP:"))
                {
                    throw;
                }
            }
        }

        public string ApplicationName { get; private set; }

        public bool CheckForUpdateDisabled { get; set; }

        public string InstalledVersion { get; private set; }

        public bool ShowDiagnosticWindow { get; set; }
      
        public string ReferenceAssembly { get; set; }
    }
}