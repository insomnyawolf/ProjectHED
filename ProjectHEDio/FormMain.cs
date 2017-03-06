using System;
using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Controls;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Net;
using System.Threading;

namespace ProjectHEDio
{
    public partial class FormMain : MetroFramework.Forms.MetroForm
    {
        //Workaround for load
        //EDIT AND FIX THIS
        public bool onloadskip = true;
        //EDIT AND FIX THIS
        //Workaround for load

        private Thread DownloadThread = null;

        private List<WebClient> WebClientList = new List<WebClient>();

        private System.Windows.Forms.Timer StatusUpdateTimer = new System.Windows.Forms.Timer();

        public FormMain()
        {
            InitializeComponent();

            // Set label positions on About tab
            this.labelAbout1.Location = new Point(145, 14);
            this.labelAbout2.Location = new Point(180, 42);
            this.labelAbout3.Location = new Point(157, 70);
            this.labelAbout4.Location = new Point(179, 101);

            // Do this thing
            comboBoxLanguageSelector.Text = "English";

            // Set progress bar to have a value to allow marquee style
            progressBarMain.Value = 0;

            // Set numeric value controls to call change event
            numericUpDownRestrictImageSizesWidth.Value = 1920;
            numericUpDownRestrictImageSizesHeight.Value = 1080;

            // Workaround for text box to have prompt text
            textBoxTags.Text = "Test :3c";
            textBoxTags.Text = "";

            // Workaround for combo boxes in source tab to have initial text
            // Workaround for combo boxes to toggle Enabled property of numeric up down property on value changed
            // Workaround for each source panel to not have enabled controls unless the source is checked
            foreach (Control p in panelSources.Controls)
            {
                if (p is MetroPanel)
                {
                    MetroCheckBox checkBoxSelected = null;
                    MetroComboBox comboBoxLimitType = null;
                    NumericUpDown numericUpDownLimitAmount = null;
                    foreach (Control c in p.Controls)
                    {
                        if (c is MetroCheckBox)
                        {
                            checkBoxSelected = (MetroCheckBox)c;
                        }
                        else if (c is MetroComboBox)
                        {
                            comboBoxLimitType = (MetroComboBox)c;
                        }
                        else if (c is NumericUpDown)
                        {
                            numericUpDownLimitAmount = (NumericUpDown)c;
                        }
                    }
                    comboBoxLimitType.Enabled = false;
                    comboBoxLimitType.Text = "No Limit";
                    comboBoxLimitType.SelectedIndexChanged += (sender, args) =>
                    {
                        if (comboBoxLimitType.Text != "No Limit")
                        {
                            numericUpDownLimitAmount.Enabled = true;
                        }
                        else
                        {
                            numericUpDownLimitAmount.Enabled = false;
                        }
                    };
                    checkBoxSelected.CheckedChanged += (sender, args) =>
                    {
                        if (checkBoxSelected.Checked)
                        {
                            comboBoxLimitType.Enabled = true;
                            if (comboBoxLimitType.Text != "No Limit")
                            {
                                numericUpDownLimitAmount.Enabled = true;
                            }
                            else
                            {
                                numericUpDownLimitAmount.Enabled = false;
                            }
                        }
                        else
                        {
                            comboBoxLimitType.Enabled = false;
                            numericUpDownLimitAmount.Enabled = false;
                        }
                        
                        // Get how many sources are selected
                        int sources = 0;
                        foreach (Control panel in panelSources.Controls)
                        {
                            if (panel is MetroPanel)
                            {
                                foreach (Control c in panel.Controls)
                                {
                                    if (c is MetroCheckBox)
                                    {
                                        MetroCheckBox cBox = (MetroCheckBox)c;
                                        if (cBox.Checked)
                                        {
                                            sources++;
                                        }
                                    }
                                }
                            }
                        }
                        labelStatus.Text = "Status: " + sources + " source" + (sources == 1 ? " is" : "s are") + " selected.";
                    };
                }
            }
        }

