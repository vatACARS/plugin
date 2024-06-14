namespace vatACARS.Components
{
    partial class HandoffSelector
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
            this.tbl_dataAuthorities = new System.Windows.Forms.TableLayoutPanel();
            this.insetPanel1 = new vatsys.InsetPanel();
            this.insetPanel2 = new vatsys.InsetPanel();
            this.tbl_sectors = new System.Windows.Forms.TableLayoutPanel();
            this.btn_handoff = new vatsys.GenericButton();
            this.btn_logoff = new vatsys.GenericButton();
            this.insetPanel1.SuspendLayout();
            this.insetPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbl_dataAuthorities
            // 
            this.tbl_dataAuthorities.BackColor = System.Drawing.Color.Transparent;
            this.tbl_dataAuthorities.ColumnCount = 5;
            this.tbl_dataAuthorities.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tbl_dataAuthorities.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tbl_dataAuthorities.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tbl_dataAuthorities.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tbl_dataAuthorities.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tbl_dataAuthorities.Location = new System.Drawing.Point(3, 3);
            this.tbl_dataAuthorities.Name = "tbl_dataAuthorities";
            this.tbl_dataAuthorities.RowCount = 4;
            this.tbl_dataAuthorities.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tbl_dataAuthorities.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tbl_dataAuthorities.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tbl_dataAuthorities.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tbl_dataAuthorities.Size = new System.Drawing.Size(492, 124);
            this.tbl_dataAuthorities.TabIndex = 1;
            // 
            // insetPanel1
            // 
            this.insetPanel1.Controls.Add(this.tbl_dataAuthorities);
            this.insetPanel1.Location = new System.Drawing.Point(3, 3);
            this.insetPanel1.Name = "insetPanel1";
            this.insetPanel1.Size = new System.Drawing.Size(498, 130);
            this.insetPanel1.TabIndex = 5;
            // 
            // insetPanel2
            // 
            this.insetPanel2.Controls.Add(this.tbl_sectors);
            this.insetPanel2.Location = new System.Drawing.Point(3, 141);
            this.insetPanel2.Name = "insetPanel2";
            this.insetPanel2.Size = new System.Drawing.Size(498, 99);
            this.insetPanel2.TabIndex = 6;
            // 
            // tbl_sectors
            // 
            this.tbl_sectors.AutoScroll = true;
            this.tbl_sectors.BackColor = System.Drawing.Color.Transparent;
            this.tbl_sectors.ColumnCount = 4;
            this.tbl_sectors.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tbl_sectors.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tbl_sectors.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tbl_sectors.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tbl_sectors.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tbl_sectors.Location = new System.Drawing.Point(3, 3);
            this.tbl_sectors.Name = "tbl_sectors";
            this.tbl_sectors.RowCount = 3;
            this.tbl_sectors.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tbl_sectors.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tbl_sectors.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tbl_sectors.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tbl_sectors.Size = new System.Drawing.Size(492, 93);
            this.tbl_sectors.TabIndex = 1;
            // 
            // btn_handoff
            // 
            this.btn_handoff.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btn_handoff.Font = new System.Drawing.Font("Terminus (TTF)", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.btn_handoff.Location = new System.Drawing.Point(387, 246);
            this.btn_handoff.Name = "btn_handoff";
            this.btn_handoff.Size = new System.Drawing.Size(105, 28);
            this.btn_handoff.SubFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_handoff.SubText = "";
            this.btn_handoff.TabIndex = 7;
            this.btn_handoff.Text = "HANDOFF";
            this.btn_handoff.UseVisualStyleBackColor = true;
            this.btn_handoff.Click += new System.EventHandler(this.btn_handoff_Click);
            // 
            // btn_logoff
            // 
            this.btn_logoff.Font = new System.Drawing.Font("Terminus (TTF)", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.btn_logoff.Location = new System.Drawing.Point(12, 246);
            this.btn_logoff.Name = "btn_logoff";
            this.btn_logoff.Size = new System.Drawing.Size(105, 28);
            this.btn_logoff.SubFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_logoff.SubText = "";
            this.btn_logoff.TabIndex = 8;
            this.btn_logoff.Text = "LOGOFF";
            this.btn_logoff.UseVisualStyleBackColor = true;
            this.btn_logoff.Click += new System.EventHandler(this.btn_logoff_Click);
            // 
            // HandoffSelector
            // 
            this.ClientSize = new System.Drawing.Size(504, 280);
            this.Controls.Add(this.btn_logoff);
            this.Controls.Add(this.btn_handoff);
            this.Controls.Add(this.insetPanel2);
            this.Controls.Add(this.insetPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimizeBox = false;
            this.Name = "HandoffSelector";
            this.Resizeable = false;
            this.insetPanel1.ResumeLayout(false);
            this.insetPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tbl_dataAuthorities;
        private vatsys.InsetPanel insetPanel1;
        private vatsys.InsetPanel insetPanel2;
        private System.Windows.Forms.TableLayoutPanel tbl_sectors;
        private vatsys.GenericButton btn_handoff;
        private vatsys.GenericButton btn_logoff;
    }
}