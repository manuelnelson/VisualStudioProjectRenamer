namespace VSPRBase.Services
{
    using Forms;
    using VSPRInterfaces;

    internal sealed class AboutBoxService : IAboutBoxService
    {
        public void ShowAboutBox()
        {
            using (AboutBox aboutbox = new AboutBox())
            {
                aboutbox.ShowDialog();
            }
        }
    }
}