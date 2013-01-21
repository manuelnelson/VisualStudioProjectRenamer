namespace VSPRCommon
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    using ComponentFactory.Krypton.Toolkit;

    [Serializable]
    public class Settings
    {
        public Settings()
        {
            // Initialize with default values, if there was no settings saved before.
            SelectedLanguage = "en-US";
            Layout = PaletteModeManager.Office2007Blue;
            UseSystemLanguage = true;
            Proxy = new Proxy();
        }

        public PaletteModeManager Layout { get; set; }

        public string SelectedLanguage { get; set; }

        public bool UseSystemLanguage { get; set; }

        public Proxy Proxy { get; set; }

        public bool CheckForUpdateOnStartup { get; set; }

        [XmlIgnore]
        public IList<string> Languages
        {
            get { return new Language().GetLanguages(); }
        }
    }
}