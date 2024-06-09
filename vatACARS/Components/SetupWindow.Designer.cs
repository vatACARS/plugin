namespace vatACARS
{
    partial class SetupWindow
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
            this.btn_connect = new vatsys.GenericButton();
            this.lbl_stationCodePrompt = new vatsys.TextLabel();
            this.lbl_enablehop = new vatsys.TextLabel();
            this.lbl_hoplogon = new vatsys.TextLabel();
            this.tbx_hoplogon = new vatsys.TextField();
            this.toggle_hop = new vatsys.GenericButton();
            this.slider_vol = new VATSYSControls.Slider();
            this.btn_test = new vatsys.GenericButton();
            this.lbl_vol = new vatsys.TextLabel();
            this.tbx_timeout = new vatsys.TextField();
            this.lbl_timeout = new vatsys.TextLabel();
            this.tbx_stationCode = new vatsys.TextField();
            this.lbl_stationCode = new vatsys.TextLabel();
            this.lbl_vatACARSToken = new vatsys.TextLabel();
            this.tbx_vatAcarsToken = new vatsys.TextField();
            this.btn_checkStationCode = new vatsys.GenericButton();
            ((System.ComponentModel.ISupportInitialize)(this.slider_vol)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_connect
            // 
            this.btn_connect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_connect.Font = new System.Drawing.Font("Terminus (TTF)", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.btn_connect.Location = new System.Drawing.Point(314, 273);
            this.btn_connect.Name = "btn_connect";
            this.btn_connect.Size = new System.Drawing.Size(101, 28);
            this.btn_connect.SubFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_connect.SubText = "";
            this.btn_connect.TabIndex = 1;
            this.btn_connect.Text = "Connect";
            this.btn_connect.UseVisualStyleBackColor = true;
            this.btn_connect.Click += new System.EventHandler(this.btn_connect_Click);
            // 
            // lbl_stationCodePrompt
            // 
            this.lbl_stationCodePrompt.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbl_stationCodePrompt.Font = new System.Drawing.Font("Terminus (TTF)", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lbl_stationCodePrompt.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_stationCodePrompt.HasBorder = false;
            this.lbl_stationCodePrompt.InteractiveText = true;
            this.lbl_stationCodePrompt.Location = new System.Drawing.Point(12, 9);
            this.lbl_stationCodePrompt.Name = "lbl_stationCodePrompt";
            this.lbl_stationCodePrompt.Size = new System.Drawing.Size(403, 26);
            this.lbl_stationCodePrompt.TabIndex = 10;
            this.lbl_stationCodePrompt.Text = "ADD \"CPDLC ICAO\" TO YOUR CONTROLLER INFO";
            this.lbl_stationCodePrompt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_enablehop
            // 
            this.lbl_enablehop.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbl_enablehop.Font = new System.Drawing.Font("Terminus (TTF)", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lbl_enablehop.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_enablehop.HasBorder = false;
            this.lbl_enablehop.InteractiveText = true;
            this.lbl_enablehop.Location = new System.Drawing.Point(12, 108);
            this.lbl_enablehop.Name = "lbl_enablehop";
            this.lbl_enablehop.Size = new System.Drawing.Size(159, 26);
            this.lbl_enablehop.TabIndex = 12;
            this.lbl_enablehop.Text = "ENABLE HOPPIES";
            this.lbl_enablehop.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_hoplogon
            // 
            this.lbl_hoplogon.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbl_hoplogon.Font = new System.Drawing.Font("Terminus (TTF)", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lbl_hoplogon.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_hoplogon.HasBorder = false;
            this.lbl_hoplogon.InteractiveText = true;
            this.lbl_hoplogon.Location = new System.Drawing.Point(12, 141);
            this.lbl_hoplogon.Name = "lbl_hoplogon";
            this.lbl_hoplogon.Size = new System.Drawing.Size(159, 26);
            this.lbl_hoplogon.TabIndex = 13;
            this.lbl_hoplogon.Text = "HOPPIES LOGON CODE";
            this.lbl_hoplogon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbx_hoplogon
            // 
            this.tbx_hoplogon.BackColor = System.Drawing.SystemColors.ControlDark;
            this.tbx_hoplogon.Font = new System.Drawing.Font("Terminus (TTF)", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.tbx_hoplogon.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.tbx_hoplogon.Location = new System.Drawing.Point(177, 143);
            this.tbx_hoplogon.Name = "tbx_hoplogon";
            this.tbx_hoplogon.NumericCharOnly = false;
            this.tbx_hoplogon.OctalOnly = false;
            this.tbx_hoplogon.PasswordChar = '*';
            this.tbx_hoplogon.Size = new System.Drawing.Size(238, 25);
            this.tbx_hoplogon.TabIndex = 17;
            this.tbx_hoplogon.TextChanged += new System.EventHandler(this.tbx_hoplogon_TextChanged);
            // 
            // toggle_hop
            // 
            this.toggle_hop.Font = new System.Drawing.Font("Terminus (TTF)", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.toggle_hop.Location = new System.Drawing.Point(177, 108);
            this.toggle_hop.Name = "toggle_hop";
            this.toggle_hop.Size = new System.Drawing.Size(26, 26);
            this.toggle_hop.SubFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toggle_hop.SubText = "";
            this.toggle_hop.TabIndex = 19;
            this.toggle_hop.UseVisualStyleBackColor = true;
            this.toggle_hop.MouseUp += new System.Windows.Forms.MouseEventHandler(this.toggle_hop_MouseUp);
            // 
            // slider_vol
            // 
            this.slider_vol.CustomPaintText = false;
            this.slider_vol.FontColor = System.Drawing.SystemColors.ControlDark;
            this.slider_vol.LargeChange = 1;
            this.slider_vol.Location = new System.Drawing.Point(177, 174);
            this.slider_vol.Name = "slider_vol";
            this.slider_vol.Size = new System.Drawing.Size(206, 45);
            this.slider_vol.TabIndex = 21;
            this.slider_vol.Text = "label1";
            this.slider_vol.Scroll += new System.EventHandler(this.slider_vol_Scroll);
            // 
            // btn_test
            // 
            this.btn_test.Font = new System.Drawing.Font("Terminus (TTF)", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.btn_test.Location = new System.Drawing.Point(389, 181);
            this.btn_test.Name = "btn_test";
            this.btn_test.Size = new System.Drawing.Size(26, 26);
            this.btn_test.SubFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_test.SubText = "";
            this.btn_test.TabIndex = 22;
            this.btn_test.UseVisualStyleBackColor = true;
            this.btn_test.Click += new System.EventHandler(this.btn_test_Click);
            this.btn_test.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_test_MouseUp);
            // 
            // lbl_vol
            // 
            this.lbl_vol.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbl_vol.Font = new System.Drawing.Font("Terminus (TTF)", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lbl_vol.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_vol.HasBorder = false;
            this.lbl_vol.InteractiveText = true;
            this.lbl_vol.Location = new System.Drawing.Point(12, 174);
            this.lbl_vol.Name = "lbl_vol";
            this.lbl_vol.Size = new System.Drawing.Size(159, 45);
            this.lbl_vol.TabIndex = 23;
            this.lbl_vol.Text = "NOTIFICATION VOLUME";
            this.lbl_vol.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbx_timeout
            // 
            this.tbx_timeout.BackColor = System.Drawing.SystemColors.ControlDark;
            this.tbx_timeout.Font = new System.Drawing.Font("Terminus (TTF)", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.tbx_timeout.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.tbx_timeout.Location = new System.Drawing.Point(177, 234);
            this.tbx_timeout.Name = "tbx_timeout";
            this.tbx_timeout.NumericCharOnly = false;
            this.tbx_timeout.OctalOnly = false;
            this.tbx_timeout.Size = new System.Drawing.Size(85, 25);
            this.tbx_timeout.TabIndex = 25;
            this.tbx_timeout.TextChanged += new System.EventHandler(this.tbx_timeout_TextChanged);
            // 
            // lbl_timeout
            // 
            this.lbl_timeout.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbl_timeout.Font = new System.Drawing.Font("Terminus (TTF)", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lbl_timeout.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_timeout.HasBorder = false;
            this.lbl_timeout.InteractiveText = true;
            this.lbl_timeout.Location = new System.Drawing.Point(12, 226);
            this.lbl_timeout.Name = "lbl_timeout";
            this.lbl_timeout.Size = new System.Drawing.Size(159, 45);
            this.lbl_timeout.TabIndex = 26;
            this.lbl_timeout.Text = "FINISHED MESSAGE TIMEOUT";
            this.lbl_timeout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbx_stationCode
            // 
            this.tbx_stationCode.BackColor = System.Drawing.SystemColors.ControlDark;
            this.tbx_stationCode.Enabled = false;
            this.tbx_stationCode.Font = new System.Drawing.Font("Terminus (TTF)", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.tbx_stationCode.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.tbx_stationCode.Location = new System.Drawing.Point(177, 42);
            this.tbx_stationCode.Name = "tbx_stationCode";
            this.tbx_stationCode.NumericCharOnly = false;
            this.tbx_stationCode.OctalOnly = false;
            this.tbx_stationCode.Size = new System.Drawing.Size(154, 25);
            this.tbx_stationCode.TabIndex = 15;
            this.tbx_stationCode.Text = "Add your code to controller remarks";
            // 
            // lbl_stationCode
            // 
            this.lbl_stationCode.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbl_stationCode.Font = new System.Drawing.Font("Terminus (TTF)", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lbl_stationCode.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_stationCode.HasBorder = false;
            this.lbl_stationCode.InteractiveText = true;
            this.lbl_stationCode.Location = new System.Drawing.Point(12, 42);
            this.lbl_stationCode.Name = "lbl_stationCode";
            this.lbl_stationCode.Size = new System.Drawing.Size(159, 26);
            this.lbl_stationCode.TabIndex = 27;
            this.lbl_stationCode.Text = "STATION CODE";
            this.lbl_stationCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_vatACARSToken
            // 
            this.lbl_vatACARSToken.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbl_vatACARSToken.Font = new System.Drawing.Font("Terminus (TTF)", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lbl_vatACARSToken.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_vatACARSToken.HasBorder = false;
            this.lbl_vatACARSToken.InteractiveText = true;
            this.lbl_vatACARSToken.Location = new System.Drawing.Point(12, 75);
            this.lbl_vatACARSToken.Name = "lbl_vatACARSToken";
            this.lbl_vatACARSToken.Size = new System.Drawing.Size(159, 26);
            this.lbl_vatACARSToken.TabIndex = 28;
            this.lbl_vatACARSToken.Text = "VATACARS TOKEN";
            this.lbl_vatACARSToken.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbx_vatAcarsToken
            // 
            this.tbx_vatAcarsToken.BackColor = System.Drawing.SystemColors.ControlDark;
            this.tbx_vatAcarsToken.Font = new System.Drawing.Font("Terminus (TTF)", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.tbx_vatAcarsToken.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.tbx_vatAcarsToken.Location = new System.Drawing.Point(177, 75);
            this.tbx_vatAcarsToken.Name = "tbx_vatAcarsToken";
            this.tbx_vatAcarsToken.NumericCharOnly = false;
            this.tbx_vatAcarsToken.OctalOnly = false;
            this.tbx_vatAcarsToken.PasswordChar = '*';
            this.tbx_vatAcarsToken.Size = new System.Drawing.Size(238, 25);
            this.tbx_vatAcarsToken.TabIndex = 29;
            // 
            // btn_checkStationCode
            // 
            this.btn_checkStationCode.Font = new System.Drawing.Font("Terminus (TTF)", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.btn_checkStationCode.Location = new System.Drawing.Point(337, 42);
            this.btn_checkStationCode.Name = "btn_checkStationCode";
            this.btn_checkStationCode.Size = new System.Drawing.Size(78, 26);
            this.btn_checkStationCode.SubFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_checkStationCode.SubText = "";
            this.btn_checkStationCode.TabIndex = 30;
            this.btn_checkStationCode.Text = "CHECK";
            this.btn_checkStationCode.UseVisualStyleBackColor = true;
            this.btn_checkStationCode.Click += new System.EventHandler(this.btn_checkStationCode_Click);
            // 
            // SetupWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 313);
            this.Controls.Add(this.btn_checkStationCode);
            this.Controls.Add(this.tbx_vatAcarsToken);
            this.Controls.Add(this.lbl_vatACARSToken);
            this.Controls.Add(this.lbl_stationCode);
            this.Controls.Add(this.lbl_timeout);
            this.Controls.Add(this.tbx_timeout);
            this.Controls.Add(this.lbl_vol);
            this.Controls.Add(this.btn_test);
            this.Controls.Add(this.slider_vol);
            this.Controls.Add(this.toggle_hop);
            this.Controls.Add(this.tbx_hoplogon);
            this.Controls.Add(this.tbx_stationCode);
            this.Controls.Add(this.lbl_hoplogon);
            this.Controls.Add(this.lbl_enablehop);
            this.Controls.Add(this.lbl_stationCodePrompt);
            this.Controls.Add(this.btn_connect);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HasMinimizeButton = false;
            this.HasSendBackButton = false;
            this.MiddleClickClose = false;
            this.MinimizeBox = false;
            this.Name = "SetupWindow";
            this.Resizeable = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "vatACARS Setup";
            this.Load += new System.EventHandler(this.SetupWindow_Load);
            this.Shown += new System.EventHandler(this.SetupWindow_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.slider_vol)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private vatsys.GenericButton btn_connect;
        private vatsys.TextLabel lbl_stationCodePrompt;
        private vatsys.TextLabel lbl_enablehop;
        private vatsys.TextLabel lbl_hoplogon;
        private vatsys.TextField tbx_hoplogon;
        private vatsys.GenericButton toggle_hop;
        private vatsys.GenericButton btn_test;
        public VATSYSControls.Slider slider_vol;
        private vatsys.TextLabel lbl_vol;
        private vatsys.TextField tbx_timeout;
        private vatsys.TextLabel lbl_timeout;
        private vatsys.TextField tbx_stationCode;
        private vatsys.TextLabel lbl_stationCode;
        private vatsys.TextLabel lbl_vatACARSToken;
        private vatsys.TextField tbx_vatAcarsToken;
        private vatsys.GenericButton btn_checkStationCode;
    }
}