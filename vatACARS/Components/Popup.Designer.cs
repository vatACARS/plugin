namespace vatACARS.Components
{
    partial class PopupWindow
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
            this.btn_2 = new vatsys.GenericButton();
            this.btn_1 = new vatsys.GenericButton();
            this.lbl_content = new vatsys.TextLabel();
            this.SuspendLayout();
            // 
            // btn_2
            // 
            this.btn_2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_2.Font = new System.Drawing.Font("Terminus (TTF)", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.btn_2.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btn_2.Location = new System.Drawing.Point(138, 59);
            this.btn_2.Name = "btn_2";
            this.btn_2.Size = new System.Drawing.Size(90, 28);
            this.btn_2.SubFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_2.SubText = "";
            this.btn_2.TabIndex = 2;
            this.btn_2.UseVisualStyleBackColor = true;
            this.btn_2.Click += new System.EventHandler(this.btn_2_Click);
            // 
            // btn_1
            // 
            this.btn_1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_1.Font = new System.Drawing.Font("Terminus (TTF)", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.btn_1.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btn_1.Location = new System.Drawing.Point(12, 59);
            this.btn_1.Name = "btn_1";
            this.btn_1.Size = new System.Drawing.Size(90, 28);
            this.btn_1.SubFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_1.SubText = "";
            this.btn_1.TabIndex = 1;
            this.btn_1.UseVisualStyleBackColor = true;
            this.btn_1.Click += new System.EventHandler(this.btn_1_Click);
            // 
            // lbl_content
            // 
            this.lbl_content.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_content.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbl_content.Font = new System.Drawing.Font("Terminus (TTF)", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lbl_content.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_content.HasBorder = false;
            this.lbl_content.InteractiveText = true;
            this.lbl_content.Location = new System.Drawing.Point(12, 9);
            this.lbl_content.Name = "lbl_content";
            this.lbl_content.Size = new System.Drawing.Size(216, 47);
            this.lbl_content.TabIndex = 3;
            this.lbl_content.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PopupWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(240, 99);
            this.ControlBox = false;
            this.Controls.Add(this.lbl_content);
            this.Controls.Add(this.btn_1);
            this.Controls.Add(this.btn_2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HasCloseButton = false;
            this.HasMinimizeButton = false;
            this.HasSendBackButton = false;
            this.HideOnClose = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MiddleClickClose = false;
            this.Name = "PopupWindow";
            this.Resizeable = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "vatACARS";
            this.ResumeLayout(false);

        }

        #endregion
        private vatsys.GenericButton btn_2;
        private vatsys.GenericButton btn_1;
        private vatsys.TextLabel lbl_content;
    }
}