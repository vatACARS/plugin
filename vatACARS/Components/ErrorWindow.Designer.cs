using System.Drawing;
using System.Windows.Forms;

namespace vatACARS.Components
{
    partial class ErrorWindow
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
            this.messagePanel = new System.Windows.Forms.TableLayoutPanel();
            this.insetPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // insetPanel2
            // 
            this.insetPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.insetPanel2.Controls.Add(this.messagePanel);
            this.insetPanel2.Location = new System.Drawing.Point(12, 12);
            this.insetPanel2.Name = "insetPanel2";
            this.insetPanel2.Size = new System.Drawing.Size(422, 198);
            this.insetPanel2.TabIndex = 4;
            // 
            // messagePanel
            // 
            this.messagePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.messagePanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.messagePanel.ColumnCount = 1;
            this.messagePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.messagePanel.Location = new System.Drawing.Point(3, 3);
            this.messagePanel.Name = "messagePanel";
            this.messagePanel.RowCount = 3;
            this.messagePanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.messagePanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.messagePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.messagePanel.Size = new System.Drawing.Size(416, 192);
            this.messagePanel.TabIndex = 0;
            // 
            // ErrorWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 222);
            this.Controls.Add(this.insetPanel2);
            this.HasMinimizeButton = false;
            this.HasSendBackButton = false;
            this.MiddleClickClose = false;
            this.MinimumSize = new System.Drawing.Size(450, 250);
            this.Name = "ErrorWindow";
            this.Text = "VatACARS Error Window";
            this.TopMost = true;
            this.insetPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private vatsys.InsetPanel insetPanel2;
        private TableLayoutPanel messagePanel;
    }
}