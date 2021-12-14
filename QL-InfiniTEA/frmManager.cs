using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using QL_InfiniTEA.DAO;
using QL_InfiniTEA.DTO;

namespace QL_InfiniTEA
{
    public partial class frmManager : Form
    {
        BindingSource list_SP = new BindingSource();

        BindingSource list_DMSP = new BindingSource();

        BindingSource list_BAN = new BindingSource();

        BindingSource list_TK = new BindingSource();

        BindingSource list_NV = new BindingSource();

        public TaikhoanDTO loginAccount;
        public frmManager()
        {
            InitializeComponent();
        }

        #region Methods

        private void frmManager_Load(object sender, EventArgs e)
        {
            LoadTT();
        }

        void LoadTT()
        {
            Grid_Sanpham.DataSource = list_SP;
            Grid_TK.DataSource = list_TK;
            Grid_NV.DataSource = list_NV;
            Grid_DMSP.DataSource = list_DMSP;
            Grid_Ban.DataSource = list_BAN;

            Load_DateTimePicker();
            Load_TKDoanhthu(dtpTungay.Value, dtpDenngay.Value);


            Load_DSSanpham();
            Binding_SP();
            Load_DMSanpham();

            Load_DS_DMSanpham();
            Binding_DMSanpham();

            Load_DS_Ban();
            Binding_DS_Ban();

            Load_TK();
            Binding_TK();

            Load_NV();
            Binding_NV();
        }

        //Tab Doanh thu
        void Load_TKDoanhthu(DateTime checkIn, DateTime checkOut)
        {
            Grid_Doanhthu.DataSource = HoadonDAO.Instance.Hienthi_Doanhthu(checkIn, checkOut);
        }

        void Load_DoanhthuNgay(DateTime date)
        {
            Grid_Doanhthu.DataSource = HoadonDAO.Instance.Hienthi_DoanhthuNgay(date);
        }

        void Load_DateTimePicker() 
        {
            DateTime today = DateTime.Now;

            dtpTungay.Value = new DateTime(today.Year, today.Month, 1); //Load về đầu tháng - tạo sự thân thiện với người dùng
            // cộng 1 tháng vào tháng checkIn sau đó trừ 1 ngày thì có được ngày cuối tháng checkIn
            dtpDenngay.Value = dtpTungay.Value.AddMonths(1).AddDays(-1);
            dtpDoanhThuNgay.Value = today;
        }

        //Tab Sản phẩm
        void Load_DSSanpham()
        {
            list_SP.DataSource = SanphamDAO.Instance.LayDS_Sanpham();
        }

        void Binding_SP()
        {
            txtIDSP.DataBindings.Clear();
            txtIDSP.DataBindings.Add("Text", Grid_Sanpham.DataSource, "Mã sản phẩm", true, DataSourceUpdateMode.Never);

            txtTenSP.DataBindings.Clear();
            txtTenSP.DataBindings.Add("Text", Grid_Sanpham.DataSource, "Tên sản phẩm", true, DataSourceUpdateMode.Never);

            cboDMSP.DataBindings.Clear();
            cboDMSP.DataBindings.Add("Text", Grid_Sanpham.DataSource, "Tên danh mục", true, DataSourceUpdateMode.Never);

            numGia.DataBindings.Clear();
            numGia.DataBindings.Add("Value", Grid_Sanpham.DataSource, "Đơn giá", true, DataSourceUpdateMode.Never);
        }

        void Load_DMSanpham() 
        {
            List<DMSanphamDTO> listDMSP = DMSanphamDAO.Instance.LayDS_DMSanpham();
            cboDMSP.DataSource = listDMSP;
            cboDMSP.DisplayMember = "ten_dmsp";
        }

        //Tab Ban
        void Load_DS_Ban()
        {
            list_BAN.DataSource = BanDAO.Instance.Load_DS_DMBan_ChoTabDMBan();
        }

        void Binding_DS_Ban()
        {
            txtIDBan.DataBindings.Clear();
            txtIDBan.DataBindings.Add("Text", Grid_Ban.DataSource, "Mã bàn", true, DataSourceUpdateMode.Never);

            txtTenBan.DataBindings.Clear();
            txtTenBan.DataBindings.Add("Text", Grid_Ban.DataSource, "Tên bàn", true, DataSourceUpdateMode.Never);

            txtTrangthaiBan.DataBindings.Clear();
            txtTrangthaiBan.DataBindings.Add("Text", Grid_Ban.DataSource, "Trạng thái", true, DataSourceUpdateMode.Never);
        }


        //Tab Nhân viên
        void Load_NV()
        {
            list_NV.DataSource = NhanvienDAO.Instance.LayDS_Nhanvien();
        }

