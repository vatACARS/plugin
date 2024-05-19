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
            this.btn_time = new vatsys.GenericButton();
            this.lbl_PDC = new vatsys.TextLabel();
            this.btn_type = new vatsys.GenericButton();
            this.lbl_dep = new vatsys.TextLabel();
            this.btn_callsign = new vatsys.GenericButton();
            this.lbl_route = new vatsys.TextLabel();
            this.lbl_freq = new vatsys.TextLabel();
            this.lbl_ssr = new vatsys.TextLabel();
            this.lbl_callsign = new vatsys.TextLabel();
            this.lbl_type = new vatsys.TextLabel();
            this.btn_dep = new vatsys.GenericButton();
            this.lbl_runway = new vatsys.TextLabel();
            this.btn_runway = new vatsys.GenericButton();
            this.lbl_clrto = new vatsys.TextLabel();
            this.btn_dest = new vatsys.GenericButton();
            this.lbl_via = new vatsys.TextLabel();
            this.btn_via = new vatsys.GenericButton();
            this.lbl_climb = new vatsys.TextLabel();
            this.btn_climb = new vatsys.GenericButton();
            this.btn_free = new vatsys.GenericButton();
            this.btn_ssr = new vatsys.GenericButton();
            this.btn_freq = new vatsys.GenericButton();
            this.btn_route = new vatsys.GenericButton();
            this.lbl_free = new vatsys.TextLabel();
            this.btn_send = new vatsys.GenericButton();
            this.SuspendLayout();
            // 
            // btn_time
            // 
            this.btn_time.Font = new System.Drawing.Font("Terminus (TTF)", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.btn_time.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btn_time.Location = new System.Drawing.Point(144, 6);
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
            this.lbl_PDC.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_PDC.Font = new System.Drawing.Font("Terminus (TTF)", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lbl_PDC.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_PDC.HasBorder = false;
            this.lbl_PDC.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_PDC.InteractiveText = true;
            this.lbl_PDC.Location = new System.Drawing.Point(8, 9);
            this.lbl_PDC.Name = "lbl_PDC";
            this.lbl_PDC.Size = new System.Drawing.Size(130, 21);
            this.lbl_PDC.TabIndex = 47;
            this.lbl_PDC.Text = "PDC        :";
            this.lbl_PDC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_PDC.Click += new System.EventHandler(this.label1_Click);
            // 
            // btn_type
            // 
            this.btn_type.Font = new System.Drawing.Font("Terminus (TTF)", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.btn_type.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btn_type.Location = new System.Drawing.Point(429, 6);
            this.btn_type.Name = "btn_type";
            this.btn_type.Size = new System.Drawing.Size(90, 28);
            this.btn_type.SubFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_type.SubText = "";
            this.btn_type.TabIndex = 48;
            this.btn_type.Text = "B738";
            this.btn_type.UseVisualStyleBackColor = true;
            // 
            // lbl_dep
            // 
            this.lbl_dep.AutoSize = true;
            this.lbl_dep.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_dep.Font = new System.Drawing.Font("Terminus (TTF)", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lbl_dep.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_dep.HasBorder = false;
            this.lbl_dep.InteractiveText = true;
            this.lbl_dep.Location = new System.Drawing.Point(8, 77);
            this.lbl_dep.Name = "lbl_dep";
            this.lbl_dep.Size = new System.Drawing.Size(130, 21);
            this.lbl_dep.TabIndex = 51;
            this.lbl_dep.Text = "DEPARTURE  :";
            this.lbl_dep.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_dep.Click += new System.EventHandler(this.label3_Click);
            // 
            // btn_callsign
            // 
            this.btn_callsign.Font = new System.Drawing.Font("Terminus (TTF)", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.btn_callsign.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btn_callsign.Location = new System.Drawing.Point(144, 40);
            this.btn_callsign.Name = "btn_callsign";
            this.btn_callsign.Size = new System.Drawing.Size(90, 28);
            this.btn_callsign.SubFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_callsign.SubText = "";
            this.btn_callsign.TabIndex = 54;
            this.btn_callsign.Text = "QFA123";
            this.btn_callsign.UseVisualStyleBackColor = true;
            // 
            // lbl_route
            // 
            this.lbl_route.AutoSize = true;
            this.lbl_route.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_route.Font = new System.Drawing.Font("Terminus (TTF)", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lbl_route.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_route.HasBorder = false;
            this.lbl_route.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_route.InteractiveText = true;
            this.lbl_route.Location = new System.Drawing.Point(8, 179);
            this.lbl_route.Name = "lbl_route";
            this.lbl_route.Size = new System.Drawing.Size(130, 21);
            this.lbl_route.TabIndex = 59;
            this.lbl_route.Text = "ROUTE      :";
            this.lbl_route.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_freq
            // 
            this.lbl_freq.AutoSize = true;
            this.lbl_freq.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_freq.Font = new System.Drawing.Font("Terminus (TTF)", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lbl_freq.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_freq.HasBorder = false;
            this.lbl_freq.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_freq.InteractiveText = true;
            this.lbl_freq.Location = new System.Drawing.Point(323, 77);
            this.lbl_freq.Name = "lbl_freq";
            this.lbl_freq.Size = new System.Drawing.Size(100, 21);
            this.lbl_freq.TabIndex = 64;
            this.lbl_freq.Text = "DEP FREQ:";
            this.lbl_freq.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_freq.Click += new System.EventHandler(this.label7_Click);
            // 
            // lbl_ssr
            // 
            this.lbl_ssr.AutoSize = true;
            this.lbl_ssr.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_ssr.Font = new System.Drawing.Font("Terminus (TTF)", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lbl_ssr.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_ssr.HasBorder = false;
            this.lbl_ssr.InteractiveText = true;
            this.lbl_ssr.Location = new System.Drawing.Point(323, 145);
            this.lbl_ssr.Name = "lbl_ssr";
            this.lbl_ssr.Size = new System.Drawing.Size(100, 21);
            this.lbl_ssr.TabIndex = 66;
            this.lbl_ssr.Text = "SQUAWK  :";
            this.lbl_ssr.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_callsign
            // 
            this.lbl_callsign.AutoSize = true;
            this.lbl_callsign.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_callsign.Font = new System.Drawing.Font("Terminus (TTF)", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lbl_callsign.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_callsign.HasBorder = false;
            this.lbl_callsign.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_callsign.InteractiveText = true;
            this.lbl_callsign.Location = new System.Drawing.Point(8, 43);
            this.lbl_callsign.Name = "lbl_callsign";
            this.lbl_callsign.Size = new System.Drawing.Size(130, 21);
            this.lbl_callsign.TabIndex = 71;
            this.lbl_callsign.Text = "CALLSIGN   :";
            this.lbl_callsign.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_type
            // 
            this.lbl_type.AutoSize = true;
            this.lbl_type.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_type.Font = new System.Drawing.Font("Terminus (TTF)", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lbl_type.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_type.HasBorder = false;
            this.lbl_type.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_type.InteractiveText = true;
            this.lbl_type.Location = new System.Drawing.Point(323, 9);
            this.lbl_type.Name = "lbl_type";
            this.lbl_type.Size = new System.Drawing.Size(100, 21);
            this.lbl_type.TabIndex = 72;
            this.lbl_type.Text = "TYPE    :";
            this.lbl_type.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_dep
            // 
            this.btn_dep.Font = new System.Drawing.Font("Terminus (TTF)", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.btn_dep.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btn_dep.Location = new System.Drawing.Point(144, 74);
            this.btn_dep.Name = "btn_dep";
            this.btn_dep.Size = new System.Drawing.Size(90, 28);
            this.btn_dep.SubFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_dep.SubText = "";
            this.btn_dep.TabIndex = 73;
            this.btn_dep.Text = "ZZZZ";
            this.btn_dep.UseVisualStyleBackColor = true;
            // 
            // lbl_runway
            // 
            this.lbl_runway.AutoSize = true;
            this.lbl_runway.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_runway.Font = new System.Drawing.Font("Terminus (TTF)", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lbl_runway.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_runway.HasBorder = false;
            this.lbl_runway.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_runway.InteractiveText = true;
            this.lbl_runway.Location = new System.Drawing.Point(323, 43);
            this.lbl_runway.Name = "lbl_runway";
            this.lbl_runway.Size = new System.Drawing.Size(100, 21);
            this.lbl_runway.TabIndex = 74;
            this.lbl_runway.Text = "RUNWAY  :";
            this.lbl_runway.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_runway
            // 
            this.btn_runway.Font = new System.Drawing.Font("Terminus (TTF)", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.btn_runway.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btn_runway.Location = new System.Drawing.Point(429, 40);
            this.btn_runway.Name = "btn_runway";
            this.btn_runway.Size = new System.Drawing.Size(90, 28);
            this.btn_runway.SubFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_runway.SubText = "";
            this.btn_runway.TabIndex = 75;
            this.btn_runway.Text = "16L";
            this.btn_runway.UseVisualStyleBackColor = true;
            // 
            // lbl_clrto
            // 
            this.lbl_clrto.AutoSize = true;
            this.lbl_clrto.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_clrto.Font = new System.Drawing.Font("Terminus (TTF)", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lbl_clrto.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_clrto.HasBorder = false;
            this.lbl_clrto.InteractiveText = true;
            this.lbl_clrto.Location = new System.Drawing.Point(8, 111);
            this.lbl_clrto.Name = "lbl_clrto";
            this.lbl_clrto.Size = new System.Drawing.Size(130, 21);
            this.lbl_clrto.TabIndex = 76;
            this.lbl_clrto.Text = "CLEARED TO :";
            this.lbl_clrto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_dest
            // 
            this.btn_dest.Font = new System.Drawing.Font("Terminus (TTF)", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.btn_dest.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btn_dest.Location = new System.Drawing.Point(144, 108);
            this.btn_dest.Name = "btn_dest";
            this.btn_dest.Size = new System.Drawing.Size(90, 28);
            this.btn_dest.SubFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_dest.SubText = "";
            this.btn_dest.TabIndex = 77;
            this.btn_dest.Text = "ZZZZ";
            this.btn_dest.UseVisualStyleBackColor = true;
            // 
            // lbl_via
            // 
            this.lbl_via.AutoSize = true;
            this.lbl_via.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_via.Font = new System.Drawing.Font("Terminus (TTF)", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lbl_via.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_via.HasBorder = false;
            this.lbl_via.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_via.InteractiveText = true;
            this.lbl_via.Location = new System.Drawing.Point(8, 146);
            this.lbl_via.Name = "lbl_via";
            this.lbl_via.Size = new System.Drawing.Size(130, 21);
            this.lbl_via.TabIndex = 78;
            this.lbl_via.Text = "VIA        :";
            this.lbl_via.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_via
            // 
            this.btn_via.Font = new System.Drawing.Font("Terminus (TTF)", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.btn_via.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btn_via.Location = new System.Drawing.Point(144, 142);
            this.btn_via.Name = "btn_via";
            this.btn_via.Size = new System.Drawing.Size(90, 28);
            this.btn_via.SubFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_via.SubText = "";
            this.btn_via.TabIndex = 79;
            this.btn_via.Text = "ABCDE1";
            this.btn_via.UseVisualStyleBackColor = true;
            // 
            // lbl_climb
            // 
            this.lbl_climb.AutoSize = true;
            this.lbl_climb.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_climb.Font = new System.Drawing.Font("Terminus (TTF)", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lbl_climb.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_climb.HasBorder = false;
            this.lbl_climb.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_climb.InteractiveText = true;
            this.lbl_climb.Location = new System.Drawing.Point(323, 111);
            this.lbl_climb.Name = "lbl_climb";
            this.lbl_climb.Size = new System.Drawing.Size(100, 21);
            this.lbl_climb.TabIndex = 80;
            this.lbl_climb.Text = "CLIMB   :";
            this.lbl_climb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_climb
            // 
            this.btn_climb.Font = new System.Drawing.Font("Terminus (TTF)", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.btn_climb.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btn_climb.Location = new System.Drawing.Point(429, 108);
            this.btn_climb.Name = "btn_climb";
            this.btn_climb.Size = new System.Drawing.Size(90, 28);
            this.btn_climb.SubFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_climb.SubText = "";
            this.btn_climb.TabIndex = 81;
            this.btn_climb.Text = "5000";
            this.btn_climb.UseVisualStyleBackColor = true;
            // 
            // btn_free
            // 
            this.btn_free.Font = new System.Drawing.Font("Terminus (TTF)", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.btn_free.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btn_free.Location = new System.Drawing.Point(144, 210);
            this.btn_free.Name = "btn_free";
            this.btn_free.Size = new System.Drawing.Size(375, 28);
            this.btn_free.SubFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_free.SubText = "";
            this.btn_free.TabIndex = 82;
            this.btn_free.Text = "FREE TEXT";
            this.btn_free.UseVisualStyleBackColor = true;
            // 
            // btn_ssr
            // 
            this.btn_ssr.Font = new System.Drawing.Font("Terminus (TTF)", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.btn_ssr.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btn_ssr.Location = new System.Drawing.Point(429, 142);
            this.btn_ssr.Name = "btn_ssr";
            this.btn_ssr.Size = new System.Drawing.Size(90, 28);
            this.btn_ssr.SubFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ssr.SubText = "";
            this.btn_ssr.TabIndex = 83;
            this.btn_ssr.Text = "1234";
            this.btn_ssr.UseVisualStyleBackColor = true;
            // 
            // btn_freq
            // 
            this.btn_freq.Font = new System.Drawing.Font("Terminus (TTF)", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.btn_freq.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btn_freq.Location = new System.Drawing.Point(429, 74);
            this.btn_freq.Name = "btn_freq";
            this.btn_freq.Size = new System.Drawing.Size(90, 28);
            this.btn_freq.SubFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_freq.SubText = "";
            this.btn_freq.TabIndex = 84;
            this.btn_freq.Text = "123.45";
            this.btn_freq.UseVisualStyleBackColor = true;
            // 
            // btn_route
            // 
            this.btn_route.Font = new System.Drawing.Font("Terminus (TTF)", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.btn_route.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btn_route.Location = new System.Drawing.Point(144, 176);
            this.btn_route.Name = "btn_route";
            this.btn_route.Size = new System.Drawing.Size(375, 28);
            this.btn_route.SubFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_route.SubText = "";
            this.btn_route.TabIndex = 86;
            this.btn_route.Text = "DCT ZZZZ DCT ZZZZ";
            this.btn_route.UseVisualStyleBackColor = true;
            // 
            // lbl_free
            // 
            this.lbl_free.AutoSize = true;
            this.lbl_free.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_free.Font = new System.Drawing.Font("Terminus (TTF)", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lbl_free.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_free.HasBorder = false;
            this.lbl_free.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_free.InteractiveText = true;
            this.lbl_free.Location = new System.Drawing.Point(8, 213);
            this.lbl_free.Name = "lbl_free";
            this.lbl_free.Size = new System.Drawing.Size(130, 21);
            this.lbl_free.TabIndex = 87;
            this.lbl_free.Text = "FREE TEXT  :";
            this.lbl_free.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_send
            // 
            this.btn_send.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_send.Font = new System.Drawing.Font("Terminus (TTF)", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.btn_send.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btn_send.Location = new System.Drawing.Point(429, 244);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(90, 28);
            this.btn_send.SubFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_send.SubText = "";
            this.btn_send.TabIndex = 88;
            this.btn_send.Text = "SEND";
            this.btn_send.UseVisualStyleBackColor = true;
            // 
            // PDCWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 284);
            this.ControlBox = false;
            this.Controls.Add(this.btn_send);
            this.Controls.Add(this.lbl_free);
            this.Controls.Add(this.btn_route);
            this.Controls.Add(this.btn_freq);
            this.Controls.Add(this.btn_ssr);
            this.Controls.Add(this.btn_free);
            this.Controls.Add(this.btn_climb);
            this.Controls.Add(this.lbl_climb);
            this.Controls.Add(this.btn_via);
            this.Controls.Add(this.lbl_via);
            this.Controls.Add(this.btn_dest);
            this.Controls.Add(this.lbl_clrto);
            this.Controls.Add(this.btn_runway);
            this.Controls.Add(this.lbl_runway);
            this.Controls.Add(this.btn_dep);
            this.Controls.Add(this.lbl_type);
            this.Controls.Add(this.lbl_callsign);
            this.Controls.Add(this.lbl_ssr);
            this.Controls.Add(this.lbl_freq);
            this.Controls.Add(this.lbl_route);
            this.Controls.Add(this.btn_callsign);
            this.Controls.Add(this.lbl_dep);
            this.Controls.Add(this.btn_type);
            this.Controls.Add(this.lbl_PDC);
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
            this.Load += new System.EventHandler(this.PDCWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private vatsys.GenericButton btn_time;
        private vatsys.TextLabel lbl_PDC;
        private vatsys.GenericButton btn_type;
        private vatsys.TextLabel lbl_dep;
        private vatsys.GenericButton btn_callsign;
        private vatsys.TextLabel lbl_route;
        private vatsys.TextLabel lbl_freq;
        private vatsys.TextLabel lbl_ssr;
        private vatsys.TextLabel lbl_callsign;
        private vatsys.TextLabel lbl_type;
        private vatsys.GenericButton btn_dep;
        private vatsys.TextLabel lbl_runway;
        private vatsys.GenericButton btn_runway;
        private vatsys.TextLabel lbl_clrto;
        private vatsys.GenericButton btn_dest;
        private vatsys.TextLabel lbl_via;
        private vatsys.GenericButton btn_via;
        private vatsys.TextLabel lbl_climb;
        private vatsys.GenericButton btn_climb;
        private vatsys.GenericButton btn_free;
        private vatsys.GenericButton btn_ssr;
        private vatsys.GenericButton btn_freq;
        private vatsys.GenericButton btn_route;
        private vatsys.TextLabel lbl_free;
        private vatsys.GenericButton btn_send;
    }
}