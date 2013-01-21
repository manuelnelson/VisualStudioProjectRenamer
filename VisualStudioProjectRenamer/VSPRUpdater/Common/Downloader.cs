namespace VSPRUpdater.Common
{
    using System;
    using System.IO;
    using System.Net;
    using System.Windows.Forms;
    using System.Xml;
    using Forms;
    using VSPRInterfaces;

    internal sealed class Downloader : IDownloader
    {
        private readonly ISettingsService settingsService;

        public Downloader(ISettingsService settingsService)
        {
            this.settingsService = settingsService;
        }

        public IAppCast DownloadAppCast(string appCastUrl, IConfiguration configuration)
        {
            WebRequest request = WebRequest.Create(appCastUrl);
            WebResponse response = request.GetResponse();

            Stream inputstream = response.GetResponseStream();
            IAppCast latestVersion = null;

            if (inputstream != null)
            {
                XmlTextReader reader = new XmlTextReader(inputstream);
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(reader);

                latestVersion = ServiceLocator.GetInstance<IAppCast>();

                XmlNode node = xmlDocument.SelectSingleNode(Constants.ReleaseNotesLinkNode);
                if (node != null)
                {
                    latestVersion.ReleaseNotesLink = node.InnerText;
                }

                node = xmlDocument.SelectSingleNode(Constants.VersionNode);
                if (node != null)
                {
                    latestVersion.Version = node.InnerText;
                }

                node = xmlDocument.SelectSingleNode(Constants.DownloadUrlNode);
                if (node != null)
                {
                    latestVersion.DownloadLink = node.InnerText;
                }

                latestVersion.ApplicationName = configuration.ApplicationName;
                latestVersion.InstalledVersion = configuration.InstalledVersion;
            }

            return latestVersion;
        }

        public void DownloadUpdate(IAppCast appcast, string fileName, Form form)
        {
            var downloadForm = (DownloadForm)form;
            using (WebClient client = new WebClient())
            {
                // Check if we need a proxy
                var settings = settingsService.LoadSettings();
                if (settings.Proxy.IsValid)
                {
                    client.Proxy = new WebProxy(settings.Proxy.Url) { Credentials = new NetworkCredential(settings.Proxy.Username, settings.Proxy.Password) };
                }

                client.DownloadProgressChanged += downloadForm.ClientDownloadProgressChanged;
                client.DownloadFileCompleted += downloadForm.ClientDownloadFileCompleted;

                Uri url = new Uri(appcast.DownloadLink);
                client.DownloadFileAsync(url, fileName);
            }
        }
    }
}