        void Binding_NV()
        {
            txtIDNV.DataBindings.Clear();
            txtIDNV.DataBindings.Add("Text", Grid_NV.DataSource, "Mã nhân viên", true, DataSourceUpdateMode.Never);

            txtTenNV.DataBindings.Clear();
            txtTenNV.DataBindings.Add("Text", Grid_NV.DataSource, "Tên nhân viên", true, DataSourceUpdateMode.Never);

            txtSDT.DataBindings.Clear();
            txtSDT.DataBindings.Add("Text", Grid_NV.DataSource, "Số điện thoại", true, DataSourceUpdateMode.Never);

            txtDiachi.DataBindings.Clear();
            txtDiachi.DataBindings.Add("Text", Grid_NV.DataSource, "Địa chỉ", true, DataSourceUpdateMode.Never);

            txtCCCD.DataBindings.Clear();
            txtCCCD.DataBindings.Add("Text", Grid_NV.DataSource, "Căn cước công dân", true, DataSourceUpdateMode.Never);
        }


        //Tab Tài khoản
        void Load_TK()
        {
            list_TK.DataSource = TaikhoanDAO.Instance.Lay_DS_Taikhoan();
        }
        void Binding_TK()
        {
            txtusername.DataBindings.Add("Text", Grid_TK.DataSource, "Tài khoản", true, DataSourceUpdateMode.Never);

            txtMaNhanVien.DataBindings.Add("Text", Grid_TK.DataSource, "Mã nhân viên", true, DataSourceUpdateMode.Never);

            txtTen.DataBindings.Add("Text", Grid_TK.DataSource, "Tên nhân viên", true, DataSourceUpdateMode.Never);

            numLoaiTK.DataBindings.Add("Value", Grid_TK.DataSource, "Loại tài khoản", true, DataSourceUpdateMode.Never);
        }


        #endregion



