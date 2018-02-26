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
    public partial class FormDefaultCamera : Form
    {
        private string wavelength;
        public FormDefaultCamera(string wavelength)
        {
            InitializeComponent();
            this.wavelength = wavelength;
            if (this.wavelength == "halpha")
            {
                tbDefaultCamera.Text = Properties.Settings.Default.HalphaCamera;
            }
            else
            {
                tbDefaultCamera.Text = Properties.Settings.Default.VisibleCamera;
            }
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            tbDefaultCamera.Text = Camera.Choose("");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (wavelength == "halpha")
            {
                Properties.Settings.Default.HalphaCamera = tbDefaultCamera.Text;
            }
            else
            {
                Properties.Settings.Default.VisibleCamera = tbDefaultCamera.Text;
            }
            Properties.Settings.Default.Save();
            this.Close();
        }
    }
}
