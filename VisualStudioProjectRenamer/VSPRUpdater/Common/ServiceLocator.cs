namespace VSPRUpdater.Common
{
    using StructureMap;
    using VSPRInterfaces;

    /// <summary>
    /// The Service Locator class. Retrieve all interfaces in this assembly via this class.
    /// 
    /// <![CDATA[
    /// Examples:
    ///    ObjectFactory.Initialize(x =>
    ///     {
    ///         x.For<IRepository>().Use<Repository>()
    ///         .WithCtorArg("connectionString").EqualTo("a connection string");
    ///     
    ///         // Or, since it's smelly to embed a connection string directly into code,
    ///         // we could pull the connection string from the AppSettings
    /// 
    ///         x.For<IRepository>().Use<Repository>()
    ///         .WithCtorArg("connectionString").EqualToAppSetting("CONNECTION-STRING");
    ///     });
    /// ]]>
    /// </summary>
    internal sealed class ServiceLocator
    {
        public static void Configure()
        {
            // The container is already initialized in the vsprbase assembly thats why
            // we only need to add the types defined in this assembly to the object factory instead of 
            // initializing the container here again.
            ObjectFactory.Container.Configure(x =>
                                                  {
                                                      x.For<IConfiguration>().Use<Configuration>();
                                                      x.For<IDownloader>().Use<Downloader>();
                                                      x.For<IInstaller>().Use<Installer>();
                                                      x.For<IAssemblyAccessor>().Use<AssemblyAccessor>();
                                                      x.For<IAppCast>().Use<AppCast>();
                                                  });
        }

        public static T GetInstance<T>()
        {
            return ObjectFactory.TryGetInstance<T>();
        }

        public static T GetNamedInstance<T>(string name)
        {
            return ObjectFactory.GetNamedInstance<T>(name);
        }
    }
}