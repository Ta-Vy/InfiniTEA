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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        bool Login(string taikhoan, string matkhau)
        {
            return TaikhoanDAO.Instance.Login(taikhoan, matkhau);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string taikhoan = txtTK.Text;
            string matkhau = txtMK.Text;
            if(Login(taikhoan, matkhau))
            {
                TaikhoanDTO loginAccount = TaikhoanDAO.Instance.LayTaiKhoan(taikhoan);

                frmOrder f = new frmOrder(loginAccount);
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Vui lòng kiểm tra lại thông tin đăng nhập!","Lỗi", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit(); //Thoát ứng dụng
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e) //Event close form
        {
            if (MessageBox.Show("Bạn có thực sự muốn thoát không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK) //Nếu như người dùng không nhấn OK
            {
                e.Cancel = true; //Không thực thi Event này (không đóng form)
            }    
        }

        
    }
}
