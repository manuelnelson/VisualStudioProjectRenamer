namespace VSPRBase.Forms
{
    internal sealed partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.kryptonManager = new ComponentFactory.Krypton.Toolkit.KryptonManager(this.components);
            this.kryptonPanel = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.updateLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.updateOnStartupCheckBox = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.proxyPasswordLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.proxyPasswordTextbox = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.proxyUsernameLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.proxyAddressLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.proxySettingsLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.proxyAddressTextbox = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.proxyUsernameTextBox = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.applySettingsButton = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.chooseLanguageLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.languageSettingsLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.useSystemLanguageCheckBox = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.languagesComboBox = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.layoutSettingsLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.okButton = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.office2010BlueRadioButton = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.professionalOffice2003RadioButton = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.sparkleBlueRadioButton = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.sparklePurpleRadioButton = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.sparkleOrangeRadioButton = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.office2007BlueRadioButton = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.office2010SilverRadioButton = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.office2007SilverRadioButton = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel)).BeginInit();
            this.kryptonPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.languagesComboBox)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel
            // 
            this.kryptonPanel.Controls.Add(this.updateLabel);
            this.kryptonPanel.Controls.Add(this.updateOnStartupCheckBox);
            this.kryptonPanel.Controls.Add(this.proxyPasswordLabel);
            this.kryptonPanel.Controls.Add(this.proxyPasswordTextbox);
            this.kryptonPanel.Controls.Add(this.proxyUsernameLabel);
            this.kryptonPanel.Controls.Add(this.proxyAddressLabel);
            this.kryptonPanel.Controls.Add(this.proxySettingsLabel);
            this.kryptonPanel.Controls.Add(this.proxyAddressTextbox);
            this.kryptonPanel.Controls.Add(this.proxyUsernameTextBox);
            this.kryptonPanel.Controls.Add(this.applySettingsButton);
            this.kryptonPanel.Controls.Add(this.chooseLanguageLabel);
            this.kryptonPanel.Controls.Add(this.languageSettingsLabel);
            this.kryptonPanel.Controls.Add(this.useSystemLanguageCheckBox);
            this.kryptonPanel.Controls.Add(this.languagesComboBox);
            this.kryptonPanel.Controls.Add(this.layoutSettingsLabel);
            this.kryptonPanel.Controls.Add(this.okButton);
            this.kryptonPanel.Controls.Add(this.office2010BlueRadioButton);
            this.kryptonPanel.Controls.Add(this.professionalOffice2003RadioButton);
            this.kryptonPanel.Controls.Add(this.sparkleBlueRadioButton);
            this.kryptonPanel.Controls.Add(this.sparklePurpleRadioButton);
            this.kryptonPanel.Controls.Add(this.sparkleOrangeRadioButton);
            this.kryptonPanel.Controls.Add(this.office2007BlueRadioButton);
            this.kryptonPanel.Controls.Add(this.office2010SilverRadioButton);
            this.kryptonPanel.Controls.Add(this.office2007SilverRadioButton);
            this.kryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel.Name = "kryptonPanel";
            this.kryptonPanel.Size = new System.Drawing.Size(551, 433);
            this.kryptonPanel.TabIndex = 0;
            // 
            // updateLabel
            // 
            this.updateLabel.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldPanel;
            this.updateLabel.Location = new System.Drawing.Point(9, 283);
            this.updateLabel.Name = "updateLabel";
            this.updateLabel.Size = new System.Drawing.Size(70, 20);
            this.updateLabel.TabIndex = 17;
            this.updateLabel.Values.Image = global::VSPRBase.Properties.Resources.update;
            this.updateLabel.Values.Text = "Update";
            // 
            // updateOnStartupCheckBox
            // 
            this.updateOnStartupCheckBox.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl;
            this.updateOnStartupCheckBox.Location = new System.Drawing.Point(29, 309);
            this.updateOnStartupCheckBox.Name = "updateOnStartupCheckBox";
            this.updateOnStartupCheckBox.Size = new System.Drawing.Size(177, 20);
            this.updateOnStartupCheckBox.TabIndex = 16;
            this.updateOnStartupCheckBox.Text = "Check for update on startup";
            this.updateOnStartupCheckBox.Values.Text = "Check for update on startup";
            this.updateOnStartupCheckBox.CheckedChanged += new System.EventHandler(this.updateOnStartupCheckBox_CheckedChanged);
            // 
            // proxyPasswordLabel
            // 
            this.proxyPasswordLabel.Location = new System.Drawing.Point(231, 335);
            this.proxyPasswordLabel.Name = "proxyPasswordLabel";
            this.proxyPasswordLabel.Size = new System.Drawing.Size(62, 20);
            this.proxyPasswordLabel.TabIndex = 0;
            this.proxyPasswordLabel.TabStop = false;
            this.proxyPasswordLabel.Values.Text = "Password";
            // 
            // proxyPasswordTextbox
            // 
            this.proxyPasswordTextbox.Location = new System.Drawing.Point(231, 361);
            this.proxyPasswordTextbox.Name = "proxyPasswordTextbox";
            this.proxyPasswordTextbox.Size = new System.Drawing.Size(302, 20);
            this.proxyPasswordTextbox.TabIndex = 14;
            // 
            // proxyUsernameLabel
            // 
            this.proxyUsernameLabel.Location = new System.Drawing.Point(231, 283);
            this.proxyUsernameLabel.Name = "proxyUsernameLabel";
            this.proxyUsernameLabel.Size = new System.Drawing.Size(35, 20);
            this.proxyUsernameLabel.TabIndex = 0;
            this.proxyUsernameLabel.TabStop = false;
            this.proxyUsernameLabel.Values.Text = "User";
            // 
            // proxyAddressLabel
            // 
            this.proxyAddressLabel.Location = new System.Drawing.Point(231, 234);
            this.proxyAddressLabel.Name = "proxyAddressLabel";
            this.proxyAddressLabel.Size = new System.Drawing.Size(54, 20);
            this.proxyAddressLabel.TabIndex = 0;
            this.proxyAddressLabel.TabStop = false;
            this.proxyAddressLabel.Values.Text = "Address";
            // 
            // proxySettingsLabel
            // 
            this.proxySettingsLabel.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldPanel;
            this.proxySettingsLabel.Location = new System.Drawing.Point(208, 208);
            this.proxySettingsLabel.Name = "proxySettingsLabel";
            this.proxySettingsLabel.Size = new System.Drawing.Size(110, 20);
            this.proxySettingsLabel.TabIndex = 0;
            this.proxySettingsLabel.TabStop = false;
            this.proxySettingsLabel.Values.Image = global::VSPRBase.Properties.Resources.server_small;
            this.proxySettingsLabel.Values.Text = "Proxy settings";
            // 
            // proxyAddressTextbox
            // 
            this.proxyAddressTextbox.Location = new System.Drawing.Point(231, 257);
            this.proxyAddressTextbox.Name = "proxyAddressTextbox";
            this.proxyAddressTextbox.Size = new System.Drawing.Size(302, 20);
            this.proxyAddressTextbox.TabIndex = 12;
            // 
            // proxyUsernameTextBox
            // 
            this.proxyUsernameTextBox.Location = new System.Drawing.Point(231, 309);
            this.proxyUsernameTextBox.Name = "proxyUsernameTextBox";
            this.proxyUsernameTextBox.Size = new System.Drawing.Size(302, 20);
            this.proxyUsernameTextBox.TabIndex = 13;
            // 
            // applySettingsButton
            // 
            this.applySettingsButton.Location = new System.Drawing.Point(443, 153);
            this.applySettingsButton.Name = "applySettingsButton";
            this.applySettingsButton.Size = new System.Drawing.Size(90, 25);
            this.applySettingsButton.TabIndex = 11;
            this.applySettingsButton.Values.Text = "Apply";
            this.applySettingsButton.Click += new System.EventHandler(this.ApplySettingsButtonClick);
            // 
            // chooseLanguageLabel
            // 
            this.chooseLanguageLabel.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.chooseLanguageLabel.Location = new System.Drawing.Point(231, 100);
            this.chooseLanguageLabel.Name = "chooseLanguageLabel";
            this.chooseLanguageLabel.Size = new System.Drawing.Size(110, 20);
            this.chooseLanguageLabel.TabIndex = 0;
            this.chooseLanguageLabel.TabStop = false;
            this.chooseLanguageLabel.Values.Text = "Choose language";
            // 
            // languageSettingsLabel
            // 
            this.languageSettingsLabel.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldPanel;
            this.languageSettingsLabel.Location = new System.Drawing.Point(208, 32);
            this.languageSettingsLabel.Name = "languageSettingsLabel";
            this.languageSettingsLabel.Size = new System.Drawing.Size(133, 20);
            this.languageSettingsLabel.TabIndex = 0;
            this.languageSettingsLabel.TabStop = false;
            this.languageSettingsLabel.Values.Image = global::VSPRBase.Properties.Resources.languageSettings;
            this.languageSettingsLabel.Values.Text = "Language settings";
            // 
            // useSystemLanguageCheckBox
            // 
            this.useSystemLanguageCheckBox.Checked = true;
            this.useSystemLanguageCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.useSystemLanguageCheckBox.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl;
            this.useSystemLanguageCheckBox.Location = new System.Drawing.Point(231, 58);
            this.useSystemLanguageCheckBox.Name = "useSystemLanguageCheckBox";
            this.useSystemLanguageCheckBox.Size = new System.Drawing.Size(140, 20);
            this.useSystemLanguageCheckBox.TabIndex = 9;
            this.useSystemLanguageCheckBox.Text = "Use System language";
            this.useSystemLanguageCheckBox.Values.Text = "Use System language";
            this.useSystemLanguageCheckBox.CheckedChanged += new System.EventHandler(this.UseSystemLanguageCheckBoxCheckedChanged);
            // 
            // languagesComboBox
            // 
            this.languagesComboBox.DropDownWidth = 302;
            this.languagesComboBox.Location = new System.Drawing.Point(231, 126);
            this.languagesComboBox.Name = "languagesComboBox";
            this.languagesComboBox.Size = new System.Drawing.Size(302, 21);
            this.languagesComboBox.TabIndex = 10;
            // 
            // layoutSettingsLabel
            // 
            this.layoutSettingsLabel.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldPanel;
            this.layoutSettingsLabel.Location = new System.Drawing.Point(9, 32);
            this.layoutSettingsLabel.Name = "layoutSettingsLabel";
            this.layoutSettingsLabel.Size = new System.Drawing.Size(116, 20);
            this.layoutSettingsLabel.TabIndex = 0;
            this.layoutSettingsLabel.TabStop = false;
            this.layoutSettingsLabel.Values.Image = global::VSPRBase.Properties.Resources.layoutSettings;
            this.layoutSettingsLabel.Values.Text = "Layout settings";
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(443, 396);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(90, 25);
            this.okButton.TabIndex = 15;
            this.okButton.Values.Text = "OK";
            this.okButton.Click += new System.EventHandler(this.OkButtonClick);
            // 
            // office2010BlueRadioButton
            // 
            this.office2010BlueRadioButton.Location = new System.Drawing.Point(29, 160);
            this.office2010BlueRadioButton.Name = "office2010BlueRadioButton";
            this.office2010BlueRadioButton.Size = new System.Drawing.Size(112, 20);
            this.office2010BlueRadioButton.TabIndex = 5;
            this.office2010BlueRadioButton.Values.Text = "Office 2010 Blue";
            this.office2010BlueRadioButton.CheckedChanged += new System.EventHandler(this.Office2010BlueRadioButtonCheckedChanged);
            // 
            // professionalOffice2003RadioButton
            // 
            this.professionalOffice2003RadioButton.Location = new System.Drawing.Point(29, 58);
            this.professionalOffice2003RadioButton.Name = "professionalOffice2003RadioButton";
            this.professionalOffice2003RadioButton.Size = new System.Drawing.Size(154, 20);
            this.professionalOffice2003RadioButton.TabIndex = 1;
            this.professionalOffice2003RadioButton.Values.Text = "Professional Office 2003";
            this.professionalOffice2003RadioButton.CheckedChanged += new System.EventHandler(this.ProfessionalOffice2003RadioButtonCheckedChanged);
            // 
            // sparkleBlueRadioButton
            // 
            this.sparkleBlueRadioButton.Location = new System.Drawing.Point(29, 234);
            this.sparkleBlueRadioButton.Name = "sparkleBlueRadioButton";
            this.sparkleBlueRadioButton.Size = new System.Drawing.Size(89, 20);
            this.sparkleBlueRadioButton.TabIndex = 8;
            this.sparkleBlueRadioButton.Values.Text = "Sparkle Blue";
            this.sparkleBlueRadioButton.CheckedChanged += new System.EventHandler(this.SparkleBlueRadioButtonCheckedChanged);
            // 
            // sparklePurpleRadioButton
            // 
            this.sparklePurpleRadioButton.Location = new System.Drawing.Point(29, 208);
            this.sparklePurpleRadioButton.Name = "sparklePurpleRadioButton";
            this.sparklePurpleRadioButton.Size = new System.Drawing.Size(101, 20);
            this.sparklePurpleRadioButton.TabIndex = 7;
            this.sparklePurpleRadioButton.Values.Text = "Sparkle Purple";
            this.sparklePurpleRadioButton.CheckedChanged += new System.EventHandler(this.SparklePurpleRadioButtonCheckedChanged);
            // 
            // sparkleOrangeRadioButton
            // 
            this.sparkleOrangeRadioButton.Location = new System.Drawing.Point(29, 182);
            this.sparkleOrangeRadioButton.Name = "sparkleOrangeRadioButton";
            this.sparkleOrangeRadioButton.Size = new System.Drawing.Size(107, 20);
            this.sparkleOrangeRadioButton.TabIndex = 6;
            this.sparkleOrangeRadioButton.Values.Text = "Sparkle Orange";
            this.sparkleOrangeRadioButton.CheckedChanged += new System.EventHandler(this.SparkleOrangeRadioButtonCheckedChanged);
            // 
            // office2007BlueRadioButton
            // 
            this.office2007BlueRadioButton.Location = new System.Drawing.Point(29, 134);
            this.office2007BlueRadioButton.Name = "office2007BlueRadioButton";
            this.office2007BlueRadioButton.Size = new System.Drawing.Size(112, 20);
            this.office2007BlueRadioButton.TabIndex = 4;
            this.office2007BlueRadioButton.Values.Text = "Office 2007 Blue";
            this.office2007BlueRadioButton.CheckedChanged += new System.EventHandler(this.Office2007BlueRadioButtonCheckedChanged);
            // 
            // office2010SilverRadioButton
            // 
            this.office2010SilverRadioButton.Location = new System.Drawing.Point(29, 108);
            this.office2010SilverRadioButton.Name = "office2010SilverRadioButton";
            this.office2010SilverRadioButton.Size = new System.Drawing.Size(117, 20);
            this.office2010SilverRadioButton.TabIndex = 3;
            this.office2010SilverRadioButton.Values.Text = "Office 2010 Silver";
            this.office2010SilverRadioButton.CheckedChanged += new System.EventHandler(this.Office2010SilverRadioButtonCheckedChanged);
            // 
            // office2007SilverRadioButton
            // 
            this.office2007SilverRadioButton.Location = new System.Drawing.Point(29, 82);
            this.office2007SilverRadioButton.Name = "office2007SilverRadioButton";
            this.office2007SilverRadioButton.Size = new System.Drawing.Size(117, 20);
            this.office2007SilverRadioButton.TabIndex = 2;
            this.office2007SilverRadioButton.Values.Text = "Office 2007 Silver";
            this.office2007SilverRadioButton.CheckedChanged += new System.EventHandler(this.Office2007SilverRadioButtonCheckedChanged);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 433);
            this.Controls.Add(this.kryptonPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel)).EndInit();
            this.kryptonPanel.ResumeLayout(false);
            this.kryptonPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.languagesComboBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonManager kryptonManager;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton office2010SilverRadioButton;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton office2007SilverRadioButton;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton sparkleOrangeRadioButton;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton office2007BlueRadioButton;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton professionalOffice2003RadioButton;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton sparkleBlueRadioButton;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton sparklePurpleRadioButton;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton office2010BlueRadioButton;
        private ComponentFactory.Krypton.Toolkit.KryptonButton okButton;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel layoutSettingsLabel;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox languagesComboBox;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox useSystemLanguageCheckBox;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel languageSettingsLabel;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel chooseLanguageLabel;
        private ComponentFactory.Krypton.Toolkit.KryptonButton applySettingsButton;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel proxySettingsLabel;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox proxyAddressTextbox;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox proxyUsernameTextBox;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel proxyAddressLabel;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel proxyUsernameLabel;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel proxyPasswordLabel;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox proxyPasswordTextbox;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel updateLabel;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox updateOnStartupCheckBox;
    }
}

