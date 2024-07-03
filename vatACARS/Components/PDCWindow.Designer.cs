namespace vatACARS.Components
{
    partial class PDCWindow
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
            this.lbl_metaInfo = new vatsys.TextLabel();
            this.btn_send = new vatsys.GenericButton();
            this.lbl_destRoute = new vatsys.TextLabel();
            this.lbl_sidRwy = new vatsys.TextLabel();
            this.lbl_initAlt = new vatsys.TextLabel();
            this.lbl_sqwkDeps = new vatsys.TextLabel();
            this.lbl_pdcHeader = new vatsys.TextLabel();
            this.lbl_route = new vatsys.TextLabel();
            this.lbl_depFreq = new vatsys.TextLabel();
            this.tbx_depfreq = new vatsys.TextField();
            this.tbx_freetext = new vatsys.TextField();
            this.textLabel1 = new vatsys.TextLabel();
            this.insetPanel2 = new vatsys.InsetPanel();
            this.insetPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_metaInfo
            // 
            this.lbl_metaInfo.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbl_metaInfo.Font = new System.Drawing.Font("Terminus (TTF)", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lbl_metaInfo.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_metaInfo.HasBorder = false;
            this.lbl_metaInfo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_metaInfo.InteractiveText = true;
            this.lbl_metaInfo.Location = new System.Drawing.Point(5, 25);
            this.lbl_metaInfo.Name = "lbl_metaInfo";
            this.lbl_metaInfo.Size = new System.Drawing.Size(327, 18);
            this.lbl_metaInfo.TabIndex = 47;
            this.lbl_metaInfo.Text = "JST000 B738 YSSY 0000";
            this.lbl_metaInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_send
            // 
            this.btn_send.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_send.Font = new System.Drawing.Font("Terminus (TTF)", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.btn_send.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btn_send.Location = new System.Drawing.Point(258, 240);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(90, 28);
            this.btn_send.SubFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_send.SubText = "";
            this.btn_send.TabIndex = 88;
            this.btn_send.Text = "SEND";
            this.btn_send.UseVisualStyleBackColor = true;
            this.btn_send.Click += new System.EventHandler(this.btn_send_Click);
            // 
            // lbl_destRoute
            // 
            this.lbl_destRoute.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbl_destRoute.Font = new System.Drawing.Font("Terminus (TTF)", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lbl_destRoute.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_destRoute.HasBorder = false;
            this.lbl_destRoute.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_destRoute.InteractiveText = true;
            this.lbl_destRoute.Location = new System.Drawing.Point(12, 67);
            this.lbl_destRoute.Name = "lbl_destRoute";
            this.lbl_destRoute.Size = new System.Drawing.Size(337, 18);
            this.lbl_destRoute.TabIndex = 89;
            this.lbl_destRoute.Text = "CLRD TO * VIA";
            this.lbl_destRoute.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_sidRwy
            // 
            this.lbl_sidRwy.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbl_sidRwy.Font = new System.Drawing.Font("Terminus (TTF)", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lbl_sidRwy.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_sidRwy.HasBorder = false;
            this.lbl_sidRwy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_sidRwy.InteractiveText = true;
            this.lbl_sidRwy.Location = new System.Drawing.Point(12, 88);
            this.lbl_sidRwy.Name = "lbl_sidRwy";
            this.lbl_sidRwy.Size = new System.Drawing.Size(337, 18);
            this.lbl_sidRwy.TabIndex = 90;
            this.lbl_sidRwy.Text = "SID * RWY *";
            this.lbl_sidRwy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_initAlt
            // 
            this.lbl_initAlt.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbl_initAlt.Font = new System.Drawing.Font("Terminus (TTF)", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lbl_initAlt.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_initAlt.HasBorder = false;
            this.lbl_initAlt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_initAlt.InteractiveText = true;
            this.lbl_initAlt.Location = new System.Drawing.Point(12, 130);
            this.lbl_initAlt.Name = "lbl_initAlt";
            this.lbl_initAlt.Size = new System.Drawing.Size(337, 18);
            this.lbl_initAlt.TabIndex = 91;
            this.lbl_initAlt.Text = "CLIMB VIA SID TO *";
            this.lbl_initAlt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_sqwkDeps
            // 
            this.lbl_sqwkDeps.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbl_sqwkDeps.Font = new System.Drawing.Font("Terminus (TTF)", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lbl_sqwkDeps.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_sqwkDeps.HasBorder = false;
            this.lbl_sqwkDeps.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_sqwkDeps.InteractiveText = true;
            this.lbl_sqwkDeps.Location = new System.Drawing.Point(12, 151);
            this.lbl_sqwkDeps.Name = "lbl_sqwkDeps";
            this.lbl_sqwkDeps.Size = new System.Drawing.Size(337, 18);
            this.lbl_sqwkDeps.TabIndex = 92;
            this.lbl_sqwkDeps.Text = "SQUAWK ****";
            this.lbl_sqwkDeps.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_pdcHeader
            // 
            this.lbl_pdcHeader.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbl_pdcHeader.Font = new System.Drawing.Font("Terminus (TTF)", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lbl_pdcHeader.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_pdcHeader.HasBorder = false;
            this.lbl_pdcHeader.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_pdcHeader.InteractiveText = true;
            this.lbl_pdcHeader.Location = new System.Drawing.Point(5, 2);
            this.lbl_pdcHeader.Name = "lbl_pdcHeader";
            this.lbl_pdcHeader.Size = new System.Drawing.Size(327, 18);
            this.lbl_pdcHeader.TabIndex = 94;
            this.lbl_pdcHeader.Text = "PDC 000000";
            this.lbl_pdcHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_route
            // 
            this.lbl_route.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbl_route.Font = new System.Drawing.Font("Terminus (TTF)", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lbl_route.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_route.HasBorder = false;
            this.lbl_route.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_route.InteractiveText = true;
            this.lbl_route.Location = new System.Drawing.Point(12, 109);
            this.lbl_route.Name = "lbl_route";
            this.lbl_route.Size = new System.Drawing.Size(337, 18);
            this.lbl_route.TabIndex = 95;
            this.lbl_route.Text = "ROUTE: * * *";
            this.lbl_route.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_depFreq
            // 
            this.lbl_depFreq.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbl_depFreq.Font = new System.Drawing.Font("Terminus (TTF)", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lbl_depFreq.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_depFreq.HasBorder = false;
            this.lbl_depFreq.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_depFreq.InteractiveText = true;
            this.lbl_depFreq.Location = new System.Drawing.Point(12, 172);
            this.lbl_depFreq.Name = "lbl_depFreq";
            this.lbl_depFreq.Size = new System.Drawing.Size(91, 18);
            this.lbl_depFreq.TabIndex = 96;
            this.lbl_depFreq.Text = "DEP FREQ:";
            this.lbl_depFreq.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbx_depfreq
            // 
            this.tbx_depfreq.BackColor = System.Drawing.SystemColors.ControlDark;
            this.tbx_depfreq.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.tbx_depfreq.Location = new System.Drawing.Point(110, 172);
            this.tbx_depfreq.Name = "tbx_depfreq";
            this.tbx_depfreq.NumericCharOnly = false;
            this.tbx_depfreq.OctalOnly = false;
            this.tbx_depfreq.Size = new System.Drawing.Size(100, 25);
            this.tbx_depfreq.TabIndex = 97;
            // 
            // tbx_freetext
            // 
            this.tbx_freetext.BackColor = System.Drawing.SystemColors.ControlDark;
            this.tbx_freetext.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.tbx_freetext.Location = new System.Drawing.Point(109, 200);
            this.tbx_freetext.Name = "tbx_freetext";
            this.tbx_freetext.NumericCharOnly = false;
            this.tbx_freetext.OctalOnly = false;
            this.tbx_freetext.Size = new System.Drawing.Size(240, 25);
            this.tbx_freetext.TabIndex = 98;
            // 
            // textLabel1
            // 
            this.textLabel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.textLabel1.Font = new System.Drawing.Font("Terminus (TTF)", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.textLabel1.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.textLabel1.HasBorder = false;
            this.textLabel1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.textLabel1.InteractiveText = true;
            this.textLabel1.Location = new System.Drawing.Point(12, 200);
            this.textLabel1.Name = "textLabel1";
            this.textLabel1.Size = new System.Drawing.Size(91, 18);
            this.textLabel1.TabIndex = 99;
            this.textLabel1.Text = "FREE TEXT:";
            this.textLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // insetPanel2
            // 
            this.insetPanel2.Controls.Add(this.lbl_metaInfo);
            this.insetPanel2.Controls.Add(this.lbl_pdcHeader);
            this.insetPanel2.Location = new System.Drawing.Point(12, 12);
            this.insetPanel2.Name = "insetPanel2";
            this.insetPanel2.Padding = new System.Windows.Forms.Padding(2);
            this.insetPanel2.Size = new System.Drawing.Size(337, 45);
            this.insetPanel2.TabIndex = 101;
            // 
            // PDCWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 280);
            this.ControlBox = false;
            this.Controls.Add(this.lbl_destRoute);
            this.Controls.Add(this.insetPanel2);
            this.Controls.Add(this.textLabel1);
            this.Controls.Add(this.tbx_freetext);
            this.Controls.Add(this.tbx_depfreq);
            this.Controls.Add(this.lbl_depFreq);
            this.Controls.Add(this.lbl_route);
            this.Controls.Add(this.lbl_sqwkDeps);
            this.Controls.Add(this.lbl_initAlt);
            this.Controls.Add(this.lbl_sidRwy);
            this.Controls.Add(this.btn_send);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HasSendBackButton = false;
            this.HideOnClose = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MiddleClickClose = false;
            this.Name = "PDCWindow";
            this.Resizeable = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "PDC Editor";
            this.insetPanel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private vatsys.TextLabel lbl_metaInfo;
        private vatsys.GenericButton btn_send;
        private vatsys.TextLabel lbl_destRoute;
        private vatsys.TextLabel lbl_sidRwy;
        private vatsys.TextLabel lbl_initAlt;
        private vatsys.TextLabel lbl_sqwkDeps;
        private vatsys.TextLabel lbl_pdcHeader;
        private vatsys.TextLabel lbl_route;
        private vatsys.TextLabel lbl_depFreq;
        private vatsys.TextField tbx_depfreq;
        private vatsys.TextField tbx_freetext;
        private vatsys.TextLabel textLabel1;
        private vatsys.InsetPanel insetPanel2;
    }
}