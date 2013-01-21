namespace VSPRBase.Services
{
    using System.Windows.Forms;
    using Forms;
    using VSPRCommon;
    using VSPRInterfaces;

    internal sealed class ConfirmationDialogService : IConfirmationDialogService
    {
        public DialogResult ShowConfirmationDialog(Project oldProject, Project newProject)
        {
            ConfirmationDialog confirmationDialog = new ConfirmationDialog(oldProject, newProject);
            DialogResult dialogResult;

            using (confirmationDialog)
            {
                dialogResult = confirmationDialog.ShowDialog();
            }

            return dialogResult;
        }
    }
}