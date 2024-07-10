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
            this.scr_quickfill = new VATSYSControls.ScrollBar();
            this.btn_confirm = new vatsys.GenericButton();
            this.tbx_freetext = new vatsys.TextField();
            this.label1 = new System.Windows.Forms.Label();
            this.insetPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // insetPanel1
            // 
            this.insetPanel1.Controls.Add(this.tbl_quickFillSelector);
            this.insetPanel1.Location = new System.Drawing.Point(1, 2);
            this.insetPanel1.Name = "insetPanel1";
            this.insetPanel1.Size = new System.Drawing.Size(507, 165);
            this.insetPanel1.TabIndex = 8;
            // 
            // tbl_quickFillSelector
            // 
            this.tbl_quickFillSelector.BackColor = System.Drawing.Color.Transparent;
            this.tbl_quickFillSelector.ColumnCount = 8;
            this.tbl_quickFillSelector.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 63F));
            this.tbl_quickFillSelector.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 63F));
            this.tbl_quickFillSelector.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 63F));
            this.tbl_quickFillSelector.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 63F));
            this.tbl_quickFillSelector.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 63F));
            this.tbl_quickFillSelector.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 63F));
            this.tbl_quickFillSelector.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 63F));
            this.tbl_quickFillSelector.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 63F));
            this.tbl_quickFillSelector.Location = new System.Drawing.Point(3, 3);
            this.tbl_quickFillSelector.Name = "tbl_quickFillSelector";
            this.tbl_quickFillSelector.RowCount = 4;
            this.tbl_quickFillSelector.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tbl_quickFillSelector.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tbl_quickFillSelector.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tbl_quickFillSelector.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tbl_quickFillSelector.Size = new System.Drawing.Size(501, 159);
            this.tbl_quickFillSelector.TabIndex = 1;
            // 
            // scr_quickfill
            // 
            this.scr_quickfill.ActualHeight = 10;
            this.scr_quickfill.Change = 1;
            this.scr_quickfill.Location = new System.Drawing.Point(4, 170);
            this.scr_quickfill.Name = "scr_quickfill";
            this.scr_quickfill.Orientation = System.Windows.Forms.ScrollOrientation.VerticalScroll;
            this.scr_quickfill.PreferredHeight = 10;
            this.scr_quickfill.Size = new System.Drawing.Size(501, 20);
            this.scr_quickfill.TabIndex = 9;
            this.scr_quickfill.Value = 0;
            this.scr_quickfill.Scroll += new System.EventHandler(this.scr_quickfill_Scroll);
            // 
            // btn_confirm
            // 
            this.btn_confirm.Font = new System.Drawing.Font("Terminus (TTF)", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.btn_confirm.Location = new System.Drawing.Point(397, 199);
            this.btn_confirm.Name = "btn_confirm";
            this.btn_confirm.Size = new System.Drawing.Size(108, 25);
            this.btn_confirm.SubFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_confirm.SubText = "";
            this.btn_confirm.TabIndex = 11;
            this.btn_confirm.Text = "Confirm";
            this.btn_confirm.UseVisualStyleBackColor = true;
            this.btn_confirm.Click += new System.EventHandler(this.btn_confirm_Click);
            // 
            // tbx_freetext
            // 
            this.tbx_freetext.BackColor = System.Drawing.SystemColors.ControlDark;
            this.tbx_freetext.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.tbx_freetext.Location = new System.Drawing.Point(4, 199);
            this.tbx_freetext.Name = "tbx_freetext";
            this.tbx_freetext.NumericCharOnly = false;
            this.tbx_freetext.OctalOnly = false;
            this.tbx_freetext.Size = new System.Drawing.Size(187, 25);
            this.tbx_freetext.TabIndex = 10;
            this.tbx_freetext.WordWrap = false;
            this.tbx_freetext.TextChanged += new System.EventHandler(this.tbx_freetext_TextChanged);
            this.tbx_freetext.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbx_freetext_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(248, 205);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 12;
            this.label1.Text = "label1";
            // 
            // QuickFillWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 237);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbx_freetext);
            this.Controls.Add(this.btn_confirm);
            this.Controls.Add(this.insetPanel1);
            this.Controls.Add(this.scr_quickfill);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private vatsys.InsetPanel insetPanel1;
        private System.Windows.Forms.TableLayoutPanel tbl_quickFillSelector;
        private VATSYSControls.ScrollBar scr_quickfill;
        private vatsys.GenericButton btn_confirm;
        private vatsys.TextField tbx_freetext;
        private System.Windows.Forms.Label label1;
    }
}