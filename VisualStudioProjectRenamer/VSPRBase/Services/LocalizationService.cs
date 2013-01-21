namespace VSPRBase.Services
{
    using System;
    using System.Globalization;
    using System.Reflection;
    using System.Resources;
    using System.Threading;
    using VSPRCommon.EventArguments;
    using VSPRInterfaces;
    using VSPRLocalization;

    /// <summary>
    /// Wrapperclass around the resource manager. Localization files are stored in the VSPRLocalization assembly.
    /// </summary>
    internal sealed class LocalizationService : ILocalizationService
    {
        private readonly ResourceManager resourceManager;

        public LocalizationService()
        {
            resourceManager = new ResourceManager("VSPRLocalization.VSPRLocalization", Assembly.GetAssembly(typeof (LocaleBootstrap)));

            // The application starts always with the system culture.. at least for now until i am able to save settings.
            SystemCulture = new CultureInfo(Thread.CurrentThread.CurrentUICulture.Name);
        }

        public CultureInfo CurrentCulture { get; private set; }

        public CultureInfo SystemCulture { get; private set; }

        public event EventHandler<LanguageChangedEventArgs> LanguageChanged;

        public void InvokeLanguageChanged(LanguageChangedEventArgs args)
        {
            EventHandler<LanguageChangedEventArgs> handler = LanguageChanged;
            if (handler != null)
            {
                handler(this, args);
            }
        }

        public string GetString(string resourceName)
        {
            if (CurrentCulture != null)
            {
                // Use the culture that was set in the gui.
                SetCulture(CurrentCulture.Name);
            }

            return resourceManager.GetString(resourceName);
        }

        public void SetCulture(string culture)
        {
            // New culture was set in the gui
            if (!culture.Equals(Thread.CurrentThread.CurrentUICulture.Name))
            {
                // This is used for the language of the user interface
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);

                // This is used with formatting and sort options (e.g. number and date formats)
                // e.g. a float value 2.352 will be 2,3.52 if CurrentCulture is set to de-DE
                Thread.CurrentThread.CurrentCulture = new CultureInfo(culture);

                CurrentCulture = Thread.CurrentThread.CurrentUICulture;

                // Notify every gui element that is listening to the LanguageChanged Event, that the language changed.
                InvokeLanguageChanged(new LanguageChangedEventArgs(true));
            }
        }
    }
}