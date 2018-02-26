using ASCOM.DriverAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sun_tracker
{
    public partial class FormDefaultTelescope : Form
    {
        public FormDefaultTelescope()
        {
            InitializeComponent();
            tbDefaultTelescope.Text = Properties.Settings.Default.Telescope;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Telescope = tbDefaultTelescope.Text;
            Properties.Settings.Default.Save();
            this.Close();
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            tbDefaultTelescope.Text = Telescope.Choose("");
        }
    }
}
