namespace VSPRBase.Forms
{
    using System;
    using System.Windows.Forms;
    using Common;
    using ComponentFactory.Krypton.Toolkit;
    using VSPRCommon;
    using VSPRInterfaces;

    internal sealed partial class ErrorDialog : KryptonForm, ILocalizable
    {
        private bool errorMessageWasCopiedToClipBoard;

        public ErrorDialog(string errorMessage)
        {
            InitializeComponent();
            LocalizationService = ServiceLocator.GetInstance<ILocalizationService>();

            Localize();
            SetErrorMessage(errorMessage);
        }

        public ILocalizationService LocalizationService { get; private set; }

        public void Localize()
        {
            Text = LocalizationService.GetString(LocalizationResourceNames.ErrorDialogFormText);
            errorMessageInfoLabel.Text = LocalizationService.GetString(LocalizationResourceNames.ErrorDialogErrorMessageLabelText);
            closeButton.Text = LocalizationService.GetString(LocalizationResourceNames.ErrorDialogCloseButtonText);
            copyToClipBoardButton.Text = LocalizationService.GetString(LocalizationResourceNames.ErrorDialogCopyButtonText);
        }

        private void CloseButtonClick(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }

        private void CopyToClipBoardButtonClick(object sender, EventArgs e)
        {
            if(errorMessageWasCopiedToClipBoard)
            {
                return;
            }

            Clipboard.SetDataObject(errorMessageRichtTextBox.Text, true);
            errorMessageInfoLabel.Text = LocalizationService.GetString(LocalizationResourceNames.ErrorDialogErrorMessageCopied);
            copyToClipBoardButton.Enabled = false;
            errorMessageWasCopiedToClipBoard = true;
        }

        private void CopyToClipBoardButtonMouseLeave(object sender, EventArgs e)
        {
            lblStatus.Text = string.Empty;
        }

        private void CopyToClipBoardButtonMouseMove(object sender, MouseEventArgs e)
        {
            lblStatus.Text = LocalizationService.GetString(LocalizationResourceNames.ErrorDialogCopyErrorMessageToolTip);
        }

        private void SetErrorMessage(string errorMessage)
        {
            errorMessageRichtTextBox.Text = errorMessage;
        }
    }
}