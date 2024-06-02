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
            this.lbl_stationCode = new vatsys.TextLabel();
            this.lbl_enablehop = new vatsys.TextLabel();
            this.lbl_hoplogon = new vatsys.TextLabel();
            this.tbx_logonCode = new vatsys.TextField();
            this.tbx_hoplogon = new vatsys.TextField();
            this.toggle_hop = new vatsys.GenericButton();
            this.lbl_error = new vatsys.TextLabel();
            this.slider_vol = new VATSYSControls.Slider();
            this.btn_test = new vatsys.GenericButton();
            this.lbl_vol = new vatsys.TextLabel();
            ((System.ComponentModel.ISupportInitialize)(this.slider_vol)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_connect
            // 
            this.btn_connect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_connect.Font = new System.Drawing.Font("Terminus (TTF)", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.btn_connect.Location = new System.Drawing.Point(314, 166);
            this.btn_connect.Name = "btn_connect";
            this.btn_connect.Size = new System.Drawing.Size(101, 28);
            this.btn_connect.SubFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_connect.SubText = "";
            this.btn_connect.TabIndex = 1;
            this.btn_connect.Text = "Connect";
            this.btn_connect.UseVisualStyleBackColor = true;
            this.btn_connect.Click += new System.EventHandler(this.btn_connect_Click);
            // 
            // lbl_stationCode
            // 
            this.lbl_stationCode.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbl_stationCode.Font = new System.Drawing.Font("Terminus (TTF)", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lbl_stationCode.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_stationCode.HasBorder = false;
            this.lbl_stationCode.InteractiveText = true;
            this.lbl_stationCode.Location = new System.Drawing.Point(12, 9);
            this.lbl_stationCode.Name = "lbl_stationCode";
            this.lbl_stationCode.Size = new System.Drawing.Size(159, 26);
            this.lbl_stationCode.TabIndex = 10;
            this.lbl_stationCode.Text = "STATION CODE";
            this.lbl_stationCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_enablehop
            // 
            this.lbl_enablehop.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbl_enablehop.Font = new System.Drawing.Font("Terminus (TTF)", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lbl_enablehop.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_enablehop.HasBorder = false;
            this.lbl_enablehop.InteractiveText = true;
            this.lbl_enablehop.Location = new System.Drawing.Point(12, 40);
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
            this.lbl_hoplogon.Location = new System.Drawing.Point(12, 73);
            this.lbl_hoplogon.Name = "lbl_hoplogon";
            this.lbl_hoplogon.Size = new System.Drawing.Size(159, 26);
            this.lbl_hoplogon.TabIndex = 13;
            this.lbl_hoplogon.Text = "HOPPIES LOGON CODE";
            this.lbl_hoplogon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_hoplogon.Click += new System.EventHandler(this.lbl_logonCode_Click);
            // 
            // tbx_logonCode
            // 
            this.tbx_logonCode.BackColor = System.Drawing.SystemColors.ControlDark;
            this.tbx_logonCode.Font = new System.Drawing.Font("Terminus (TTF)", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.tbx_logonCode.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.tbx_logonCode.Location = new System.Drawing.Point(177, 9);
            this.tbx_logonCode.Name = "tbx_logonCode";
            this.tbx_logonCode.NumericCharOnly = false;
            this.tbx_logonCode.OctalOnly = false;
            this.tbx_logonCode.Size = new System.Drawing.Size(85, 25);
            this.tbx_logonCode.TabIndex = 15;
            this.tbx_logonCode.TextChanged += new System.EventHandler(this.tbx_logonCode_TextChanged);
            // 
            // tbx_hoplogon
            // 
            this.tbx_hoplogon.BackColor = System.Drawing.SystemColors.ControlDark;
            this.tbx_hoplogon.Font = new System.Drawing.Font("Terminus (TTF)", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.tbx_hoplogon.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.tbx_hoplogon.Location = new System.Drawing.Point(177, 75);
            this.tbx_hoplogon.Name = "tbx_hoplogon";
            this.tbx_hoplogon.NumericCharOnly = false;
            this.tbx_hoplogon.OctalOnly = false;
            this.tbx_hoplogon.Size = new System.Drawing.Size(238, 25);
            this.tbx_hoplogon.TabIndex = 17;
            this.tbx_hoplogon.TextChanged += new System.EventHandler(this.tbx_hoplogon_TextChanged);
            // 
            // toggle_hop
            // 
            this.toggle_hop.Font = new System.Drawing.Font("Terminus (TTF)", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.toggle_hop.Location = new System.Drawing.Point(177, 40);
            this.toggle_hop.Name = "toggle_hop";
            this.toggle_hop.Size = new System.Drawing.Size(26, 26);
            this.toggle_hop.SubFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toggle_hop.SubText = "";
            this.toggle_hop.TabIndex = 19;
            this.toggle_hop.UseVisualStyleBackColor = true;
            this.toggle_hop.MouseUp += new System.Windows.Forms.MouseEventHandler(this.toggle_hop_MouseUp);
            // 
            // lbl_error
            // 
            this.lbl_error.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_error.Font = new System.Drawing.Font("Terminus (TTF)", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lbl_error.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_error.HasBorder = false;
            this.lbl_error.InteractiveText = true;
            this.lbl_error.Location = new System.Drawing.Point(12, 166);
            this.lbl_error.Name = "lbl_error";
            this.lbl_error.Size = new System.Drawing.Size(296, 28);
            this.lbl_error.TabIndex = 20;
            this.lbl_error.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // slider_vol
            // 
            this.slider_vol.CustomPaintText = false;
            this.slider_vol.FontColor = System.Drawing.SystemColors.ControlDark;
            this.slider_vol.LargeChange = 1;
            this.slider_vol.Location = new System.Drawing.Point(177, 106);
            this.slider_vol.Name = "slider_vol";
            this.slider_vol.Size = new System.Drawing.Size(206, 45);
            this.slider_vol.TabIndex = 21;
            this.slider_vol.Text = "label1";
            this.slider_vol.Scroll += new System.EventHandler(this.slider_vol_Scroll);
            // 
            // btn_test
            // 
            this.btn_test.Font = new System.Drawing.Font("Terminus (TTF)", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.btn_test.Location = new System.Drawing.Point(389, 113);
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
            this.lbl_vol.Location = new System.Drawing.Point(12, 106);
            this.lbl_vol.Name = "lbl_vol";
            this.lbl_vol.Size = new System.Drawing.Size(159, 45);
            this.lbl_vol.TabIndex = 23;
            this.lbl_vol.Text = "NOTIFICATION VOLUME";
            this.lbl_vol.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SetupWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 206);
            this.Controls.Add(this.lbl_vol);
            this.Controls.Add(this.btn_test);
            this.Controls.Add(this.slider_vol);
            this.Controls.Add(this.lbl_error);
            this.Controls.Add(this.toggle_hop);
            this.Controls.Add(this.tbx_hoplogon);
            this.Controls.Add(this.tbx_logonCode);
            this.Controls.Add(this.lbl_hoplogon);
            this.Controls.Add(this.lbl_enablehop);
            this.Controls.Add(this.lbl_stationCode);
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
        private vatsys.TextLabel lbl_stationCode;
        private vatsys.TextLabel lbl_enablehop;
        private vatsys.TextLabel lbl_hoplogon;
        private vatsys.TextField tbx_logonCode;
        private vatsys.TextField tbx_hoplogon;
        private vatsys.GenericButton toggle_hop;
        private vatsys.TextLabel lbl_error;
        private vatsys.GenericButton btn_test;
        public VATSYSControls.Slider slider_vol;
        private vatsys.TextLabel lbl_vol;
    }
}