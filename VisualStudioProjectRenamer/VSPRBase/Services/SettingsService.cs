namespace VSPRBase.Services
{
    using System;
    using System.Windows.Forms;
    using NK.Foundation.Xml.Deserialization;
    using NK.Foundation.Xml.Serialization;
    using VSPRCommon;
    using VSPRInterfaces;

    internal class SettingsService : ISettingsService
    {
        private readonly string path;

        public SettingsService()
        {
            path = string.Format("{0}\\settings.xml", Application.StartupPath);
        }

        public Settings LoadSettings()
        {
            Settings settings;

            try
            {
                Deserializer deserializer = new Deserializer();
                settings = deserializer.Deserialize<Settings>(path);
            }
            catch (Exception exception)
            {
                var message = exception.Message;
                settings = new Settings();
            }

            return settings;
        }

        public bool SaveSettings(Settings settings)
        {
            bool wasSaved;
            Serializer serializer = new Serializer();
           
            try
            {
                serializer.Serialize(settings, path);
                wasSaved = true;
            }
            catch (Exception exception)
            {
                var message = exception.Message;
                wasSaved = false;
            }

            return wasSaved;
        }
    }
}