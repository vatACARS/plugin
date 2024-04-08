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
            this.cancelButton = new vatsys.GenericButton();
            this.b_restartPlugin = new vatsys.GenericButton();
            this.lbl_stationCode = new vatsys.TextLabel();
            this.tbx_stationCode = new vatsys.TextField();
            this.lbl_acarsServer = new vatsys.TextLabel();
            this.lbl_logonCode = new vatsys.TextLabel();
            this.tbx_acarsServer = new vatsys.TextField();
            this.tbx_logonCode = new vatsys.TextField();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.Font = new System.Drawing.Font("Terminus (TTF)", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cancelButton.Location = new System.Drawing.Point(305, 114);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(140, 28);
            this.cancelButton.SubFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelButton.SubText = "";
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // b_restartPlugin
            // 
            this.b_restartPlugin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.b_restartPlugin.Font = new System.Drawing.Font("Terminus (TTF)", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.b_restartPlugin.Location = new System.Drawing.Point(12, 114);
            this.b_restartPlugin.Name = "b_restartPlugin";
            this.b_restartPlugin.Size = new System.Drawing.Size(140, 28);
            this.b_restartPlugin.SubFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_restartPlugin.SubText = "";
            this.b_restartPlugin.TabIndex = 9;
            this.b_restartPlugin.Text = "Save & Connect";
            this.b_restartPlugin.UseVisualStyleBackColor = true;
            // 
            // lbl_stationCode
            // 
            this.lbl_stationCode.Font = new System.Drawing.Font("Terminus (TTF)", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lbl_stationCode.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_stationCode.HasBorder = false;
            this.lbl_stationCode.InteractiveText = false;
            this.lbl_stationCode.Location = new System.Drawing.Point(12, 9);
            this.lbl_stationCode.Name = "lbl_stationCode";
            this.lbl_stationCode.Size = new System.Drawing.Size(140, 26);
            this.lbl_stationCode.TabIndex = 10;
            this.lbl_stationCode.Text = "Station Code";
            this.lbl_stationCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbx_stationCode
            // 
            this.tbx_stationCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbx_stationCode.BackColor = System.Drawing.SystemColors.ControlDark;
            this.tbx_stationCode.Font = new System.Drawing.Font("Terminus (TTF)", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.tbx_stationCode.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.tbx_stationCode.Location = new System.Drawing.Point(169, 9);
            this.tbx_stationCode.Name = "tbx_stationCode";
            this.tbx_stationCode.NumericCharOnly = false;
            this.tbx_stationCode.OctalOnly = false;
            this.tbx_stationCode.Size = new System.Drawing.Size(74, 25);
            this.tbx_stationCode.TabIndex = 11;
            // 
            // lbl_acarsServer
            // 
            this.lbl_acarsServer.Font = new System.Drawing.Font("Terminus (TTF)", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lbl_acarsServer.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_acarsServer.HasBorder = false;
            this.lbl_acarsServer.InteractiveText = false;
            this.lbl_acarsServer.Location = new System.Drawing.Point(12, 73);
            this.lbl_acarsServer.Name = "lbl_acarsServer";
            this.lbl_acarsServer.Size = new System.Drawing.Size(140, 26);
            this.lbl_acarsServer.TabIndex = 12;
            this.lbl_acarsServer.Text = "ACARS Server";
            this.lbl_acarsServer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_logonCode
            // 
            this.lbl_logonCode.Font = new System.Drawing.Font("Terminus (TTF)", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lbl_logonCode.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_logonCode.HasBorder = false;
            this.lbl_logonCode.InteractiveText = false;
            this.lbl_logonCode.Location = new System.Drawing.Point(12, 41);
            this.lbl_logonCode.Name = "lbl_logonCode";
            this.lbl_logonCode.Size = new System.Drawing.Size(140, 26);
            this.lbl_logonCode.TabIndex = 13;
            this.lbl_logonCode.Text = "Logon Code";
            this.lbl_logonCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbx_acarsServer
            // 
            this.tbx_acarsServer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbx_acarsServer.BackColor = System.Drawing.SystemColors.ControlDark;
            this.tbx_acarsServer.Font = new System.Drawing.Font("Terminus (TTF)", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.tbx_acarsServer.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.tbx_acarsServer.Location = new System.Drawing.Point(170, 73);
            this.tbx_acarsServer.Name = "tbx_acarsServer";
            this.tbx_acarsServer.NumericCharOnly = false;
            this.tbx_acarsServer.OctalOnly = false;
            this.tbx_acarsServer.Size = new System.Drawing.Size(276, 25);
            this.tbx_acarsServer.TabIndex = 14;
            // 
            // tbx_logonCode
            // 
            this.tbx_logonCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbx_logonCode.BackColor = System.Drawing.SystemColors.ControlDark;
            this.tbx_logonCode.Font = new System.Drawing.Font("Terminus (TTF)", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.tbx_logonCode.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.tbx_logonCode.Location = new System.Drawing.Point(169, 41);
            this.tbx_logonCode.Name = "tbx_logonCode";
            this.tbx_logonCode.NumericCharOnly = false;
            this.tbx_logonCode.OctalOnly = false;
            this.tbx_logonCode.Size = new System.Drawing.Size(276, 25);
            this.tbx_logonCode.TabIndex = 15;
            // 
            // SetupWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 155);
            this.Controls.Add(this.tbx_logonCode);
            this.Controls.Add(this.tbx_acarsServer);
            this.Controls.Add(this.lbl_logonCode);
            this.Controls.Add(this.lbl_acarsServer);
            this.Controls.Add(this.tbx_stationCode);
            this.Controls.Add(this.lbl_stationCode);
            this.Controls.Add(this.b_restartPlugin);
            this.Controls.Add(this.cancelButton);
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
            this.TopMost = true;
            this.Shown += new System.EventHandler(this.SetupWindow_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private vatsys.GenericButton cancelButton;
        private vatsys.GenericButton b_restartPlugin;
        private vatsys.TextLabel lbl_stationCode;
        private vatsys.TextField tbx_stationCode;
        private vatsys.TextLabel lbl_acarsServer;
        private vatsys.TextLabel lbl_logonCode;
        private vatsys.TextField tbx_acarsServer;
        private vatsys.TextField tbx_logonCode;
    }
}