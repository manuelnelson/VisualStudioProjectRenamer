namespace VSPRInterfaces
{
    public interface ILocalizable
    {
        ILocalizationService LocalizationService { get; }
        void Localize();
    }
}