        private void checkBoxUseTags_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxUseTags.Checked)
            {
                textBoxTags.Enabled = true;
            }
            else
            {
                textBoxTags.Clear();
                textBoxTags.Enabled = false;
            }
        }

        private void checkBoxRestrictImageSizes_CheckedChanged(object sender, EventArgs e)
        {
            bool enabled = checkBoxRestrictImageSizes.Checked;
            panelRestrictImageSizes.Enabled = enabled;
            panelRestrictImageSizesMethod.Enabled = enabled;
            numericUpDownRestrictImageSizesWidth.Enabled = enabled;
            numericUpDownRestrictImageSizesHeight.Enabled = enabled;
            if (enabled)
            {
                radioButtonRestrictImageSizesEqual.Checked = true;
                radioButtonRestrictImageSizesMethodManual.Checked = true;
            }
            else
            {
                foreach (Control c in panelRestrictImageSizes.Controls)
                {
                    if (c is MetroRadioButton)
                    {
                        MetroRadioButton m = (MetroRadioButton)c;
                        m.Checked = false;
                    }
                }
                foreach (Control c in panelRestrictImageSizesMethod.Controls)
                {
                    if (c is MetroRadioButton)
                    {
                        MetroRadioButton m = (MetroRadioButton)c;
                        m.Checked = false;
                    }
                    if (c is MetroCheckBox)
                    {
                        MetroCheckBox m = (MetroCheckBox)c;
                        m.Checked = false;
                    }
                }
            }
        }

        private void numericUpDownRestrictImageSizesEitherControl_ValueChanged(object sender, EventArgs e)
        {
            foreach (Control c in panelRestrictImageSizes.Controls)
            {
                if (c is MetroRadioButton)
                {
                    MetroRadioButton m = (MetroRadioButton)c;
                    // (?<Width>[w0-9]+)x(?<Height>[h0-9]+)\.
                    // ([w0-9]+x[h0-9]+)
                    string pattern = "([w0-9]+x[h0-9]+)";
                    string match = Regex.Match(m.Text, pattern).Groups[1].Value;
                    string newResolution = (int)numericUpDownRestrictImageSizesWidth.Value + "x" + (int)numericUpDownRestrictImageSizesHeight.Value;
                    m.Text = m.Text.Replace(match, newResolution);
                }
            }
        }

        private void buttonSourcesSelectAll_Click(object sender, EventArgs e)
        {
            foreach (Control p in panelSources.Controls)
            {
                if (p is MetroPanel)
                {
                    foreach (Control c in p.Controls)
                    {
                        if (c is MetroCheckBox)
                        {
                            MetroCheckBox checkBox = (MetroCheckBox)c;
                            checkBox.Checked = true;
                        }
                    }
                }
            }
        }

        private void buttonSourcesDeselectAll_Click(object sender, EventArgs e)
        {
            foreach (Control p in panelSources.Controls)
            {
                if (p is MetroPanel)
                {
                    foreach (Control c in p.Controls)
                    {
                        if (c is MetroCheckBox)
                        {
                            MetroCheckBox checkBox = (MetroCheckBox)c;
                            checkBox.Checked = false;
                        }
                    }
                }
            }
        }

        private void labelAbout3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/MoeChezzy/ProjectHED");
        }

        private void pictureBoxDonate_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/MoeChezzy/ProjectHED");
        }

        private void pictureBoxDonate_MouseEnter(object sender, EventArgs e)
        {
            pictureBoxDonate.Cursor = Cursors.Hand;
        }

        private void pictureBoxDonate_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxDonate.Cursor = Cursors.Default;
        }

        private void UpdateStatus(string status, MetroColorStyle style = MetroColorStyle.Black)
        {
            if (this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate { UpdateStatus(status, style); });
                return;
            }
            this.labelStatus.Style = style;
            this.labelStatus.Text = "Status: " + status;
        }

        private void buttonDownloadDirectoryBrowse_Click(object sender, EventArgs e)
        {
            folderBrowserDialogMain.ShowDialog();
            textBoxDownloadDirectory.Text = folderBrowserDialogMain.SelectedPath;
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            bool isDownloading = DownloadThread != null && DownloadThread.IsAlive;
            if (!Website.IsScraping() && !isDownloading)
            {
                // Currently not downloading

                // Check to see if download directory is valid or set
                if (string.IsNullOrWhiteSpace(textBoxDownloadDirectory.Text) || !Directory.Exists(textBoxDownloadDirectory.Text))
                {
                    UpdateStatus("Couldn't start download - no valid download directory was set.", MetroColorStyle.Red);
                    return;
                }

                // Check to see if tag usage is checked but no tags were inserted
                if (checkBoxUseTags.Checked && string.IsNullOrWhiteSpace(textBoxTags.Text))
                {
                    UpdateStatus("Couldn't start download - no tags were specified when \"Use Tags\" is checked.", MetroColorStyle.Red);
                    return;
                }

                // Check to see if any sources have been checked
                int checkedSources = 0;
                foreach (Control p in panelSources.Controls)
                {
                    if (p is MetroPanel)
                    {
                        foreach (Control c in p.Controls)
                        {
                            if (c is MetroCheckBox)
                            {
                                MetroCheckBox checkBox = (MetroCheckBox)c;
                                if (checkBox.Checked)
                                {
                                    checkedSources++;
                                }
                            }
                        }
                    }
                }
                if (checkedSources < 1)
                {
                    UpdateStatus("Couldn't start download - no sources were checked.", MetroColorStyle.Red);
                    return;
                }

                // Check if the thread is alive
                if (DownloadThread != null && DownloadThread.IsAlive)
                {
                    UpdateStatus("Couldn't start download - thread is still alive.", MetroColorStyle.Red);
                    return;
                }

                // TODO: Check if any invalid tags are present

                // Disable controls
                ToggleControls(false);

                // Start the download thread
                DownloadThread = new Thread(StartDownload);
                DownloadThread.Start();

                // Start the status update timer
                StatusUpdateTimer = new System.Windows.Forms.Timer();
                StatusUpdateTimer.Interval = 100;
                StatusUpdateTimer.Tick += (o, args) =>
                {
                    if (Website.IsScraping())
                    {
                        /*
                        if (progressBarMain.Style != ProgressBarStyle.Marquee)
                        {
                            progressBarMain.Style = ProgressBarStyle.Marquee;
                        }
                        */
                        decimal percent = Website.GetDownloadedFiles() * 100.0m / (Website.GetTotalFiles() == 0 ? int.MaxValue : Website.GetTotalFiles());
                        progressBarMain.Value = (int)percent;
                        UpdateStatus(string.Format("Currently scraping all files (scraped: {0} / downloaded: {1})!", Website.GetTotalFiles(), Website.GetDownloadedFiles()));
                    }
                    else
                    {
                        if (progressBarMain.Style != ProgressBarStyle.Blocks)
                        {
                            progressBarMain.Style = ProgressBarStyle.Blocks;
                        }
                        UpdateStatus(string.Format("Downloading all files ({0}/{1})!", Website.GetDownloadedFiles(), Website.GetTotalFiles()));
                        decimal percent = Website.GetDownloadedFiles() * 100.0m / (Website.GetTotalFiles() == 0 ? int.MaxValue : Website.GetTotalFiles());
                        progressBarMain.Value = (int)percent;
                    }

                    if (!DownloadThread.IsAlive)
                    {
                        // End
                        UpdateStatus("Finished downloading " + Website.GetDownloadedFiles() + " files! Expected: " + Website.GetTotalFiles() + ". dlnk: " + Website.GetLinkDuplicates() + ". dfln: " + Website.GetFilenameDuplicates() + ".", MetroColorStyle.Green);
                        progressBarMain.Value = 100;
                        StatusUpdateTimer.Stop();
                    }
                };
                StatusUpdateTimer.Start();
            }
            else
            {
                // Currently downloading
                DialogResult confirmation = MessageBox.Show("ProjectHED is still downloading images!" + Environment.NewLine + "Are you sure you want to stop the operation?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirmation == DialogResult.No)
                {
                    return;
                }

                // Bleh
                DownloadThread.Abort();
                StatusUpdateTimer.Stop();

                foreach (Website w in Website.WebsiteList)
                {
                    w.KillThread();
                }

                foreach (WebClient wc in WebClientList)
                {
                    if (wc.IsBusy)
                    {
                        wc.CancelAsync();
                    }
                }
                foreach (WebClient wc in WebClientList)
                {
                    wc.Dispose();
                }
                progressBarMain.Style = ProgressBarStyle.Blocks;
                progressBarMain.Value = 0;
                UpdateStatus("Aborted download! Finished downloads: " + Website.GetDownloadedFiles() + ".", MetroColorStyle.Orange);
                WebClientList.Clear();
                ToggleControls(true);
            }
        }

        private void ToggleControls(bool enabled)
        {
            // Check if this method is called on non UI thread
            if (this.InvokeRequired)
            {
                // Call the method on the main UI thread
                this.Invoke((MethodInvoker)delegate { ToggleControls(enabled); });
                return;
            }

            buttonStart.Text = enabled ? "Start" : "Stop";

            // All of the first tab (Picture Options) is sensitive
            tabControlMain.TabPages[0].Enabled = enabled;

            // All of the second tab (Source Selection) is sensitive
            tabControlMain.TabPages[1].Enabled = enabled;

            // Some of the third tab (Download Settings) is sensitive
            buttonDownloadDirectoryBrowse.Enabled = enabled;
            checkBoxOverwrite.Enabled = enabled;
            checkBoxRetryDownloads.Enabled = enabled;
            numericUpDownMaxRetryAttempts.Enabled = enabled;
        }

        private string GetComboBoxText(MetroComboBox comboBox)
        {
            if (this.InvokeRequired)
            {
                // this.Invoke((MethodInvoker)(() => GetComboBoxText(comboBox)));
                return (string)this.Invoke(new Func<string>(() => GetComboBoxText(comboBox)));
            }
            return comboBox.Text;
        }

        private string StripFilename(string filename)
        {
            string result = filename;

            // Replace invalid filename characters with _
            foreach (char c in Path.GetInvalidFileNameChars())
            {
                result = result.Replace(c, '_');
            }

            // Remove website prepends
            result = result.Replace("Konachan.com - ", "").Replace("konachan.com - ", "");
            result = result.Replace("yande.re ", "");

            // Remove numeric pid
            // ([0-9]+ )
            string pid = Regex.Match(result, "([0-9]+ )").Groups[1].Value;
            if (pid.Length > 0)
            {
                result = result.Replace(pid, "");
            }
            
            // Remove prepended underscores
            result = result.TrimStart('_');

            return result;
        }

        private void StartDownload()
        {
            List<string> urlList = new List<string>();
            List<string> filenameList = new List<string>();
            UpdateStatus("Started download!", MetroColorStyle.Green);
            
            // Clear the WebClientList
            WebClientList.Clear();
            WebClientList = new List<WebClient>();

            // Reset the Website class
            Website.Reset();

            bool usingTags = checkBoxUseTags.Checked;
            string[] tagList = null;
            if (usingTags)
            {
                tagList = textBoxTags.Text.Split(' ');
            }

            // Initialize website objects
            // Each of these objects will be in the WebsiteList
            WebsiteKonachanNet wkn = new WebsiteKonachanNet(panelSourceKonachanNet);
            WebsiteKonachanCom wkc = new WebsiteKonachanCom(panelSourceKonachanCom);
            WebsiteGelbooru wgb = new WebsiteGelbooru(panelSourceGelbooruCom);
            WebsiteYandere wyd = new WebsiteYandere(panelSourceYandere);
            WebsiteDanbooru wdb = new WebsiteDanbooru(panelSourceDanbooru);
            WebsiteSafebooru wsb = new WebsiteSafebooru(panelSourceSafebooru);

            foreach (Website w in Website.WebsiteList)
            {
                MetroCheckBox checkBox = null;
                MetroComboBox comboBox = null;
                NumericUpDown limitControl = null;
                int limit = 1;
                // Check if the source has been checked on their panel by looping through controls
                foreach (Control c in w.SourcePanel.Controls)
                {
                    if (c is MetroCheckBox)
                    {
                        checkBox = (MetroCheckBox)c;
                    }
                    if (c is MetroComboBox)
                    {
                        comboBox = (MetroComboBox)c;
                    }
                    if (c is NumericUpDown)
                    {
                        limitControl = (NumericUpDown)c;
                    }
                }
                if (!checkBox.Checked)
                {
                    // Don't initialize the scrape for this source
                    continue;
                }
                string limitType = GetComboBoxText(comboBox);
                if (limitType == "No Limit")
                {
                    limit = Int32.MaxValue;
                }
                else if (limitType == "Page Limit")
                {
                    limit = (int)limitControl.Value;
                }
                w.InitializeScrape(tagList, limit);
            }
            while (Website.IsScraping())
            {
                while (Website.WebsiteFileLinks.Count > 0)
                {
                    // Retrieve file from queue
                    ScrapedFile file = Website.WebsiteFileLinks.Dequeue();

                    // Get link of file
                    Uri uri = new Uri(file.GetLink());

                    if (urlList.Count > 0)
                    {
                        if (urlList.Contains(file.GetLink()))
                        {
                            Website.IncrementLinkDuplicates();
                            continue;
                        }
                    }
                    urlList.Add(file.GetLink());

                    // Retrieve filename and unescape it
                    string filename = Uri.UnescapeDataString(file.GetLink().Split('/')[file.GetLink().Split('/').Length - 1]);

                    // Strip filename
                    filename = StripFilename(filename);

                    if (filenameList.Count > 0)
                    {
                        if (filenameList.Contains(filename))
                        {
                            Website.IncrementFilenameDuplicates();
                            continue;
                        }
                    }
                    filenameList.Add(filename);

                    try
                    {
                        string filepath = textBoxDownloadDirectory.Text + "\\" + filename;
                        if (File.Exists(filepath))
                        {
                            if (!checkBoxOverwrite.Checked)
                            {
                                continue;
                            }
                        }

                        // Add a new WebClient to the WebClientList
                        WebClientList.Add(new WebClient());

                        // Start the download on the added WebClient
                        WebClientList.Last().DownloadFileAsync(uri, textBoxDownloadDirectory.Text + "\\" + filename);
                    }
                    catch (WebException e)
                    {
                        MessageBox.Show(e + "");
                        // An exception happened oh no whatever shall we do
                        // Retry the download if conditions are met
                        if (checkBoxRetryDownloads.Checked)
                        {
                            // Check if the file has been downloaded more times than allowed
                            if (file.GetRetries() >= (int)numericUpDownMaxRetryAttempts.Value)
                            {
                                // Don't retry downloading file
                            }
                            else
                            {
                                // Retry downloading the file
                                Website.AddToLinks(file.GetLink(), file.GetRetries() + 1);
                            }
                        }
                    }

                    // Add event handlers for WebClient here
                    WebClientList.Last().DownloadFileCompleted += (sender, eventArgs) =>
                    {
                        if (eventArgs.Error != null)
                        {
                            // An error happened
                            // Retry the download if conditions are met
                            if (checkBoxRetryDownloads.Checked)
                            {
                                // Check if the file has been downloaded more times than allowed
                                if (file.GetRetries() >= (int)numericUpDownMaxRetryAttempts.Value)
                                {
                                    // Don't retry downloading file
                                }
                                else
                                {
                                    // Retry downloading the file
                                    Website.AddToLinks(file.GetLink(), file.GetRetries() + 1);
                                }
                            }
                        }
                        else
                        {
                            // The download was completed
                            Website.IncrementDownloadedFileAmount();
                        }
                    };
                    Thread.Sleep(5);
                }
                Thread.Sleep(5);
            }
            bool isDone = false;
            while (!isDone)
            {
                isDone = true;
                foreach (WebClient wc in WebClientList)
                {
                    if (wc.IsBusy)
                    {
                        isDone = false;
                        break;
                    }
                }
                Thread.Sleep(5);
            }
            foreach (WebClient wc in WebClientList)
            {
                wc.Dispose();
            }
            WebClientList.Clear();
            ToggleControls(true);
            if (checkBoxNotify.Checked)
            {
                NotifyIconMain.ShowBalloonTip(10000, "ProjectHED", "ProjectHED has finished downloading " + Website.GetDownloadedFiles() + " files!", ToolTipIcon.Info);
            }
            if (checkBoxOpenDirectoryOnFinish.Checked)
            {
                Process.Start("explorer.exe", textBoxDownloadDirectory.Text);
            }
        }

        #region Language;

        private void comboBoxLanguageSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(onloadskip == false)
            {
                
                //Form load workaround (no english file)
                var data = File
                .ReadAllLines(comboBoxLanguageSelector.Text + ".ini")
                .Select(x => x.Split('='))
                .Where(x => x.Length > 1)
                .ToDictionary(x => x[0].Trim(), x => x[1]);

                labelStatus.Text = data["labelStatus"];

                #region tabs;

                metroTabPagePictureOptions.Text = data["metroTabPagePictureOptions"];
                metroTabPageSourceSelection.Text = data["metroTabPageSourceSelection"];
                metroTabPageDownloadSettings.Text = data["metroTabPageDownloadSettings"];
                metroTabPageAbout.Text = data["metroTabPageAbout"];

                #endregion;

                #region image options;

                checkBoxUseTags.Text = data["checkBoxUseTags"];
                textBoxTags.PromptText = data["textBoxTags"];
                labelTags1.Text = data["labelTags1"];
                labelTags2.Text = data["labelTags2"];
                labelTags3.Text = data["labelTags3"];
                checkBoxRestrictImageSizes.Text = data["checkBoxRestrictImageSizes"];
                labelRestrictImageSizes.Text = data["labelRestrictImageSizes"];
                radioButtonRestrictImageSizesEqual.Text = data["radioButtonRestrictImageSizesEqual"];
                radioButtonRestrictImageSizesGreater.Text = data["radioButtonRestrictImageSizesGreater"];
                radioButtonRestrictImageSizesLess.Text = data["radioButtonRestrictImageSizesLess"];
                radioButtonRestrictImageSizesMethodManual.Text = data["radioButtonRestrictImageSizesMethodManual"];
                radioButtonRestrictImageSizesMethodTag.Text = data["radioButtonRestrictImageSizesMethodTag"];
                checkBoxRestrictImageSizesQueryTagDontDownloadTagless.Text = data["checkBoxRestrictImageSizesQueryTagDontDownloadTagless"];
                buttonStart.Text = data["buttonStart"];

                #endregion;

            }
            
            else
            {
                onloadskip = false;
            }


        }

        #endregion;
    }
}
