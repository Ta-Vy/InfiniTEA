using QL_InfiniTEA.DAO;
using QL_InfiniTEA.DTO;
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
    public partial class frmProfile : Form
    {
        private TaikhoanDTO loginAccount;

        public TaikhoanDTO LoginAccount
        {
            get { return loginAccount; }
            set { loginAccount = value; }
        }
        public frmProfile(TaikhoanDTO acc)
        {
            InitializeComponent();
            loginAccount = acc;
            Hienthi_Taikhoan(loginAccount);

        }

        void Hienthi_Taikhoan(TaikhoanDTO acc)
        {
            txtTK.Text = loginAccount.Taikhoan;
            txtTenNV.Text = loginAccount.Ten_nv;
        }
        void Capnhat_Taikhoan()
        {
            string ten_nv = txtTenNV.Text;
            string pass = txtMK.Text;
            string newpass = txtMKmoi.Text;
            string reenterpass = txtNhaplai.Text;
            string taikhoan = txtTK.Text;

            if (!newpass.Equals(reenterpass))
            {
                MessageBox.Show("Vui lòng nhập lại mật khẩu đúng với mật khẩu mới!");
            }
            else
            {
                if(TaikhoanDAO.Instance.Capnhat_TaiKhoan(taikhoan, ten_nv, pass, newpass))
                {
                    MessageBox.Show("Cập nhật thành công!");

                    // Cập nhật tên hiển thị trên frmOrder sau khi update
                    if(capnhatTenHienthi != null)
                    {
                        capnhatTenHienthi(this, new TaikhoanEvent(TaikhoanDAO.Instance.LayTaiKhoan(taikhoan)));
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng điền đúng mật khẩu!");
                }
            }
        }
        private void btnCapnhat_Click(object sender, EventArgs e)
        {
            Capnhat_Taikhoan();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            this.Close();
        }

        //Event load lại tên nhân viên lên frmOrder sau khi cập nhật
        private event EventHandler<TaikhoanEvent> capnhatTenHienthi;
        public event EventHandler<TaikhoanEvent> CapnhatTenHienthi
        {
            add { capnhatTenHienthi += value; }
            remove { capnhatTenHienthi -= value; }
        }

        public class TaikhoanEvent : EventArgs
        {
            private TaikhoanDTO acc;

            public TaikhoanDTO Acc { get => acc; set => acc = value; }

            public TaikhoanEvent(TaikhoanDTO acc)
            {
                this.Acc = acc;
            }
        }

        private void frmProfile_Load(object sender, EventArgs e)
        {

        }

    }
}
