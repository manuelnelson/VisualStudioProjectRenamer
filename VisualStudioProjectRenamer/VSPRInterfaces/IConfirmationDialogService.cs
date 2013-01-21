namespace VSPRInterfaces
{
    using System.Windows.Forms;
    using VSPRCommon;

    public interface IConfirmationDialogService
    {
        DialogResult ShowConfirmationDialog(Project oldProject, Project newProject);
    }
}