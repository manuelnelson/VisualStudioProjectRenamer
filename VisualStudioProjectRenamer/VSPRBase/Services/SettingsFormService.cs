namespace VSPRBase.Services
{
    using System.Windows.Forms;
    using Forms;
    using VSPRInterfaces;

    internal class SettingsFormService : ISettingsFormService
    {
        public void ShowSettingsForm()
        {
            using (SettingsForm settingsForm = new SettingsForm())
            {
                DialogResult result = settingsForm.ShowDialog();
                // TODO NKO: Do something with the result
            }
        }
    }
}