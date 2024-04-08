namespace vatACARS.Components
{
    partial class UpdateNotification
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
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_preamble = new System.Windows.Forms.Label();
            this.lbl_version = new System.Windows.Forms.Label();
            this.lbl_changes = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(446, 263);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // lbl_preamble
            // 
            this.lbl_preamble.Location = new System.Drawing.Point(13, 13);
            this.lbl_preamble.Name = "lbl_preamble";
            this.lbl_preamble.Size = new System.Drawing.Size(399, 24);
            this.lbl_preamble.TabIndex = 1;
            this.lbl_preamble.Text = "A new version of vatACARS is available.";
            this.lbl_preamble.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbl_version
            // 
            this.lbl_version.Font = new System.Drawing.Font("Terminus (TTF)", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lbl_version.Location = new System.Drawing.Point(12, 37);
            this.lbl_version.Name = "lbl_version";
            this.lbl_version.Size = new System.Drawing.Size(399, 24);
            this.lbl_version.TabIndex = 2;
            this.lbl_version.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbl_changes
            // 
            this.lbl_changes.Location = new System.Drawing.Point(13, 61);
            this.lbl_changes.Name = "lbl_changes";
            this.lbl_changes.Size = new System.Drawing.Size(399, 94);
            this.lbl_changes.TabIndex = 3;
            // 
            // UpdateNotification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 164);
            this.Controls.Add(this.lbl_changes);
            this.Controls.Add(this.lbl_version);
            this.Controls.Add(this.lbl_preamble);
            this.Controls.Add(this.label1);
            this.Name = "UpdateNotification";
            this.Text = "vatACARS";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_preamble;
        private System.Windows.Forms.Label lbl_version;
        private System.Windows.Forms.Label lbl_changes;
    }
}