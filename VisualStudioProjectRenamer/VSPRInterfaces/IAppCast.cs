namespace VSPRInterfaces
{
    public interface IAppCast
    {
        string ApplicationName { get; set; }
        string InstalledVersion { get; set; }
        string DownloadLink { get; set; }
        string ReleaseNotesLink { get; set; }
        string Version { get; set; }
        int CompareTo(IAppCast other);
    }
}