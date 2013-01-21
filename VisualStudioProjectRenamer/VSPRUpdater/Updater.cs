namespace VSPRUpdater
{
    using System;
    using System.Drawing;
    using System.Net;
    using System.Net.Security;
    using System.Security.Cryptography.X509Certificates;
    using System.Windows.Forms;
    using Common;
    using Forms;
    using VSPRCommon;
    using VSPRInterfaces;

    public sealed class Updater : IUpdater
    {
        private DiagnosticForm diagnosticWindow;
        private readonly IDownloader downloader;
        private readonly ILocalizationService localizationService;
        private Settings settings;
        private readonly ISettingsService settingsservice;

        public Updater()
        {
            ServiceLocator.Configure();

            settingsservice = ServiceLocator.GetInstance<ISettingsService>();
            localizationService = ServiceLocator.GetInstance<ILocalizationService>();
            downloader = ServiceLocator.GetInstance<IDownloader>();
            Configuration = ServiceLocator.GetInstance<IConfiguration>();

            ApplySettings();
        }

        public string AppCastUrl { get; set; }

        public bool ShowDiagnosticWindow { get; set; }

        public bool TrustEverySSLConnection { get; set; }

        public void GetUpdate()
        {
            Init();

            IAppCast appCastItem;
            if (IsUpdateRequired(out appCastItem))
            {
                GetUpdate(appCastItem);
            }
            else
            {
                string text = localizationService.GetString(LocalizationResourceNames.NoUpdateRequiredMessage);
                string caption = localizationService.GetString(LocalizationResourceNames.NoUpdateRequiredCaption);
                MessageBox.Show(text, caption, MessageBoxButtons.OK);
            }

            HideDiagnosticForm();
        }

        public void ReportDiagnosticMessage(string message)
        {
            if (diagnosticWindow.InvokeRequired)
            {
                diagnosticWindow.Invoke(new Action<string>(ReportDiagnosticMessage), message);
            }
            else
            {
                diagnosticWindow.Report(message);
            }
        }

        private void ApplySettings()
        {
            settings = settingsservice.LoadSettings();
            localizationService.SetCulture(settings.SelectedLanguage);
        }

        private IConfiguration Configuration { get; set; }

        private void GetUpdate(IAppCast appCastItem)
        {
            ShowDiagnosticWindowIfNeeded();

            ReportDiagnosticMessage(localizationService.GetString(LocalizationResourceNames.UpdaterUpdateStartDiagMessage));
            ReportDiagnosticMessage(localizationService.GetString(LocalizationResourceNames.UpdaterReadingConfigDiagMessage));
            ReportDiagnosticMessage(string.Format(localizationService.GetString(LocalizationResourceNames.UpdaterUpdateNeededDiagMessage), Configuration.InstalledVersion, appCastItem.Version));

            ShowUpdateForm(appCastItem);
        }

        private void HideDiagnosticForm()
        {
            if (diagnosticWindow != null)
            {
                diagnosticWindow.Hide();
            }
        }

        private void Init()
        {
            ServicePointManager.ServerCertificateValidationCallback += RemoteCertificateValidation;

            diagnosticWindow = new DiagnosticForm();
            ShowDiagnosticWindowIfNeeded();
            ReportDiagnosticMessage(string.Format(localizationService.GetString(LocalizationResourceNames.UpdaterUsingUrlDiagMessage), AppCastUrl));
        }

        private void InitDownloadAndInstallProcess(IAppCast item)
        {
            DownloadForm downloadForm = new DownloadForm(this, item);
            downloadForm.ShowDialog();
        }

        private bool IsUpdateRequired(out IAppCast latestVersion)
        {
            ReportDiagnosticMessage(localizationService.GetString(LocalizationResourceNames.UpdaterCheckingAppCastDiagMessage));

            try
            {
                latestVersion = downloader.DownloadAppCast(AppCastUrl, Configuration);
            }
            catch (Exception exception)
            {
                ReportDiagnosticMessage(string.Format(localizationService.GetString(LocalizationResourceNames.UpdaterErrorDownloadingAppCastDiagMessage), exception.Message));
                latestVersion = null;
            }

            if (latestVersion == null)
            {
                ReportDiagnosticMessage(localizationService.GetString(LocalizationResourceNames.UpdaterNoVersionInfoInAppCastDiagMessage));
                return false;
            }

            ReportDiagnosticMessage(string.Format(localizationService.GetString(LocalizationResourceNames.UpdaterLatestVersionDiagMessage), latestVersion.Version));

            // Compare the installed version with the one available on the server.
            Version installedVersion = new Version(Configuration.InstalledVersion);
            Version serverVersion = new Version(latestVersion.Version);

            if (serverVersion <= installedVersion)
            {
                ReportDiagnosticMessage(string.Format(localizationService.GetString(LocalizationResourceNames.UpdaterInstalledVersionIsValidDiagMessage), Configuration.InstalledVersion));
                return false;
            }

            return true;
        }

        private bool RemoteCertificateValidation(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            if (TrustEverySSLConnection)
            {
                HttpWebRequest httpWebRequest = sender as HttpWebRequest;
                if (httpWebRequest == null)
                {
                    return certificate is X509Certificate2 && ((X509Certificate2)certificate).Verify();
                }

                // return our trust 
                if (httpWebRequest.RequestUri.Equals(new Uri(AppCastUrl)))
                {
                    return true;
                }

                return (certificate is X509Certificate2) && ((X509Certificate2)certificate).Verify();
            }

            // check our certificate                 
            return (certificate is X509Certificate2) && ((X509Certificate2)certificate).Verify();
        }

        private void ShowDiagnosticWindowIfNeeded()
        {
            if (diagnosticWindow.InvokeRequired)
            {
                diagnosticWindow.Invoke(new Action(ShowDiagnosticWindowIfNeeded));
            }
            else
            {
                if (ShowDiagnosticWindow)
                {
                    Point newLocation = new Point { X = Screen.PrimaryScreen.Bounds.Width - diagnosticWindow.Width, Y = 0 };

                    diagnosticWindow.Location = newLocation;
                    diagnosticWindow.Show();
                }
            }
        }

        private void ShowUpdateForm(IAppCast currentItem)
        {
            UpdaterForm updaterForm = new UpdaterForm(currentItem) { TopMost = true };
            DialogResult dialogResult = updaterForm.ShowDialog();

            if (dialogResult.Equals(DialogResult.Yes))
            {
                InitDownloadAndInstallProcess(currentItem);
            }
        }
    }
}