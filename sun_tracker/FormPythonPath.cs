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
    public partial class FormPythonPath : Form
    {
        public FormPythonPath()
        {
            InitializeComponent();
            tbPythonPath.Text = Properties.Settings.Default.PythonPath;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.PythonPath = tbPythonPath.Text;
            Properties.Settings.Default.Save();
            this.Close();
        }
    }
}
