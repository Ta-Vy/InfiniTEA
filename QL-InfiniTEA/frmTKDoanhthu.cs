using QL_InfiniTEA.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace QL_InfiniTEA
{
    public partial class frmTKDoanhthu : Form
    {
        public frmTKDoanhthu()
        {
            InitializeComponent();
        }

        private DateTime startDate;
        private DateTime endDate;

        public DateTime StartDate { get => startDate; set => startDate = value; }
        public DateTime EndDate { get => endDate; set => endDate = value; }

        private void frmTKDoanhthu_Load(object sender, EventArgs e)
        {
            //DataTable dta = HoadonDAO.Instance.ThongKeSanPham(StartDate, EndDate);
            //DataTable dta = Ketnoi.Instance.ExecuteQuery
            //("select * from view_DTTheoSanPham where [Ngày] >= '" + StartDate.Tostring("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture.stringFormat) + "' and [Ngày] <= '" + EndDate.Tostring("yyyy/MM/dd", System.Globalization.CultureInfo.InvariantCulture.stringFormat) + "'");
            DataTable dta = Ketnoi.Instance.ExecuteQuery
            ("select * from view_DTTheoSanPham where [Ngày] >= '" + StartDate + "' and [Ngày] <= '" + EndDate + "'");

            rptTK_SP_DaBan rpt = new rptTK_SP_DaBan();

            rpt.SetDataSource(dta);
            rptViewer_TKDoanhthu.ReportSource = rpt;
        }
    }
}
