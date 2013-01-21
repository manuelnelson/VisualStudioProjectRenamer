namespace VSPRUpdater.Forms
{
    using System;
    using System.Windows.Forms;
    using Common;
    using ComponentFactory.Krypton.Toolkit;
    using VSPRCommon;
    using VSPRInterfaces;

    public partial class UpdaterForm : KryptonForm
    {
        private readonly IAppCast item;
        private readonly ILocalizationService localizationService;

        public UpdaterForm(IAppCast item)
        {
            InitializeComponent();

            this.item = item;
            localizationService = ServiceLocator.GetInstance<ILocalizationService>();
            Localize();

            Browser.AllowWebBrowserDrop = false;
            Browser.AllowNavigation = false;

            if (!string.IsNullOrEmpty(item.ReleaseNotesLink))
            {
                Browser.Navigate(item.ReleaseNotesLink);
            }
        }

        private void Localize()
        {
            newVersionLabel.Text = string.Format(localizationService.GetString(LocalizationResourceNames.UpdaterFormNewVersionAvailable), item.ApplicationName);
            infoTextLabel.Text = string.Format(localizationService.GetString(LocalizationResourceNames.UpdaterFormInfoText), item.ApplicationName, item.Version, item.InstalledVersion);
            Text = localizationService.GetString(LocalizationResourceNames.UpdaterFormText);
            cancelButton.Text = localizationService.GetString(LocalizationResourceNames.UpdaterFormCancelButtonText);
            installButton.Text = localizationService.GetString(LocalizationResourceNames.UpdaterFormInstallButtonText);
        }

        private void UpdateButtonClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
        }

        private void CancelButtonClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}