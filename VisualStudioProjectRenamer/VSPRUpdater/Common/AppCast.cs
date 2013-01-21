namespace VSPRUpdater.Common
{
    using System;
    using VSPRInterfaces;

    internal sealed class AppCast : IComparable<IAppCast>, IAppCast
    {
        public string ApplicationName { get; set; }
        public string InstalledVersion { get; set; }
        public string DownloadLink { get; set; }
        public string ReleaseNotesLink { get; set; }
        public string Version { get; set; }

        public int CompareTo(IAppCast other)
        {
            Version version = new Version(Version);
            Version otherVersion = new Version(other.Version);

            return version.CompareTo(otherVersion);
        }
    }
}