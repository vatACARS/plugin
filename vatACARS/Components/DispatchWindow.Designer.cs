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
            this.lbl_receivedMsgs = new vatsys.TextLabel();
            this.btn_reply = new vatsys.GenericButton();
            this.btn_standby = new vatsys.GenericButton();
            this.btn_cancel = new vatsys.GenericButton();
            this.insetPanel2 = new vatsys.InsetPanel();
            this.lvw_messages = new vatsys.ListViewEx();
            this.scr_cpdlc = new VATSYSControls.ScrollBar();
            this.insetPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_receivedMsgs
            // 
            this.lbl_receivedMsgs.AutoSize = true;
            this.lbl_receivedMsgs.Font = new System.Drawing.Font("Terminus (TTF)", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lbl_receivedMsgs.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_receivedMsgs.HasBorder = false;
            this.lbl_receivedMsgs.InteractiveText = false;
            this.lbl_receivedMsgs.Location = new System.Drawing.Point(13, 13);
            this.lbl_receivedMsgs.Name = "lbl_receivedMsgs";
            this.lbl_receivedMsgs.Size = new System.Drawing.Size(144, 17);
            this.lbl_receivedMsgs.TabIndex = 0;
            this.lbl_receivedMsgs.Text = "Received Messages";
            this.lbl_receivedMsgs.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_reply
            // 
            this.btn_reply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_reply.Font = new System.Drawing.Font("Terminus (TTF)", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.btn_reply.Location = new System.Drawing.Point(12, 324);
            this.btn_reply.Name = "btn_reply";
            this.btn_reply.Size = new System.Drawing.Size(122, 28);
            this.btn_reply.SubFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_reply.SubText = "";
            this.btn_reply.TabIndex = 2;
            this.btn_reply.Text = "Reply";
            this.btn_reply.UseVisualStyleBackColor = true;
            this.btn_reply.Click += new System.EventHandler(this.btn_reply_Click);
            // 
            // btn_standby
            // 
            this.btn_standby.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_standby.Font = new System.Drawing.Font("Terminus (TTF)", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.btn_standby.Location = new System.Drawing.Point(140, 324);
            this.btn_standby.Name = "btn_standby";
            this.btn_standby.Size = new System.Drawing.Size(122, 28);
            this.btn_standby.SubFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_standby.SubText = "";
            this.btn_standby.TabIndex = 3;
            this.btn_standby.Text = "Standby";
            this.btn_standby.UseVisualStyleBackColor = true;
            this.btn_standby.Click += new System.EventHandler(this.btn_standby_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_cancel.Font = new System.Drawing.Font("Terminus (TTF)", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.btn_cancel.Location = new System.Drawing.Point(399, 324);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(122, 28);
            this.btn_cancel.SubFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancel.SubText = "";
            this.btn_cancel.TabIndex = 4;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = true;
            // 
            // insetPanel2
            // 
            this.insetPanel2.Controls.Add(this.lvw_messages);
            this.insetPanel2.Location = new System.Drawing.Point(12, 34);
            this.insetPanel2.Name = "insetPanel2";
            this.insetPanel2.Size = new System.Drawing.Size(482, 284);
            this.insetPanel2.TabIndex = 3;
            // 
            // lvw_messages
            // 
            this.lvw_messages.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lvw_messages.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.lvw_messages.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvw_messages.HideSelection = false;
            this.lvw_messages.LabelWrap = false;
            this.lvw_messages.Location = new System.Drawing.Point(3, 3);
            this.lvw_messages.MultiSelect = false;
            this.lvw_messages.Name = "lvw_messages";
            this.lvw_messages.Scrollable = false;
            this.lvw_messages.Size = new System.Drawing.Size(476, 278);
            this.lvw_messages.Sorting = System.Windows.Forms.SortOrder.Descending;
            this.lvw_messages.TabIndex = 2;
            this.lvw_messages.TileSize = new System.Drawing.Size(440, 26);
            this.lvw_messages.UseCompatibleStateImageBehavior = false;
            this.lvw_messages.View = System.Windows.Forms.View.Tile;
            this.lvw_messages.SelectedIndexChanged += new System.EventHandler(this.lvw_messages_SelectedIndexChanged);
            // 
            // scr_cpdlc
            // 
            this.scr_cpdlc.ActualHeight = 10;
            this.scr_cpdlc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scr_cpdlc.Change = 1;
            this.scr_cpdlc.Location = new System.Drawing.Point(500, 34);
            this.scr_cpdlc.Name = "scr_cpdlc";
            this.scr_cpdlc.Orientation = System.Windows.Forms.ScrollOrientation.VerticalScroll;
            this.scr_cpdlc.PreferredHeight = 10;
            this.scr_cpdlc.Size = new System.Drawing.Size(20, 284);
            this.scr_cpdlc.TabIndex = 5;
            this.scr_cpdlc.Value = 0;
            // 
            // DispatchWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 372);
            this.ControlBox = false;
            this.Controls.Add(this.scr_cpdlc);
            this.Controls.Add(this.insetPanel2);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_standby);
            this.Controls.Add(this.btn_reply);
            this.Controls.Add(this.lbl_receivedMsgs);
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
            this.Text = "ACARS Editor";
            this.TopMost = true;
            this.insetPanel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private vatsys.TextLabel lbl_receivedMsgs;
        private vatsys.GenericButton btn_reply;
        private vatsys.GenericButton btn_standby;
        private vatsys.GenericButton btn_cancel;
        private vatsys.InsetPanel insetPanel2;
        private vatsys.ListViewEx lvw_messages;
        private VATSYSControls.ScrollBar scr_cpdlc;
    }
}