        #region Events
        #region
        private void dtpDenngay_ValueChanged(object sender, EventArgs e)
        {

        }
        private void panel18_Paint(object sender, PaintEventArgs e)
        {

        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void tcManager_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        #endregion

        //Tab Doanh thu
        #region Tab_Doanhthu
        private void btnThongke_Click(object sender, EventArgs e)
        {
            Load_TKDoanhthu(dtpTungay.Value, dtpDenngay.Value);
        }
        private void btnBCThongke_Click(object sender, EventArgs e)
        {
            frmTKDoanhthu f = new frmTKDoanhthu();
            //f.StartDate = dtpTungay.Value.ToString("yyyy-MM-dd");
            //f.EndDate = dtpDenngay.Value.ToString("yyyy-MM-dd");
            f.StartDate = dtpTungay.Value;
            f.EndDate = dtpDenngay.Value;
            f.ShowDialog();
        }
        private void btnDoanhthu_Click(object sender, EventArgs e)
        {
            Load_DoanhthuNgay(dtpDoanhThuNgay.Value);
        }
        private void btnBCDoanhthu_Click(object sender, EventArgs e)
        {
            frmBCDoanhthu f = new frmBCDoanhthu();
            f.Date = dtpDoanhThuNgay.Value;
            f.ShowDialog();

        }
        #endregion

        //Tab Sản phẩm
        #region Tab_Sanpham

        private void btnTaoSP_Click(object sender, EventArgs e)
        {
            txtTenSP.Text = "";
            numGia.Value = 0;
            cboDMSP.Text = "";

            txtTenSP.Focus();
        }

        private void btnThemSP_Click(object sender, EventArgs e)
        {
            string ten_sp = txtTenSP.Text;
            int id_dmsp = (cboDMSP.SelectedItem as DMSanphamDTO).Id_dmsp;
            float gia = (float)numGia.Value;

            if(SanphamDAO.Instance.Them_SP(ten_sp, id_dmsp, gia))
            {
                MessageBox.Show("Thêm thành công!");
                Load_DSSanpham();
                if (insertSP != null)
                {
                    insertSP(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra!");
            }
        }

        private void btnSuaSP_Click(object sender, EventArgs e)
        {
            string ten_sp = txtTenSP.Text;           
            int id_dmsp = (cboDMSP.SelectedItem as DMSanphamDTO).Id_dmsp;
            float gia = (float)numGia.Value;

            int id_sp = Convert.ToInt32(txtIDSP.Text);

            if (SanphamDAO.Instance.Sua_SP(id_sp, ten_sp, id_dmsp, gia))
            {
                MessageBox.Show("Sửa thành công!");
                Load_DSSanpham();
                if (updateSP != null)
                {
                    updateSP(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra!");
            }
        }

        private void btnXoaSP_Click(object sender, EventArgs e)
        {
            int id_sp = Convert.ToInt32(txtIDSP.Text);
            if (SanphamDAO.Instance.Xoa_SP(id_sp))
            {
                MessageBox.Show("Xóa thành công!");
                Load_DSSanpham();
                if(deleteSP != null)
                {
                    deleteSP(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra!");
            }
        }

        private event EventHandler insertSP;
        public event EventHandler InsertSP
        {
            add { insertSP += value; }
            remove { insertSP -= value; }
        }

        private event EventHandler updateSP;
        public event EventHandler UpdateSP
        {
            add { updateSP += value; }
            remove { updateSP -= value; }
        }

        private event EventHandler deleteSP;
        public event EventHandler DeleteSP
        {
            add { deleteSP += value; }
            remove { deleteSP -= value; }
        }

        private void btnTimSP_Click(object sender, EventArgs e)
        {
            //list_SP.DataSource = Tim_SP(txtTimSP.Text);
            string ten_sp = txtTimSP.Text;
            DataTable dta = SanphamDAO.Instance.Tim_SP_TheoTen(ten_sp);
            list_SP.DataSource = dta;
        }
        #endregion

        //Tab Danh mục sản phẩm
        #region Tab_DMSanpham

        void Load_DS_DMSanpham()
        {
            list_DMSP.DataSource = DMSanphamDAO.Instance.Lay_DS_DMSP_TabDMSP();
        }

        void Binding_DMSanpham()
        {
            txtIDDM.DataBindings.Add("Text", Grid_DMSP.DataSource, "Mã danh mục", true, DataSourceUpdateMode.Never);

            txtTenDM.DataBindings.Add("Text", Grid_DMSP.DataSource, "Tên danh mục", true, DataSourceUpdateMode.Never);
        }

        private void btnTaoDM_Click(object sender, EventArgs e)
        {
            txtTenDM.Text = "";
            txtTenDM.Focus();
        }

        private void btnThemDM_Click(object sender, EventArgs e)
        {
            string ten_dmsp = txtTenDM.Text;
            

            if (DMSanphamDAO.Instance.Them_DMSP(ten_dmsp))
            {
                MessageBox.Show("Thêm thành công!");
                Load_DS_DMSanpham();
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra!");
            }
        }

        private void btnSuaDM_Click(object sender, EventArgs e)
        {
            string ten_dmsp = txtTenDM.Text;
            int id_dmsp = Convert.ToInt32(txtIDDM.Text);

            if (DMSanphamDAO.Instance.Sua_DMSP(id_dmsp, ten_dmsp))
            {
                MessageBox.Show("Sửa thành công!");
                Load_DS_DMSanpham();
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra!");
            }
        }

        private void btnXoaDM_Click(object sender, EventArgs e)
        {
            int id_dmsp = Convert.ToInt32(txtIDDM.Text);

            if (DMSanphamDAO.Instance.Xoa_DMSP(id_dmsp))
            {
                MessageBox.Show("Xóa thành công!");
                Load_DS_DMSanpham();
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra!");
            }
        }

        private void btnTimDM_Click(object sender, EventArgs e)
        {
            string ten_dmsp = txtTimDM.Text;
            DataTable dta = DMSanphamDAO.Instance.Tim_DMSP_TheoTen(ten_dmsp);

            list_DMSP.DataSource = dta;
        }
        #endregion

        //Tab Danh mục bàn
        #region Tab_DMBan

        private void btnTaoBan_Click(object sender, EventArgs e)
        {
            txtTenBan.Text = "";
            txtTrangthaiBan.Text = "Trống";
        }

        private void btnThemBan_Click(object sender, EventArgs e)
        {
            string ten_ban = txtTenBan.Text;


            if (BanDAO.Instance.Them_Ban(ten_ban))
            {
                MessageBox.Show("Thêm bàn thành công!");
                Load_DS_Ban();
                if (insertBan != null)
                {
                    insertBan(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra khi thêm bàn!");
            }
        }

        private void btnSuaBan_Click(object sender, EventArgs e)
        {
            string ten_ban = txtTenBan.Text;
            int id_ban = Convert.ToInt32(txtIDBan.Text);

            if (BanDAO.Instance.Sua_Ban(ten_ban, id_ban))
            {
                MessageBox.Show("Sửa bàn thành công!");
                Load_DS_Ban();
                if (updateBan != null)
                {
                    updateBan(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra khi sửa bàn!");
            }
        }

        private void btnXoaBan_Click(object sender, EventArgs e)
        {
            int id_ban = Convert.ToInt32(txtIDBan.Text);

            if (BanDAO.Instance.Xoa_Ban(id_ban))
            {
                MessageBox.Show("Xóa bàn thành công!");
                Load_DS_Ban();
                if (deleteBan != null)
                {
                    deleteBan(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra khi xóa bàn!");
            }
        }

        private event EventHandler insertBan;
        public event EventHandler InsertBan
        {
            add { insertBan += value; }
            remove { insertBan -= value; }
        }

        private event EventHandler updateBan;
        public event EventHandler UpdateBan
        {
            add { updateBan += value; }
            remove { updateBan -= value; }
        }

        private event EventHandler deleteBan;
        public event EventHandler DeleteBan
        {
            add { deleteBan += value; }
            remove { deleteBan -= value; }
        }
        #endregion


        //Tab Nhân viên
        #region Tab_Nhanvien

        private void btnTaoNV_Click(object sender, EventArgs e)
        {
            txtTenNV.Text = "";
            txtDiachi.Text = "";
            txtSDT.Text = "";
            txtCCCD.Text = "";

            txtTenNV.Focus();
        }

        private void btnThemNV_Click(object sender, EventArgs e)
        {
            string ten_nv = txtTenNV.Text;
            string diachi = txtDiachi.Text;
            string sdt = txtSDT.Text;
            string cccd = txtCCCD.Text;

            if (NhanvienDAO.Instance.Them_NV(ten_nv, sdt, diachi, cccd))
            {
                MessageBox.Show("Thêm thành công!");
                Load_NV();
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra!");
            }
        }

        private void btnSuaNV_Click(object sender, EventArgs e)
        {
            string ten_nv = txtTenNV.Text;
            string diachi = txtDiachi.Text;
            string sdt = txtSDT.Text;
            string cccd = txtCCCD.Text;

            int id_nv = Convert.ToInt32(txtIDNV.Text);

            if (NhanvienDAO.Instance.Sua_NV(id_nv, ten_nv, sdt, diachi, cccd))
            {
                MessageBox.Show("Sửa thành công!");
                Load_NV();
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra!");
            }
        }

        private void btnXoaNV_Click(object sender, EventArgs e)
        {
            int id_nv = Convert.ToInt32(txtIDNV.Text);

            if (NhanvienDAO.Instance.Xoa_NV(id_nv) == true)
            {
                MessageBox.Show("Xóa thành công!");
                Load_NV();
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra!");
            }
        }

        private void btnTimNV_Click(object sender, EventArgs e)
        {
            string ten_nv = txtTimNV.Text;
            DataTable dta = NhanvienDAO.Instance.Tim_NV_TheoTen(ten_nv);

            list_NV.DataSource = dta;
        }
        #endregion


        //Tab Tài khoản
        #region Taikhoan

        private void btnTaoTK_Click(object sender, EventArgs e)
        {
            txtusername.Text = "";
            txtTen.Text = "";
            numLoaiTK.Value = 0;

            txtusername.Focus();
        }

        private void btnThemTK_Click(object sender, EventArgs e)
        {
            string taikhoan = txtusername.Text;
            int id_nv = Convert.ToInt32(txtMaNhanVien.Text);
            string ten_nv = txtTen.Text;
            int loai = (int)numLoaiTK.Value;

            if (TaikhoanDAO.Instance.Them_TK(taikhoan, id_nv, ten_nv, loai))
            {
                MessageBox.Show("Thêm tài khoản thành công!");
                Load_TK();
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra!");
            }
        }

        private void btnSuaTK_Click(object sender, EventArgs e)
        {
            string taikhoan = txtusername.Text;
            string ten_nv = txtTen.Text;
            int loai = (int)numLoaiTK.Value;

            if (TaikhoanDAO.Instance.Sua_TK(taikhoan, ten_nv, loai))
            {
                MessageBox.Show("Sửa tài khoản thành công!");
                Load_TK();
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra!");
            }
        }

        private void btnXoaTK_Click(object sender, EventArgs e)
        {
            string taikhoan = txtusername.Text;

            if (loginAccount.Taikhoan.Equals(taikhoan))
            {
                MessageBox.Show("Đừng tự hủy như thế chứ! :v");
                return;
            }

            if (TaikhoanDAO.Instance.Xoa_TK(taikhoan))
            {
                MessageBox.Show("Xóa tài khoản thành công!");
                Load_TK();
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra!");
            }
        }
        private void btnTImTK_Click(object sender, EventArgs e)
        {
            string taikhoan = txtTimTK.Text;
            list_TK.DataSource = TaikhoanDAO.Instance.Tim_TK(taikhoan);
        }
        private void btnDatlai_Click(object sender, EventArgs e)
        {
            string taikhoan = txtusername.Text;        

            if (TaikhoanDAO.Instance.Reset_Password(taikhoan))
            {
                MessageBox.Show("Đặt lại mật khẩu thành công!");
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra!");
            }
        }








        #endregion

        #endregion

        
    }

}
