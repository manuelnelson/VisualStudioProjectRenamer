namespace VSPRBase.Forms
{
    using System;
    using System.Windows.Forms;
    using Common;
    using ComponentFactory.Krypton.Toolkit;
    using VSPRCommon;
    using VSPRInterfaces;

    internal sealed partial class ConfirmationDialog : KryptonForm, ILocalizable
    {
        private readonly Project newProject;
        private readonly Project oldProject;

        public ConfirmationDialog(Project oldProject, Project newProject)
        {
            LocalizationService = ServiceLocator.GetInstance<ILocalizationService>();
            this.oldProject = oldProject;
            this.newProject = newProject;

            InitializeComponent();
            Localize();
        }

        public ILocalizationService LocalizationService { get; private set; }

        public void Localize()
        {
            Text = LocalizationService.GetString(LocalizationResourceNames.ConfirmationDialogFormText);
            confirmationMessageRichTextbox.Text = string.Format(LocalizationService.GetString(LocalizationResourceNames.ConfirmationDialogConfirmRenameQuestion), oldProject.ProjectName, newProject.ProjectName);
            // TODO NKO: Format the old and new project name somehow (example below)
            //rtbMessage.Rtf = //@"{\rtf1\ansi This is in \b bold\b0.}";
            confirmButton.Text = LocalizationService.GetString(LocalizationResourceNames.ConfirmationDialogOKButtonText);
            cancelButton.Text = LocalizationService.GetString(LocalizationResourceNames.ConfirmationDialogCancelButtonText);
        }

        private void CancelButtonClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void ConfirmButtonClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}