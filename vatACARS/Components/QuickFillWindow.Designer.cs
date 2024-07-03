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
            this.tbl_quickFillSelector = new System.Windows.Forms.TableLayoutPanel();
            this.scr_connections = new VATSYSControls.ScrollBar();
            this.tbx_freetext = new System.Windows.Forms.TextBox();
            this.btn_confirm = new vatsys.GenericButton();
            this.insetPanel2 = new vatsys.InsetPanel();
            this.insetPanel1.SuspendLayout();
            this.insetPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // insetPanel1
            // 
            this.insetPanel1.Controls.Add(this.tbl_quickFillSelector);
            this.insetPanel1.Location = new System.Drawing.Point(1, 2);
            this.insetPanel1.Name = "insetPanel1";
            this.insetPanel1.Size = new System.Drawing.Size(507, 130);
            this.insetPanel1.TabIndex = 8;
            // 
            // tbl_quickFillSelector
            // 
            this.tbl_quickFillSelector.BackColor = System.Drawing.Color.Transparent;
            this.tbl_quickFillSelector.ColumnCount = 8;
            this.tbl_quickFillSelector.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tbl_quickFillSelector.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tbl_quickFillSelector.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tbl_quickFillSelector.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tbl_quickFillSelector.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tbl_quickFillSelector.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tbl_quickFillSelector.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tbl_quickFillSelector.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tbl_quickFillSelector.Location = new System.Drawing.Point(3, 3);
            this.tbl_quickFillSelector.Name = "tbl_quickFillSelector";
            this.tbl_quickFillSelector.RowCount = 4;
            this.tbl_quickFillSelector.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tbl_quickFillSelector.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tbl_quickFillSelector.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tbl_quickFillSelector.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tbl_quickFillSelector.Size = new System.Drawing.Size(501, 124);
            this.tbl_quickFillSelector.TabIndex = 1;
            // 
            // scr_connections
            // 
            this.scr_connections.ActualHeight = 10;
            this.scr_connections.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scr_connections.Change = 1;
            this.scr_connections.Location = new System.Drawing.Point(356, 2);
            this.scr_connections.Name = "scr_connections";
            this.scr_connections.Orientation = System.Windows.Forms.ScrollOrientation.VerticalScroll;
            this.scr_connections.PreferredHeight = 10;
            this.scr_connections.Size = new System.Drawing.Size(20, 35);
            this.scr_connections.TabIndex = 9;
            this.scr_connections.Value = 0;
            // 
            // tbx_freetext
            // 
            this.tbx_freetext.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbx_freetext.Location = new System.Drawing.Point(3, 4);
            this.tbx_freetext.Name = "tbx_freetext";
            this.tbx_freetext.Size = new System.Drawing.Size(237, 18);
            this.tbx_freetext.TabIndex = 10;
            this.tbx_freetext.WordWrap = false;
            this.tbx_freetext.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbx_freetext_KeyUp);
            // 
            // btn_confirm
            // 
            this.btn_confirm.Font = new System.Drawing.Font("Terminus (TTF)", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.btn_confirm.Location = new System.Drawing.Point(397, 138);
            this.btn_confirm.Name = "btn_confirm";
            this.btn_confirm.Size = new System.Drawing.Size(108, 25);
            this.btn_confirm.SubFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_confirm.SubText = "";
            this.btn_confirm.TabIndex = 11;
            this.btn_confirm.Text = "Confirm";
            this.btn_confirm.UseVisualStyleBackColor = true;
            this.btn_confirm.Click += new System.EventHandler(this.btn_confirm_Click);
            // 
            // insetPanel2
            // 
            this.insetPanel2.Controls.Add(this.tbx_freetext);
            this.insetPanel2.Location = new System.Drawing.Point(4, 138);
            this.insetPanel2.Name = "insetPanel2";
            this.insetPanel2.Size = new System.Drawing.Size(243, 25);
            this.insetPanel2.TabIndex = 9;
            // 
            // QuickFillWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 168);
            this.Controls.Add(this.insetPanel2);
            this.Controls.Add(this.btn_confirm);
            this.Controls.Add(this.insetPanel1);
            this.Controls.Add(this.scr_connections);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MiddleClickClose = false;
            this.Name = "QuickFillWindow";
            this.Resizeable = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Options Selector";
            this.TopMost = true;
            this.insetPanel1.ResumeLayout(false);
            this.insetPanel2.ResumeLayout(false);
            this.insetPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private vatsys.InsetPanel insetPanel1;
        private System.Windows.Forms.TableLayoutPanel tbl_quickFillSelector;
        private VATSYSControls.ScrollBar scr_connections;
        private System.Windows.Forms.TextBox tbx_freetext;
        private vatsys.GenericButton btn_confirm;
        private InsetPanel insetPanel2;
    }
}