using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Controls;

namespace ProjectHEDio
{
    public static class ConfigHelper
    {
        public static void WriteConfig(string language, bool overwrite, bool retryDownloads, int maxRetryAttempts, bool notify, bool openDirectoryOnFinish)
        {
            Properties.Settings.Default.Language = language;
            Properties.Settings.Default.Overwrite = overwrite;
            Properties.Settings.Default.RetryDownloads = retryDownloads;
            Properties.Settings.Default.MaxRetryAttempts = maxRetryAttempts;
            Properties.Settings.Default.Notify = notify;
            Properties.Settings.Default.OpenDirectoryOnFinish = openDirectoryOnFinish;
            Properties.Settings.Default.Save();
        }

        public static void LoadConfig(ref MetroComboBox language, ref MetroCheckBox overwrite, ref MetroCheckBox retryDownloads, ref NumericUpDown maxRetryAttempts, ref MetroCheckBox notify, ref MetroCheckBox openDirectoryOnFinish, bool recursive = false)
        {
            try
            {
                // Check if the saved language exists
                bool languageOptionFound = false;
                foreach (object o in language.Items)
                {
                    if (o.ToString() == Properties.Settings.Default.Language)
                    {
                        languageOptionFound = true;
                        break;
                    }
                }
                language.Text = languageOptionFound ? Properties.Settings.Default.Language : language.Items[0].ToString();
                overwrite.Checked = Properties.Settings.Default.Overwrite;
                retryDownloads.Checked = Properties.Settings.Default.RetryDownloads;
                maxRetryAttempts.Value = Properties.Settings.Default.MaxRetryAttempts;
                notify.Checked = Properties.Settings.Default.Notify;
                openDirectoryOnFinish.Checked = Properties.Settings.Default.OpenDirectoryOnFinish;
            }
            catch (Exception e)
            {
                LogHelper.Log("Couldn't load config: " + e.Message, LogHelper.LogType.Error);
                // Something bad happened
                // Create a default config
                SetDefaultConfig();
                if (!recursive)
                {
                    LoadConfig(ref language, ref overwrite, ref retryDownloads, ref maxRetryAttempts, ref notify, ref openDirectoryOnFinish, true);
                }
            }
        }

        private static void SetDefaultConfig()
        {
            Properties.Settings.Default.Language = "English";
            Properties.Settings.Default.Overwrite = true;
            Properties.Settings.Default.RetryDownloads = true;
            Properties.Settings.Default.MaxRetryAttempts = 3;
            Properties.Settings.Default.Notify = true;
            Properties.Settings.Default.OpenDirectoryOnFinish = false;
            Properties.Settings.Default.Save();
        }
    }
}
