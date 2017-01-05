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

namespace ProjectHEDio
{
    public partial class FormMain : MetroFramework.Forms.MetroForm
    {
        public FormMain()
        {
            InitializeComponent();
            comboBoxLanguageSelector.Text = "English";
        }

        private void metroButtonStart_Click(object sender, EventArgs e)
        {

        }
    }
}
