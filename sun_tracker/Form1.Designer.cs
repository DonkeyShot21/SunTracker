namespace sun_tracker
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnChoose = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.labelLST = new System.Windows.Forms.Label();
            this.labelValLST = new System.Windows.Forms.Label();
            this.labelRA = new System.Windows.Forms.Label();
            this.labelValRA = new System.Windows.Forms.Label();
            this.timerCoord = new System.Windows.Forms.Timer(this.components);
            this.labelDec = new System.Windows.Forms.Label();
            this.labelValDec = new System.Windows.Forms.Label();
            this.labelValAlt = new System.Windows.Forms.Label();
            this.labelAlt = new System.Windows.Forms.Label();
            this.labelValAz = new System.Windows.Forms.Label();
            this.labelAz = new System.Windows.Forms.Label();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.tbAzRASlew = new System.Windows.Forms.TextBox();
            this.labelAltDecSlew = new System.Windows.Forms.Label();
            this.labelAzRASlew = new System.Windows.Forms.Label();
            this.tbAltDecSlew = new System.Windows.Forms.TextBox();
            this.btnSlew = new System.Windows.Forms.Button();
            this.btnEquatHorizon = new System.Windows.Forms.Button();
            this.btnPark = new System.Windows.Forms.Button();
            this.labelStatus = new System.Windows.Forms.Label();
            this.cbTrack = new System.Windows.Forms.CheckBox();
            this.labelValStatus = new System.Windows.Forms.Label();
            this.btnSlewSun = new System.Windows.Forms.Button();
            this.separator = new System.Windows.Forms.Label();
            this.btnChooseVisibleCamera = new System.Windows.Forms.Button();
            this.btnConnectVisibleCamera = new System.Windows.Forms.Button();
            this.tbChooseVisibleCamera = new System.Windows.Forms.TextBox();
            this.tbChoose = new System.Windows.Forms.TextBox();
            this.btnStartVisibleExposure = new System.Windows.Forms.Button();
            this.btnDownloadVisible = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnChooseHalphaCamera = new System.Windows.Forms.Button();
            this.tbChooseHalphaCamera = new System.Windows.Forms.TextBox();
            this.btnConnectHalphaCamera = new System.Windows.Forms.Button();
            this.btnDownloadHalpha = new System.Windows.Forms.Button();
            this.btnStartHalphaExposure = new System.Windows.Forms.Button();
            this.btnAbort = new System.Windows.Forms.Button();
            this.btnTrackHalpha = new System.Windows.Forms.Button();
            this.timerTracking = new System.Windows.Forms.Timer(this.components);
            this.buttonTrackVisible = new System.Windows.Forms.Button();
            this.btnStopTracking = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnChoose
            // 
            this.btnChoose.Location = new System.Drawing.Point(119, 10);
            this.btnChoose.Name = "btnChoose";
            this.btnChoose.Size = new System.Drawing.Size(75, 23);
            this.btnChoose.TabIndex = 1;
            this.btnChoose.Text = "Choose...";
            this.btnChoose.UseVisualStyleBackColor = true;
            this.btnChoose.Click += new System.EventHandler(this.btnChoose_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(200, 10);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 2;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // labelLST
            // 
            this.labelLST.AutoSize = true;
            this.labelLST.Location = new System.Drawing.Point(10, 65);
            this.labelLST.Name = "labelLST";
            this.labelLST.Size = new System.Drawing.Size(30, 13);
            this.labelLST.TabIndex = 3;
            this.labelLST.Text = "LST:";
            this.labelLST.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelValLST
            // 
            this.labelValLST.AutoSize = true;
            this.labelValLST.Location = new System.Drawing.Point(47, 65);
            this.labelValLST.Name = "labelValLST";
            this.labelValLST.Size = new System.Drawing.Size(10, 13);
            this.labelValLST.TabIndex = 4;
            this.labelValLST.Text = "-";
            // 
            // labelRA
            // 
            this.labelRA.AutoSize = true;
            this.labelRA.Location = new System.Drawing.Point(15, 82);
            this.labelRA.Name = "labelRA";
            this.labelRA.Size = new System.Drawing.Size(25, 13);
            this.labelRA.TabIndex = 5;
            this.labelRA.Text = "RA:";
            this.labelRA.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelValRA
            // 
            this.labelValRA.AutoSize = true;
            this.labelValRA.Location = new System.Drawing.Point(47, 82);
            this.labelValRA.Name = "labelValRA";
            this.labelValRA.Size = new System.Drawing.Size(10, 13);
            this.labelValRA.TabIndex = 6;
            this.labelValRA.Text = "-";
            // 
            // timerCoord
            // 
            this.timerCoord.Tick += new System.EventHandler(this.timerCoord_Tick);
            // 
            // labelDec
            // 
            this.labelDec.AutoSize = true;
            this.labelDec.Location = new System.Drawing.Point(12, 99);
            this.labelDec.Name = "labelDec";
            this.labelDec.Size = new System.Drawing.Size(30, 13);
            this.labelDec.TabIndex = 7;
            this.labelDec.Text = "Dec:";
            this.labelDec.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelValDec
            // 
            this.labelValDec.AutoSize = true;
            this.labelValDec.Location = new System.Drawing.Point(47, 99);
            this.labelValDec.Name = "labelValDec";
            this.labelValDec.Size = new System.Drawing.Size(10, 13);
            this.labelValDec.TabIndex = 8;
            this.labelValDec.Text = "-";
            // 
            // labelValAlt
            // 
            this.labelValAlt.AutoSize = true;
            this.labelValAlt.Location = new System.Drawing.Point(47, 133);
            this.labelValAlt.Name = "labelValAlt";
            this.labelValAlt.Size = new System.Drawing.Size(10, 13);
            this.labelValAlt.TabIndex = 12;
            this.labelValAlt.Text = "-";
            // 
            // labelAlt
            // 
            this.labelAlt.AutoSize = true;
            this.labelAlt.Location = new System.Drawing.Point(18, 135);
            this.labelAlt.Name = "labelAlt";
            this.labelAlt.Size = new System.Drawing.Size(22, 13);
            this.labelAlt.TabIndex = 11;
            this.labelAlt.Text = "Alt:";
            this.labelAlt.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelValAz
            // 
            this.labelValAz.AutoSize = true;
            this.labelValAz.Location = new System.Drawing.Point(47, 116);
            this.labelValAz.Name = "labelValAz";
            this.labelValAz.Size = new System.Drawing.Size(10, 13);
            this.labelValAz.TabIndex = 10;
            this.labelValAz.Text = "-";
            // 
            // labelAz
            // 
            this.labelAz.AutoSize = true;
            this.labelAz.Location = new System.Drawing.Point(18, 116);
            this.labelAz.Name = "labelAz";
            this.labelAz.Size = new System.Drawing.Size(22, 13);
            this.labelAz.TabIndex = 9;
            this.labelAz.Text = "Az:";
            this.labelAz.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnUp
            // 
            this.btnUp.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnUp.BackgroundImage")));
            this.btnUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnUp.Location = new System.Drawing.Point(182, 56);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(30, 30);
            this.btnUp.TabIndex = 13;
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnRight
            // 
            this.btnRight.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRight.BackgroundImage")));
            this.btnRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRight.Location = new System.Drawing.Point(217, 91);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(30, 30);
            this.btnRight.TabIndex = 14;
            this.btnRight.UseVisualStyleBackColor = true;
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // btnDown
            // 
            this.btnDown.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDown.BackgroundImage")));
            this.btnDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDown.Location = new System.Drawing.Point(182, 126);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(30, 30);
            this.btnDown.TabIndex = 15;
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnLeft
            // 
            this.btnLeft.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLeft.BackgroundImage")));
            this.btnLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLeft.Location = new System.Drawing.Point(147, 91);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(30, 30);
            this.btnLeft.TabIndex = 16;
            this.btnLeft.UseVisualStyleBackColor = true;
            this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
            // 
            // tbAzRASlew
            // 
            this.tbAzRASlew.Location = new System.Drawing.Point(50, 207);
            this.tbAzRASlew.Name = "tbAzRASlew";
            this.tbAzRASlew.Size = new System.Drawing.Size(63, 20);
            this.tbAzRASlew.TabIndex = 17;
            // 
            // labelAltDecSlew
            // 
            this.labelAltDecSlew.AutoSize = true;
            this.labelAltDecSlew.Location = new System.Drawing.Point(22, 238);
            this.labelAltDecSlew.Name = "labelAltDecSlew";
            this.labelAltDecSlew.Size = new System.Drawing.Size(22, 13);
            this.labelAltDecSlew.TabIndex = 19;
            this.labelAltDecSlew.Text = "Alt:";
            this.labelAltDecSlew.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelAzRASlew
            // 
            this.labelAzRASlew.AutoSize = true;
            this.labelAzRASlew.Location = new System.Drawing.Point(22, 210);
            this.labelAzRASlew.Name = "labelAzRASlew";
            this.labelAzRASlew.Size = new System.Drawing.Size(22, 13);
            this.labelAzRASlew.TabIndex = 18;
            this.labelAzRASlew.Text = "Az:";
            this.labelAzRASlew.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tbAltDecSlew
            // 
            this.tbAltDecSlew.Location = new System.Drawing.Point(50, 235);
            this.tbAltDecSlew.Name = "tbAltDecSlew";
            this.tbAltDecSlew.Size = new System.Drawing.Size(63, 20);
            this.tbAltDecSlew.TabIndex = 20;
            // 
            // btnSlew
            // 
            this.btnSlew.Location = new System.Drawing.Point(119, 233);
            this.btnSlew.Name = "btnSlew";
            this.btnSlew.Size = new System.Drawing.Size(75, 23);
            this.btnSlew.TabIndex = 21;
            this.btnSlew.Text = "Slew";
            this.btnSlew.UseVisualStyleBackColor = true;
            this.btnSlew.Click += new System.EventHandler(this.btnSlew_Click);
            // 
            // btnEquatHorizon
            // 
            this.btnEquatHorizon.Location = new System.Drawing.Point(119, 205);
            this.btnEquatHorizon.Name = "btnEquatHorizon";
            this.btnEquatHorizon.Size = new System.Drawing.Size(75, 23);
            this.btnEquatHorizon.TabIndex = 22;
            this.btnEquatHorizon.Text = "Hor / Eq";
            this.btnEquatHorizon.UseVisualStyleBackColor = true;
            this.btnEquatHorizon.Click += new System.EventHandler(this.btnEquatHorizon_Click);
            // 
            // btnPark
            // 
            this.btnPark.Location = new System.Drawing.Point(200, 234);
            this.btnPark.Name = "btnPark";
            this.btnPark.Size = new System.Drawing.Size(75, 23);
            this.btnPark.TabIndex = 23;
            this.btnPark.Text = "Unpark";
            this.btnPark.UseVisualStyleBackColor = true;
            this.btnPark.Click += new System.EventHandler(this.btnPark_Click);
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(141, 176);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(40, 13);
            this.labelStatus.TabIndex = 25;
            this.labelStatus.Text = "Status:";
            this.labelStatus.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cbTrack
            // 
            this.cbTrack.AutoSize = true;
            this.cbTrack.Location = new System.Drawing.Point(211, 211);
            this.cbTrack.Name = "cbTrack";
            this.cbTrack.Size = new System.Drawing.Size(54, 17);
            this.cbTrack.TabIndex = 26;
            this.cbTrack.Text = "Track";
            this.cbTrack.UseVisualStyleBackColor = true;
            this.cbTrack.CheckedChanged += new System.EventHandler(this.cbTrack_CheckedChanged);
            // 
            // labelValStatus
            // 
            this.labelValStatus.AutoSize = true;
            this.labelValStatus.Location = new System.Drawing.Point(179, 176);
            this.labelValStatus.Name = "labelValStatus";
            this.labelValStatus.Size = new System.Drawing.Size(73, 13);
            this.labelValStatus.TabIndex = 27;
            this.labelValStatus.Text = "Disconnected";
            // 
            // btnSlewSun
            // 
            this.btnSlewSun.Location = new System.Drawing.Point(12, 263);
            this.btnSlewSun.Name = "btnSlewSun";
            this.btnSlewSun.Size = new System.Drawing.Size(75, 23);
            this.btnSlewSun.TabIndex = 28;
            this.btnSlewSun.Text = "Slew to Sun";
            this.btnSlewSun.UseVisualStyleBackColor = true;
            this.btnSlewSun.Click += new System.EventHandler(this.btnSlewSun_Click);
            // 
            // separator
            // 
            this.separator.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.separator.Location = new System.Drawing.Point(281, 10);
            this.separator.Name = "separator";
            this.separator.Size = new System.Drawing.Size(2, 323);
            this.separator.TabIndex = 29;
            // 
            // btnChooseVisibleCamera
            // 
            this.btnChooseVisibleCamera.Location = new System.Drawing.Point(395, 29);
            this.btnChooseVisibleCamera.Name = "btnChooseVisibleCamera";
            this.btnChooseVisibleCamera.Size = new System.Drawing.Size(75, 23);
            this.btnChooseVisibleCamera.TabIndex = 30;
            this.btnChooseVisibleCamera.Text = "Choose...";
            this.btnChooseVisibleCamera.UseVisualStyleBackColor = true;
            this.btnChooseVisibleCamera.Click += new System.EventHandler(this.btnChooseVisibleCamera_Click);
            // 
            // btnConnectVisibleCamera
            // 
            this.btnConnectVisibleCamera.Location = new System.Drawing.Point(476, 29);
            this.btnConnectVisibleCamera.Name = "btnConnectVisibleCamera";
            this.btnConnectVisibleCamera.Size = new System.Drawing.Size(75, 23);
            this.btnConnectVisibleCamera.TabIndex = 32;
            this.btnConnectVisibleCamera.Text = "Connect";
            this.btnConnectVisibleCamera.UseVisualStyleBackColor = true;
            this.btnConnectVisibleCamera.Click += new System.EventHandler(this.btnConnectVisibleCamera_Click);
            // 
            // tbChooseVisibleCamera
            // 
            this.tbChooseVisibleCamera.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::sun_tracker.Properties.Settings.Default, "Camera", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbChooseVisibleCamera.Location = new System.Drawing.Point(289, 32);
            this.tbChooseVisibleCamera.Name = "tbChooseVisibleCamera";
            this.tbChooseVisibleCamera.ReadOnly = true;
            this.tbChooseVisibleCamera.Size = new System.Drawing.Size(100, 20);
            this.tbChooseVisibleCamera.TabIndex = 31;
            this.tbChooseVisibleCamera.Text = global::sun_tracker.Properties.Settings.Default.Camera;
            // 
            // tbChoose
            // 
            this.tbChoose.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::sun_tracker.Properties.Settings.Default, "Telescope", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbChoose.Location = new System.Drawing.Point(13, 13);
            this.tbChoose.Name = "tbChoose";
            this.tbChoose.ReadOnly = true;
            this.tbChoose.Size = new System.Drawing.Size(100, 20);
            this.tbChoose.TabIndex = 0;
            this.tbChoose.Text = global::sun_tracker.Properties.Settings.Default.Telescope;
            // 
            // btnStartVisibleExposure
            // 
            this.btnStartVisibleExposure.Location = new System.Drawing.Point(395, 58);
            this.btnStartVisibleExposure.Name = "btnStartVisibleExposure";
            this.btnStartVisibleExposure.Size = new System.Drawing.Size(75, 23);
            this.btnStartVisibleExposure.TabIndex = 33;
            this.btnStartVisibleExposure.Text = "Start Exposure";
            this.btnStartVisibleExposure.UseVisualStyleBackColor = true;
            this.btnStartVisibleExposure.Click += new System.EventHandler(this.btnStartVisibleExposure_Click);
            // 
            // btnDownloadVisible
            // 
            this.btnDownloadVisible.Location = new System.Drawing.Point(476, 58);
            this.btnDownloadVisible.Name = "btnDownloadVisible";
            this.btnDownloadVisible.Size = new System.Drawing.Size(75, 23);
            this.btnDownloadVisible.TabIndex = 34;
            this.btnDownloadVisible.Text = "Download";
            this.btnDownloadVisible.UseVisualStyleBackColor = true;
            this.btnDownloadVisible.Click += new System.EventHandler(this.btnDownloadVisible_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(289, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 35;
            this.label1.Text = "Visible:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(289, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 36;
            this.label2.Text = "H-alpha:";
            // 
            // btnChooseHalphaCamera
            // 
            this.btnChooseHalphaCamera.Location = new System.Drawing.Point(395, 106);
            this.btnChooseHalphaCamera.Name = "btnChooseHalphaCamera";
            this.btnChooseHalphaCamera.Size = new System.Drawing.Size(75, 23);
            this.btnChooseHalphaCamera.TabIndex = 37;
            this.btnChooseHalphaCamera.Text = "Choose...";
            this.btnChooseHalphaCamera.UseVisualStyleBackColor = true;
            this.btnChooseHalphaCamera.Click += new System.EventHandler(this.btnChooseHalphaCamera_Click);
            // 
            // tbChooseHalphaCamera
            // 
            this.tbChooseHalphaCamera.Location = new System.Drawing.Point(289, 109);
            this.tbChooseHalphaCamera.Name = "tbChooseHalphaCamera";
            this.tbChooseHalphaCamera.Size = new System.Drawing.Size(100, 20);
            this.tbChooseHalphaCamera.TabIndex = 38;
            this.tbChooseHalphaCamera.Text = "Choose Camera...";
            // 
            // btnConnectHalphaCamera
            // 
            this.btnConnectHalphaCamera.Location = new System.Drawing.Point(476, 106);
            this.btnConnectHalphaCamera.Name = "btnConnectHalphaCamera";
            this.btnConnectHalphaCamera.Size = new System.Drawing.Size(75, 23);
            this.btnConnectHalphaCamera.TabIndex = 39;
            this.btnConnectHalphaCamera.Text = "Connect";
            this.btnConnectHalphaCamera.UseVisualStyleBackColor = true;
            this.btnConnectHalphaCamera.Click += new System.EventHandler(this.btnConnectHalphaCamera_Click);
            // 
            // btnDownloadHalpha
            // 
            this.btnDownloadHalpha.Location = new System.Drawing.Point(476, 136);
            this.btnDownloadHalpha.Name = "btnDownloadHalpha";
            this.btnDownloadHalpha.Size = new System.Drawing.Size(75, 23);
            this.btnDownloadHalpha.TabIndex = 40;
            this.btnDownloadHalpha.Text = "Download";
            this.btnDownloadHalpha.UseVisualStyleBackColor = true;
            this.btnDownloadHalpha.Click += new System.EventHandler(this.btnDownloadHalpha_Click);
            // 
            // btnStartHalphaExposure
            // 
            this.btnStartHalphaExposure.Location = new System.Drawing.Point(395, 136);
            this.btnStartHalphaExposure.Name = "btnStartHalphaExposure";
            this.btnStartHalphaExposure.Size = new System.Drawing.Size(75, 23);
            this.btnStartHalphaExposure.TabIndex = 41;
            this.btnStartHalphaExposure.Text = "Start";
            this.btnStartHalphaExposure.UseVisualStyleBackColor = true;
            this.btnStartHalphaExposure.Click += new System.EventHandler(this.btnStartHalphaExposure_Click);
            // 
            // btnAbort
            // 
            this.btnAbort.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAbort.BackgroundImage")));
            this.btnAbort.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAbort.Location = new System.Drawing.Point(182, 91);
            this.btnAbort.Name = "btnAbort";
            this.btnAbort.Size = new System.Drawing.Size(30, 30);
            this.btnAbort.TabIndex = 42;
            this.btnAbort.UseVisualStyleBackColor = true;
            this.btnAbort.Click += new System.EventHandler(this.btnAbort_Click);
            // 
            // btnTrackHalpha
            // 
            this.btnTrackHalpha.Location = new System.Drawing.Point(93, 263);
            this.btnTrackHalpha.Name = "btnTrackHalpha";
            this.btnTrackHalpha.Size = new System.Drawing.Size(84, 23);
            this.btnTrackHalpha.TabIndex = 43;
            this.btnTrackHalpha.Text = "Track Halpha";
            this.btnTrackHalpha.UseVisualStyleBackColor = true;
            this.btnTrackHalpha.Click += new System.EventHandler(this.btnTrackHalpha_Click);
            // 
            // timerTracking
            // 
            this.timerTracking.Interval = 30000;
            this.timerTracking.Tick += new System.EventHandler(this.timerTracking_Tick);
            // 
            // buttonTrackVisible
            // 
            this.buttonTrackVisible.Location = new System.Drawing.Point(183, 263);
            this.buttonTrackVisible.Name = "buttonTrackVisible";
            this.buttonTrackVisible.Size = new System.Drawing.Size(92, 23);
            this.buttonTrackVisible.TabIndex = 44;
            this.buttonTrackVisible.Text = "Track Visible";
            this.buttonTrackVisible.UseVisualStyleBackColor = true;
            this.buttonTrackVisible.Click += new System.EventHandler(this.buttonTrackVisible_Click);
            // 
            // btnStopTracking
            // 
            this.btnStopTracking.Location = new System.Drawing.Point(12, 292);
            this.btnStopTracking.Name = "btnStopTracking";
            this.btnStopTracking.Size = new System.Drawing.Size(86, 23);
            this.btnStopTracking.TabIndex = 45;
            this.btnStopTracking.Text = "Stop Tracking";
            this.btnStopTracking.UseVisualStyleBackColor = true;
            this.btnStopTracking.Click += new System.EventHandler(this.btnStopTracking_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(561, 340);
            this.Controls.Add(this.btnStopTracking);
            this.Controls.Add(this.buttonTrackVisible);
            this.Controls.Add(this.btnTrackHalpha);
            this.Controls.Add(this.btnAbort);
            this.Controls.Add(this.btnStartHalphaExposure);
            this.Controls.Add(this.btnDownloadHalpha);
            this.Controls.Add(this.btnConnectHalphaCamera);
            this.Controls.Add(this.tbChooseHalphaCamera);
            this.Controls.Add(this.btnChooseHalphaCamera);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDownloadVisible);
            this.Controls.Add(this.btnStartVisibleExposure);
            this.Controls.Add(this.btnConnectVisibleCamera);
            this.Controls.Add(this.tbChooseVisibleCamera);
            this.Controls.Add(this.btnChooseVisibleCamera);
            this.Controls.Add(this.separator);
            this.Controls.Add(this.btnSlewSun);
            this.Controls.Add(this.labelValStatus);
            this.Controls.Add(this.cbTrack);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.btnPark);
            this.Controls.Add(this.btnEquatHorizon);
            this.Controls.Add(this.btnSlew);
            this.Controls.Add(this.tbAltDecSlew);
            this.Controls.Add(this.labelAltDecSlew);
            this.Controls.Add(this.labelAzRASlew);
            this.Controls.Add(this.tbAzRASlew);
            this.Controls.Add(this.btnLeft);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnRight);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.labelValAlt);
            this.Controls.Add(this.labelAlt);
            this.Controls.Add(this.labelValAz);
            this.Controls.Add(this.labelAz);
            this.Controls.Add(this.labelValDec);
            this.Controls.Add(this.labelDec);
            this.Controls.Add(this.labelValRA);
            this.Controls.Add(this.labelRA);
            this.Controls.Add(this.labelValLST);
            this.Controls.Add(this.labelLST);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.btnChoose);
            this.Controls.Add(this.tbChoose);
            this.Name = "Form1";
            this.Text = "Sun Tracker";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbChoose;
        private System.Windows.Forms.Button btnChoose;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label labelLST;
        private System.Windows.Forms.Label labelValLST;
        private System.Windows.Forms.Label labelRA;
        private System.Windows.Forms.Label labelValRA;
        private System.Windows.Forms.Timer timerCoord;
        private System.Windows.Forms.Label labelDec;
        private System.Windows.Forms.Label labelValDec;
        private System.Windows.Forms.Label labelValAlt;
        private System.Windows.Forms.Label labelAlt;
        private System.Windows.Forms.Label labelValAz;
        private System.Windows.Forms.Label labelAz;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.TextBox tbAzRASlew;
        private System.Windows.Forms.Label labelAltDecSlew;
        private System.Windows.Forms.Label labelAzRASlew;
        private System.Windows.Forms.TextBox tbAltDecSlew;
        private System.Windows.Forms.Button btnSlew;
        private System.Windows.Forms.Button btnEquatHorizon;
        private System.Windows.Forms.Button btnPark;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.CheckBox cbTrack;
        private System.Windows.Forms.Label labelValStatus;
        private System.Windows.Forms.Button btnSlewSun;
        private System.Windows.Forms.Label separator;
        private System.Windows.Forms.Button btnChooseVisibleCamera;
        private System.Windows.Forms.TextBox tbChooseVisibleCamera;
        private System.Windows.Forms.Button btnConnectVisibleCamera;
        private System.Windows.Forms.Button btnStartVisibleExposure;
        private System.Windows.Forms.Button btnDownloadVisible;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnChooseHalphaCamera;
        private System.Windows.Forms.TextBox tbChooseHalphaCamera;
        private System.Windows.Forms.Button btnConnectHalphaCamera;
        private System.Windows.Forms.Button btnDownloadHalpha;
        private System.Windows.Forms.Button btnStartHalphaExposure;
        private System.Windows.Forms.Button btnAbort;
        private System.Windows.Forms.Button btnTrackHalpha;
        private System.Windows.Forms.Timer timerTracking;
        private System.Windows.Forms.Button buttonTrackVisible;
        private System.Windows.Forms.Button btnStopTracking;
    }
}

