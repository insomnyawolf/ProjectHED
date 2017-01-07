using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Controls;
using System.Text.RegularExpressions;

namespace ProjectHEDio
{
    public partial class FormMain : MetroFramework.Forms.MetroForm
    {
        public FormMain()
        {
            InitializeComponent();

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
                        
                        // Get how many sources are selected.
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

        private void buttonStart_Click(object sender, EventArgs e)
        {
            
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
    }
}
