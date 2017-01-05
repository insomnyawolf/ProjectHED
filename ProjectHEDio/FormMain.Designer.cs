namespace ProjectHEDio
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.tabControlMain = new MetroFramework.Controls.MetroTabControl();
            this.metroTabPagePictureOptions = new MetroFramework.Controls.MetroTabPage();
            this.metroTabPageSourceSelection = new MetroFramework.Controls.MetroTabPage();
            this.metroTabPageDownloadSettings = new MetroFramework.Controls.MetroTabPage();
            this.metroTabPageConfiguration = new MetroFramework.Controls.MetroTabPage();
            this.metroTabPageAbout = new MetroFramework.Controls.MetroTabPage();
            this.comboBoxLanguageSelector = new MetroFramework.Controls.MetroComboBox();
            this.progressBarMain = new MetroFramework.Controls.MetroProgressBar();
            this.metroButtonStart = new MetroFramework.Controls.MetroButton();
            this.labelStatus = new MetroFramework.Controls.MetroLabel();
            this.tabControlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.metroTabPagePictureOptions);
            this.tabControlMain.Controls.Add(this.metroTabPageSourceSelection);
            this.tabControlMain.Controls.Add(this.metroTabPageDownloadSettings);
            this.tabControlMain.Controls.Add(this.metroTabPageConfiguration);
            this.tabControlMain.Controls.Add(this.metroTabPageAbout);
            this.tabControlMain.Location = new System.Drawing.Point(23, 63);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(530, 271);
            this.tabControlMain.TabIndex = 0;
            // 
            // metroTabPagePictureOptions
            // 
            this.metroTabPagePictureOptions.HorizontalScrollbarBarColor = true;
            this.metroTabPagePictureOptions.Location = new System.Drawing.Point(4, 35);
            this.metroTabPagePictureOptions.Name = "metroTabPagePictureOptions";
            this.metroTabPagePictureOptions.Size = new System.Drawing.Size(522, 232);
            this.metroTabPagePictureOptions.TabIndex = 0;
            this.metroTabPagePictureOptions.Text = "Picture Options";
            this.metroTabPagePictureOptions.VerticalScrollbarBarColor = true;
            // 
            // metroTabPageSourceSelection
            // 
            this.metroTabPageSourceSelection.HorizontalScrollbarBarColor = true;
            this.metroTabPageSourceSelection.Location = new System.Drawing.Point(4, 35);
            this.metroTabPageSourceSelection.Name = "metroTabPageSourceSelection";
            this.metroTabPageSourceSelection.Size = new System.Drawing.Size(522, 232);
            this.metroTabPageSourceSelection.TabIndex = 1;
            this.metroTabPageSourceSelection.Text = "Source Selection";
            this.metroTabPageSourceSelection.VerticalScrollbarBarColor = true;
            // 
            // metroTabPageDownloadSettings
            // 
            this.metroTabPageDownloadSettings.HorizontalScrollbarBarColor = true;
            this.metroTabPageDownloadSettings.Location = new System.Drawing.Point(4, 35);
            this.metroTabPageDownloadSettings.Name = "metroTabPageDownloadSettings";
            this.metroTabPageDownloadSettings.Size = new System.Drawing.Size(522, 232);
            this.metroTabPageDownloadSettings.TabIndex = 2;
            this.metroTabPageDownloadSettings.Text = "Download Settings";
            this.metroTabPageDownloadSettings.VerticalScrollbarBarColor = true;
            // 
            // metroTabPageConfiguration
            // 
            this.metroTabPageConfiguration.HorizontalScrollbarBarColor = true;
            this.metroTabPageConfiguration.Location = new System.Drawing.Point(4, 35);
            this.metroTabPageConfiguration.Name = "metroTabPageConfiguration";
            this.metroTabPageConfiguration.Size = new System.Drawing.Size(522, 232);
            this.metroTabPageConfiguration.TabIndex = 3;
            this.metroTabPageConfiguration.Text = "Configuration";
            this.metroTabPageConfiguration.VerticalScrollbarBarColor = true;
            // 
            // metroTabPageAbout
            // 
            this.metroTabPageAbout.HorizontalScrollbarBarColor = true;
            this.metroTabPageAbout.Location = new System.Drawing.Point(4, 35);
            this.metroTabPageAbout.Name = "metroTabPageAbout";
            this.metroTabPageAbout.Size = new System.Drawing.Size(522, 232);
            this.metroTabPageAbout.TabIndex = 4;
            this.metroTabPageAbout.Text = "About";
            this.metroTabPageAbout.VerticalScrollbarBarColor = true;
            // 
            // comboBoxLanguageSelector
            // 
            this.comboBoxLanguageSelector.FormattingEnabled = true;
            this.comboBoxLanguageSelector.ItemHeight = 23;
            this.comboBoxLanguageSelector.Items.AddRange(new object[] {
            "English"});
            this.comboBoxLanguageSelector.Location = new System.Drawing.Point(23, 340);
            this.comboBoxLanguageSelector.MaxDropDownItems = 20;
            this.comboBoxLanguageSelector.Name = "comboBoxLanguageSelector";
            this.comboBoxLanguageSelector.Size = new System.Drawing.Size(121, 29);
            this.comboBoxLanguageSelector.TabIndex = 1;
            // 
            // progressBarMain
            // 
            this.progressBarMain.Location = new System.Drawing.Point(150, 340);
            this.progressBarMain.Name = "progressBarMain";
            this.progressBarMain.Size = new System.Drawing.Size(336, 29);
            this.progressBarMain.TabIndex = 2;
            // 
            // metroButtonStart
            // 
            this.metroButtonStart.Location = new System.Drawing.Point(492, 340);
            this.metroButtonStart.Name = "metroButtonStart";
            this.metroButtonStart.Size = new System.Drawing.Size(61, 29);
            this.metroButtonStart.TabIndex = 3;
            this.metroButtonStart.Text = "Start";
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(23, 372);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(97, 19);
            this.labelStatus.TabIndex = 4;
            this.labelStatus.Text = "Status: Waiting.";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 403);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.metroButtonStart);
            this.Controls.Add(this.progressBarMain);
            this.Controls.Add(this.comboBoxLanguageSelector);
            this.Controls.Add(this.tabControlMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.Resizable = false;
            this.Text = "ProjectHED";
            this.tabControlMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTabControl tabControlMain;
        private MetroFramework.Controls.MetroTabPage metroTabPagePictureOptions;
        private MetroFramework.Controls.MetroTabPage metroTabPageSourceSelection;
        private MetroFramework.Controls.MetroTabPage metroTabPageDownloadSettings;
        private MetroFramework.Controls.MetroTabPage metroTabPageConfiguration;
        private MetroFramework.Controls.MetroTabPage metroTabPageAbout;
        private MetroFramework.Controls.MetroComboBox comboBoxLanguageSelector;
        private MetroFramework.Controls.MetroProgressBar progressBarMain;
        private MetroFramework.Controls.MetroButton metroButtonStart;
        private MetroFramework.Controls.MetroLabel labelStatus;
    }
}