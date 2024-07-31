using System.Windows.Forms;

namespace vatACARS.Components
{
    partial class DispatchWindow
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
            System.Windows.Forms.ListViewGroup listViewGroup7 = new System.Windows.Forms.ListViewGroup("", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup8 = new System.Windows.Forms.ListViewGroup("", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup9 = new System.Windows.Forms.ListViewGroup("", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup10 = new System.Windows.Forms.ListViewGroup("", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup11 = new System.Windows.Forms.ListViewGroup("", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup12 = new System.Windows.Forms.ListViewGroup("", System.Windows.Forms.HorizontalAlignment.Left);
            this.insetPanel2 = new vatsys.InsetPanel();
            this.lvw_messages = new vatsys.ListViewEx();
            this.col_timestamp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_message = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.scr_messages = new VATSYSControls.ScrollBar();
            this.insetPanel1 = new vatsys.InsetPanel();
            this.tbl_connected = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_messages = new vatsys.TextLabel();
            this.lbl_connections = new vatsys.TextLabel();
            this.insetPanel2.SuspendLayout();
            this.insetPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // insetPanel2
            // 
            this.insetPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.insetPanel2.Controls.Add(this.lvw_messages);
            this.insetPanel2.Location = new System.Drawing.Point(3, 24);
            this.insetPanel2.Name = "insetPanel2";
            this.insetPanel2.Size = new System.Drawing.Size(502, 138);
            this.insetPanel2.TabIndex = 3;
            // 
            // lvw_messages
            // 
            this.lvw_messages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvw_messages.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvw_messages.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.col_timestamp,
            this.col_message});
            this.lvw_messages.Font = new System.Drawing.Font("Terminus (TTF)", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lvw_messages.FullRowSelect = true;
            listViewGroup7.Header = "";
            listViewGroup7.Name = "downlink";
            listViewGroup8.Header = "";
            listViewGroup8.Name = "downlinkResponseNotRequired";
            listViewGroup9.Header = "";
            listViewGroup9.Name = "ADSC";
            listViewGroup10.Header = "";
            listViewGroup10.Name = "defer";
            listViewGroup11.Header = "";
            listViewGroup11.Name = "uplink";
            listViewGroup12.Header = "";
            listViewGroup12.Name = "finished";
            this.lvw_messages.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup7,
            listViewGroup8,
            listViewGroup9,
            listViewGroup10,
            listViewGroup11,
            listViewGroup12});
            this.lvw_messages.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvw_messages.HideSelection = false;
            this.lvw_messages.Location = new System.Drawing.Point(3, 3);
            this.lvw_messages.MultiSelect = false;
            this.lvw_messages.Name = "lvw_messages";
            this.lvw_messages.OwnerDraw = true;
            this.lvw_messages.ShowGroups = false;
            this.lvw_messages.Size = new System.Drawing.Size(496, 132);
            this.lvw_messages.TabIndex = 2;
            this.lvw_messages.UseCompatibleStateImageBehavior = false;
            this.lvw_messages.View = System.Windows.Forms.View.Details;
            this.lvw_messages.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.lvw_messages_DrawItem);
            this.lvw_messages.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lvw_messages_MouseUp);
            this.lvw_messages.MouseWheel += new MouseEventHandler(this.MessageScroll_MouseWheel);
            // 
            // col_timestamp
            // 
            this.col_timestamp.Text = "";
            this.col_timestamp.Width = 80;
            // 
            // col_message
            // 
            this.col_message.Text = "";
            this.col_message.Width = 421;
            // 
            // scr_messages
            // 
            this.scr_messages.ActualHeight = 10;
            this.scr_messages.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scr_messages.Change = 1;
            this.scr_messages.Location = new System.Drawing.Point(508, 24);
            this.scr_messages.Name = "scr_messages";
            this.scr_messages.Orientation = System.Windows.Forms.ScrollOrientation.VerticalScroll;
            this.scr_messages.PreferredHeight = 10;
            this.scr_messages.Size = new System.Drawing.Size(20, 138);
            this.scr_messages.TabIndex = 5;
            this.scr_messages.Value = 0;
            this.scr_messages.Scroll += new System.EventHandler(this.scr_messages_Scroll);
            this.scr_messages.Scrolling += new System.EventHandler(this.scr_messages_Scroll);
            this.scr_messages.MouseWheel += new MouseEventHandler(this.MessageScroll_MouseWheel);
            // 
            // insetPanel1
            // 
            this.insetPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.insetPanel1.Controls.Add(this.tbl_connected);
            this.insetPanel1.Location = new System.Drawing.Point(3, 193);
            this.insetPanel1.Name = "insetPanel1";
            this.insetPanel1.Size = new System.Drawing.Size(525, 121);
            this.insetPanel1.TabIndex = 4;
            // 
            // tbl_connected
            // 
            this.tbl_connected.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbl_connected.BackColor = System.Drawing.Color.Transparent;
            this.tbl_connected.ColumnCount = 5;
            this.tbl_connected.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 104F));
            this.tbl_connected.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 104F));
            this.tbl_connected.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 104F));
            this.tbl_connected.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 104F));
            this.tbl_connected.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 104F));
            this.tbl_connected.Location = new System.Drawing.Point(3, 3);
            this.tbl_connected.Name = "tbl_connected";
            this.tbl_connected.RowCount = 4;
            this.tbl_connected.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tbl_connected.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tbl_connected.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tbl_connected.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tbl_connected.Size = new System.Drawing.Size(519, 115);
            this.tbl_connected.TabIndex = 1;
            this.tbl_connected.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tbl_connected_MouseDown);
            // 
            // lbl_messages
            // 
            this.lbl_messages.AutoSize = true;
            this.lbl_messages.Font = new System.Drawing.Font("Terminus (TTF)", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lbl_messages.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_messages.HasBorder = false;
            this.lbl_messages.InteractiveText = false;
            this.lbl_messages.Location = new System.Drawing.Point(3, 4);
            this.lbl_messages.Name = "lbl_messages";
            this.lbl_messages.Size = new System.Drawing.Size(168, 17);
            this.lbl_messages.TabIndex = 8;
            this.lbl_messages.Text = "Transceiver Messages";
            this.lbl_messages.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_connections
            // 
            this.lbl_connections.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_connections.AutoSize = true;
            this.lbl_connections.Font = new System.Drawing.Font("Terminus (TTF)", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lbl_connections.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_connections.HasBorder = false;
            this.lbl_connections.InteractiveText = false;
            this.lbl_connections.Location = new System.Drawing.Point(3, 173);
            this.lbl_connections.Name = "lbl_connections";
            this.lbl_connections.Size = new System.Drawing.Size(152, 17);
            this.lbl_connections.TabIndex = 9;
            this.lbl_connections.Text = "Connected Stations";
            this.lbl_connections.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DispatchWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 326);
            this.Controls.Add(this.lbl_connections);
            this.Controls.Add(this.lbl_messages);
            this.Controls.Add(this.insetPanel1);
            this.Controls.Add(this.scr_messages);
            this.Controls.Add(this.insetPanel2);
            this.HasSendBackButton = false;
            this.HideOnClose = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MiddleClickClose = false;
            this.MinimumSize = new System.Drawing.Size(537, 354);
            this.Name = "DispatchWindow";
            this.Text = "Dispatch Interface";
            this.ResizeBegin += new System.EventHandler(this.DispatchWindow_ResizeBegin);
            this.ResizeEnd += new System.EventHandler(this.DispatchWindow_ResizeEnd);
            this.SizeChanged += new System.EventHandler(this.DispatchWindow_SizeChanged);
            this.insetPanel2.ResumeLayout(false);
            this.insetPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private vatsys.InsetPanel insetPanel2;
        private vatsys.ListViewEx lvw_messages;
        private VATSYSControls.ScrollBar scr_messages;
        private System.Windows.Forms.ColumnHeader col_message;
        private System.Windows.Forms.ColumnHeader col_timestamp;
        private vatsys.InsetPanel insetPanel1;
        private vatsys.TextLabel lbl_messages;
        private vatsys.TextLabel lbl_connections;
        private System.Windows.Forms.TableLayoutPanel tbl_connected;
    }
}