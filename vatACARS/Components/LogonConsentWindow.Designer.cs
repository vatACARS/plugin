namespace vatACARS.Components
{
    partial class LogonConsentWindow
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
            this.lbl_callsign = new vatsys.TextLabel();
            this.btn_accept = new vatsys.GenericButton();
            this.btn_unable = new vatsys.GenericButton();
            this.SuspendLayout();
            // 
            // lbl_callsign
            // 
            this.lbl_callsign.Font = new System.Drawing.Font("Terminus (TTF)", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lbl_callsign.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_callsign.HasBorder = false;
            this.lbl_callsign.InteractiveText = false;
            this.lbl_callsign.Location = new System.Drawing.Point(12, 9);
            this.lbl_callsign.Name = "lbl_callsign";
            this.lbl_callsign.Size = new System.Drawing.Size(229, 30);
            this.lbl_callsign.TabIndex = 0;
            this.lbl_callsign.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_accept
            // 
            this.btn_accept.Font = new System.Drawing.Font("Terminus (TTF)", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.btn_accept.Location = new System.Drawing.Point(15, 47);
            this.btn_accept.Name = "btn_accept";
            this.btn_accept.Size = new System.Drawing.Size(105, 28);
            this.btn_accept.SubFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_accept.SubText = "";
            this.btn_accept.TabIndex = 1;
            this.btn_accept.Text = "ACCEPT";
            this.btn_accept.UseVisualStyleBackColor = true;
            this.btn_accept.Click += new System.EventHandler(this.btn_accept_Click);
            // 
            // btn_unable
            // 
            this.btn_unable.Font = new System.Drawing.Font("Terminus (TTF)", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.btn_unable.Location = new System.Drawing.Point(136, 47);
            this.btn_unable.Name = "btn_unable";
            this.btn_unable.Size = new System.Drawing.Size(105, 28);
            this.btn_unable.SubFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_unable.SubText = "";
            this.btn_unable.TabIndex = 2;
            this.btn_unable.Text = "UNABLE";
            this.btn_unable.UseVisualStyleBackColor = true;
            this.btn_unable.Click += new System.EventHandler(this.btn_unable_Click);
            // 
            // LogonConsentWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(253, 87);
            this.Controls.Add(this.btn_unable);
            this.Controls.Add(this.btn_accept);
            this.Controls.Add(this.lbl_callsign);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HasCloseButton = false;
            this.HasMinimizeButton = false;
            this.MinimizeBox = false;
            this.Name = "LogonConsentWindow";
            this.Resizeable = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Logon Request";
            this.ResumeLayout(false);

        }

        #endregion

        private vatsys.TextLabel lbl_callsign;
        private vatsys.GenericButton btn_accept;
        private vatsys.GenericButton btn_unable;
    }
}