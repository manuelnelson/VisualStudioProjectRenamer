namespace VSPRBase.Common
{
	using Factories;
	using Renamer;
	using Services;
	using StructureMap;
	using VSPRInterfaces;
	using VSPRUpdater;

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
	public sealed class ServiceLocator
	{
		public static void Initialize()
		{
			ObjectFactory.Initialize(x =>
										 {
											 x.For<IErrorDialogService>().Use<ErrorDialogService>();
											 x.For<IGuard>().Use<Guard>();
											 x.For<IProjectService>().Use<ProjectService>();
											 x.For<IAboutBoxService>().Use<AboutBoxService>();

											 // The ILocalizationService needs to be a singleton, as every gui control will use this to change locale.
											 // The service fires an event, when the language was changed and this only work with a singleton.
											 x.For<ILocalizationService>().Singleton().Use<LocalizationService>();
											 x.For<ISettingsFormService>().Use<SettingsFormService>();
											 x.For<IConfirmationDialogService>().Use<ConfirmationDialogService>();
											 x.For<IRenameService>().Use<RenameService>();
											 x.For<IRenamerFactory>().Use<RenamerFactory>();
											 x.For<IRenamer>().Use<SVNRenamer>().Named(Constants.SVNRenamer);
											 x.For<IRenamer>().Use<StandardRenamer>().Named(Constants.StandardRenamer);
											 x.For<IVersionControlDetector>().Use<VersionControlDetector>();
											 x.For<IUpdateService>().Use<UpdateService>();
											 x.For<IUpdater>().Use<Updater>();
											 x.For<ICopyService>().Use<CopyService>();
										     x.For<ISettingsService>().Use<SettingsService>();
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