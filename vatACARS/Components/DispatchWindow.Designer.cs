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
            this.insetPanel2 = new vatsys.InsetPanel();
            this.lvw_messages = new vatsys.ListViewEx();
            this.col_timestamp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_message = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.scr_cpdlc = new VATSYSControls.ScrollBar();
            this.insetPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // insetPanel2
            // 
            this.insetPanel2.Controls.Add(this.lvw_messages);
            this.insetPanel2.Location = new System.Drawing.Point(3, 4);
            this.insetPanel2.Name = "insetPanel2";
            this.insetPanel2.Size = new System.Drawing.Size(507, 325);
            this.insetPanel2.TabIndex = 3;
            // 
            // lvw_messages
            // 
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
            this.lvw_messages.Size = new System.Drawing.Size(501, 319);
            this.lvw_messages.TabIndex = 2;
            this.lvw_messages.UseCompatibleStateImageBehavior = false;
            this.lvw_messages.View = System.Windows.Forms.View.Details;
            this.lvw_messages.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.lvw_messages_DrawItem);
            this.lvw_messages.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lvw_messages_MouseUp);
            // 
            // col_timestamp
            // 
            this.col_timestamp.Text = "";
            // 
            // col_message
            // 
            this.col_message.Text = "";
            this.col_message.Width = 441;
            // 
            // scr_cpdlc
            // 
            this.scr_cpdlc.ActualHeight = 10;
            this.scr_cpdlc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scr_cpdlc.Change = 1;
            this.scr_cpdlc.Location = new System.Drawing.Point(511, 4);
            this.scr_cpdlc.Name = "scr_cpdlc";
            this.scr_cpdlc.Orientation = System.Windows.Forms.ScrollOrientation.VerticalScroll;
            this.scr_cpdlc.PreferredHeight = 10;
            this.scr_cpdlc.Size = new System.Drawing.Size(20, 325);
            this.scr_cpdlc.TabIndex = 5;
            this.scr_cpdlc.Value = 0;
            // 
            // DispatchWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 333);
            this.ControlBox = false;
            this.Controls.Add(this.scr_cpdlc);
            this.Controls.Add(this.insetPanel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HasSendBackButton = false;
            this.HideOnClose = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(950, 400);
            this.MiddleClickClose = false;
            this.MinimumSize = new System.Drawing.Size(537, 263);
            this.Name = "DispatchWindow";
            this.Resizeable = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Dispatch";
            this.TopMost = true;
            this.insetPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private vatsys.InsetPanel insetPanel2;
        private vatsys.ListViewEx lvw_messages;
        private VATSYSControls.ScrollBar scr_cpdlc;
        private System.Windows.Forms.ColumnHeader col_message;
        private System.Windows.Forms.ColumnHeader col_timestamp;
    }
}