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
    public partial class FormSlew : Form
    {
        string slewMode = "HOR";
        FormHome fh;
        public FormSlew(FormHome fh)
        {
            this.fh = fh;
            InitializeComponent();
        }

        private void btnEquatHorizon_Click(object sender, EventArgs e)
        {
            if (slewMode == "HOR")
            {
                slewMode = "EQ";
                labelAzRASlew.Text = "RA:";
                labelAltDecSlew.Text = "Dec:";
            }
            else if (slewMode == "EQ")
            {
                slewMode = "HOR";
                labelAzRASlew.Text = "Az:";
                labelAltDecSlew.Text = "Alt:";
            }
        }

        private void btnSlew_Click(object sender, EventArgs e)
        {
            fh.slewSelector(slewMode, tbAzRASlew.Text, tbAltDecSlew.Text);
            this.Close();
        }
    }
}
