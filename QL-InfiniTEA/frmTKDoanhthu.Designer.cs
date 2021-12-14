
namespace QL_InfiniTEA
{
    partial class frmTKDoanhthu
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
            this.rptViewer_TKDoanhthu = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // rptViewer_TKDoanhthu
            // 
            this.rptViewer_TKDoanhthu.ActiveViewIndex = -1;
            this.rptViewer_TKDoanhthu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rptViewer_TKDoanhthu.Cursor = System.Windows.Forms.Cursors.Default;
            this.rptViewer_TKDoanhthu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rptViewer_TKDoanhthu.Location = new System.Drawing.Point(0, 0);
            this.rptViewer_TKDoanhthu.Name = "rptViewer_TKDoanhthu";
            this.rptViewer_TKDoanhthu.Size = new System.Drawing.Size(1211, 753);
            this.rptViewer_TKDoanhthu.TabIndex = 0;
            // 
            // frmTKDoanhthu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1211, 753);
            this.Controls.Add(this.rptViewer_TKDoanhthu);
            this.Name = "frmTKDoanhthu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Doanh thu theo sản phẩm";
            this.Load += new System.EventHandler(this.frmTKDoanhthu_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer rptViewer_TKDoanhthu;
    }
}