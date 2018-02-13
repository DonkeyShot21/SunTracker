using ASCOM.DeviceInterface;
using ASCOM.DriverAccess;
using ASCOM.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sun_tracker
{
    public partial class Form1 : Form
    {

        // TELESCOPE

        string telescopeProgID;
        bool UIisActive = false;
        string slewMode = "HOR";
        Telescope telescope;
        string trackingWavelength = default(string);

        Util U = new Util();

        public Form1() => InitializeComponent();


        private void btnChoose_Click(object sender, EventArgs e)
        {
            telescopeProgID = Telescope.Choose("ASCOM.Celestron.Telescope");
            tbChoose.Text = telescopeProgID;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (telescopeProgID != default(string) && btnConnect.Text == "Connect")
                {
                    connect();
                }
                else
                {
                    disconnect();
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void connect()
        {
            telescope = new Telescope(telescopeProgID);
            telescope.Connected = true;
            checkPark();
            checkTracking();

            timerCoord.Start();
            btnConnect.Text = "Disconnect";
            labelValStatus.Text = "Connected";
            UIisActive = true;
        }

        private void disconnect()
        {
            btnConnect.Text = "Connect";
            labelValLST.Text = "-";
            labelValRA.Text = "-";
            labelValDec.Text = "-";
            labelValAz.Text = "-";
            labelValAlt.Text = "-";
            labelValStatus.Text = "Disconnected";
            telescope = default(Telescope);
            timerCoord.Stop();
            UIisActive = false;
        }

        private void checkPark()
        {
            if (telescope.AtPark == false && btnPark.Text == "Unpark")
            {
                btnPark.Text = "Park";
            }
            else if (telescope.AtPark == true && btnPark.Text == "Park")
            {
                btnPark.Text = "Unpark";
            }
        }

        private void checkTracking()
        {
            if (telescope.Tracking ^ cbTrack.Checked)
            {
                cbTrack.Checked = telescope.Tracking;
            }

        }

        private void setGuideRates(double newRA, double newDec)
        {
            if (telescope.CanSetGuideRates)
            {
                try
                {
                    telescope.GuideRateRightAscension = newRA;
                    telescope.GuideRateDeclination = newDec;
                }
                catch
                {
                    //do nothing for now
                }
            }
        }

        private string DecimalToSexagesimalAstropy(double dec)
        {
            string cmd = "-c";
            string args = "from astropy.coordinates import Angle;" +
                          "a = Angle('" + dec + " degrees');" +
                          "print(a.to_string(unit = 'deg', decimal = False, sep = ':', precision = 0, pad = True))";
            string sexa = runCmdPy(cmd, args);
            return sexa;
        }

        private string DecimalToSexagesimal(double dec)
        {
            int h = (int)dec;
            double m = (dec - h) * 60;
            int s = Convert.ToInt32((m % 1) * 60);
            return string.Format("{0:00}:{1:00}:{2:00}",h,Math.Abs((int)m),Math.Abs(s));
        }

        private void updateCoordinates()
        {
            labelValLST.Text = DecimalToSexagesimal(telescope.SiderealTime);
            labelValRA.Text = DecimalToSexagesimal(telescope.RightAscension);
            labelValDec.Text = DecimalToSexagesimal(telescope.Declination);
            labelValAz.Text = DecimalToSexagesimal(telescope.Azimuth);
            labelValAlt.Text = DecimalToSexagesimal(telescope.Altitude);
        }

        private void timerCoord_Tick(object sender, EventArgs e)
        {
            try
            {
                if (UIisActive && telescope.Connected == true)
                {
                    updateCoordinates();
                    checkPark();
                    checkTracking();
                }
                else
                {
                    disconnect();
                }
            }
            catch
            {
                disconnect();
            }
        }

        private void SlewHorizontal(double az, double alt, bool async)
        {
            if (Math.Abs(az) > 90 || Math.Abs(alt) > 90)
            {
                return;
            }
            else if (telescope.CanSlewAltAz)
            {
                labelValStatus.Text = "Slewing...";
                setTracking(false);

                if (telescope.CanSlewAltAzAsync)
                {
                    telescope.SlewToAltAzAsync(az, alt);
                }
                else
                {
                    telescope.SlewToAltAz(az, alt);
                }
                labelValStatus.Text = "Connected";
            }
        }

        private void SlewEquatorial(double ra, double dec, bool async)
        {
            if (ra > 24 || ra < 0 || Math.Abs(dec) > 90)
            {
                return;
            }
            else if (telescope.CanSlew)
            {
                labelValStatus.Text = "Slewing...";
                setTracking(true);
                
                if (telescope.CanSlewAsync)
                {
                    telescope.SlewToCoordinatesAsync(ra, dec);
                }
                else
                {
                    telescope.SlewToCoordinates(ra, dec);
                }
                labelValStatus.Text = "Connected";
            }
        }

        private void btnSlew_Click(object sender, EventArgs e)
        {
            if (UIisActive == false)
            {
                return;
            }

            if (double.TryParse(tbAzRASlew.Text, out double AzRA) && double.TryParse(tbAltDecSlew.Text, out double AltDec))
            {
                if (slewMode == "HOR")
                {
                    SlewHorizontal(AzRA, AltDec, true);
                }
                else if(slewMode == "EQ")
                {
                    SlewEquatorial(AzRA, AltDec, true);
                }
            }
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

        private void btnPark_Click(object sender, EventArgs e)
        {
            if (UIisActive)
            {
                if (telescope.CanPark && telescope.CanUnpark)
                {
                    if (telescope.AtPark)
                    {
                        labelValStatus.Text = "Unparking...";
                        setTracking(true);
                        telescope.Unpark();
                        labelValStatus.Text = "Connected";
                        btnPark.Text = "Park";
                    }
                    else
                    {
                        labelValStatus.Text = "Parking...";
                        setTracking(false);
                        telescope.Park();
                        labelValStatus.Text = "Connected";
                        btnPark.Text = "Unpark";
                    }
                }
            }
        }

        private void btnAbort_Click(object sender, EventArgs e)
        {
            if (UIisActive && telescope.Slewing)
            {
                telescope.AbortSlew();
            }
        }

        private void setTracking(bool onoff)
        {
            if (UIisActive && telescope.CanSetTracking)
            {
                cbTrack.Checked = onoff;
                telescope.Tracking = onoff;
            }
        }
        
        private void cbTrack_CheckedChanged(object sender, EventArgs e)
        {
            if (UIisActive)
            {
                if (telescope.Tracking == true)
                {
                    setTracking(false);
                }
                else
                {
                    setTracking(true);
                }
            }
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            telescope.PulseGuide(GuideDirections.guideEast, 100);
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            telescope.PulseGuide(GuideDirections.guideNorth, 100);
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            telescope.PulseGuide(GuideDirections.guideWest, 100);
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            telescope.PulseGuide(GuideDirections.guideSouth, 100);
        }

        private string sunCoord()
        {
            try
            {
                if (UIisActive)
                {
                    string cmd = AppDomain.CurrentDomain.BaseDirectory + "/SunRaDec.py";
                    string RADec = runCmdPy(cmd, "");
                    return RADec;
                }
                else
                {
                    throw new Exception("Scope is not connected!");
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
        }

        private void btnSlewSun_Click(object sender, EventArgs e)
        {
            labelValStatus.Text = "Calculating Coord...";
            Task<string> t = Task<string>.Factory.StartNew(() => sunCoord());
            string[] RADec = t.Result.Split(' ');

            if (double.TryParse(RADec[0], out double RA) && double.TryParse(RADec[1], out double Dec))
            {
                SlewEquatorial(RA, Dec, true);
            }
        }

        private void btnTrackHalpha_Click(object sender, EventArgs e)
        {
            trackingWavelength = "HALPHA";
            timerTracking.Start();
        }

        private void buttonTrackVisible_Click(object sender, EventArgs e)
        {
            trackingWavelength = "VISIBLE";
            timerTracking.Start();
        }

        private void timerTracking_Tick(object sender, EventArgs e)
        {
            try
            {
                if (trackingWavelength == "VISIBLE")
                {
                    if (VisibleCamera.Connected != true)
                    {
                        timerTracking.Stop();
                        throw new Exception("Camera is not connected!");
                    }
                    else
                    {
                        
                    }

                }
                else if (trackingWavelength == "HALPHA")
                {
                    if (HalphaCamera.Connected != true)
                    {
                        timerTracking.Stop();
                        throw new Exception("Camera is not connected!");
                    }
                    else
                    {

                    }

                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnStopTracking_Click(object sender, EventArgs e)
        {
            timerTracking.Stop();
        }









        // CAMERAS

        string VisibleCameraProgID;
        string HalphaCameraProgID;
        Camera VisibleCamera;
        Camera HalphaCamera;


        private void btnChooseVisibleCamera_Click(object sender, EventArgs e)
        {
            VisibleCameraProgID = Camera.Choose("ASCOM.QHYCCD.Camera");
            tbChooseVisibleCamera.Text = VisibleCameraProgID;
        }

        private void btnChooseHalphaCamera_Click(object sender, EventArgs e)
        {
            HalphaCameraProgID = Camera.Choose("ASCOM.QHYCCD_CAM2ST.Camera");
            tbChooseHalphaCamera.Text = HalphaCameraProgID;
        }

        private void btnConnectVisibleCamera_Click(object sender, EventArgs e)
        {
            try
            {
                if (VisibleCameraProgID != default(string) && btnConnectVisibleCamera.Text == "Connect")
                {
                    connectVisibleCamera();
                }
                else
                {
                    disconnectVisibleCamera();
                }

            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConnectHalphaCamera_Click(object sender, EventArgs e)
        {
            try
            {
                if (HalphaCameraProgID != default(string) && btnConnectHalphaCamera.Text == "Connect")
                {
                    connectHalphaCamera();
                }
                else
                {
                    disconnectHalphaCamera();
                }

            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void connectVisibleCamera()
        {
            VisibleCamera = new Camera(VisibleCameraProgID);
            VisibleCamera.Connected = true;
            btnConnectVisibleCamera.Text = "Disconnect";
        }

        private void connectHalphaCamera()
        {
            HalphaCamera = new Camera(HalphaCameraProgID);
            HalphaCamera.Connected = true;
            btnConnectHalphaCamera.Text = "Disconnect";
        }

        private void disconnectVisibleCamera()
        {
            VisibleCamera.Connected = false;
            VisibleCamera = default(Camera);
            btnConnectVisibleCamera.Text = "Connect";
        }

        private void disconnectHalphaCamera()
        {
            HalphaCamera.Connected = false;
            HalphaCamera = default(Camera);
            btnConnectHalphaCamera.Text = "Connect";
        }

        private void btnStartVisibleExposure_Click(object sender, EventArgs e)
        {
            VisibleCamera.StartExposure(0.01, true);
        }

        private void btnStartHalphaExposure_Click(object sender, EventArgs e)
        {
            HalphaCamera.StartExposure(0.01, true);
        }

        private async void btnDownloadVisible_Click(object sender, EventArgs e)
        {
            if (VisibleCamera.ImageReady)
            {
                int[,] img = (int[,])VisibleCamera.ImageArray;
                int width = img.GetLength(0);
                int height = img.GetLength(1);
                var info = await storeImageAsync(width, height, true, "visible", img);
            }
        }

        private async void btnDownloadHalpha_Click(object sender, EventArgs e)
        {
            if (HalphaCamera.ImageReady)
            {
                int[,] img = (int[,])HalphaCamera.ImageArray;
                int width = img.GetLength(0);
                int height = img.GetLength(1);
                var info = await storeImageAsync(width, height, true, "halpha", img);
            }
        }







        // PYTHON INTERFACE

        private Task<string> storeImageAsync(int width, int height, bool sendViaFTP, string wavelength, int[,] array)
        {
            return Task.Run<string>(() =>
            {
                string fn = @"image_array.csv";

                List<int> listArray = new List<int>(width*height);
                for (int i = 0; i < width; i++)
                {
                    for (int j = 0; j < height; j++)
                        listArray.Add(array[i, j]);
                }
                File.WriteAllText(fn, String.Join(" ", listArray));

                List<string> listArgs = new List<string> { fn, width.ToString(), height.ToString(), sendViaFTP.ToString(), wavelength };
                string args = string.Join(" ", listArgs);
                string info = runCmdPy("storeImage.py", args);
                Console.WriteLine(info);
                return info;
            });
        }

        public string runCmdPy(string cmd, string args)
        {
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = Properties.Settings.Default.PythonPath;
            start.Arguments = string.Format("\"{0}\" \"{1}\"", cmd, args);
            start.UseShellExecute = false;
            start.CreateNoWindow = true;
            start.RedirectStandardOutput = true;
            start.RedirectStandardError = true;
            using (Process process = Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    string stderr = process.StandardError.ReadToEnd();
                    return result;
                }
            }
        }


    }
}
