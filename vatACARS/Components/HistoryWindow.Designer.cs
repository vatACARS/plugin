using System.Windows.Forms;

namespace vatACARS.Components
{
    partial class HistoryWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HistoryWindow));
            this.insetPanel2 = new vatsys.InsetPanel();
            this.lvw_messages = new vatsys.ListViewEx();
            this.col_timestamp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_message = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.scr_messages = new VATSYSControls.ScrollBar();
            this.lbl_acid = new vatsys.TextLabel();
            this.dd_acids = new VATSYSControls.DropDownBox();
            this.insetPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // insetPanel2
            // 
            this.insetPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.insetPanel2.Controls.Add(this.lvw_messages);
            this.insetPanel2.Location = new System.Drawing.Point(3, 52);
            this.insetPanel2.Name = "insetPanel2";
            this.insetPanel2.Size = new System.Drawing.Size(502, 250);
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
            this.lvw_messages.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvw_messages.HideSelection = false;
            this.lvw_messages.Location = new System.Drawing.Point(3, 3);
            this.lvw_messages.MultiSelect = false;
            this.lvw_messages.Name = "lvw_messages";
            this.lvw_messages.OwnerDraw = true;
            this.lvw_messages.ShowGroups = false;
            this.lvw_messages.Size = new System.Drawing.Size(496, 244);
            this.lvw_messages.TabIndex = 2;
            this.lvw_messages.UseCompatibleStateImageBehavior = false;
            this.lvw_messages.View = System.Windows.Forms.View.Details;
            this.lvw_messages.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.lvw_messages_DrawItem);
            this.lvw_messages.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.MessageScroll_MouseWheel);
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
            this.scr_messages.Location = new System.Drawing.Point(508, 52);
            this.scr_messages.Name = "scr_messages";
            this.scr_messages.Orientation = System.Windows.Forms.ScrollOrientation.VerticalScroll;
            this.scr_messages.PreferredHeight = 10;
            this.scr_messages.Size = new System.Drawing.Size(20, 250);
            this.scr_messages.TabIndex = 5;
            this.scr_messages.Value = 0;
            this.scr_messages.Scroll += new System.EventHandler(this.scr_messages_Scroll);
            this.scr_messages.Scrolling += new System.EventHandler(this.scr_messages_Scroll);
            this.scr_messages.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.MessageScroll_MouseWheel);
            // 
            // lbl_acid
            // 
            this.lbl_acid.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbl_acid.Font = new System.Drawing.Font("Terminus (TTF)", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lbl_acid.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_acid.HasBorder = false;
            this.lbl_acid.InteractiveText = false;
            this.lbl_acid.Location = new System.Drawing.Point(3, 9);
            this.lbl_acid.Name = "lbl_acid";
            this.lbl_acid.Size = new System.Drawing.Size(56, 25);
            this.lbl_acid.TabIndex = 8;
            this.lbl_acid.Text = "ACID: ";
            this.lbl_acid.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dd_acids
            // 
            this.dd_acids.BackColor = System.Drawing.SystemColors.ControlDark;
            this.dd_acids.FocusColor = System.Drawing.Color.Cyan;
            this.dd_acids.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.dd_acids.Items = ((System.Collections.ObjectModel.ObservableCollection<string>)(resources.GetObject("dd_acids.Items")));
            this.dd_acids.Location = new System.Drawing.Point(65, 9);
            this.dd_acids.Name = "dd_acids";
            this.dd_acids.SelectedIndex = -1;
            this.dd_acids.Size = new System.Drawing.Size(92, 25);
            this.dd_acids.TabIndex = 103;
            this.dd_acids.SelectedIndexChanged += new System.EventHandler(this.dd_acids_SelectedIndexChanged);
            // 
            // HistoryWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 314);
            this.Controls.Add(this.dd_acids);
            this.Controls.Add(this.lbl_acid);
            this.Controls.Add(this.scr_messages);
            this.Controls.Add(this.insetPanel2);
            this.HasSendBackButton = false;
            this.HideOnClose = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MiddleClickClose = false;
            this.MinimumSize = new System.Drawing.Size(537, 342);
            this.Name = "HistoryWindow";
            this.Text = "History Window";
            this.Load += new System.EventHandler(this.HistoryWindow_Load);
            this.ResizeEnd += new System.EventHandler(this.HistoryWindow_ResizeEnd);
            this.SizeChanged += new System.EventHandler(this.HistoryWindow_SizeChanged);
            this.insetPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private vatsys.InsetPanel insetPanel2;
        private vatsys.ListViewEx lvw_messages;
        private VATSYSControls.ScrollBar scr_messages;
        private System.Windows.Forms.ColumnHeader col_message;
        private System.Windows.Forms.ColumnHeader col_timestamp;
        private vatsys.TextLabel lbl_acid;
        private VATSYSControls.DropDownBox dd_acids;
    }
}