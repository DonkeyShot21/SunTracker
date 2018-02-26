namespace sun_tracker
{
    partial class FormSlew
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
            this.btnEquatHorizon = new System.Windows.Forms.Button();
            this.btnSlew = new System.Windows.Forms.Button();
            this.tbAltDecSlew = new System.Windows.Forms.TextBox();
            this.labelAltDecSlew = new System.Windows.Forms.Label();
            this.labelAzRASlew = new System.Windows.Forms.Label();
            this.tbAzRASlew = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnEquatHorizon
            // 
            this.btnEquatHorizon.Location = new System.Drawing.Point(107, 12);
            this.btnEquatHorizon.Name = "btnEquatHorizon";
            this.btnEquatHorizon.Size = new System.Drawing.Size(75, 23);
            this.btnEquatHorizon.TabIndex = 28;
            this.btnEquatHorizon.Text = "Hor / Eq";
            this.btnEquatHorizon.UseVisualStyleBackColor = true;
            this.btnEquatHorizon.Click += new System.EventHandler(this.btnEquatHorizon_Click);
            // 
            // btnSlew
            // 
            this.btnSlew.Location = new System.Drawing.Point(107, 40);
            this.btnSlew.Name = "btnSlew";
            this.btnSlew.Size = new System.Drawing.Size(75, 23);
            this.btnSlew.TabIndex = 27;
            this.btnSlew.Text = "Slew";
            this.btnSlew.UseVisualStyleBackColor = true;
            this.btnSlew.Click += new System.EventHandler(this.btnSlew_Click);
            // 
            // tbAltDecSlew
            // 
            this.tbAltDecSlew.Location = new System.Drawing.Point(38, 42);
            this.tbAltDecSlew.Name = "tbAltDecSlew";
            this.tbAltDecSlew.Size = new System.Drawing.Size(63, 20);
            this.tbAltDecSlew.TabIndex = 26;
            // 
            // labelAltDecSlew
            // 
            this.labelAltDecSlew.AutoSize = true;
            this.labelAltDecSlew.Location = new System.Drawing.Point(10, 45);
            this.labelAltDecSlew.Name = "labelAltDecSlew";
            this.labelAltDecSlew.Size = new System.Drawing.Size(22, 13);
            this.labelAltDecSlew.TabIndex = 25;
            this.labelAltDecSlew.Text = "Alt:";
            this.labelAltDecSlew.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelAzRASlew
            // 
            this.labelAzRASlew.AutoSize = true;
            this.labelAzRASlew.Location = new System.Drawing.Point(10, 17);
            this.labelAzRASlew.Name = "labelAzRASlew";
            this.labelAzRASlew.Size = new System.Drawing.Size(22, 13);
            this.labelAzRASlew.TabIndex = 24;
            this.labelAzRASlew.Text = "Az:";
            this.labelAzRASlew.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tbAzRASlew
            // 
            this.tbAzRASlew.Location = new System.Drawing.Point(38, 14);
            this.tbAzRASlew.Name = "tbAzRASlew";
            this.tbAzRASlew.Size = new System.Drawing.Size(63, 20);
            this.tbAzRASlew.TabIndex = 23;
            // 
            // FormSlew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(194, 74);
            this.Controls.Add(this.btnEquatHorizon);
            this.Controls.Add(this.btnSlew);
            this.Controls.Add(this.tbAltDecSlew);
            this.Controls.Add(this.labelAltDecSlew);
            this.Controls.Add(this.labelAzRASlew);
            this.Controls.Add(this.tbAzRASlew);
            this.Name = "FormSlew";
            this.Text = "FormSlew";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEquatHorizon;
        private System.Windows.Forms.Button btnSlew;
        private System.Windows.Forms.TextBox tbAltDecSlew;
        private System.Windows.Forms.Label labelAltDecSlew;
        private System.Windows.Forms.Label labelAzRASlew;
        private System.Windows.Forms.TextBox tbAzRASlew;
    }
}