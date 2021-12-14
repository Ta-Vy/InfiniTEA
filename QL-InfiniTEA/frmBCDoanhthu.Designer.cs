
namespace QL_InfiniTEA
{
    partial class frmBCDoanhthu
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
            this.rptViewer_BCDoanhthu = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.rptBCDoanhthuNgay1 = new QL_InfiniTEA.rptBCDoanhthuNgay();
            this.SuspendLayout();
            // 
            // rptViewer_BCDoanhthu
            // 
            this.rptViewer_BCDoanhthu.ActiveViewIndex = -1;
            this.rptViewer_BCDoanhthu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rptViewer_BCDoanhthu.Cursor = System.Windows.Forms.Cursors.Default;
            this.rptViewer_BCDoanhthu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rptViewer_BCDoanhthu.Location = new System.Drawing.Point(0, 0);
            this.rptViewer_BCDoanhthu.Name = "rptViewer_BCDoanhthu";
            this.rptViewer_BCDoanhthu.Size = new System.Drawing.Size(1269, 621);
            this.rptViewer_BCDoanhthu.TabIndex = 0;
            // 
            // frmBCDoanhthu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1269, 621);
            this.Controls.Add(this.rptViewer_BCDoanhthu);
            this.Name = "frmBCDoanhthu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Doanh thu ngày";
            this.Load += new System.EventHandler(this.frmBCDoanhthu_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer rptViewer_BCDoanhthu;
        private rptBCDoanhthuNgay rptBCDoanhthuNgay1;
        //private rptBCDoanhthuTheoNgay rptBCDoanhthuTheoNgay1;
    }
}