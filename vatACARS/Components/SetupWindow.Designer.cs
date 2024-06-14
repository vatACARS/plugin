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
            this.lbl_enableHoppies = new vatsys.TextLabel();
            this.lbl_hoppiesLogonCode = new vatsys.TextLabel();
            this.tbx_hoppiesLogonCode = new vatsys.TextField();
            this.btn_enableHoppies = new vatsys.GenericButton();
            this.sld_auralAlertVolume = new VATSYSControls.Slider();
            this.btn_auralAlertVolumeTest = new vatsys.GenericButton();
            this.lbl_auralAlertVolume = new vatsys.TextLabel();
            this.tbx_messageTimeout = new vatsys.TextField();
            this.lbl_messageTimeout = new vatsys.TextLabel();
            this.tbx_stationCode = new vatsys.TextField();
            this.lbl_stationCode = new vatsys.TextLabel();
            this.lbl_vatACARSToken = new vatsys.TextLabel();
            this.tbx_vatACARSToken = new vatsys.TextField();
            this.btn_checkStationCode = new vatsys.GenericButton();
            this.lbl_statusMessage = new vatsys.TextLabel();
            ((System.ComponentModel.ISupportInitialize)(this.sld_auralAlertVolume)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_connect
            // 
            this.btn_connect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_connect.Font = new System.Drawing.Font("Terminus (TTF)", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.btn_connect.Location = new System.Drawing.Point(314, 314);
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
            this.lbl_stationCodePrompt.Text = "ADD \"CPDLC ICAO\" OR \"PDC ICAO\" TO CONTROLLER INFO";
            this.lbl_stationCodePrompt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_enableHoppies
            // 
            this.lbl_enableHoppies.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbl_enableHoppies.Font = new System.Drawing.Font("Terminus (TTF)", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lbl_enableHoppies.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_enableHoppies.HasBorder = false;
            this.lbl_enableHoppies.InteractiveText = true;
            this.lbl_enableHoppies.Location = new System.Drawing.Point(12, 108);
            this.lbl_enableHoppies.Name = "lbl_enableHoppies";
            this.lbl_enableHoppies.Size = new System.Drawing.Size(159, 26);
            this.lbl_enableHoppies.TabIndex = 12;
            this.lbl_enableHoppies.Text = "ENABLE HOPPIES";
            this.lbl_enableHoppies.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_hoppiesLogonCode
            // 
            this.lbl_hoppiesLogonCode.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbl_hoppiesLogonCode.Font = new System.Drawing.Font("Terminus (TTF)", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lbl_hoppiesLogonCode.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_hoppiesLogonCode.HasBorder = false;
            this.lbl_hoppiesLogonCode.InteractiveText = true;
            this.lbl_hoppiesLogonCode.Location = new System.Drawing.Point(12, 141);
            this.lbl_hoppiesLogonCode.Name = "lbl_hoppiesLogonCode";
            this.lbl_hoppiesLogonCode.Size = new System.Drawing.Size(159, 26);
            this.lbl_hoppiesLogonCode.TabIndex = 13;
            this.lbl_hoppiesLogonCode.Text = "HOPPIES LOGON CODE";
            this.lbl_hoppiesLogonCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbx_hoppiesLogonCode
            // 
            this.tbx_hoppiesLogonCode.BackColor = System.Drawing.SystemColors.ControlDark;
            this.tbx_hoppiesLogonCode.Font = new System.Drawing.Font("Terminus (TTF)", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.tbx_hoppiesLogonCode.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.tbx_hoppiesLogonCode.Location = new System.Drawing.Point(177, 143);
            this.tbx_hoppiesLogonCode.Name = "tbx_hoppiesLogonCode";
            this.tbx_hoppiesLogonCode.NumericCharOnly = false;
            this.tbx_hoppiesLogonCode.OctalOnly = false;
            this.tbx_hoppiesLogonCode.PasswordChar = '*';
            this.tbx_hoppiesLogonCode.Size = new System.Drawing.Size(238, 25);
            this.tbx_hoppiesLogonCode.TabIndex = 17;
            this.tbx_hoppiesLogonCode.TextChanged += new System.EventHandler(this.tbx_hoppiesLogonCode_TextChanged);
            // 
            // btn_enableHoppies
            // 
            this.btn_enableHoppies.Font = new System.Drawing.Font("Terminus (TTF)", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.btn_enableHoppies.Location = new System.Drawing.Point(177, 108);
            this.btn_enableHoppies.Name = "btn_enableHoppies";
            this.btn_enableHoppies.Size = new System.Drawing.Size(26, 26);
            this.btn_enableHoppies.SubFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_enableHoppies.SubText = "";
            this.btn_enableHoppies.TabIndex = 19;
            this.btn_enableHoppies.UseVisualStyleBackColor = true;
            this.btn_enableHoppies.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_enableHoppies_MouseUp);
            // 
            // sld_auralAlertVolume
            // 
            this.sld_auralAlertVolume.CustomPaintText = false;
            this.sld_auralAlertVolume.FontColor = System.Drawing.SystemColors.ControlDark;
            this.sld_auralAlertVolume.LargeChange = 1;
            this.sld_auralAlertVolume.Location = new System.Drawing.Point(177, 174);
            this.sld_auralAlertVolume.Name = "sld_auralAlertVolume";
            this.sld_auralAlertVolume.Size = new System.Drawing.Size(206, 45);
            this.sld_auralAlertVolume.TabIndex = 21;
            this.sld_auralAlertVolume.Text = "label1";
            this.sld_auralAlertVolume.Scroll += new System.EventHandler(this.sld_auralAlertVolume_Scroll);
            // 
            // btn_auralAlertVolumeTest
            // 
            this.btn_auralAlertVolumeTest.Font = new System.Drawing.Font("Terminus (TTF)", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.btn_auralAlertVolumeTest.Location = new System.Drawing.Point(389, 181);
            this.btn_auralAlertVolumeTest.Name = "btn_auralAlertVolumeTest";
            this.btn_auralAlertVolumeTest.Size = new System.Drawing.Size(26, 26);
            this.btn_auralAlertVolumeTest.SubFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_auralAlertVolumeTest.SubText = "";
            this.btn_auralAlertVolumeTest.TabIndex = 22;
            this.btn_auralAlertVolumeTest.UseVisualStyleBackColor = true;
            this.btn_auralAlertVolumeTest.Click += new System.EventHandler(this.btn_test_Click);
            this.btn_auralAlertVolumeTest.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_auralAlertVolumeTest_MouseUp);
            // 
            // lbl_auralAlertVolume
            // 
            this.lbl_auralAlertVolume.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbl_auralAlertVolume.Font = new System.Drawing.Font("Terminus (TTF)", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lbl_auralAlertVolume.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_auralAlertVolume.HasBorder = false;
            this.lbl_auralAlertVolume.InteractiveText = true;
            this.lbl_auralAlertVolume.Location = new System.Drawing.Point(12, 174);
            this.lbl_auralAlertVolume.Name = "lbl_auralAlertVolume";
            this.lbl_auralAlertVolume.Size = new System.Drawing.Size(159, 45);
            this.lbl_auralAlertVolume.TabIndex = 23;
            this.lbl_auralAlertVolume.Text = "NOTIFICATION VOLUME";
            this.lbl_auralAlertVolume.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbx_messageTimeout
            // 
            this.tbx_messageTimeout.BackColor = System.Drawing.SystemColors.ControlDark;
            this.tbx_messageTimeout.Font = new System.Drawing.Font("Terminus (TTF)", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.tbx_messageTimeout.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.tbx_messageTimeout.Location = new System.Drawing.Point(177, 234);
            this.tbx_messageTimeout.Name = "tbx_messageTimeout";
            this.tbx_messageTimeout.NumericCharOnly = false;
            this.tbx_messageTimeout.OctalOnly = false;
            this.tbx_messageTimeout.Size = new System.Drawing.Size(85, 25);
            this.tbx_messageTimeout.TabIndex = 25;
            this.tbx_messageTimeout.TextChanged += new System.EventHandler(this.tbx_messageTimeout_TextChanged);
            // 
            // lbl_messageTimeout
            // 
            this.lbl_messageTimeout.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbl_messageTimeout.Font = new System.Drawing.Font("Terminus (TTF)", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lbl_messageTimeout.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_messageTimeout.HasBorder = false;
            this.lbl_messageTimeout.InteractiveText = true;
            this.lbl_messageTimeout.Location = new System.Drawing.Point(12, 226);
            this.lbl_messageTimeout.Name = "lbl_messageTimeout";
            this.lbl_messageTimeout.Size = new System.Drawing.Size(159, 45);
            this.lbl_messageTimeout.TabIndex = 26;
            this.lbl_messageTimeout.Text = "FINISHED MESSAGE TIMEOUT";
            this.lbl_messageTimeout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            // tbx_vatACARSToken
            // 
            this.tbx_vatACARSToken.BackColor = System.Drawing.SystemColors.ControlDark;
            this.tbx_vatACARSToken.Font = new System.Drawing.Font("Terminus (TTF)", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.tbx_vatACARSToken.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.tbx_vatACARSToken.Location = new System.Drawing.Point(177, 75);
            this.tbx_vatACARSToken.Name = "tbx_vatACARSToken";
            this.tbx_vatACARSToken.NumericCharOnly = false;
            this.tbx_vatACARSToken.OctalOnly = false;
            this.tbx_vatACARSToken.PasswordChar = '*';
            this.tbx_vatACARSToken.Size = new System.Drawing.Size(238, 25);
            this.tbx_vatACARSToken.TabIndex = 29;
            this.tbx_vatACARSToken.TextChanged += new System.EventHandler(this.tbx_vatAcarsToken_TextChanged);
            // 
            // btn_checkStationCode
            // 
            this.btn_checkStationCode.Font = new System.Drawing.Font("Terminus (TTF)", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.btn_checkStationCode.Location = new System.Drawing.Point(337, 41);
            this.btn_checkStationCode.Name = "btn_checkStationCode";
            this.btn_checkStationCode.Size = new System.Drawing.Size(78, 26);
            this.btn_checkStationCode.SubFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_checkStationCode.SubText = "";
            this.btn_checkStationCode.TabIndex = 30;
            this.btn_checkStationCode.Text = "Check";
            this.btn_checkStationCode.UseVisualStyleBackColor = true;
            this.btn_checkStationCode.Click += new System.EventHandler(this.btn_checkStationCode_Click);
            // 
            // lbl_statusMessage
            // 
            this.lbl_statusMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_statusMessage.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbl_statusMessage.Font = new System.Drawing.Font("Terminus (TTF)", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lbl_statusMessage.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_statusMessage.HasBorder = false;
            this.lbl_statusMessage.InteractiveText = true;
            this.lbl_statusMessage.Location = new System.Drawing.Point(12, 285);
            this.lbl_statusMessage.Name = "lbl_statusMessage";
            this.lbl_statusMessage.Size = new System.Drawing.Size(287, 57);
            this.lbl_statusMessage.TabIndex = 31;
            this.lbl_statusMessage.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // SetupWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 354);
            this.Controls.Add(this.lbl_statusMessage);
            this.Controls.Add(this.btn_checkStationCode);
            this.Controls.Add(this.tbx_vatACARSToken);
            this.Controls.Add(this.lbl_vatACARSToken);
            this.Controls.Add(this.lbl_stationCode);
            this.Controls.Add(this.lbl_messageTimeout);
            this.Controls.Add(this.tbx_messageTimeout);
            this.Controls.Add(this.lbl_auralAlertVolume);
            this.Controls.Add(this.btn_auralAlertVolumeTest);
            this.Controls.Add(this.sld_auralAlertVolume);
            this.Controls.Add(this.btn_enableHoppies);
            this.Controls.Add(this.tbx_hoppiesLogonCode);
            this.Controls.Add(this.tbx_stationCode);
            this.Controls.Add(this.lbl_hoppiesLogonCode);
            this.Controls.Add(this.lbl_enableHoppies);
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
            this.Shown += new System.EventHandler(this.SetupWindow_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.sld_auralAlertVolume)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private vatsys.GenericButton btn_connect;
        private vatsys.TextLabel lbl_stationCodePrompt;
        private vatsys.TextLabel lbl_enableHoppies;
        private vatsys.TextLabel lbl_hoppiesLogonCode;
        private vatsys.TextField tbx_hoppiesLogonCode;
        private vatsys.GenericButton btn_enableHoppies;
        private vatsys.GenericButton btn_auralAlertVolumeTest;
        public VATSYSControls.Slider sld_auralAlertVolume;
        private vatsys.TextLabel lbl_auralAlertVolume;
        private vatsys.TextField tbx_messageTimeout;
        private vatsys.TextLabel lbl_messageTimeout;
        private vatsys.TextField tbx_stationCode;
        private vatsys.TextLabel lbl_stationCode;
        private vatsys.TextLabel lbl_vatACARSToken;
        private vatsys.TextField tbx_vatACARSToken;
        private vatsys.GenericButton btn_checkStationCode;
        private vatsys.TextLabel lbl_statusMessage;
    }
}