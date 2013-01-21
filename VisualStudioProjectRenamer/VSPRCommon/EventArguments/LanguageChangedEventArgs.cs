namespace VSPRCommon.EventArguments
{
    using System;

    public sealed class LanguageChangedEventArgs : EventArgs
    {
        public LanguageChangedEventArgs(bool refresh)
        {
            Refresh = refresh;
        }

        public bool Refresh { get; set; }
    }
}