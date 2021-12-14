using QL_InfiniTEA.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_InfiniTEA
{
    public partial class frmBCDoanhthu : Form
    {
        public frmBCDoanhthu()
        {
            InitializeComponent();
        }

        private DateTime date;

        public DateTime Date { get => date; set => date = value; }

        private void frmBCDoanhthu_Load(object sender, EventArgs e)
        {
            DataTable dta = HoadonDAO.Instance.DoanhThuTheoNgay(Date);
            rptBCDoanhthuNgay rpt = new rptBCDoanhthuNgay();
            rpt.SetDataSource(dta);
            rptViewer_BCDoanhthu.ReportSource = rpt;
        }
    }
}
