namespace VSPRBase.Forms
{
    using System;
    using Common;
    using ComponentFactory.Krypton.Toolkit;
    using VSPRCommon;
    using VSPRCommon.EventArguments;
    using VSPRInterfaces;

    internal sealed partial class SettingsForm : KryptonForm, ILocalizable
    {
        private readonly Settings settings;
        private readonly ISettingsService settingsService;

        public SettingsForm()
        {
            LocalizationService = ServiceLocator.GetInstance<ILocalizationService>();
            settingsService = ServiceLocator.GetInstance<ISettingsService>();
            InitializeComponent();

            settings = settingsService.LoadSettings();

            LocalizationService.LanguageChanged += LanguageChanged;

            BindControls();
            ApplySettings();
            ToogleLanguageControls();

            Localize();
        }

        public ILocalizationService LocalizationService { get; private set; }

        public void Localize()
        {
            Text = LocalizationService.GetString(LocalizationResourceNames.SettingsFormFormText);
            layoutSettingsLabel.Text = LocalizationService.GetString(LocalizationResourceNames.SettingsFormLayoutSettingsLabelText);
            languageSettingsLabel.Text = LocalizationService.GetString(LocalizationResourceNames.SettingsFormLanguageSettingsLabelText);
            chooseLanguageLabel.Text = LocalizationService.GetString(LocalizationResourceNames.SettingsFormChooseLanguageLabelText);
            applySettingsButton.Text = LocalizationService.GetString(LocalizationResourceNames.SettingsFormApplyButtonText);
            useSystemLanguageCheckBox.Text = LocalizationService.GetString(LocalizationResourceNames.SettingsFormUseSystemLanguageLabeltext);
            proxySettingsLabel.Text = LocalizationService.GetString(LocalizationResourceNames.SettingsFormProxySettingsLabelText);
            proxyAddressLabel.Text = LocalizationService.GetString(LocalizationResourceNames.SettingsFormProxyAddressLabelText);
            proxyPasswordLabel.Text = LocalizationService.GetString(LocalizationResourceNames.SettingsFormProxyPasswordLabelText);
            proxyUsernameLabel.Text = LocalizationService.GetString(LocalizationResourceNames.SettingsFormProxyUsernameLabelText);
            updateLabel.Text = LocalizationService.GetString(LocalizationResourceNames.SettingsFormUpdateLabelText);
            updateOnStartupCheckBox.Text = LocalizationService.GetString(LocalizationResourceNames.SettingsFormUpdateCheckBoxText);
        }

        private void ApplySettings()
        {
            useSystemLanguageCheckBox.Checked = settings.UseSystemLanguage;
            updateOnStartupCheckBox.Checked = settings.CheckForUpdateOnStartup;

            switch(settings.Layout)
            {
                case PaletteModeManager.Office2007Blue:
                    office2007BlueRadioButton.Checked = true;
                    break;

                case PaletteModeManager.Office2007Silver:
                    office2007SilverRadioButton.Checked = true;
                    break;

                case PaletteModeManager.Office2010Blue:
                    office2010BlueRadioButton.Checked = true;
                    break;

                case PaletteModeManager.Office2010Silver:
                    office2007SilverRadioButton.Checked = true;
                    break;

                case PaletteModeManager.ProfessionalOffice2003:
                    professionalOffice2003RadioButton.Checked = true;
                    break;

                case PaletteModeManager.SparkleBlue:
                    sparkleBlueRadioButton.Checked = true;
                    break;

                case PaletteModeManager.SparkleOrange:
                    sparkleOrangeRadioButton.Checked = true;
                    break;

                case PaletteModeManager.SparklePurple:
                    sparklePurpleRadioButton.Checked = true;
                    break;

                default:
                    office2007BlueRadioButton.Checked = true;
                    break;
            }

            if(!string.IsNullOrEmpty(settings.Proxy.Url))
            {
                proxyAddressTextbox.Text = settings.Proxy.Url;
            }

            if(!string.IsNullOrEmpty(settings.Proxy.Username))
            {
                proxyUsernameTextBox.Text = settings.Proxy.Username;
            }

            // TODO NKO ENCRYPT PASSWORD.
            if(!string.IsNullOrEmpty(settings.Proxy.Password))
            {
                proxyPasswordTextbox.Text = settings.Proxy.Password;
            }
        }

