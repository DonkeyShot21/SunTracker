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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sun_tracker
{
    public partial class FormHome : Form
    {

        // TELESCOPE

        string telescopeProgID;
        public bool UIisActive = false;
        Telescope telescope;
        string trackingWavelength = default(string);
        public int declinationDirection;
        double moveAxisSpeed;

        Util U = new Util();

        public FormHome()
        {
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            InitializeComponent();
            telescopeProgID = Properties.Settings.Default.Telescope;
            comboBoxSpeed.Text = Properties.Settings.Default.MoveAxisSpeed;
            VisibleCameraProgID = Properties.Settings.Default.VisibleCamera;
            HalphaCameraProgID = Properties.Settings.Default.HalphaCamera;
            visibleGain = Properties.Settings.Default.VisibleGain;
            visibleExposure = Properties.Settings.Default.VisibleExposure;
            comboBoxTimerVisible.Text = Properties.Settings.Default.TimerVisible;
            tbGainVisible.Text = Properties.Settings.Default.VisibleGain.ToString();
            tbExposureVisible.Text = Properties.Settings.Default.VisibleExposure.ToString();
            halphaGain = Properties.Settings.Default.HalphaGain;
            halphaExposure = Properties.Settings.Default.HalphaExposure;
            ComboBoxTimerHalpha.Text = Properties.Settings.Default.TimerHalpha;
            tbGainHalpha.Text = Properties.Settings.Default.HalphaGain.ToString();
            tbExposureHalpha.Text = Properties.Settings.Default.HalphaExposure.ToString();
            cbTrackingTimer.Text = Properties.Settings.Default.TrackingTimer;
            trackingWavelength = Properties.Settings.Default.TrackingWavelength.ToUpper();
        }


        private void btnChoose_Click(object sender, EventArgs e)
        {
            telescopeProgID = Telescope.Choose(Properties.Settings.Default.Telescope);
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

        private void checkSide()
        {
            switch (telescope.SideOfPier)
            {
                case PierSide.pierEast:
                    declinationDirection = -1;
                    break;
                case PierSide.pierWest:
                    declinationDirection = 1;
                    break;
                default:
                    return;
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
            if (coordinatesToolStripMenuItem.Checked == true)
            {
                string dumpFile = "C:\\solar\\coord_dump.csv";
                List<string> coord = new List<string> { telescope.SiderealTime.ToString(), telescope.RightAscension.ToString(), telescope.Declination.ToString(), telescope.Azimuth.ToString(), telescope.Altitude.ToString() };
                File.AppendAllText(dumpFile, string.Join(" ", coord) + "\n");
            }
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
                    checkSide();
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

        private void slewHorizontal(double az, double alt, bool async)
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

        private void slewEquatorial(double ra, double dec, bool async)
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

        public void slewSelector(string slewMode, string AzRASlew, string AltDecSlew)
        {
            if (UIisActive == false)
            {
                return;
            }
            try
            {
                if (double.TryParse(AzRASlew, out double AzRA) && double.TryParse(AltDecSlew, out double AltDec))
                {
                    if (slewMode == "HOR")
                    {
                        slewHorizontal(AzRA, AltDec, true);
                    }
                    else if (slewMode == "EQ")
                    {
                        slewEquatorial(AzRA, AltDec, true);
                    }
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                telescope.MoveAxis(TelescopeAxes.axisPrimary, 0);
                telescope.MoveAxis(TelescopeAxes.axisSecondary, 0);
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

        //RIGHT
        private void btnRight_MouseDown(object sender, MouseEventArgs e)
        {
            try { telescope.MoveAxis(TelescopeAxes.axisPrimary, moveAxisSpeed); } catch { }
        }

        private void btnRight_MouseUp(object sender, MouseEventArgs e)
        {
            try { telescope.MoveAxis(TelescopeAxes.axisPrimary, 0); } catch { }
        }

        //UP
        private void btnUp_MouseDown(object sender, MouseEventArgs e)
        {
            try { telescope.MoveAxis(TelescopeAxes.axisSecondary, declinationDirection * moveAxisSpeed); } catch { }
        }

        private void btnUp_MouseUp(object sender, MouseEventArgs e)
        {
            try { telescope.MoveAxis(TelescopeAxes.axisSecondary, 0); } catch { }
        }

        //LEFT
        private void btnLeft_MouseDown(object sender, MouseEventArgs e)
        {
            try { telescope.MoveAxis(TelescopeAxes.axisPrimary, - moveAxisSpeed); } catch { }
        }

        private void btnLeft_MouseUp(object sender, MouseEventArgs e)
        {
            try { telescope.MoveAxis(TelescopeAxes.axisPrimary, 0); } catch { }
        }

        //DOWN
        private void btnDown_MouseDown(object sender, MouseEventArgs e)
        {
            try { telescope.MoveAxis(TelescopeAxes.axisSecondary, - declinationDirection * moveAxisSpeed); } catch { }
        }

        private void btnDown_MouseUp(object sender, MouseEventArgs e)
        {
            try { telescope.MoveAxis(TelescopeAxes.axisSecondary, 0); } catch { }
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
                slewEquatorial(RA, Dec, true);
            }
        }

        private void btnStartTracking_Click(object sender, EventArgs e)
        {
            timerTracking.Start();
        }

        private async void timerTracking_Tick(object sender, EventArgs e)
        {
            Console.WriteLine(trackingWavelength);
            try
            {
                if (trackingWavelength.ToUpper() == "VISIBLE")
                {
                    if (VisibleCamera.Connected != true)
                    {
                        timerTracking.Stop();
                        throw new Exception(trackingWavelength + " Camera is not connected!");
                    }
                    else
                    {
                        var offset_radius = (await calculateOffset("VISIBLE")).Split(' ');
                        double offsetRA = Double.Parse(offset_radius[0]);
                        double offsetDec = Double.Parse(offset_radius[1]);
                        int radius = Int32.Parse(offset_radius[2]);
                        goToOffset(offsetRA, offsetDec);
                    }

                }
                else if (trackingWavelength.ToUpper() == "HALPHA")
                {
                    if (HalphaCamera.Connected != true)
                    {
                        timerTracking.Stop();
                        throw new Exception(trackingWavelength + " Camera is not connected!");
                    }
                    else
                    {
                        //TODO
                    }
                }
            }
            catch (Exception exp)
            {
                timerTracking.Stop();
                MessageBox.Show(exp.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private async void goToOffset(double offsetRA, double offsetDec)
        {
            double targetRA = telescope.RightAscension + offsetRA;
            double targetDec = telescope.Declination + offsetDec;

            Console.WriteLine(targetRA.ToString() + ", " + telescope.RightAscension.ToString() + ", " + offsetRA.ToString());
            Console.WriteLine(targetDec.ToString() + ", " + telescope.Declination.ToString());

            await Task.Factory.StartNew(() => moveAxisToTarget(telescope, targetRA, targetDec, 0.3, 0.5, 0.005, 150));
        }

        private void moveAxisToTarget(Telescope telescope, double targetRA, double targetDec, double speed, double maxRate, double tolerance, int maxSteps)
        {
            if (telescope.CanMoveAxis(TelescopeAxes.axisPrimary))
            {
                int steps = 0;
                double rateRA;
                while (Math.Abs(targetRA - telescope.RightAscension) > tolerance && steps < maxSteps)
                {
                    rateRA = - Math.Sign(targetRA - telescope.RightAscension) * Math.Min(Math.Abs((targetRA - telescope.RightAscension) * speed), maxRate);
                    telescope.MoveAxis(TelescopeAxes.axisPrimary, rateRA);
                    if (steps % 10 == 0)
                    {
                        Console.WriteLine("RA: " + (targetRA - telescope.RightAscension).ToString());
                        Console.WriteLine("\n");
                    }
                    steps += 1;
                    Thread.Sleep(10);
                }
                telescope.MoveAxis(TelescopeAxes.axisPrimary, 0);
            }

            if (telescope.CanMoveAxis(TelescopeAxes.axisSecondary))
            {
                int steps = 0;
                double rateDec;
                while (Math.Abs(targetDec - telescope.Declination) > tolerance && steps < maxSteps)
                {
                    rateDec = declinationDirection * Math.Sign(targetDec - telescope.Declination) * Math.Min(Math.Abs((targetDec - telescope.Declination) * speed), maxRate);
                    telescope.MoveAxis(TelescopeAxes.axisSecondary, rateDec);
                    if (steps % 10 == 0)
                    {
                        Console.WriteLine("DEC: " + (targetDec - telescope.Declination).ToString());
                        Console.WriteLine("\n");
                    }
                    steps += 1;
                    Thread.Sleep(10);
                }
                telescope.MoveAxis(TelescopeAxes.axisSecondary, 0);
            }
        }

        private void btnStopTracking_Click(object sender, EventArgs e)
        {
            timerTracking.Stop();
        }

        private void comboBoxSpeed_SelectedIndexChanged(object sender, EventArgs e)
        {
            double.TryParse(comboBoxSpeed.Text.Replace(" deg/sec", ""), out moveAxisSpeed);
            Properties.Settings.Default.MoveAxisSpeed = comboBoxSpeed.Text;
            Properties.Settings.Default.Save();
        }







        // CAMERAS

        string VisibleCameraProgID;
        string HalphaCameraProgID;
        Camera VisibleCamera;
        Camera HalphaCamera;
        int visibleTimeStep;
        int halphaTimeStep;
        int trackingTimeStep;


        double visibleExposure; // in milliseconds
        short visibleGain;

        double halphaExposure;
        short halphaGain;

        private void btnChooseVisibleCamera_Click(object sender, EventArgs e)
        {
            VisibleCameraProgID = Camera.Choose(Properties.Settings.Default.VisibleCamera);
            tbChooseVisibleCamera.Text = VisibleCameraProgID;
        }

        private void btnChooseHalphaCamera_Click(object sender, EventArgs e)
        {
            HalphaCameraProgID = Camera.Choose(Properties.Settings.Default.VisibleCamera);
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
            VisibleCamera.Gain = visibleGain;
            btnConnectVisibleCamera.Text = "Disconnect";
            timerVisibleLiveView.Start();
        }

        private void connectHalphaCamera()
        {
            HalphaCamera = new Camera(HalphaCameraProgID);
            HalphaCamera.Connected = true;
            HalphaCamera.Gain = halphaGain;
            btnConnectHalphaCamera.Text = "Disconnect";
            timerHalphaLiveView.Start();
        }

        private void disconnectVisibleCamera()
        {
            VisibleCamera.Connected = false;
            VisibleCamera = default(Camera);
            btnConnectVisibleCamera.Text = "Connect";
            timerVisibleLiveView.Stop();
        }

        private void disconnectHalphaCamera()
        {
            HalphaCamera.Connected = false;
            HalphaCamera = default(Camera);
            btnConnectHalphaCamera.Text = "Connect";
            timerHalphaLiveView.Stop();
        }

        private void btnStartRoutineHalpha_Click(object sender, EventArgs e)
        {
            HalphaCamera.StartExposure(0.001*halphaExposure, true);
        }

        private void takeTrackingImage(string wavelength, string filename)
        {
            if (wavelength == "VISIBLE")
            {
                VisibleCamera.StartExposure(0.001 * visibleExposure, true);
                while (!VisibleCamera.ImageReady)
                {
                    Thread.Sleep((int)(visibleExposure / 3));
                }
                int[,] img = (int[,])VisibleCamera.ImageArray;
                int width = img.GetLength(0);
                int height = img.GetLength(1);                
                var info = storeImageAsync(width, height, false, "visible", filename, img);
            }

            if (wavelength == "HALPHA")
            {
                HalphaCamera.StartExposure(0.001 * halphaExposure, true);
                while (!HalphaCamera.ImageReady)
                {
                    Thread.Sleep((int)(halphaExposure / 3));
                }
                int[,] img = (int[,])HalphaCamera.ImageArray;
                int width = img.GetLength(0);
                int height = img.GetLength(1);
                var info = storeImageAsync(width, height, false, "halpha", filename, img);
            }
        }

        private void comboBoxTimerVisible_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTimerVisible.Text.Contains("min"))
            {
                visibleTimeStep = 60 * 1000 *int.Parse(comboBoxTimerVisible.Text.Replace(" min",""));
            }
            else if (comboBoxTimerVisible.Text.Contains("sec"))
            {
                visibleTimeStep = 1000 * int.Parse(comboBoxTimerVisible.Text.Replace(" sec", ""));
            }
            Properties.Settings.Default.TimerVisible = comboBoxTimerVisible.Text;
            Properties.Settings.Default.Save();
        }

        private void ComboBoxTimerHalpha_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBoxTimerHalpha.Text.Contains("min"))
            {
                halphaTimeStep = 60 * 1000 * int.Parse(ComboBoxTimerHalpha.Text.Replace(" min", ""));
            }
            else if (ComboBoxTimerHalpha.Text.Contains("sec"))
            {
                visibleTimeStep = 1000 * int.Parse(ComboBoxTimerHalpha.Text.Replace(" sec", ""));
            }
            Properties.Settings.Default.TimerHalpha = ComboBoxTimerHalpha.Text;
            Properties.Settings.Default.Save();
        }

        private void btnStartRoutineVisible_Click(object sender, EventArgs e)
        {
            timerVisiblePhoto.Interval = visibleTimeStep;
            timerVisiblePhoto.Start();
        }

        private void btnStopRoutineHalpha_Click(object sender, EventArgs e)
        {
            timerHalphaPhoto.Interval = halphaTimeStep;
            timerVisiblePhoto.Start();
        }

        private void btnStopRoutineVisible_Click(object sender, EventArgs e)
        {
            timerVisiblePhoto.Stop();
        }

        private async void btnSinglePhotoVisible_Click(object sender, EventArgs e)
        {
            await Task.Factory.StartNew(() => takeVisiblePhoto());
        }

        private async void timerVisiblePhoto_Tick(object sender, EventArgs e)
        {
            await Task.Factory.StartNew(() => takeVisiblePhoto());
        }

        private async void timerHalphaPhoto_Tick(object sender, EventArgs e)
        {
            await Task.Factory.StartNew(() => takeHalphaPhoto());
        }

        private async void takeVisiblePhoto()
        {
            VisibleCamera.StartExposure(0.001 * visibleExposure, true);
            while (!VisibleCamera.ImageReady)
            {
                Thread.Sleep((int)visibleExposure / 3);
            }
            if (VisibleCamera.ImageReady)
            {
                int[,] img = (int[,])VisibleCamera.ImageArray;
                int width = img.GetLength(0);
                int height = img.GetLength(1);
                string filename = "visible/visible.stf";
                var info = await storeImageAsync(width, height, cbFTPVisible.Checked, "visible", filename, img);
                //Console.WriteLine(info);
            }
        }

        private async void takeHalphaPhoto()
        {
            HalphaCamera.StartExposure(0.001 * halphaExposure, true);
            while (!HalphaCamera.ImageReady)
            {
                Thread.Sleep((int)halphaExposure / 3);
            }
            if (HalphaCamera.ImageReady)
            {
                int[,] img = (int[,])HalphaCamera.ImageArray;
                int width = img.GetLength(0);
                int height = img.GetLength(1);
                string filename = "halpha/halpha.stf";
                var info = await storeImageAsync(width, height, cbFTPHalpha.Checked, "halpha", filename, img);
                //Console.WriteLine(info);
            }
        }

        private void tbGainVisible_TextChanged(object sender, EventArgs e)
        {
            if (short.TryParse(tbGainVisible.Text, out short g))
            {
                halphaGain = g;
                Properties.Settings.Default.VisibleGain = g;
                Properties.Settings.Default.Save();
            }
        }

        private void tbGainHalpha_TextChanged(object sender, EventArgs e)
        {
            if (short.TryParse(tbGainHalpha.Text, out short g))
            {
                halphaGain = g;
                Properties.Settings.Default.HalphaGain = g;
                Properties.Settings.Default.Save();
            }
        }

        private void tbExposureVisible_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(tbExposureVisible.Text, out double exp))
            {
                visibleExposure = exp;
                Properties.Settings.Default.VisibleExposure = exp;
                Properties.Settings.Default.Save();
            }
        }

        private void tbExposureHalpha_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(tbExposureHalpha.Text, out double exp))
            {
                halphaExposure = exp;
                Properties.Settings.Default.HalphaExposure = exp;
                Properties.Settings.Default.Save();
            }
        }

        private void cbTrackingTimer_SelectedIndexChanged(object sender, EventArgs e)
        {
            int.TryParse(cbTrackingTimer.Text.Replace(" min",""), out trackingTimeStep);
            Properties.Settings.Default.TrackingTimer = cbTrackingTimer.Text;
            Properties.Settings.Default.Save();
        }

        private async void timerVisibleLiveView_Tick(object sender, EventArgs e)
        {
            pbVisible.Image = await FromFile("preview/visible.bmp");
        }

        private async void timerHalphaLiveView_Tick(object sender, EventArgs e)
        {
            pbHalpha.Image = await FromFile("preview/halpha.bmp");
        }






        // PYTHON INTERFACE & UTIL

        private Task<string> calculateOffset(string wavelength)
        {
            return Task.Run<string>(() =>
            {
                string csvFilename = "tracking_" + wavelength.ToLower() + ".csv";
                takeTrackingImage(wavelength, csvFilename);
                string bmpFilename = csvFilename.Replace(".csv", ".bmp");
                string result = runCmdPy("calculateOffset.py", wavelength + " " + bmpFilename);
                //Console.WriteLine(result);
                return result;
            });
        }

        private Task<string> storeImageAsync(int width, int height, bool sendViaFTP, string wavelength, string filename, int[,] array)
        {
            return Task.Run<string>(() =>
            {
                List<int> listArray = new List<int>(width*height);
                for (int i = 0; i < width; i++)
                {
                    for (int j = 0; j < height; j++)
                        listArray.Add(array[i, j]);
                }
                File.WriteAllText(filename, String.Join(" ", listArray));

                bool flipX = false, flipY = false;
                if (wavelength == "halpha")
                {
                    flipX = halphaFlipXToolStripMenuItem1.Checked;
                    flipY = halphaFlipYToolStripMenuItem1.Checked;
                } else if (wavelength == "visible")
                {
                    flipX = visibleFlipXToolStripMenuItem1.Checked;
                    flipY = visibleFlipYToolStripMenuItem1.Checked;
                }

                List<string> listArgs = new List<string> { filename, width.ToString(), height.ToString(), sendViaFTP.ToString(), wavelength, flipX.ToString(), flipY.ToString() };
                string args = string.Join(" ", listArgs);
                string info = runCmdPy("storeImage.py", args);
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
                    Console.WriteLine(result + "\n" + stderr);
                    return result;
                }
            }
        }

        public static Task<Image> FromFile(string path)
        {
            return Task.Run<Image>(() =>
            {
                var bytes = File.ReadAllBytes(path);
                var ms = new MemoryStream(bytes);
                var img = Image.FromStream(ms);
                return img;
            });
        }


        // MENU

        private void pathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPythonPath fpp = new FormPythonPath();
            fpp.ShowDialog();
        }

        private void setDefaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDefaultTelescope fdt = new FormDefaultTelescope();
            fdt.ShowDialog();
        }

        private void visibleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDefaultCamera fdc = new FormDefaultCamera("visible");
            fdc.ShowDialog();
        }

        private void halphaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDefaultCamera fdc = new FormDefaultCamera("halpha");
            fdc.ShowDialog();
        }

        private void slewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSlew fs = new FormSlew(this);
            fs.ShowDialog();
        }

    }
}
