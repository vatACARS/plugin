namespace vatACARS.Components
{
    partial class QuickResponseWindow
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
            this.btn_tfc = new vatsys.GenericButton();
            this.btn_def = new vatsys.GenericButton();
            this.btn_stanby = new vatsys.GenericButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.UnableLabel = new System.Windows.Forms.Label();
            this.ToEditLabel = new System.Windows.Forms.Label();
            this.DelayLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_air = new vatsys.GenericButton();
            this.btn_editor = new vatsys.GenericButton();
            this.lbl_editor = new vatsys.TextLabel();
            this.lbl_unable = new vatsys.TextLabel();
            this.lbl_delay = new vatsys.TextLabel();
            this.btn_edit = new vatsys.GenericButton();
            this.btn_airspace = new vatsys.GenericButton();
            this.btn_traffic = new vatsys.GenericButton();
            this.btn_deferred = new vatsys.GenericButton();
            this.btn_standby = new vatsys.GenericButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_1 = new vatsys.GenericButton();
            this.lvw_freetextInput = new vatsys.ListViewEx();
            this.insetPanel3 = new vatsys.InsetPanel();
            this.btn_send = new vatsys.GenericButton();
            this.btn_restore = new vatsys.GenericButton();
            this.btn_suspend = new vatsys.GenericButton();
            this.insetPanel1 = new vatsys.InsetPanel();
            this.lvw_messageSelector = new vatsys.ListViewEx();
            this.scr_messageSelector = new VATSYSControls.ScrollBar();
            this.lvw_messages = new vatsys.ListViewEx();
            this.insetPanel2 = new vatsys.InsetPanel();
            this.btn_escape = new vatsys.GenericButton();
            this.lbl_receivedMsgs = new vatsys.TextLabel();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.insetPanel3.SuspendLayout();
            this.insetPanel1.SuspendLayout();
            this.insetPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_tfc
            // 
            this.btn_tfc.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btn_tfc.Font = new System.Drawing.Font("Terminus (TTF)", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.btn_tfc.Location = new System.Drawing.Point(377, 53);
            this.btn_tfc.Name = "btn_tfc";
            this.btn_tfc.Size = new System.Drawing.Size(90, 28);
            this.btn_tfc.SubFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_tfc.SubText = "";
            this.btn_tfc.TabIndex = 39;
            this.btn_tfc.Text = "Traffic";
            this.btn_tfc.UseVisualStyleBackColor = true;
            // 
            // btn_def
            // 
            this.btn_def.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btn_def.Font = new System.Drawing.Font("Terminus (TTF)", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.btn_def.Location = new System.Drawing.Point(95, 53);
            this.btn_def.Name = "btn_def";
            this.btn_def.Size = new System.Drawing.Size(90, 28);
            this.btn_def.SubFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_def.SubText = "";
            this.btn_def.TabIndex = 36;
            this.btn_def.Text = "Deferred";
            this.btn_def.UseVisualStyleBackColor = true;
            // 
            // btn_stanby
            // 
            this.btn_stanby.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btn_stanby.Font = new System.Drawing.Font("Terminus (TTF)", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.btn_stanby.Location = new System.Drawing.Point(-1, 53);
            this.btn_stanby.Name = "btn_stanby";
            this.btn_stanby.Size = new System.Drawing.Size(90, 28);
            this.btn_stanby.SubFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_stanby.SubText = "";
            this.btn_stanby.TabIndex = 35;
            this.btn_stanby.Text = "Standby";
            this.btn_stanby.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.UnableLabel);
            this.panel2.Controls.Add(this.ToEditLabel);
            this.panel2.Controls.Add(this.DelayLabel);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.btn_tfc);
            this.panel2.Controls.Add(this.btn_air);
            this.panel2.Controls.Add(this.btn_def);
            this.panel2.Controls.Add(this.btn_stanby);
            this.panel2.Controls.Add(this.btn_editor);
            this.panel2.Location = new System.Drawing.Point(11, 99);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(565, 84);
            this.panel2.TabIndex = 46;
            // 
            // UnableLabel
            // 
            this.UnableLabel.Font = new System.Drawing.Font("Terminus (TTF)", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.UnableLabel.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.UnableLabel.Location = new System.Drawing.Point(389, 16);
            this.UnableLabel.Name = "UnableLabel";
            this.UnableLabel.Size = new System.Drawing.Size(147, 18);
            this.UnableLabel.TabIndex = 43;
            this.UnableLabel.Text = "Unable Due To";
            this.UnableLabel.Click += new System.EventHandler(this.label2_Click_1);
            // 
            // ToEditLabel
            // 
            this.ToEditLabel.Font = new System.Drawing.Font("Terminus (TTF)", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.ToEditLabel.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.ToEditLabel.Location = new System.Drawing.Point(238, 16);
            this.ToEditLabel.Name = "ToEditLabel";
            this.ToEditLabel.Size = new System.Drawing.Size(106, 18);
            this.ToEditLabel.TabIndex = 41;
            this.ToEditLabel.Text = "To Editor";
            this.ToEditLabel.Click += new System.EventHandler(this.label2_Click);
            // 
            // DelayLabel
            // 
            this.DelayLabel.Font = new System.Drawing.Font("Terminus (TTF)", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.DelayLabel.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.DelayLabel.Location = new System.Drawing.Point(13, 16);
            this.DelayLabel.Name = "DelayLabel";
            this.DelayLabel.Size = new System.Drawing.Size(159, 18);
            this.DelayLabel.TabIndex = 44;
            this.DelayLabel.Text = "Delay Response";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(252, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 40;
            this.label1.Text = "label1";
            // 
            // btn_air
            // 
            this.btn_air.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btn_air.Font = new System.Drawing.Font("Terminus (TTF)", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.btn_air.Location = new System.Drawing.Point(473, 53);
            this.btn_air.Name = "btn_air";
            this.btn_air.Size = new System.Drawing.Size(90, 28);
            this.btn_air.SubFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_air.SubText = "";
            this.btn_air.TabIndex = 38;
            this.btn_air.Text = "Airspace";
            this.btn_air.UseVisualStyleBackColor = true;
            // 
            // btn_editor
            // 
            this.btn_editor.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btn_editor.Font = new System.Drawing.Font("Terminus (TTF)", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.btn_editor.Location = new System.Drawing.Point(242, 53);
            this.btn_editor.Name = "btn_editor";
            this.btn_editor.Size = new System.Drawing.Size(80, 28);
            this.btn_editor.SubFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_editor.SubText = "";
            this.btn_editor.TabIndex = 42;
            this.btn_editor.Text = "Edit";
            this.btn_editor.UseVisualStyleBackColor = true;
            // 
            // lbl_editor
            // 
            this.lbl_editor.Font = new System.Drawing.Font("Terminus (TTF)", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lbl_editor.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_editor.HasBorder = false;
            this.lbl_editor.InteractiveText = false;
            this.lbl_editor.Location = new System.Drawing.Point(161, 17);
            this.lbl_editor.Name = "lbl_editor";
            this.lbl_editor.Size = new System.Drawing.Size(242, 17);
            this.lbl_editor.TabIndex = 33;
            this.lbl_editor.Text = "To Editor";
            this.lbl_editor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_unable
            // 
            this.lbl_unable.Font = new System.Drawing.Font("Terminus (TTF)", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lbl_unable.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_unable.HasBorder = false;
            this.lbl_unable.InteractiveText = false;
            this.lbl_unable.Location = new System.Drawing.Point(351, 17);
            this.lbl_unable.Name = "lbl_unable";
            this.lbl_unable.Size = new System.Drawing.Size(186, 17);
            this.lbl_unable.TabIndex = 32;
            this.lbl_unable.Text = "Unable Due To";
            this.lbl_unable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_delay
            // 
            this.lbl_delay.Font = new System.Drawing.Font("Terminus (TTF)", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lbl_delay.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_delay.HasBorder = false;
            this.lbl_delay.InteractiveText = false;
            this.lbl_delay.Location = new System.Drawing.Point(14, 17);
            this.lbl_delay.Name = "lbl_delay";
            this.lbl_delay.Size = new System.Drawing.Size(186, 17);
            this.lbl_delay.TabIndex = 31;
            this.lbl_delay.Text = "Delay Response";
            this.lbl_delay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_edit
            // 
            this.btn_edit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_edit.Font = new System.Drawing.Font("Terminus (TTF)", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.btn_edit.Location = new System.Drawing.Point(253, 53);
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Size = new System.Drawing.Size(70, 28);
            this.btn_edit.SubFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_edit.SubText = "";
            this.btn_edit.TabIndex = 30;
            this.btn_edit.Text = "Edit";
            this.btn_edit.UseVisualStyleBackColor = true;
            // 
            // btn_airspace
            // 
            this.btn_airspace.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_airspace.Font = new System.Drawing.Font("Terminus (TTF)", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.btn_airspace.Location = new System.Drawing.Point(466, 53);
            this.btn_airspace.Name = "btn_airspace";
            this.btn_airspace.Size = new System.Drawing.Size(90, 28);
            this.btn_airspace.SubFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_airspace.SubText = "";
            this.btn_airspace.TabIndex = 29;
            this.btn_airspace.Text = "Airspace";
            this.btn_airspace.UseVisualStyleBackColor = true;
            // 
            // btn_traffic
            // 
            this.btn_traffic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_traffic.Font = new System.Drawing.Font("Terminus (TTF)", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.btn_traffic.Location = new System.Drawing.Point(370, 53);
            this.btn_traffic.Name = "btn_traffic";
            this.btn_traffic.Size = new System.Drawing.Size(90, 28);
            this.btn_traffic.SubFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_traffic.SubText = "";
            this.btn_traffic.TabIndex = 28;
            this.btn_traffic.Text = "Traffic";
            this.btn_traffic.UseVisualStyleBackColor = true;
            // 
            // btn_deferred
            // 
            this.btn_deferred.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_deferred.Font = new System.Drawing.Font("Terminus (TTF)", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.btn_deferred.Location = new System.Drawing.Point(110, 53);
            this.btn_deferred.Name = "btn_deferred";
            this.btn_deferred.Size = new System.Drawing.Size(90, 28);
            this.btn_deferred.SubFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_deferred.SubText = "";
            this.btn_deferred.TabIndex = 27;
            this.btn_deferred.Text = "Deferred";
            this.btn_deferred.UseVisualStyleBackColor = true;
            // 
            // btn_standby
            // 
            this.btn_standby.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_standby.Font = new System.Drawing.Font("Terminus (TTF)", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.btn_standby.Location = new System.Drawing.Point(14, 53);
            this.btn_standby.Name = "btn_standby";
            this.btn_standby.Size = new System.Drawing.Size(90, 28);
            this.btn_standby.SubFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_standby.SubText = "";
            this.btn_standby.TabIndex = 26;
            this.btn_standby.Text = "Standby";
            this.btn_standby.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbl_editor);
            this.panel1.Controls.Add(this.lbl_unable);
            this.panel1.Controls.Add(this.lbl_delay);
            this.panel1.Controls.Add(this.btn_edit);
            this.panel1.Controls.Add(this.btn_airspace);
            this.panel1.Controls.Add(this.btn_traffic);
            this.panel1.Controls.Add(this.btn_deferred);
            this.panel1.Controls.Add(this.btn_standby);
            this.panel1.Location = new System.Drawing.Point(10, 99);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(566, 84);
            this.panel1.TabIndex = 45;
            this.panel1.Visible = false;
            // 
            // btn_1
            // 
            this.btn_1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_1.Font = new System.Drawing.Font("Terminus (TTF)", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.btn_1.Location = new System.Drawing.Point(10, 371);
            this.btn_1.Name = "btn_1";
            this.btn_1.Size = new System.Drawing.Size(31, 31);
            this.btn_1.SubFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_1.SubText = "";
            this.btn_1.TabIndex = 44;
            this.btn_1.Text = "1";
            this.btn_1.UseVisualStyleBackColor = true;
            // 
            // lvw_freetextInput
            // 
            this.lvw_freetextInput.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lvw_freetextInput.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.lvw_freetextInput.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lvw_freetextInput.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvw_freetextInput.HideSelection = false;
            this.lvw_freetextInput.LabelWrap = false;
            this.lvw_freetextInput.Location = new System.Drawing.Point(3, 3);
            this.lvw_freetextInput.MultiSelect = false;
            this.lvw_freetextInput.Name = "lvw_freetextInput";
            this.lvw_freetextInput.Scrollable = false;
            this.lvw_freetextInput.Size = new System.Drawing.Size(523, 25);
            this.lvw_freetextInput.Sorting = System.Windows.Forms.SortOrder.Descending;
            this.lvw_freetextInput.TabIndex = 2;
            this.lvw_freetextInput.TileSize = new System.Drawing.Size(440, 26);
            this.lvw_freetextInput.UseCompatibleStateImageBehavior = false;
            this.lvw_freetextInput.View = System.Windows.Forms.View.Tile;
            // 
            // insetPanel3
            // 
            this.insetPanel3.Controls.Add(this.lvw_freetextInput);
            this.insetPanel3.Location = new System.Drawing.Point(47, 371);
            this.insetPanel3.Name = "insetPanel3";
            this.insetPanel3.Size = new System.Drawing.Size(529, 31);
            this.insetPanel3.TabIndex = 40;
            // 
            // btn_send
            // 
            this.btn_send.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btn_send.Font = new System.Drawing.Font("Terminus (TTF)", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.btn_send.Location = new System.Drawing.Point(466, 408);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(111, 28);
            this.btn_send.SubFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_send.SubText = "";
            this.btn_send.TabIndex = 43;
            this.btn_send.Text = "Send";
            this.btn_send.UseVisualStyleBackColor = true;
            // 
            // btn_restore
            // 
            this.btn_restore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_restore.Font = new System.Drawing.Font("Terminus (TTF)", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.btn_restore.Location = new System.Drawing.Point(106, 408);
            this.btn_restore.Name = "btn_restore";
            this.btn_restore.Size = new System.Drawing.Size(90, 28);
            this.btn_restore.SubFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_restore.SubText = "";
            this.btn_restore.TabIndex = 42;
            this.btn_restore.Text = "Restore";
            this.btn_restore.UseVisualStyleBackColor = true;
            // 
            // btn_suspend
            // 
            this.btn_suspend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_suspend.Font = new System.Drawing.Font("Terminus (TTF)", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.btn_suspend.Location = new System.Drawing.Point(202, 408);
            this.btn_suspend.Name = "btn_suspend";
            this.btn_suspend.Size = new System.Drawing.Size(90, 28);
            this.btn_suspend.SubFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_suspend.SubText = "";
            this.btn_suspend.TabIndex = 41;
            this.btn_suspend.Text = "Suspend";
            this.btn_suspend.UseVisualStyleBackColor = true;
            // 
            // insetPanel1
            // 
            this.insetPanel1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.insetPanel1.Controls.Add(this.lvw_messageSelector);
            this.insetPanel1.Location = new System.Drawing.Point(11, 189);
            this.insetPanel1.Name = "insetPanel1";
            this.insetPanel1.Size = new System.Drawing.Size(546, 176);
            this.insetPanel1.TabIndex = 39;
            // 
            // lvw_messageSelector
            // 
            this.lvw_messageSelector.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lvw_messageSelector.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.lvw_messageSelector.Font = new System.Drawing.Font("Terminus (TTF)", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lvw_messageSelector.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvw_messageSelector.HideSelection = false;
            this.lvw_messageSelector.LabelWrap = false;
            this.lvw_messageSelector.Location = new System.Drawing.Point(3, 3);
            this.lvw_messageSelector.MultiSelect = false;
            this.lvw_messageSelector.Name = "lvw_messageSelector";
            this.lvw_messageSelector.ShowGroups = false;
            this.lvw_messageSelector.Size = new System.Drawing.Size(539, 170);
            this.lvw_messageSelector.TabIndex = 2;
            this.lvw_messageSelector.TileSize = new System.Drawing.Size(440, 20);
            this.lvw_messageSelector.UseCompatibleStateImageBehavior = false;
            this.lvw_messageSelector.View = System.Windows.Forms.View.Tile;
            // 
            // scr_messageSelector
            // 
            this.scr_messageSelector.ActualHeight = 10;
            this.scr_messageSelector.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.scr_messageSelector.Change = 1;
            this.scr_messageSelector.Location = new System.Drawing.Point(559, 189);
            this.scr_messageSelector.Name = "scr_messageSelector";
            this.scr_messageSelector.Orientation = System.Windows.Forms.ScrollOrientation.VerticalScroll;
            this.scr_messageSelector.PreferredHeight = 10;
            this.scr_messageSelector.Size = new System.Drawing.Size(17, 176);
            this.scr_messageSelector.TabIndex = 38;
            this.scr_messageSelector.Value = 0;
            // 
            // lvw_messages
            // 
            this.lvw_messages.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lvw_messages.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.lvw_messages.Font = new System.Drawing.Font("Terminus (TTF)", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lvw_messages.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvw_messages.HideSelection = false;
            this.lvw_messages.LabelWrap = false;
            this.lvw_messages.Location = new System.Drawing.Point(3, 3);
            this.lvw_messages.MultiSelect = false;
            this.lvw_messages.Name = "lvw_messages";
            this.lvw_messages.Scrollable = false;
            this.lvw_messages.ShowGroups = false;
            this.lvw_messages.Size = new System.Drawing.Size(559, 74);
            this.lvw_messages.Sorting = System.Windows.Forms.SortOrder.Descending;
            this.lvw_messages.TabIndex = 2;
            this.lvw_messages.TileSize = new System.Drawing.Size(550, 26);
            this.lvw_messages.UseCompatibleStateImageBehavior = false;
            this.lvw_messages.View = System.Windows.Forms.View.Tile;
            // 
            // insetPanel2
            // 
            this.insetPanel2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.insetPanel2.Controls.Add(this.lvw_messages);
            this.insetPanel2.Location = new System.Drawing.Point(11, 16);
            this.insetPanel2.Name = "insetPanel2";
            this.insetPanel2.Size = new System.Drawing.Size(565, 80);
            this.insetPanel2.TabIndex = 37;
            // 
            // btn_escape
            // 
            this.btn_escape.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_escape.Font = new System.Drawing.Font("Terminus (TTF)", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.btn_escape.Location = new System.Drawing.Point(10, 408);
            this.btn_escape.Name = "btn_escape";
            this.btn_escape.Size = new System.Drawing.Size(90, 28);
            this.btn_escape.SubFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_escape.SubText = "";
            this.btn_escape.TabIndex = 36;
            this.btn_escape.Text = "Escape";
            this.btn_escape.UseVisualStyleBackColor = true;
            // 
            // lbl_receivedMsgs
            // 
            this.lbl_receivedMsgs.AutoSize = true;
            this.lbl_receivedMsgs.Font = new System.Drawing.Font("Terminus (TTF)", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lbl_receivedMsgs.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_receivedMsgs.HasBorder = false;
            this.lbl_receivedMsgs.InteractiveText = false;
            this.lbl_receivedMsgs.Location = new System.Drawing.Point(13, 17);
            this.lbl_receivedMsgs.Name = "lbl_receivedMsgs";
            this.lbl_receivedMsgs.Size = new System.Drawing.Size(144, 17);
            this.lbl_receivedMsgs.TabIndex = 35;
            this.lbl_receivedMsgs.Text = "Received Messages";
            this.lbl_receivedMsgs.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // QuickResponseWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 452);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_1);
            this.Controls.Add(this.insetPanel3);
            this.Controls.Add(this.btn_send);
            this.Controls.Add(this.btn_restore);
            this.Controls.Add(this.btn_suspend);
            this.Controls.Add(this.insetPanel1);
            this.Controls.Add(this.scr_messageSelector);
            this.Controls.Add(this.insetPanel2);
            this.Controls.Add(this.btn_escape);
            this.Controls.Add(this.lbl_receivedMsgs);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HasSendBackButton = false;
            this.HideOnClose = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MiddleClickClose = false;
            this.Name = "QuickResponseWindow";
            this.Resizeable = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "ACARS Editor";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.insetPanel3.ResumeLayout(false);
            this.insetPanel1.ResumeLayout(false);
            this.insetPanel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private vatsys.GenericButton btn_tfc;
        private vatsys.GenericButton btn_def;
        private vatsys.GenericButton btn_stanby;
        private System.Windows.Forms.Panel panel2;
        private vatsys.GenericButton btn_air;
        private vatsys.TextLabel lbl_editor;
        private vatsys.TextLabel lbl_unable;
        private vatsys.TextLabel lbl_delay;
        private vatsys.GenericButton btn_edit;
        private vatsys.GenericButton btn_airspace;
        private vatsys.GenericButton btn_traffic;
        private vatsys.GenericButton btn_deferred;
        private vatsys.GenericButton btn_standby;
        private System.Windows.Forms.Panel panel1;
        private vatsys.GenericButton btn_1;
        private vatsys.ListViewEx lvw_freetextInput;
        private vatsys.InsetPanel insetPanel3;
        private vatsys.GenericButton btn_send;
        private vatsys.GenericButton btn_restore;
        private vatsys.GenericButton btn_suspend;
        private vatsys.InsetPanel insetPanel1;
        private vatsys.ListViewEx lvw_messageSelector;
        private VATSYSControls.ScrollBar scr_messageSelector;
        private vatsys.ListViewEx lvw_messages;
        private vatsys.InsetPanel insetPanel2;
        private vatsys.GenericButton btn_escape;
        private vatsys.TextLabel lbl_receivedMsgs;
        private System.Windows.Forms.Label ToEditLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label UnableLabel;
        private vatsys.GenericButton btn_editor;
        private System.Windows.Forms.Label DelayLabel;
    }
}