        private void ApplySettingsButtonClick(object sender, EventArgs e)
        {
            settings.SelectedLanguage = languagesComboBox.SelectedValue.ToString();
            LocalizationService.SetCulture(settings.SelectedLanguage);
        }

        private void BindControls()
        {
            languagesComboBox.BeginInit();
            languagesComboBox.DataSource = settings.Languages;
            languagesComboBox.EndInit();
        }

        private void LanguageChanged(object sender, LanguageChangedEventArgs e)
        {
            Localize();
        }

        private void Office2007BlueRadioButtonCheckedChanged(object sender, EventArgs e)
        {
            kryptonManager.GlobalPaletteMode = PaletteModeManager.Office2007Blue;
            settings.Layout = PaletteModeManager.Office2007Blue;
        }

        private void Office2007SilverRadioButtonCheckedChanged(object sender, EventArgs e)
        {
            kryptonManager.GlobalPaletteMode = PaletteModeManager.Office2007Silver;
            settings.Layout = PaletteModeManager.Office2007Silver;
        }

        private void Office2010BlueRadioButtonCheckedChanged(object sender, EventArgs e)
        {
            kryptonManager.GlobalPaletteMode = PaletteModeManager.Office2010Blue;
            settings.Layout = PaletteModeManager.Office2010Blue;
        }

        private void Office2010SilverRadioButtonCheckedChanged(object sender, EventArgs e)
        {
            kryptonManager.GlobalPaletteMode = PaletteModeManager.Office2010Silver;
            settings.Layout = PaletteModeManager.Office2010Silver;
        }

        private void OkButtonClick(object sender, EventArgs e)
        {
            // TODO NKO Encrypt this data.
            settings.Proxy.Url = proxyAddressTextbox.Text;
            settings.Proxy.Username = proxyUsernameTextBox.Text;
            settings.Proxy.Password = proxyPasswordTextbox.Text;

            settingsService.SaveSettings(settings);

            Close();
            Dispose();
        }

        private void ProfessionalOffice2003RadioButtonCheckedChanged(object sender, EventArgs e)
        {
            kryptonManager.GlobalPaletteMode = PaletteModeManager.ProfessionalOffice2003;
            settings.Layout = PaletteModeManager.ProfessionalOffice2003;
        }

        private void SparkleBlueRadioButtonCheckedChanged(object sender, EventArgs e)
        {
            kryptonManager.GlobalPaletteMode = PaletteModeManager.SparkleBlue;
            settings.Layout = PaletteModeManager.SparkleBlue;
        }

        private void SparkleOrangeRadioButtonCheckedChanged(object sender, EventArgs e)
        {
            kryptonManager.GlobalPaletteMode = PaletteModeManager.SparkleOrange;
            settings.Layout = PaletteModeManager.SparkleOrange;
        }

        private void SparklePurpleRadioButtonCheckedChanged(object sender, EventArgs e)
        {
            kryptonManager.GlobalPaletteMode = PaletteModeManager.SparklePurple;
            settings.Layout = PaletteModeManager.SparklePurple;
        }

        private void ToogleLanguageControls()
        {
            if(useSystemLanguageCheckBox.Checked)
            {
                // Hide the controls.
                chooseLanguageLabel.Enabled = false;
                chooseLanguageLabel.Visible = false;

                languagesComboBox.Enabled = false;
                languagesComboBox.Visible = false;

                applySettingsButton.Enabled = false;
                applySettingsButton.Visible = false;
            }
            else
            {
                // Show the controls.
                chooseLanguageLabel.Enabled = true;
                chooseLanguageLabel.Visible = true;

                languagesComboBox.Enabled = true;
                languagesComboBox.Visible = true;

                applySettingsButton.Enabled = true;
                applySettingsButton.Visible = true;
            }
        }

        private void UseSystemLanguageCheckBoxCheckedChanged(object sender, EventArgs e)
        {
            ToogleLanguageControls();

            // Set default system language.
            if(useSystemLanguageCheckBox.Checked)
            {
                LocalizationService.SetCulture(LocalizationService.SystemCulture.Name);
                settings.UseSystemLanguage = true;
            }
            else
            {
                settings.UseSystemLanguage = false;
            }
        }

        private void updateOnStartupCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            settings.CheckForUpdateOnStartup = updateOnStartupCheckBox.Checked;
        }
    }
}