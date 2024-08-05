using System.Windows.Forms;
using vatsys;

namespace vatACARS.Components
{
    partial class QuickFillWindow
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
            this.insetPanel1 = new vatsys.InsetPanel();
            this.lvw_quickfillselector = new vatsys.ListViewEx();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.scr_quickfill = new VATSYSControls.ScrollBar();
            this.btn_confirm = new vatsys.GenericButton();
            this.tbx_freetext = new vatsys.TextField();
            this.insetPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // insetPanel1
            // 
            this.insetPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.insetPanel1.Controls.Add(this.lvw_quickfillselector);
            this.insetPanel1.Location = new System.Drawing.Point(12, 2);
            this.insetPanel1.Name = "insetPanel1";
            this.insetPanel1.Size = new System.Drawing.Size(195, 211);
            this.insetPanel1.TabIndex = 8;
            // 
            // lvw_quickfillselector
            // 
            this.lvw_quickfillselector.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.lvw_quickfillselector.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvw_quickfillselector.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvw_quickfillselector.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lvw_quickfillselector.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvw_quickfillselector.HideSelection = false;
            this.lvw_quickfillselector.LabelWrap = false;
            this.lvw_quickfillselector.Location = new System.Drawing.Point(3, 3);
            this.lvw_quickfillselector.MultiSelect = false;
            this.lvw_quickfillselector.Name = "lvw_quickfillselector";
            this.lvw_quickfillselector.OwnerDraw = true;
            this.lvw_quickfillselector.ShowGroups = false;
            this.lvw_quickfillselector.Size = new System.Drawing.Size(189, 205);
            this.lvw_quickfillselector.TabIndex = 3;
            this.lvw_quickfillselector.TileSize = new System.Drawing.Size(440, 20);
            this.lvw_quickfillselector.UseCompatibleStateImageBehavior = false;
            this.lvw_quickfillselector.View = System.Windows.Forms.View.Details;
            this.lvw_quickfillselector.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.lvw_quickfillselector_DrawItem);
            this.lvw_quickfillselector.SelectedIndexChanged += new System.EventHandler(this.lvw_quickfillselector_SelectedIndexChanged);
            this.lvw_quickfillselector.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.QuickScroll_MouseWheel);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 539;
            // 
            // scr_quickfill
            // 
            this.scr_quickfill.ActualHeight = 10;
            this.scr_quickfill.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scr_quickfill.Change = 1;
            this.scr_quickfill.Location = new System.Drawing.Point(213, 2);
            this.scr_quickfill.Name = "scr_quickfill";
            this.scr_quickfill.Orientation = System.Windows.Forms.ScrollOrientation.VerticalScroll;
            this.scr_quickfill.PreferredHeight = 10;
            this.scr_quickfill.Size = new System.Drawing.Size(20, 211);
            this.scr_quickfill.TabIndex = 9;
            this.scr_quickfill.Value = 0;
            this.scr_quickfill.Scroll += new System.EventHandler(this.scr_quickfill_Scroll);
            this.scr_quickfill.Scrolling += new System.EventHandler(this.scr_quickfill_Scroll);
            this.scr_quickfill.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.QuickScroll_MouseWheel);
            // 
            // btn_confirm
            // 
            this.btn_confirm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_confirm.Font = new System.Drawing.Font("Terminus (TTF)", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.btn_confirm.Location = new System.Drawing.Point(12, 250);
            this.btn_confirm.Name = "btn_confirm";
            this.btn_confirm.Size = new System.Drawing.Size(221, 25);
            this.btn_confirm.SubFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_confirm.SubText = "";
            this.btn_confirm.TabIndex = 11;
            this.btn_confirm.Text = "Confirm";
            this.btn_confirm.UseVisualStyleBackColor = true;
            this.btn_confirm.Click += new System.EventHandler(this.btn_confirm_Click);
            // 
            // tbx_freetext
            // 
            this.tbx_freetext.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbx_freetext.BackColor = System.Drawing.SystemColors.ControlDark;
            this.tbx_freetext.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.tbx_freetext.Location = new System.Drawing.Point(12, 219);
            this.tbx_freetext.Name = "tbx_freetext";
            this.tbx_freetext.NumericCharOnly = false;
            this.tbx_freetext.OctalOnly = false;
            this.tbx_freetext.Size = new System.Drawing.Size(221, 25);
            this.tbx_freetext.TabIndex = 10;
            this.tbx_freetext.WordWrap = false;
            this.tbx_freetext.TextChanged += new System.EventHandler(this.tbx_freetext_TextChanged);
            this.tbx_freetext.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbx_freetext_KeyUp);
            // 
            // QuickFillWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(250, 287);
            this.Controls.Add(this.scr_quickfill);
            this.Controls.Add(this.tbx_freetext);
            this.Controls.Add(this.btn_confirm);
            this.Controls.Add(this.insetPanel1);
            this.HasMinimizeButton = false;
            this.HasSendBackButton = false;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(590, 2000);
            this.MiddleClickClose = false;
            this.MinimumSize = new System.Drawing.Size(131, 315);
            this.Name = "QuickFillWindow";
            this.ShowInTaskbar = false;
            this.Text = "QuickFill Selector";
            this.TopMost = true;
            this.Shown += new System.EventHandler(this.QuickFillWindow_Shown);
            this.SizeChanged += new System.EventHandler(this.QuickFillWindow_SizeChanged);
            this.insetPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private vatsys.InsetPanel insetPanel1;
        private VATSYSControls.ScrollBar scr_quickfill;
        private vatsys.GenericButton btn_confirm;
        private vatsys.TextField tbx_freetext;
        private ListViewEx lvw_quickfillselector;
        private ColumnHeader columnHeader1;
    }
}