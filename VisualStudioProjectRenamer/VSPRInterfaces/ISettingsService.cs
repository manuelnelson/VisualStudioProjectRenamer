namespace VSPRInterfaces
{
    using VSPRCommon;

    public interface ISettingsService
    {
        Settings LoadSettings();
        bool SaveSettings(Settings settings);
    }
}