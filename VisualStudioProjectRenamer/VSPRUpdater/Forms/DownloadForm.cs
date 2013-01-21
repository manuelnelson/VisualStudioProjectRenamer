namespace VSPRUpdater.Forms
{
    using System;
    using System.ComponentModel;
    using System.IO;
    using System.Net;
    using Common;
    using ComponentFactory.Krypton.Toolkit;
    using VSPRCommon;
    using VSPRInterfaces;

    public partial class DownloadForm : KryptonForm
    {
        private readonly IAppCast appcast;
        private readonly IDownloader downloader;
        private readonly IInstaller installer;
        private string tempName;
        private readonly IUpdater updater;
        private readonly ILocalizationService localizationService;

        public DownloadForm(IUpdater updater, IAppCast appcast)
        {
            InitializeComponent();

            this.updater = updater;
            this.appcast = appcast;

            downloader = ServiceLocator.GetInstance<IDownloader>();
            installer = ServiceLocator.GetInstance<IInstaller>();
            localizationService = ServiceLocator.GetInstance<ILocalizationService>();

            ToogleControls();
            Localize();
            SetTempFileName();
            StartDownload();
        }

        public void ClientDownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            downloadProgressBar.Visible = false;

            if(e.Error == null)
            {
                CheckFile();
            }
            else
            {
                ReportErrorAndCloseForm(e);
            }
        }

        public void ClientDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            downloadProgressBar.Value = e.ProgressPercentage;
        }

        private void Localize()
        {
            headerLabel.Text = headerLabel.Text.Replace("APP", string.Format("{0} {1}", appcast.ApplicationName, appcast.Version));
            Text = localizationService.GetString(LocalizationResourceNames.DownloadFormDownloadingUpdateFormText);
            installAndRelaunchButton.Text = localizationService.GetString(LocalizationResourceNames.DownloadFormInstallButtonText);
        }

        private void CheckFile()
        {
            installAndRelaunchButton.Visible = true;
            headerLabel.Text = localizationService.GetString(LocalizationResourceNames.DownloadFormDownloadFinishedHeaderLabelText);

            var diagMessage = string.Format(localizationService.GetString(LocalizationResourceNames.DownloadFormDownloadFinishedDiagMessage), tempName);
            updater.ReportDiagnosticMessage(diagMessage);

            if(File.Exists(tempName))
            {
                // check if the file was downloaded successfully
                string absolutePath = Path.GetFullPath(tempName);
                if(!File.Exists(absolutePath))
                {
                    throw new FileNotFoundException();
                }
            }
        }

        private void InstallAndRelaunchButtonClick(object sender, EventArgs e)
        {
            installer.Install(tempName, updater);
        }

        private void ReportErrorAndCloseForm(AsyncCompletedEventArgs e)
        {
            var diagMessage = string.Format(localizationService.GetString(LocalizationResourceNames.DownloadFormErrorWhileDownloadingDiagMessage), e.Error.Message);
            updater.ReportDiagnosticMessage(diagMessage);

            IErrorDialogService errorDialogService = ServiceLocator.GetInstance<IErrorDialogService>();
            errorDialogService.HandleError(diagMessage);

            Close();
            Dispose();
        }

        private void SetTempFileName()
        {
            string[] segments = appcast.DownloadLink.Split('/');
            string fileName = segments[segments.Length - 1];

            tempName = Environment.ExpandEnvironmentVariables("%temp%\\" + fileName);
        }

        private void StartDownload()
        {
            downloader.DownloadUpdate(appcast, tempName, this);
        }

        private void ToogleControls()
        {
            installAndRelaunchButton.Visible = false;

            downloadProgressBar.Maximum = 100;
            downloadProgressBar.Minimum = 0;
            downloadProgressBar.Step = 1;
        }
    }
}