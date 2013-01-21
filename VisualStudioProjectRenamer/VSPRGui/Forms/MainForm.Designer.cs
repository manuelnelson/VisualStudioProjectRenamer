using System.ComponentModel;
using ComponentFactory.Krypton.Toolkit;

namespace VSPRGui.Forms
{
    using VSPRCommon;

    public sealed partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.oldProjectNameLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.newProjectNameLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.solutionNameLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.newProjectNameTextbox = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.solutionPathTextbox = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.oldProjectNamesCombobox = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.ProjectBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.statusLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.isUnderVersionControlCheckbox = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.checkInChangesCheckbox = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.showSettingsFormToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.showAboutFormToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.sendToTrayToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.productNameToolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.updateToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.panel = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.adjustFolderNamesCheckBox = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.browseButton = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.exitButton = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.renameButton = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.kryptonManager = new ComponentFactory.Krypton.Toolkit.KryptonManager(this.components);
            this.renameMainEntryFileCheckBox = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.oldProjectNamesCombobox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProjectBindingSource)).BeginInit();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panel)).BeginInit();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // oldProjectNameLabel
            // 
            this.oldProjectNameLabel.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldPanel;
            this.oldProjectNameLabel.Location = new System.Drawing.Point(12, 119);
            this.oldProjectNameLabel.Name = "oldProjectNameLabel";
            this.oldProjectNameLabel.Size = new System.Drawing.Size(111, 20);
            this.oldProjectNameLabel.TabIndex = 0;
            this.oldProjectNameLabel.Values.Text = "Old project name";
            // 
            // newProjectNameLabel
            // 
            this.newProjectNameLabel.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldPanel;
            this.newProjectNameLabel.Location = new System.Drawing.Point(12, 188);
            this.newProjectNameLabel.Name = "newProjectNameLabel";
            this.newProjectNameLabel.Size = new System.Drawing.Size(117, 20);
            this.newProjectNameLabel.TabIndex = 1;
            this.newProjectNameLabel.Values.Text = "New project name";
            // 
            // solutionNameLabel
            // 
            this.solutionNameLabel.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldPanel;
            this.solutionNameLabel.Location = new System.Drawing.Point(12, 52);
            this.solutionNameLabel.Name = "solutionNameLabel";
            this.solutionNameLabel.Size = new System.Drawing.Size(59, 20);
            this.solutionNameLabel.TabIndex = 2;
            this.solutionNameLabel.Values.Text = "Solution";
            // 
            // newProjectNameTextbox
            // 
            this.newProjectNameTextbox.Location = new System.Drawing.Point(15, 214);
            this.newProjectNameTextbox.Name = "newProjectNameTextbox";
            this.newProjectNameTextbox.Size = new System.Drawing.Size(546, 20);
            this.newProjectNameTextbox.TabIndex = 4;
            // 
            // solutionPathTextbox
            // 
            this.solutionPathTextbox.Location = new System.Drawing.Point(15, 78);
            this.solutionPathTextbox.Name = "solutionPathTextbox";
            this.solutionPathTextbox.Size = new System.Drawing.Size(546, 20);
            this.solutionPathTextbox.TabIndex = 7;
            // 
            // oldProjectNamesCombobox
            // 
            this.oldProjectNamesCombobox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedItem", this.ProjectBindingSource, "ProjectName", true));
            this.oldProjectNamesCombobox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.ProjectBindingSource, "ProjectName", true));
            this.oldProjectNamesCombobox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ProjectBindingSource, "ProjectName", true));
            this.oldProjectNamesCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.oldProjectNamesCombobox.DropDownWidth = 384;
            this.oldProjectNamesCombobox.FormattingEnabled = true;
            this.oldProjectNamesCombobox.Location = new System.Drawing.Point(15, 145);
            this.oldProjectNamesCombobox.Name = "oldProjectNamesCombobox";
            this.oldProjectNamesCombobox.Size = new System.Drawing.Size(546, 21);
            this.oldProjectNamesCombobox.TabIndex = 8;
            this.oldProjectNamesCombobox.SelectedValueChanged += new System.EventHandler(this.ComboboxOldProjectNamesSelectedValueChanged);
            // 
            // ProjectBindingSource
            // 
            this.ProjectBindingSource.DataSource = typeof(VSPRCommon.Project);
            // 
            // statusLabel
            // 
            this.statusLabel.Location = new System.Drawing.Point(15, 14);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(47, 20);
            this.statusLabel.TabIndex = 9;
            this.statusLabel.Values.Text = "Status:";
            // 
            // isUnderVersionControlCheckbox
            // 
            this.isUnderVersionControlCheckbox.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldPanel;
            this.isUnderVersionControlCheckbox.Location = new System.Drawing.Point(15, 264);
            this.isUnderVersionControlCheckbox.Name = "isUnderVersionControlCheckbox";
            this.isUnderVersionControlCheckbox.Size = new System.Drawing.Size(206, 20);
            this.isUnderVersionControlCheckbox.TabIndex = 10;
            this.isUnderVersionControlCheckbox.Text = "Solution under version control?";
            this.isUnderVersionControlCheckbox.Values.Text = "Solution under version control?";
            this.isUnderVersionControlCheckbox.CheckedChanged += new System.EventHandler(this.CheckboxIsUnderVersionControlCheckedChanged);
            // 
            // checkInChangesCheckbox
            // 
            this.checkInChangesCheckbox.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldPanel;
            this.checkInChangesCheckbox.Location = new System.Drawing.Point(15, 290);
            this.checkInChangesCheckbox.Name = "checkInChangesCheckbox";
            this.checkInChangesCheckbox.Size = new System.Drawing.Size(207, 20);
            this.checkInChangesCheckbox.TabIndex = 11;
            this.checkInChangesCheckbox.Text = "Check in changes after rename?";
            this.checkInChangesCheckbox.Values.Text = "Check in changes after rename?";
            // 
            // toolStrip
            // 
            this.toolStrip.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showSettingsFormToolStripButton,
            this.toolStripSeparator1,
            this.showAboutFormToolStripButton,
            this.toolStripSeparator2,
            this.sendToTrayToolStripButton,
            this.toolStripSeparator3,
            this.productNameToolStripLabel,
            this.updateToolStripButton});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(573, 25);
            this.toolStrip.TabIndex = 13;
            this.toolStrip.Text = "toolStrip1";
            this.toolStrip.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SetOffSetOn_MouseDown);
            this.toolStrip.MouseEnter += new System.EventHandler(this.Header_MouseEnter);
            this.toolStrip.MouseLeave += new System.EventHandler(this.Header_MouseLeave);
            this.toolStrip.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MoveFormOn_MouseMove);
            // 
            // showSettingsFormToolStripButton
            // 
            this.showSettingsFormToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.showSettingsFormToolStripButton.Image = global::VSPRGui.Properties.Resources.Settings;
            this.showSettingsFormToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.showSettingsFormToolStripButton.Name = "showSettingsFormToolStripButton";
            this.showSettingsFormToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.showSettingsFormToolStripButton.Text = "Settings";
            this.showSettingsFormToolStripButton.Click += new System.EventHandler(this.ToolStripButtonShowSettingsClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // showAboutFormToolStripButton
            // 
            this.showAboutFormToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.showAboutFormToolStripButton.Image = global::VSPRGui.Properties.Resources.info;
            this.showAboutFormToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.showAboutFormToolStripButton.Name = "showAboutFormToolStripButton";
            this.showAboutFormToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.showAboutFormToolStripButton.Text = "About";
            this.showAboutFormToolStripButton.Click += new System.EventHandler(this.ToolStripButtonShowAboutFormClick);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // sendToTrayToolStripButton
            // 
            this.sendToTrayToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.sendToTrayToolStripButton.Image = global::VSPRGui.Properties.Resources.arrow_down;
            this.sendToTrayToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sendToTrayToolStripButton.Name = "sendToTrayToolStripButton";
            this.sendToTrayToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.sendToTrayToolStripButton.Text = "Minimize to tray";
            this.sendToTrayToolStripButton.Click += new System.EventHandler(this.ToolStripButtonSendToTrayClick);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // productNameToolStripLabel
            // 
            this.productNameToolStripLabel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.productNameToolStripLabel.Name = "productNameToolStripLabel";
            this.productNameToolStripLabel.Size = new System.Drawing.Size(165, 22);
            this.productNameToolStripLabel.Text = "Visual Studio Project Renamer";
            // 
            // updateToolStripButton
            // 
            this.updateToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.updateToolStripButton.Image = global::VSPRGui.Properties.Resources.update;
            this.updateToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.updateToolStripButton.Name = "updateToolStripButton";
            this.updateToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.updateToolStripButton.Text = "Update";
            this.updateToolStripButton.Click += new System.EventHandler(this.ToolStripButtonUpdateClick);
            // 
            // panel
            // 
            this.panel.Controls.Add(this.renameMainEntryFileCheckBox);
            this.panel.Controls.Add(this.adjustFolderNamesCheckBox);
            this.panel.Controls.Add(this.browseButton);
            this.panel.Controls.Add(this.exitButton);
            this.panel.Controls.Add(this.renameButton);
            this.panel.Controls.Add(this.statusLabel);
            this.panel.Controls.Add(this.solutionNameLabel);
            this.panel.Controls.Add(this.checkInChangesCheckbox);
            this.panel.Controls.Add(this.isUnderVersionControlCheckbox);
            this.panel.Controls.Add(this.solutionPathTextbox);
            this.panel.Controls.Add(this.oldProjectNamesCombobox);
            this.panel.Controls.Add(this.oldProjectNameLabel);
            this.panel.Controls.Add(this.newProjectNameTextbox);
            this.panel.Controls.Add(this.newProjectNameLabel);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 25);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(573, 392);
            this.panel.TabIndex = 14;
            // 
            // adjustFolderNamesCheckBox
            // 
            this.adjustFolderNamesCheckBox.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldPanel;
            this.adjustFolderNamesCheckBox.Location = new System.Drawing.Point(310, 264);
            this.adjustFolderNamesCheckBox.Name = "adjustFolderNamesCheckBox";
            this.adjustFolderNamesCheckBox.Size = new System.Drawing.Size(251, 20);
            this.adjustFolderNamesCheckBox.TabIndex = 16;
            this.adjustFolderNamesCheckBox.Text = "Adjust Folder - Projectname mismatch?";
            this.adjustFolderNamesCheckBox.Values.Text = "Adjust Folder - Projectname mismatch?";
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(471, 104);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(90, 25);
            this.browseButton.TabIndex = 15;
            this.browseButton.Values.Text = "Browse";
            this.browseButton.Click += new System.EventHandler(this.BrowseButtonClick);
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(471, 355);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(90, 25);
            this.exitButton.TabIndex = 14;
            this.exitButton.Values.Text = "Exit";
            this.exitButton.Click += new System.EventHandler(this.ExitButtonClick);
            // 
            // renameButton
            // 
            this.renameButton.Location = new System.Drawing.Point(375, 355);
            this.renameButton.Name = "renameButton";
            this.renameButton.Size = new System.Drawing.Size(90, 25);
            this.renameButton.TabIndex = 13;
            this.renameButton.Values.Text = "Rename";
            this.renameButton.Click += new System.EventHandler(this.RenameButtonClick);
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipText = "VSPR is now running in the background";
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Show Visual Studio Project Renamer";
            this.notifyIcon.Visible = true;
            this.notifyIcon.DoubleClick += new System.EventHandler(this.NotifyIconDoubleClick);
            // 
            // renameMainEntryFileCheckBox
            // 
            this.renameMainEntryFileCheckBox.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.renameMainEntryFileCheckBox.Location = new System.Drawing.Point(310, 289);
            this.renameMainEntryFileCheckBox.Name = "renameMainEntryFileCheckBox";
            this.renameMainEntryFileCheckBox.Size = new System.Drawing.Size(194, 20);
            this.renameMainEntryFileCheckBox.TabIndex = 17;
            this.renameMainEntryFileCheckBox.Text = "Rename main entry file (c++)";
            this.renameMainEntryFileCheckBox.Values.Text = "Rename main entry file (c++)";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 417);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.toolStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Visual Studio Project Renamer";
            ((System.ComponentModel.ISupportInitialize)(this.oldProjectNamesCombobox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProjectBindingSource)).EndInit();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panel)).EndInit();
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private KryptonLabel oldProjectNameLabel;
        private KryptonLabel newProjectNameLabel;
        private KryptonLabel solutionNameLabel;
        private KryptonTextBox newProjectNameTextbox;
        private KryptonTextBox solutionPathTextbox;
        private KryptonComboBox oldProjectNamesCombobox;
        private KryptonLabel statusLabel;
        private KryptonCheckBox isUnderVersionControlCheckbox;
        private KryptonCheckBox checkInChangesCheckbox;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton showAboutFormToolStripButton;
        private System.Windows.Forms.ToolStripButton showSettingsFormToolStripButton;
        private KryptonPanel panel;
        private KryptonButton renameButton;
        private KryptonButton exitButton;
        private KryptonButton browseButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton sendToTrayToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel productNameToolStripLabel;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ToolStripButton updateToolStripButton;
        private System.Windows.Forms.BindingSource ProjectBindingSource;
        private KryptonManager kryptonManager;
        private KryptonCheckBox adjustFolderNamesCheckBox;
        private KryptonCheckBox renameMainEntryFileCheckBox;
    }
}

