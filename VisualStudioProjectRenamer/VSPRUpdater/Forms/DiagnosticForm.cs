namespace VSPRUpdater.Forms
{
    using System;
    using Common;
    using ComponentFactory.Krypton.Toolkit;
    using VSPRCommon;
    using VSPRInterfaces;

    public partial class DiagnosticForm : KryptonForm
    {
        private ILocalizationService localizationService;

        public DiagnosticForm()
        {
            InitializeComponent();

            localizationService = ServiceLocator.GetInstance<ILocalizationService>();
            Localize();
        }

        private void Localize()
        {
            Text = localizationService.GetString(LocalizationResourceNames.DiagnosticFormText);
            closeButton.Text = localizationService.GetString(LocalizationResourceNames.DiagnosticFormCloseButtonText);
        }

        public void Report(string message)
        {
            if(listBox.InvokeRequired)
            {
                listBox.Invoke(new Action<string>(Report), message);
            }
            else
            {
                DateTime now = DateTime.Now;
                message = string.Format("[{0}] {1}", now.ToLongTimeString(), message);

                listBox.Items.Add(message);

                // Select the last added item in the listbox.
                listBox.SelectedIndex = listBox.Items.Count - 1;
            }
        }

        private void CloseButtonClick(object sender, EventArgs e)
        {
            Hide();
        }
    }
}