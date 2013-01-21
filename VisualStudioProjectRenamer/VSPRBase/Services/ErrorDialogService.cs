namespace VSPRBase.Services
{
    using System.Windows.Forms;
    using Forms;
    using VSPRInterfaces;

    internal sealed class ErrorDialogService : IErrorDialogService
    {
        public void HandleError(string errorMessage)
        {
            ErrorDialog errorDialog = new ErrorDialog(errorMessage);

            using (errorDialog)
            {
                // TODO NKO: Do something with the result.
                DialogResult result = errorDialog.ShowDialog();
            }
        }
    }
}