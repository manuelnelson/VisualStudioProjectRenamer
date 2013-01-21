namespace VSPRInterfaces
{
    using System;
    using System.Globalization;
    using VSPRCommon.EventArguments;
    public interface ILocalizationService
    {
        CultureInfo CurrentCulture { get; }
        CultureInfo SystemCulture { get; }
        event EventHandler<LanguageChangedEventArgs> LanguageChanged;
        string GetString(string resourceName);
        void SetCulture(string culture);
    }
}