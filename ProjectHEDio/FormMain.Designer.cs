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
            this.panelRestrictImageSizesMethod = new MetroFramework.Controls.MetroPanel();
            this.checkBoxRestrictImageSizesQueryTagDontDownloadTagless = new MetroFramework.Controls.MetroCheckBox();
            this.radioButtonRestrictImageSizesMethodManual = new MetroFramework.Controls.MetroRadioButton();
            this.radioButtonRestrictImageSizesMethodTag = new MetroFramework.Controls.MetroRadioButton();
            this.panelRestrictImageSizes = new MetroFramework.Controls.MetroPanel();
            this.radioButtonRestrictImageSizesLess = new MetroFramework.Controls.MetroRadioButton();
            this.radioButtonRestrictImageSizesGreater = new MetroFramework.Controls.MetroRadioButton();
            this.radioButtonRestrictImageSizesEqual = new MetroFramework.Controls.MetroRadioButton();
            this.numericUpDownRestrictImageSizesHeight = new System.Windows.Forms.NumericUpDown();
            this.labelResolutionX = new MetroFramework.Controls.MetroLabel();
            this.numericUpDownRestrictImageSizesWidth = new System.Windows.Forms.NumericUpDown();
            this.checkBoxRestrictImageSizes = new MetroFramework.Controls.MetroCheckBox();
            this.labelTags3 = new MetroFramework.Controls.MetroLabel();
            this.labelTags2 = new MetroFramework.Controls.MetroLabel();
            this.labelTags1 = new MetroFramework.Controls.MetroLabel();
            this.textBoxTags = new MetroFramework.Controls.MetroTextBox();
            this.checkBoxUseTags = new MetroFramework.Controls.MetroCheckBox();
            this.metroTabPageSourceSelection = new MetroFramework.Controls.MetroTabPage();
            this.metroTabPageDownloadSettings = new MetroFramework.Controls.MetroTabPage();
            this.metroTabPageConfiguration = new MetroFramework.Controls.MetroTabPage();
            this.metroTabPageAbout = new MetroFramework.Controls.MetroTabPage();
            this.comboBoxLanguageSelector = new MetroFramework.Controls.MetroComboBox();
            this.buttonStart = new MetroFramework.Controls.MetroButton();
            this.labelStatus = new MetroFramework.Controls.MetroLabel();
            this.progressBarMain = new System.Windows.Forms.ProgressBar();
            this.tabControlMain.SuspendLayout();
            this.metroTabPagePictureOptions.SuspendLayout();
            this.panelRestrictImageSizesMethod.SuspendLayout();
            this.panelRestrictImageSizes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRestrictImageSizesHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRestrictImageSizesWidth)).BeginInit();
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
            this.metroTabPagePictureOptions.Controls.Add(this.panelRestrictImageSizesMethod);
            this.metroTabPagePictureOptions.Controls.Add(this.panelRestrictImageSizes);
            this.metroTabPagePictureOptions.Controls.Add(this.numericUpDownRestrictImageSizesHeight);
            this.metroTabPagePictureOptions.Controls.Add(this.labelResolutionX);
            this.metroTabPagePictureOptions.Controls.Add(this.numericUpDownRestrictImageSizesWidth);
            this.metroTabPagePictureOptions.Controls.Add(this.checkBoxRestrictImageSizes);
            this.metroTabPagePictureOptions.Controls.Add(this.labelTags3);
            this.metroTabPagePictureOptions.Controls.Add(this.labelTags2);
            this.metroTabPagePictureOptions.Controls.Add(this.labelTags1);
            this.metroTabPagePictureOptions.Controls.Add(this.textBoxTags);
            this.metroTabPagePictureOptions.Controls.Add(this.checkBoxUseTags);
            this.metroTabPagePictureOptions.HorizontalScrollbarBarColor = true;
            this.metroTabPagePictureOptions.Location = new System.Drawing.Point(4, 35);
            this.metroTabPagePictureOptions.Name = "metroTabPagePictureOptions";
            this.metroTabPagePictureOptions.Size = new System.Drawing.Size(522, 232);
            this.metroTabPagePictureOptions.TabIndex = 0;
            this.metroTabPagePictureOptions.Text = "Picture Options";
            this.metroTabPagePictureOptions.VerticalScrollbarBarColor = true;
            // 
            // panelRestrictImageSizesMethod
            // 
            this.panelRestrictImageSizesMethod.Controls.Add(this.checkBoxRestrictImageSizesQueryTagDontDownloadTagless);
            this.panelRestrictImageSizesMethod.Controls.Add(this.radioButtonRestrictImageSizesMethodManual);
            this.panelRestrictImageSizesMethod.Controls.Add(this.radioButtonRestrictImageSizesMethodTag);
            this.panelRestrictImageSizesMethod.Enabled = false;
            this.panelRestrictImageSizesMethod.HorizontalScrollbarBarColor = true;
            this.panelRestrictImageSizesMethod.HorizontalScrollbarHighlightOnWheel = false;
            this.panelRestrictImageSizesMethod.HorizontalScrollbarSize = 10;
            this.panelRestrictImageSizesMethod.Location = new System.Drawing.Point(273, 146);
            this.panelRestrictImageSizesMethod.Name = "panelRestrictImageSizesMethod";
            this.panelRestrictImageSizesMethod.Size = new System.Drawing.Size(249, 72);
            this.panelRestrictImageSizesMethod.TabIndex = 12;
            this.panelRestrictImageSizesMethod.VerticalScrollbarBarColor = true;
            this.panelRestrictImageSizesMethod.VerticalScrollbarHighlightOnWheel = false;
            this.panelRestrictImageSizesMethod.VerticalScrollbarSize = 10;
            // 
            // checkBoxRestrictImageSizesQueryTagDontDownloadTagless
            // 
            this.checkBoxRestrictImageSizesQueryTagDontDownloadTagless.AutoSize = true;
            this.checkBoxRestrictImageSizesQueryTagDontDownloadTagless.Location = new System.Drawing.Point(22, 45);
            this.checkBoxRestrictImageSizesQueryTagDontDownloadTagless.Name = "checkBoxRestrictImageSizesQueryTagDontDownloadTagless";
            this.checkBoxRestrictImageSizesQueryTagDontDownloadTagless.Size = new System.Drawing.Size(221, 15);
            this.checkBoxRestrictImageSizesQueryTagDontDownloadTagless.TabIndex = 4;
            this.checkBoxRestrictImageSizesQueryTagDontDownloadTagless.Text = "Only download images with size tags.";
            this.checkBoxRestrictImageSizesQueryTagDontDownloadTagless.UseVisualStyleBackColor = true;
            // 
            // radioButtonRestrictImageSizesMethodManual
            // 
            this.radioButtonRestrictImageSizesMethodManual.AutoSize = true;
            this.radioButtonRestrictImageSizesMethodManual.Location = new System.Drawing.Point(3, 4);
            this.radioButtonRestrictImageSizesMethodManual.Name = "radioButtonRestrictImageSizesMethodManual";
            this.radioButtonRestrictImageSizesMethodManual.Size = new System.Drawing.Size(233, 15);
            this.radioButtonRestrictImageSizesMethodManual.TabIndex = 2;
            this.radioButtonRestrictImageSizesMethodManual.TabStop = true;
            this.radioButtonRestrictImageSizesMethodManual.Text = "Check dimensions before downloading.";
            this.radioButtonRestrictImageSizesMethodManual.UseVisualStyleBackColor = true;
            // 
            // radioButtonRestrictImageSizesMethodTag
            // 
            this.radioButtonRestrictImageSizesMethodTag.AutoSize = true;
            this.radioButtonRestrictImageSizesMethodTag.Location = new System.Drawing.Point(3, 24);
            this.radioButtonRestrictImageSizesMethodTag.Name = "radioButtonRestrictImageSizesMethodTag";
            this.radioButtonRestrictImageSizesMethodTag.Size = new System.Drawing.Size(241, 15);
            this.radioButtonRestrictImageSizesMethodTag.TabIndex = 3;
            this.radioButtonRestrictImageSizesMethodTag.TabStop = true;
            this.radioButtonRestrictImageSizesMethodTag.Text = "Implement size restrictions in tag queries.";
            this.radioButtonRestrictImageSizesMethodTag.UseVisualStyleBackColor = true;
            // 
            // panelRestrictImageSizes
            // 
            this.panelRestrictImageSizes.Controls.Add(this.radioButtonRestrictImageSizesLess);
            this.panelRestrictImageSizes.Controls.Add(this.radioButtonRestrictImageSizesGreater);
            this.panelRestrictImageSizes.Controls.Add(this.radioButtonRestrictImageSizesEqual);
            this.panelRestrictImageSizes.Enabled = false;
            this.panelRestrictImageSizes.HorizontalScrollbarBarColor = true;
            this.panelRestrictImageSizes.HorizontalScrollbarHighlightOnWheel = false;
            this.panelRestrictImageSizes.HorizontalScrollbarSize = 10;
            this.panelRestrictImageSizes.Location = new System.Drawing.Point(0, 146);
            this.panelRestrictImageSizes.Name = "panelRestrictImageSizes";
            this.panelRestrictImageSizes.Size = new System.Drawing.Size(266, 72);
            this.panelRestrictImageSizes.TabIndex = 11;
            this.panelRestrictImageSizes.VerticalScrollbarBarColor = true;
            this.panelRestrictImageSizes.VerticalScrollbarHighlightOnWheel = false;
            this.panelRestrictImageSizes.VerticalScrollbarSize = 10;
            // 
            // radioButtonRestrictImageSizesLess
            // 
            this.radioButtonRestrictImageSizesLess.AutoSize = true;
            this.radioButtonRestrictImageSizesLess.Location = new System.Drawing.Point(4, 45);
            this.radioButtonRestrictImageSizesLess.Name = "radioButtonRestrictImageSizesLess";
            this.radioButtonRestrictImageSizesLess.Size = new System.Drawing.Size(248, 15);
            this.radioButtonRestrictImageSizesLess.TabIndex = 4;
            this.radioButtonRestrictImageSizesLess.TabStop = true;
            this.radioButtonRestrictImageSizesLess.Text = "Images must be larger than this resolution.";
            this.radioButtonRestrictImageSizesLess.UseVisualStyleBackColor = true;
            // 
            // radioButtonRestrictImageSizesGreater
            // 
            this.radioButtonRestrictImageSizesGreater.AutoSize = true;
            this.radioButtonRestrictImageSizesGreater.Location = new System.Drawing.Point(4, 24);
            this.radioButtonRestrictImageSizesGreater.Name = "radioButtonRestrictImageSizesGreater";
            this.radioButtonRestrictImageSizesGreater.Size = new System.Drawing.Size(248, 15);
            this.radioButtonRestrictImageSizesGreater.TabIndex = 3;
            this.radioButtonRestrictImageSizesGreater.TabStop = true;
            this.radioButtonRestrictImageSizesGreater.Text = "Images must be larger than this resolution.";
            this.radioButtonRestrictImageSizesGreater.UseVisualStyleBackColor = true;
            // 
            // radioButtonRestrictImageSizesEqual
            // 
            this.radioButtonRestrictImageSizesEqual.AutoSize = true;
            this.radioButtonRestrictImageSizesEqual.Location = new System.Drawing.Point(4, 3);
            this.radioButtonRestrictImageSizesEqual.Name = "radioButtonRestrictImageSizesEqual";
            this.radioButtonRestrictImageSizesEqual.Size = new System.Drawing.Size(209, 15);
            this.radioButtonRestrictImageSizesEqual.TabIndex = 2;
            this.radioButtonRestrictImageSizesEqual.TabStop = true;
            this.radioButtonRestrictImageSizesEqual.Text = "Images must match this resolution.";
            this.radioButtonRestrictImageSizesEqual.UseVisualStyleBackColor = true;
            // 
            // numericUpDownRestrictImageSizesHeight
            // 
            this.numericUpDownRestrictImageSizesHeight.Enabled = false;
            this.numericUpDownRestrictImageSizesHeight.Location = new System.Drawing.Point(272, 124);
            this.numericUpDownRestrictImageSizesHeight.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numericUpDownRestrictImageSizesHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownRestrictImageSizesHeight.Name = "numericUpDownRestrictImageSizesHeight";
            this.numericUpDownRestrictImageSizesHeight.Size = new System.Drawing.Size(55, 20);
            this.numericUpDownRestrictImageSizesHeight.TabIndex = 10;
            this.numericUpDownRestrictImageSizesHeight.Value = new decimal(new int[] {
            1080,
            0,
            0,
            0});
            // 
            // labelResolutionX
            // 
            this.labelResolutionX.AutoSize = true;
            this.labelResolutionX.Location = new System.Drawing.Point(251, 124);
            this.labelResolutionX.Name = "labelResolutionX";
            this.labelResolutionX.Size = new System.Drawing.Size(15, 19);
            this.labelResolutionX.TabIndex = 9;
            this.labelResolutionX.Text = "x";
            // 
            // numericUpDownRestrictImageSizesWidth
            // 
            this.numericUpDownRestrictImageSizesWidth.Enabled = false;
            this.numericUpDownRestrictImageSizesWidth.Location = new System.Drawing.Point(190, 124);
            this.numericUpDownRestrictImageSizesWidth.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numericUpDownRestrictImageSizesWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownRestrictImageSizesWidth.Name = "numericUpDownRestrictImageSizesWidth";
            this.numericUpDownRestrictImageSizesWidth.Size = new System.Drawing.Size(55, 20);
            this.numericUpDownRestrictImageSizesWidth.TabIndex = 8;
            this.numericUpDownRestrictImageSizesWidth.Value = new decimal(new int[] {
            1920,
            0,
            0,
            0});
            // 
            // checkBoxRestrictImageSizes
            // 
            this.checkBoxRestrictImageSizes.AutoSize = true;
            this.checkBoxRestrictImageSizes.FontSize = MetroFramework.MetroLinkSize.Tall;
            this.checkBoxRestrictImageSizes.Location = new System.Drawing.Point(0, 119);
            this.checkBoxRestrictImageSizes.Name = "checkBoxRestrictImageSizes";
            this.checkBoxRestrictImageSizes.Size = new System.Drawing.Size(184, 25);
            this.checkBoxRestrictImageSizes.TabIndex = 7;
            this.checkBoxRestrictImageSizes.Text = "Restrict Image Sizes";
            this.checkBoxRestrictImageSizes.UseVisualStyleBackColor = true;
            this.checkBoxRestrictImageSizes.CheckedChanged += new System.EventHandler(this.checkBoxRestrictImageSizes_CheckedChanged);
            // 
            // labelTags3
            // 
            this.labelTags3.AutoSize = true;
            this.labelTags3.Location = new System.Drawing.Point(4, 85);
            this.labelTags3.Name = "labelTags3";
            this.labelTags3.Size = new System.Drawing.Size(422, 19);
            this.labelTags3.TabIndex = 6;
            this.labelTags3.Text = "Name tags are usually denoted as \"lastname_firstname\" as a single tag.";
            // 
            // labelTags2
            // 
            this.labelTags2.AutoSize = true;
            this.labelTags2.Location = new System.Drawing.Point(4, 66);
            this.labelTags2.Name = "labelTags2";
            this.labelTags2.Size = new System.Drawing.Size(495, 19);
            this.labelTags2.TabIndex = 5;
            this.labelTags2.Text = "To use multiple tags in the same query, please separate individual tags with a sp" +
    "ace.";
            // 
            // labelTags1
            // 
            this.labelTags1.AutoSize = true;
            this.labelTags1.Location = new System.Drawing.Point(4, 47);
            this.labelTags1.Name = "labelTags1";
            this.labelTags1.Size = new System.Drawing.Size(517, 19);
            this.labelTags1.TabIndex = 4;
            this.labelTags1.Text = "If this is checked, ProjectHED will only download images containing the tags you " +
    "specify.";
            // 
            // textBoxTags
            // 
            this.textBoxTags.Enabled = false;
            this.textBoxTags.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.textBoxTags.FontWeight = MetroFramework.MetroTextBoxWeight.Light;
            this.textBoxTags.Location = new System.Drawing.Point(110, 17);
            this.textBoxTags.Name = "textBoxTags";
            this.textBoxTags.PromptText = "tags here, separated by spaces";
            this.textBoxTags.Size = new System.Drawing.Size(409, 23);
            this.textBoxTags.TabIndex = 3;
            // 
            // checkBoxUseTags
            // 
            this.checkBoxUseTags.AutoSize = true;
            this.checkBoxUseTags.FontSize = MetroFramework.MetroLinkSize.Tall;
            this.checkBoxUseTags.Location = new System.Drawing.Point(3, 15);
            this.checkBoxUseTags.Name = "checkBoxUseTags";
            this.checkBoxUseTags.Size = new System.Drawing.Size(101, 25);
            this.checkBoxUseTags.TabIndex = 2;
            this.checkBoxUseTags.Text = "Use Tags:";
            this.checkBoxUseTags.UseVisualStyleBackColor = true;
            this.checkBoxUseTags.CheckedChanged += new System.EventHandler(this.checkBoxUseTags_CheckedChanged);
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
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(492, 340);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(61, 29);
            this.buttonStart.TabIndex = 3;
            this.buttonStart.Text = "Start";
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
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
            // progressBarMain
            // 
            this.progressBarMain.Location = new System.Drawing.Point(150, 340);
            this.progressBarMain.Name = "progressBarMain";
            this.progressBarMain.Size = new System.Drawing.Size(336, 29);
            this.progressBarMain.TabIndex = 2;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 403);
            this.Controls.Add(this.progressBarMain);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.comboBoxLanguageSelector);
            this.Controls.Add(this.tabControlMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.Resizable = false;
            this.Text = "ProjectHED";
            this.tabControlMain.ResumeLayout(false);
            this.metroTabPagePictureOptions.ResumeLayout(false);
            this.metroTabPagePictureOptions.PerformLayout();
            this.panelRestrictImageSizesMethod.ResumeLayout(false);
            this.panelRestrictImageSizesMethod.PerformLayout();
            this.panelRestrictImageSizes.ResumeLayout(false);
            this.panelRestrictImageSizes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRestrictImageSizesHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRestrictImageSizesWidth)).EndInit();
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
        private MetroFramework.Controls.MetroButton buttonStart;
        private MetroFramework.Controls.MetroLabel labelStatus;
        private MetroFramework.Controls.MetroCheckBox checkBoxUseTags;
        private MetroFramework.Controls.MetroTextBox textBoxTags;
        private MetroFramework.Controls.MetroLabel labelTags1;
        private MetroFramework.Controls.MetroLabel labelTags3;
        private MetroFramework.Controls.MetroLabel labelTags2;
        private MetroFramework.Controls.MetroCheckBox checkBoxRestrictImageSizes;
        private System.Windows.Forms.NumericUpDown numericUpDownRestrictImageSizesWidth;
        private System.Windows.Forms.NumericUpDown numericUpDownRestrictImageSizesHeight;
        private MetroFramework.Controls.MetroLabel labelResolutionX;
        private MetroFramework.Controls.MetroPanel panelRestrictImageSizes;
        private MetroFramework.Controls.MetroRadioButton radioButtonRestrictImageSizesEqual;
        private MetroFramework.Controls.MetroRadioButton radioButtonRestrictImageSizesLess;
        private MetroFramework.Controls.MetroRadioButton radioButtonRestrictImageSizesGreater;
        private MetroFramework.Controls.MetroPanel panelRestrictImageSizesMethod;
        private MetroFramework.Controls.MetroRadioButton radioButtonRestrictImageSizesMethodTag;
        private MetroFramework.Controls.MetroRadioButton radioButtonRestrictImageSizesMethodManual;
        private MetroFramework.Controls.MetroCheckBox checkBoxRestrictImageSizesQueryTagDontDownloadTagless;
        private System.Windows.Forms.ProgressBar progressBarMain;
    }
}