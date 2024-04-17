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
            this.btn_save = new vatsys.GenericButton();
            this.lbl_stationCode = new vatsys.TextLabel();
            this.lbl_enablehop = new vatsys.TextLabel();
            this.lbl_hoplogon = new vatsys.TextLabel();
            this.tbx_logonCode = new vatsys.TextField();
            this.tbx_hoplogon = new vatsys.TextField();
            this.toggle_hop = new vatsys.GenericButton();
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
            // 
            // btn_save
            // 
            this.btn_save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_save.Font = new System.Drawing.Font("Terminus (TTF)", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.btn_save.Location = new System.Drawing.Point(12, 166);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(101, 28);
            this.btn_save.SubFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save.SubText = "";
            this.btn_save.TabIndex = 9;
            this.btn_save.Text = "Save";
            this.btn_save.UseVisualStyleBackColor = true;
            // 
            // lbl_stationCode
            // 
            this.lbl_stationCode.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_stationCode.Font = new System.Drawing.Font("Terminus (TTF)", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lbl_stationCode.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_stationCode.HasBorder = false;
            this.lbl_stationCode.InteractiveText = false;
            this.lbl_stationCode.Location = new System.Drawing.Point(12, 7);
            this.lbl_stationCode.Name = "lbl_stationCode";
            this.lbl_stationCode.Size = new System.Drawing.Size(159, 26);
            this.lbl_stationCode.TabIndex = 10;
            this.lbl_stationCode.Text = "STATION CODE";
            this.lbl_stationCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_enablehop
            // 
            this.lbl_enablehop.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_enablehop.Font = new System.Drawing.Font("Terminus (TTF)", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lbl_enablehop.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_enablehop.HasBorder = false;
            this.lbl_enablehop.InteractiveText = false;
            this.lbl_enablehop.Location = new System.Drawing.Point(12, 40);
            this.lbl_enablehop.Name = "lbl_enablehop";
            this.lbl_enablehop.Size = new System.Drawing.Size(159, 26);
            this.lbl_enablehop.TabIndex = 12;
            this.lbl_enablehop.Text = "ENABLE HOPPIES";
            this.lbl_enablehop.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_hoplogon
            // 
            this.lbl_hoplogon.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_hoplogon.Font = new System.Drawing.Font("Terminus (TTF)", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lbl_hoplogon.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_hoplogon.HasBorder = false;
            this.lbl_hoplogon.InteractiveText = false;
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
            // 
            // tbx_hoplogon
            // 
            this.tbx_hoplogon.BackColor = System.Drawing.SystemColors.ControlDark;
            this.tbx_hoplogon.Font = new System.Drawing.Font("Terminus (TTF)", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.tbx_hoplogon.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.tbx_hoplogon.Location = new System.Drawing.Point(177, 73);
            this.tbx_hoplogon.Name = "tbx_hoplogon";
            this.tbx_hoplogon.NumericCharOnly = false;
            this.tbx_hoplogon.OctalOnly = false;
            this.tbx_hoplogon.Size = new System.Drawing.Size(238, 25);
            this.tbx_hoplogon.TabIndex = 17;
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
            // 
            // SetupWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 206);
            this.Controls.Add(this.toggle_hop);
            this.Controls.Add(this.tbx_hoplogon);
            this.Controls.Add(this.tbx_logonCode);
            this.Controls.Add(this.lbl_hoplogon);
            this.Controls.Add(this.lbl_enablehop);
            this.Controls.Add(this.lbl_stationCode);
            this.Controls.Add(this.btn_save);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private vatsys.GenericButton btn_connect;
        private vatsys.GenericButton btn_save;
        private vatsys.TextLabel lbl_stationCode;
        private vatsys.TextLabel lbl_enablehop;
        private vatsys.TextLabel lbl_hoplogon;
        private vatsys.TextField tbx_logonCode;
        private vatsys.TextField tbx_hoplogon;
        private vatsys.GenericButton toggle_hop;
    }
}