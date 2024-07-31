namespace vatACARS.Components
{
    partial class DebugWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DebugWindow));
            this.tbx_content = new vatsys.TextField();
            this.insetPanel2 = new vatsys.InsetPanel();
            this.dd_type = new VATSYSControls.DropDownBox();
            this.lbl_type = new vatsys.TextLabel();
            this.btn_add = new vatsys.GenericButton();
            this.dd_state = new VATSYSControls.DropDownBox();
            this.lbl_state = new vatsys.TextLabel();
            this.lbl_content = new vatsys.TextLabel();
            this.tbx_station = new vatsys.TextField();
            this.lbl_callsign = new vatsys.TextLabel();
            this.lbl_messagecreate = new vatsys.TextLabel();
            this.insetPanel1 = new vatsys.InsetPanel();
            this.lbl_prov = new vatsys.TextLabel();
            this.dd_prov = new VATSYSControls.DropDownBox();
            this.btn_screate = new vatsys.GenericButton();
            this.tbx_stationc = new vatsys.TextField();
            this.lbl_stationc = new vatsys.TextLabel();
            this.lbl_stationcreate = new vatsys.TextLabel();
            this.btn_netchecks = new vatsys.GenericButton();
            this.lbl_netchecks = new vatsys.TextLabel();
            this.btn_rdmstn = new vatsys.GenericButton();
            this.lbl_rdmstn = new vatsys.TextLabel();
            this.insetPanel2.SuspendLayout();
            this.insetPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbx_content
            // 
            this.tbx_content.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbx_content.BackColor = System.Drawing.SystemColors.ControlDark;
            this.tbx_content.Font = new System.Drawing.Font("Terminus (TTF)", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.tbx_content.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.tbx_content.Location = new System.Drawing.Point(81, 63);
            this.tbx_content.Name = "tbx_content";
            this.tbx_content.NumericCharOnly = false;
            this.tbx_content.OctalOnly = false;
            this.tbx_content.Size = new System.Drawing.Size(360, 25);
            this.tbx_content.TabIndex = 16;
            // 
            // insetPanel2
            // 
            this.insetPanel2.Controls.Add(this.dd_type);
            this.insetPanel2.Controls.Add(this.lbl_type);
            this.insetPanel2.Controls.Add(this.btn_add);
            this.insetPanel2.Controls.Add(this.dd_state);
            this.insetPanel2.Controls.Add(this.lbl_state);
            this.insetPanel2.Controls.Add(this.lbl_content);
            this.insetPanel2.Controls.Add(this.tbx_station);
            this.insetPanel2.Controls.Add(this.lbl_callsign);
            this.insetPanel2.Controls.Add(this.lbl_messagecreate);
            this.insetPanel2.Controls.Add(this.tbx_content);
            this.insetPanel2.Location = new System.Drawing.Point(12, 12);
            this.insetPanel2.Name = "insetPanel2";
            this.insetPanel2.Size = new System.Drawing.Size(457, 128);
            this.insetPanel2.TabIndex = 17;
            // 
            // dd_type
            // 
            this.dd_type.BackColor = System.Drawing.SystemColors.ControlDark;
            this.dd_type.FocusColor = System.Drawing.Color.Cyan;
            this.dd_type.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.dd_type.Items = ((System.Collections.ObjectModel.ObservableCollection<string>)(resources.GetObject("dd_type.Items")));
            this.dd_type.Location = new System.Drawing.Point(205, 94);
            this.dd_type.Name = "dd_type";
            this.dd_type.SelectedIndex = -1;
            this.dd_type.Size = new System.Drawing.Size(131, 25);
            this.dd_type.TabIndex = 108;
            // 
            // lbl_type
            // 
            this.lbl_type.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbl_type.Font = new System.Drawing.Font("Terminus (TTF)", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lbl_type.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_type.HasBorder = false;
            this.lbl_type.InteractiveText = true;
            this.lbl_type.Location = new System.Drawing.Point(127, 92);
            this.lbl_type.Name = "lbl_type";
            this.lbl_type.Size = new System.Drawing.Size(72, 26);
            this.lbl_type.TabIndex = 107;
            this.lbl_type.Text = "TYPE:";
            this.lbl_type.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_add
            // 
            this.btn_add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_add.Font = new System.Drawing.Font("Terminus (TTF)", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.btn_add.Location = new System.Drawing.Point(342, 94);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(99, 28);
            this.btn_add.SubFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add.SubText = "";
            this.btn_add.TabIndex = 106;
            this.btn_add.Text = "ADD MESSAGE";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // dd_state
            // 
            this.dd_state.BackColor = System.Drawing.SystemColors.ControlDark;
            this.dd_state.FocusColor = System.Drawing.Color.Cyan;
            this.dd_state.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.dd_state.Items = ((System.Collections.ObjectModel.ObservableCollection<string>)(resources.GetObject("dd_state.Items")));
            this.dd_state.Location = new System.Drawing.Point(81, 94);
            this.dd_state.Name = "dd_state";
            this.dd_state.SelectedIndex = -1;
            this.dd_state.Size = new System.Drawing.Size(40, 25);
            this.dd_state.TabIndex = 103;
            // 
            // lbl_state
            // 
            this.lbl_state.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbl_state.Font = new System.Drawing.Font("Terminus (TTF)", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lbl_state.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_state.HasBorder = false;
            this.lbl_state.InteractiveText = true;
            this.lbl_state.Location = new System.Drawing.Point(3, 92);
            this.lbl_state.Name = "lbl_state";
            this.lbl_state.Size = new System.Drawing.Size(72, 26);
            this.lbl_state.TabIndex = 33;
            this.lbl_state.Text = "STATE:";
            this.lbl_state.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_content
            // 
            this.lbl_content.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbl_content.Font = new System.Drawing.Font("Terminus (TTF)", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lbl_content.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_content.HasBorder = false;
            this.lbl_content.InteractiveText = true;
            this.lbl_content.Location = new System.Drawing.Point(3, 61);
            this.lbl_content.Name = "lbl_content";
            this.lbl_content.Size = new System.Drawing.Size(72, 26);
            this.lbl_content.TabIndex = 31;
            this.lbl_content.Text = "CONTENT:";
            this.lbl_content.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbx_station
            // 
            this.tbx_station.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbx_station.BackColor = System.Drawing.SystemColors.ControlDark;
            this.tbx_station.Font = new System.Drawing.Font("Terminus (TTF)", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.tbx_station.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.tbx_station.Location = new System.Drawing.Point(81, 32);
            this.tbx_station.Name = "tbx_station";
            this.tbx_station.NumericCharOnly = false;
            this.tbx_station.OctalOnly = false;
            this.tbx_station.Size = new System.Drawing.Size(107, 25);
            this.tbx_station.TabIndex = 30;
            // 
            // lbl_callsign
            // 
            this.lbl_callsign.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbl_callsign.Font = new System.Drawing.Font("Terminus (TTF)", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lbl_callsign.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_callsign.HasBorder = false;
            this.lbl_callsign.InteractiveText = true;
            this.lbl_callsign.Location = new System.Drawing.Point(3, 29);
            this.lbl_callsign.Name = "lbl_callsign";
            this.lbl_callsign.Size = new System.Drawing.Size(72, 26);
            this.lbl_callsign.TabIndex = 29;
            this.lbl_callsign.Text = "STATION:";
            this.lbl_callsign.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_messagecreate
            // 
            this.lbl_messagecreate.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbl_messagecreate.Font = new System.Drawing.Font("Terminus (TTF)", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lbl_messagecreate.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_messagecreate.HasBorder = false;
            this.lbl_messagecreate.InteractiveText = true;
            this.lbl_messagecreate.Location = new System.Drawing.Point(3, 3);
            this.lbl_messagecreate.Name = "lbl_messagecreate";
            this.lbl_messagecreate.Size = new System.Drawing.Size(192, 26);
            this.lbl_messagecreate.TabIndex = 28;
            this.lbl_messagecreate.Text = "MESSAGE CREATOR";
            this.lbl_messagecreate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // insetPanel1
            // 
            this.insetPanel1.Controls.Add(this.lbl_rdmstn);
            this.insetPanel1.Controls.Add(this.btn_rdmstn);
            this.insetPanel1.Controls.Add(this.lbl_prov);
            this.insetPanel1.Controls.Add(this.dd_prov);
            this.insetPanel1.Controls.Add(this.btn_screate);
            this.insetPanel1.Controls.Add(this.tbx_stationc);
            this.insetPanel1.Controls.Add(this.lbl_stationc);
            this.insetPanel1.Controls.Add(this.lbl_stationcreate);
            this.insetPanel1.Location = new System.Drawing.Point(12, 146);
            this.insetPanel1.Name = "insetPanel1";
            this.insetPanel1.Size = new System.Drawing.Size(457, 97);
            this.insetPanel1.TabIndex = 109;
            // 
            // lbl_prov
            // 
            this.lbl_prov.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbl_prov.Font = new System.Drawing.Font("Terminus (TTF)", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lbl_prov.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_prov.HasBorder = false;
            this.lbl_prov.InteractiveText = true;
            this.lbl_prov.Location = new System.Drawing.Point(194, 29);
            this.lbl_prov.Name = "lbl_prov";
            this.lbl_prov.Size = new System.Drawing.Size(83, 26);
            this.lbl_prov.TabIndex = 109;
            this.lbl_prov.Text = "PROVIDER:";
            this.lbl_prov.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dd_prov
            // 
            this.dd_prov.BackColor = System.Drawing.SystemColors.ControlDark;
            this.dd_prov.FocusColor = System.Drawing.Color.Cyan;
            this.dd_prov.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.dd_prov.Items = ((System.Collections.ObjectModel.ObservableCollection<string>)(resources.GetObject("dd_prov.Items")));
            this.dd_prov.Location = new System.Drawing.Point(283, 32);
            this.dd_prov.Name = "dd_prov";
            this.dd_prov.SelectedIndex = -1;
            this.dd_prov.Size = new System.Drawing.Size(40, 25);
            this.dd_prov.TabIndex = 109;
            // 
            // btn_screate
            // 
            this.btn_screate.Font = new System.Drawing.Font("Terminus (TTF)", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.btn_screate.Location = new System.Drawing.Point(342, 32);
            this.btn_screate.Name = "btn_screate";
            this.btn_screate.Size = new System.Drawing.Size(99, 28);
            this.btn_screate.SubFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_screate.SubText = "";
            this.btn_screate.TabIndex = 106;
            this.btn_screate.Text = "ADD STATION";
            this.btn_screate.UseVisualStyleBackColor = true;
            this.btn_screate.Click += new System.EventHandler(this.btn_screate_Click);
            // 
            // tbx_stationc
            // 
            this.tbx_stationc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbx_stationc.BackColor = System.Drawing.SystemColors.ControlDark;
            this.tbx_stationc.Font = new System.Drawing.Font("Terminus (TTF)", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.tbx_stationc.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.tbx_stationc.Location = new System.Drawing.Point(81, 32);
            this.tbx_stationc.Name = "tbx_stationc";
            this.tbx_stationc.NumericCharOnly = false;
            this.tbx_stationc.OctalOnly = false;
            this.tbx_stationc.Size = new System.Drawing.Size(107, 25);
            this.tbx_stationc.TabIndex = 30;
            // 
            // lbl_stationc
            // 
            this.lbl_stationc.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbl_stationc.Font = new System.Drawing.Font("Terminus (TTF)", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lbl_stationc.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_stationc.HasBorder = false;
            this.lbl_stationc.InteractiveText = true;
            this.lbl_stationc.Location = new System.Drawing.Point(3, 29);
            this.lbl_stationc.Name = "lbl_stationc";
            this.lbl_stationc.Size = new System.Drawing.Size(72, 26);
            this.lbl_stationc.TabIndex = 29;
            this.lbl_stationc.Text = "STATION:";
            this.lbl_stationc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_stationcreate
            // 
            this.lbl_stationcreate.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbl_stationcreate.Font = new System.Drawing.Font("Terminus (TTF)", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lbl_stationcreate.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_stationcreate.HasBorder = false;
            this.lbl_stationcreate.InteractiveText = true;
            this.lbl_stationcreate.Location = new System.Drawing.Point(3, 3);
            this.lbl_stationcreate.Name = "lbl_stationcreate";
            this.lbl_stationcreate.Size = new System.Drawing.Size(134, 26);
            this.lbl_stationcreate.TabIndex = 28;
            this.lbl_stationcreate.Text = "STATION CREATOR";
            this.lbl_stationcreate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_netchecks
            // 
            this.btn_netchecks.Font = new System.Drawing.Font("Terminus (TTF)", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.btn_netchecks.Location = new System.Drawing.Point(174, 249);
            this.btn_netchecks.Name = "btn_netchecks";
            this.btn_netchecks.Size = new System.Drawing.Size(26, 26);
            this.btn_netchecks.SubFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_netchecks.SubText = "";
            this.btn_netchecks.TabIndex = 111;
            this.btn_netchecks.UseVisualStyleBackColor = true;
            this.btn_netchecks.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_netchecks_MouseUp);
            // 
            // lbl_netchecks
            // 
            this.lbl_netchecks.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbl_netchecks.Font = new System.Drawing.Font("Terminus (TTF)", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lbl_netchecks.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_netchecks.HasBorder = false;
            this.lbl_netchecks.InteractiveText = true;
            this.lbl_netchecks.Location = new System.Drawing.Point(9, 249);
            this.lbl_netchecks.Name = "lbl_netchecks";
            this.lbl_netchecks.Size = new System.Drawing.Size(159, 26);
            this.lbl_netchecks.TabIndex = 110;
            this.lbl_netchecks.Text = "TOGGLE NET CHECKS:";
            this.lbl_netchecks.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_rdmstn
            // 
            this.btn_rdmstn.Font = new System.Drawing.Font("Terminus (TTF)", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.btn_rdmstn.Location = new System.Drawing.Point(143, 62);
            this.btn_rdmstn.Name = "btn_rdmstn";
            this.btn_rdmstn.Size = new System.Drawing.Size(99, 28);
            this.btn_rdmstn.SubFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_rdmstn.SubText = "";
            this.btn_rdmstn.TabIndex = 110;
            this.btn_rdmstn.Text = "ADD STATION";
            this.btn_rdmstn.UseVisualStyleBackColor = true;
            this.btn_rdmstn.Click += new System.EventHandler(this.btn_rdmstn_Click);
            // 
            // lbl_rdmstn
            // 
            this.lbl_rdmstn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbl_rdmstn.Font = new System.Drawing.Font("Terminus (TTF)", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lbl_rdmstn.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_rdmstn.HasBorder = false;
            this.lbl_rdmstn.InteractiveText = true;
            this.lbl_rdmstn.Location = new System.Drawing.Point(3, 60);
            this.lbl_rdmstn.Name = "lbl_rdmstn";
            this.lbl_rdmstn.Size = new System.Drawing.Size(134, 26);
            this.lbl_rdmstn.TabIndex = 112;
            this.lbl_rdmstn.Text = "RANDOM STATION:";
            this.lbl_rdmstn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DebugWindow
            // 
            this.ClientSize = new System.Drawing.Size(481, 285);
            this.Controls.Add(this.btn_netchecks);
            this.Controls.Add(this.lbl_netchecks);
            this.Controls.Add(this.insetPanel1);
            this.Controls.Add(this.insetPanel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimizeBox = false;
            this.Name = "DebugWindow";
            this.Resizeable = false;
            this.Text = "vatACARS DEBUG";
            this.Shown += new System.EventHandler(this.DebugWindow_Shown);
            this.insetPanel2.ResumeLayout(false);
            this.insetPanel2.PerformLayout();
            this.insetPanel1.ResumeLayout(false);
            this.insetPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private vatsys.TextField tbx_content;
        private vatsys.InsetPanel insetPanel2;
        private vatsys.TextLabel lbl_messagecreate;
        private vatsys.TextLabel lbl_content;
        private vatsys.TextField tbx_station;
        private vatsys.TextLabel lbl_callsign;
        private vatsys.TextLabel lbl_state;
        private VATSYSControls.DropDownBox dd_state;
        private vatsys.GenericButton btn_add;
        private VATSYSControls.DropDownBox dd_type;
        private vatsys.TextLabel lbl_type;
        private vatsys.InsetPanel insetPanel1;
        private vatsys.GenericButton btn_screate;
        private vatsys.TextField tbx_stationc;
        private vatsys.TextLabel lbl_stationc;
        private vatsys.TextLabel lbl_stationcreate;
        private vatsys.TextLabel lbl_prov;
        private VATSYSControls.DropDownBox dd_prov;
        private vatsys.GenericButton btn_netchecks;
        private vatsys.TextLabel lbl_netchecks;
        private vatsys.GenericButton btn_rdmstn;
        private vatsys.TextLabel lbl_rdmstn;
    }
}