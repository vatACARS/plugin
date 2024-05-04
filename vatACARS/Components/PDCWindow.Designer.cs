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
            this.lbl_acname = new vatsys.TextLabel();
            this.btn_time = new vatsys.GenericButton();
            this.lbl_PDC = new vatsys.TextLabel();
            this.btn_type = new vatsys.GenericButton();
            this.lbl_clrto = new vatsys.TextLabel();
            this.btn_desicao = new vatsys.GenericButton();
            this.lbl_dep = new vatsys.TextLabel();
            this.btn_callsign = new vatsys.GenericButton();
            this.btn_depicao = new vatsys.GenericButton();
            this.btn_eobt = new vatsys.GenericButton();
            this.lbl_via = new vatsys.TextLabel();
            this.lbl_route = new vatsys.TextLabel();
            this.btn_alt = new vatsys.GenericButton();
            this.lbl_clbvia = new vatsys.TextLabel();
            this.btn_dep = new vatsys.GenericButton();
            this.btn_freq = new vatsys.GenericButton();
            this.lbl_depfreq = new vatsys.TextLabel();
            this.btn_ssr = new vatsys.GenericButton();
            this.lbl_ssr = new vatsys.TextLabel();
            this.btn_route = new vatsys.GenericButton();
            this.btn_freetxt = new vatsys.GenericButton();
            this.btn_send = new vatsys.GenericButton();
            this.btn_escape = new vatsys.GenericButton();
            this.SuspendLayout();
            // 
            // lbl_acname
            // 
            this.lbl_acname.Font = new System.Drawing.Font("Terminus (TTF)", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lbl_acname.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_acname.HasBorder = false;
            this.lbl_acname.InteractiveText = false;
            this.lbl_acname.Location = new System.Drawing.Point(12, 9);
            this.lbl_acname.Name = "lbl_acname";
            this.lbl_acname.Size = new System.Drawing.Size(397, 18);
            this.lbl_acname.TabIndex = 46;
            this.lbl_acname.Text = "AIRCRAFT NAME";
            this.lbl_acname.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btn_time
            // 
            this.btn_time.Font = new System.Drawing.Font("Terminus (TTF)", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.btn_time.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btn_time.Location = new System.Drawing.Point(56, 31);
            this.btn_time.Name = "btn_time";
            this.btn_time.Size = new System.Drawing.Size(90, 28);
            this.btn_time.SubFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_time.SubText = "";
            this.btn_time.TabIndex = 45;
            this.btn_time.Text = "123456";
            this.btn_time.UseVisualStyleBackColor = true;
            this.btn_time.Click += new System.EventHandler(this.btn_def_Click);
            // 
            // lbl_PDC
            // 
            this.lbl_PDC.AutoSize = true;
            this.lbl_PDC.Font = new System.Drawing.Font("Terminus (TTF)", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lbl_PDC.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_PDC.HasBorder = false;
            this.lbl_PDC.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_PDC.InteractiveText = false;
            this.lbl_PDC.Location = new System.Drawing.Point(12, 36);
            this.lbl_PDC.Name = "lbl_PDC";
            this.lbl_PDC.Size = new System.Drawing.Size(38, 18);
            this.lbl_PDC.TabIndex = 47;
            this.lbl_PDC.Text = "PDC";
            this.lbl_PDC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_PDC.Click += new System.EventHandler(this.label1_Click);
            // 
            // btn_type
            // 
            this.btn_type.Font = new System.Drawing.Font("Terminus (TTF)", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.btn_type.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btn_type.Location = new System.Drawing.Point(111, 65);
            this.btn_type.Name = "btn_type";
            this.btn_type.Size = new System.Drawing.Size(90, 28);
            this.btn_type.SubFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_type.SubText = "";
            this.btn_type.TabIndex = 48;
            this.btn_type.Text = "A123";
            this.btn_type.UseVisualStyleBackColor = true;
            // 
            // lbl_clrto
            // 
            this.lbl_clrto.AutoSize = true;
            this.lbl_clrto.Font = new System.Drawing.Font("Terminus (TTF)", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lbl_clrto.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_clrto.HasBorder = false;
            this.lbl_clrto.InteractiveText = false;
            this.lbl_clrto.Location = new System.Drawing.Point(12, 104);
            this.lbl_clrto.Name = "lbl_clrto";
            this.lbl_clrto.Size = new System.Drawing.Size(108, 18);
            this.lbl_clrto.TabIndex = 51;
            this.lbl_clrto.Text = "CLEARED TO";
            this.lbl_clrto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_clrto.Click += new System.EventHandler(this.label3_Click);
            // 
            // btn_desicao
            // 
            this.btn_desicao.Font = new System.Drawing.Font("Terminus (TTF)", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.btn_desicao.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btn_desicao.Location = new System.Drawing.Point(126, 99);
            this.btn_desicao.Name = "btn_desicao";
            this.btn_desicao.Size = new System.Drawing.Size(90, 28);
            this.btn_desicao.SubFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_desicao.SubText = "";
            this.btn_desicao.TabIndex = 50;
            this.btn_desicao.Text = "ZZZZ";
            this.btn_desicao.UseVisualStyleBackColor = true;
            // 
            // lbl_dep
            // 
            this.lbl_dep.AutoSize = true;
            this.lbl_dep.Font = new System.Drawing.Font("Terminus (TTF)", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lbl_dep.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_dep.HasBorder = false;
            this.lbl_dep.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_dep.InteractiveText = false;
            this.lbl_dep.Location = new System.Drawing.Point(111, 138);
            this.lbl_dep.Name = "lbl_dep";
            this.lbl_dep.Size = new System.Drawing.Size(38, 18);
            this.lbl_dep.TabIndex = 53;
            this.lbl_dep.Text = "DEP";
            this.lbl_dep.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_dep.Click += new System.EventHandler(this.label4_Click);
            // 
            // btn_callsign
            // 
            this.btn_callsign.Font = new System.Drawing.Font("Terminus (TTF)", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.btn_callsign.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btn_callsign.Location = new System.Drawing.Point(15, 65);
            this.btn_callsign.Name = "btn_callsign";
            this.btn_callsign.Size = new System.Drawing.Size(90, 28);
            this.btn_callsign.SubFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_callsign.SubText = "";
            this.btn_callsign.TabIndex = 54;
            this.btn_callsign.Text = "AAA123";
            this.btn_callsign.UseVisualStyleBackColor = true;
            // 
            // btn_depicao
            // 
            this.btn_depicao.Font = new System.Drawing.Font("Terminus (TTF)", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.btn_depicao.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btn_depicao.Location = new System.Drawing.Point(207, 65);
            this.btn_depicao.Name = "btn_depicao";
            this.btn_depicao.Size = new System.Drawing.Size(90, 28);
            this.btn_depicao.SubFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_depicao.SubText = "";
            this.btn_depicao.TabIndex = 55;
            this.btn_depicao.Text = "ZZZZ";
            this.btn_depicao.UseVisualStyleBackColor = true;
            // 
            // btn_eobt
            // 
            this.btn_eobt.Font = new System.Drawing.Font("Terminus (TTF)", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.btn_eobt.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btn_eobt.Location = new System.Drawing.Point(303, 65);
            this.btn_eobt.Name = "btn_eobt";
            this.btn_eobt.Size = new System.Drawing.Size(90, 28);
            this.btn_eobt.SubFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_eobt.SubText = "";
            this.btn_eobt.TabIndex = 56;
            this.btn_eobt.Text = "1234";
            this.btn_eobt.UseVisualStyleBackColor = true;
            // 
            // lbl_via
            // 
            this.lbl_via.AutoSize = true;
            this.lbl_via.Font = new System.Drawing.Font("Terminus (TTF)", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lbl_via.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_via.HasBorder = false;
            this.lbl_via.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_via.InteractiveText = false;
            this.lbl_via.Location = new System.Drawing.Point(222, 104);
            this.lbl_via.Name = "lbl_via";
            this.lbl_via.Size = new System.Drawing.Size(38, 18);
            this.lbl_via.TabIndex = 57;
            this.lbl_via.Text = "VIA";
            this.lbl_via.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_via.Click += new System.EventHandler(this.label2_Click);
            // 
            // lbl_route
            // 
            this.lbl_route.AutoSize = true;
            this.lbl_route.Font = new System.Drawing.Font("Terminus (TTF)", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lbl_route.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_route.HasBorder = false;
            this.lbl_route.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_route.InteractiveText = false;
            this.lbl_route.Location = new System.Drawing.Point(12, 172);
            this.lbl_route.Name = "lbl_route";
            this.lbl_route.Size = new System.Drawing.Size(68, 18);
            this.lbl_route.TabIndex = 59;
            this.lbl_route.Text = "ROUTE:";
            this.lbl_route.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_alt
            // 
            this.btn_alt.Font = new System.Drawing.Font("Terminus (TTF)", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.btn_alt.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btn_alt.Location = new System.Drawing.Point(196, 201);
            this.btn_alt.Name = "btn_alt";
            this.btn_alt.Size = new System.Drawing.Size(90, 28);
            this.btn_alt.SubFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_alt.SubText = "";
            this.btn_alt.TabIndex = 61;
            this.btn_alt.Text = "0000";
            this.btn_alt.UseVisualStyleBackColor = true;
            this.btn_alt.Click += new System.EventHandler(this.genericButton8_Click);
            // 
            // lbl_clbvia
            // 
            this.lbl_clbvia.AutoSize = true;
            this.lbl_clbvia.Font = new System.Drawing.Font("Terminus (TTF)", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lbl_clbvia.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_clbvia.HasBorder = false;
            this.lbl_clbvia.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_clbvia.InteractiveText = false;
            this.lbl_clbvia.Location = new System.Drawing.Point(12, 206);
            this.lbl_clbvia.Name = "lbl_clbvia";
            this.lbl_clbvia.Size = new System.Drawing.Size(178, 18);
            this.lbl_clbvia.TabIndex = 60;
            this.lbl_clbvia.Text = "CLIMB VIA SID TO:";
            this.lbl_clbvia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_clbvia.Click += new System.EventHandler(this.label6_Click);
            // 
            // btn_dep
            // 
            this.btn_dep.Font = new System.Drawing.Font("Terminus (TTF)", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.btn_dep.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btn_dep.Location = new System.Drawing.Point(15, 133);
            this.btn_dep.Name = "btn_dep";
            this.btn_dep.Size = new System.Drawing.Size(90, 28);
            this.btn_dep.SubFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_dep.SubText = "";
            this.btn_dep.TabIndex = 62;
            this.btn_dep.Text = "ABCDE1";
            this.btn_dep.UseVisualStyleBackColor = true;
            // 
            // btn_freq
            // 
            this.btn_freq.Font = new System.Drawing.Font("Terminus (TTF)", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.btn_freq.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btn_freq.Location = new System.Drawing.Point(116, 235);
            this.btn_freq.Name = "btn_freq";
            this.btn_freq.Size = new System.Drawing.Size(90, 28);
            this.btn_freq.SubFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_freq.SubText = "";
            this.btn_freq.TabIndex = 65;
            this.btn_freq.Text = "123.45";
            this.btn_freq.UseVisualStyleBackColor = true;
            // 
            // lbl_depfreq
            // 
            this.lbl_depfreq.AutoSize = true;
            this.lbl_depfreq.Font = new System.Drawing.Font("Terminus (TTF)", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lbl_depfreq.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_depfreq.HasBorder = false;
            this.lbl_depfreq.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_depfreq.InteractiveText = false;
            this.lbl_depfreq.Location = new System.Drawing.Point(12, 240);
            this.lbl_depfreq.Name = "lbl_depfreq";
            this.lbl_depfreq.Size = new System.Drawing.Size(98, 18);
            this.lbl_depfreq.TabIndex = 64;
            this.lbl_depfreq.Text = "DEP FREQ:";
            this.lbl_depfreq.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_depfreq.Click += new System.EventHandler(this.label7_Click);
            // 
            // btn_ssr
            // 
            this.btn_ssr.Font = new System.Drawing.Font("Terminus (TTF)", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.btn_ssr.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btn_ssr.Location = new System.Drawing.Point(86, 269);
            this.btn_ssr.Name = "btn_ssr";
            this.btn_ssr.Size = new System.Drawing.Size(90, 28);
            this.btn_ssr.SubFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ssr.SubText = "";
            this.btn_ssr.TabIndex = 67;
            this.btn_ssr.Text = "1234";
            this.btn_ssr.UseVisualStyleBackColor = true;
            // 
            // lbl_ssr
            // 
            this.lbl_ssr.AutoSize = true;
            this.lbl_ssr.Font = new System.Drawing.Font("Terminus (TTF)", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lbl_ssr.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_ssr.HasBorder = false;
            this.lbl_ssr.InteractiveText = false;
            this.lbl_ssr.Location = new System.Drawing.Point(12, 274);
            this.lbl_ssr.Name = "lbl_ssr";
            this.lbl_ssr.Size = new System.Drawing.Size(68, 18);
            this.lbl_ssr.TabIndex = 66;
            this.lbl_ssr.Text = "SQUAWK";
            this.lbl_ssr.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_route
            // 
            this.btn_route.Font = new System.Drawing.Font("Terminus (TTF)", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.btn_route.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btn_route.Location = new System.Drawing.Point(86, 167);
            this.btn_route.Name = "btn_route";
            this.btn_route.Size = new System.Drawing.Size(307, 28);
            this.btn_route.SubFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_route.SubText = "";
            this.btn_route.TabIndex = 58;
            this.btn_route.Text = "ABC ABC ABC ABC";
            this.btn_route.UseVisualStyleBackColor = true;
            // 
            // btn_freetxt
            // 
            this.btn_freetxt.Font = new System.Drawing.Font("Terminus (TTF)", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.btn_freetxt.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btn_freetxt.Location = new System.Drawing.Point(15, 303);
            this.btn_freetxt.Name = "btn_freetxt";
            this.btn_freetxt.Size = new System.Drawing.Size(378, 28);
            this.btn_freetxt.SubFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_freetxt.SubText = "";
            this.btn_freetxt.TabIndex = 68;
            this.btn_freetxt.Text = "Free Content";
            this.btn_freetxt.UseVisualStyleBackColor = true;
            // 
            // btn_send
            // 
            this.btn_send.Font = new System.Drawing.Font("Terminus (TTF)", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.btn_send.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btn_send.Location = new System.Drawing.Point(15, 337);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(90, 28);
            this.btn_send.SubFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_send.SubText = "";
            this.btn_send.TabIndex = 69;
            this.btn_send.Text = "Send";
            this.btn_send.UseVisualStyleBackColor = true;
            // 
            // btn_escape
            // 
            this.btn_escape.Font = new System.Drawing.Font("Terminus (TTF)", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.btn_escape.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btn_escape.Location = new System.Drawing.Point(303, 337);
            this.btn_escape.Name = "btn_escape";
            this.btn_escape.Size = new System.Drawing.Size(90, 28);
            this.btn_escape.SubFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_escape.SubText = "";
            this.btn_escape.TabIndex = 70;
            this.btn_escape.Text = "Escape";
            this.btn_escape.UseVisualStyleBackColor = true;
            // 
            // PDCWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 370);
            this.ControlBox = false;
            this.Controls.Add(this.btn_escape);
            this.Controls.Add(this.btn_send);
            this.Controls.Add(this.btn_freetxt);
            this.Controls.Add(this.btn_ssr);
            this.Controls.Add(this.lbl_ssr);
            this.Controls.Add(this.btn_freq);
            this.Controls.Add(this.lbl_depfreq);
            this.Controls.Add(this.btn_dep);
            this.Controls.Add(this.btn_alt);
            this.Controls.Add(this.lbl_clbvia);
            this.Controls.Add(this.lbl_route);
            this.Controls.Add(this.btn_route);
            this.Controls.Add(this.lbl_via);
            this.Controls.Add(this.btn_eobt);
            this.Controls.Add(this.btn_depicao);
            this.Controls.Add(this.btn_callsign);
            this.Controls.Add(this.lbl_dep);
            this.Controls.Add(this.lbl_clrto);
            this.Controls.Add(this.btn_desicao);
            this.Controls.Add(this.btn_type);
            this.Controls.Add(this.lbl_PDC);
            this.Controls.Add(this.lbl_acname);
            this.Controls.Add(this.btn_time);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HasSendBackButton = false;
            this.HideOnClose = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MiddleClickClose = false;
            this.Name = "PDCWindow";
            this.Resizeable = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "PDC Editor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private vatsys.TextLabel lbl_acname;
        private vatsys.GenericButton btn_time;
        private vatsys.TextLabel lbl_PDC;
        private vatsys.GenericButton btn_type;
        private vatsys.TextLabel lbl_clrto;
        private vatsys.GenericButton btn_desicao;
        private vatsys.TextLabel lbl_dep;
        private vatsys.GenericButton btn_callsign;
        private vatsys.GenericButton btn_depicao;
        private vatsys.GenericButton btn_eobt;
        private vatsys.TextLabel lbl_via;
        private vatsys.TextLabel lbl_route;
        private vatsys.GenericButton btn_alt;
        private vatsys.TextLabel lbl_clbvia;
        private vatsys.GenericButton btn_dep;
        private vatsys.GenericButton btn_freq;
        private vatsys.TextLabel lbl_depfreq;
        private vatsys.GenericButton btn_ssr;
        private vatsys.TextLabel lbl_ssr;
        private vatsys.GenericButton btn_route;
        private vatsys.GenericButton btn_freetxt;
        private vatsys.GenericButton btn_send;
        private vatsys.GenericButton btn_escape;
    }
}