namespace VSPRInterfaces
{
    public interface IUpdater
    {
        string AppCastUrl { get; set; }
        bool ShowDiagnosticWindow { get; set; }
        bool TrustEverySSLConnection { get; set; }
        void ReportDiagnosticMessage(string message);
        void GetUpdate();
    }
}