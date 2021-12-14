using QL_InfiniTEA.DAO;
using QL_InfiniTEA.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static QL_InfiniTEA.frmProfile;

namespace QL_InfiniTEA
{
    public partial class frmOrder : Form
    {
        private TaikhoanDTO loginAccount;

        public TaikhoanDTO LoginAccount 
        {
            get { return loginAccount; }
            set { loginAccount = value; }
        }

        public frmOrder(TaikhoanDTO acc)
        {
            InitializeComponent();

            this.loginAccount = acc; //Truyền tài khoản đăng nhập vào frm order
            Quyen_Account(loginAccount.Loai);

            Load_DSBan();
            Load_DMSanpham();
            Load_cboBan(cboChuyenban);
           
        }
        #region Method

        //Hàm phân quyền account - manager thì menu Quản lý sẽ Enable và ngược lại
        void Quyen_Account(int loai)
        {
            managerToolStripMenuItem.Enabled = loai == 1;
            thongtinTKToolStripMenuItem.Text += " (" + loginAccount.Ten_nv + ")";
        }

        void Load_DSBan()
        {
            flowLayoutPanelBan.Controls.Clear();

            List<BanDTO> listBan = BanDAO.Instance.Load_DSBan();
            
            foreach(BanDTO item in listBan)
            {
                Button btn = new Button() { Width = BanDAO.chieurong, Height = BanDAO.chieucao};
                btn.Text = item.Ten_ban + Environment.NewLine + item.Trangthai;

                //Bắt event - nhấn vào nút Bàn -> Hiển thị hóa đơn
                btn.Click += Btn_Click;

                btn.Tag = item;

                switch (item.Trangthai)
                {
                    case "Trống":
                        btn.BackColor = Color.Yellow;
                        break;
                    default:
                        btn.BackColor = Color.Green;
                        break;
                }
                flowLayoutPanelBan.Controls.Add(btn);
            }
        }

        void Load_DMSanpham()
        {
            List<DMSanphamDTO> listDMSP = DMSanphamDAO.Instance.LayDS_DMSanpham();
            cboDMSP.DataSource = listDMSP;
            cboDMSP.DisplayMember = "ten_dmsp";
        }

        void Load_Sanpham_TheoDMSanpham(int id_dmsp)
        {
            List<SanphamDTO> listSP = SanphamDAO.Instance.LayDS_SanphamTheoDMSP(id_dmsp);
            cboSP.DataSource = listSP;
            cboSP.DisplayMember = "ten_sp";
        }

        //Hiển thị hóa đơn theo id bàn
        void Hienthi_Hoadon(int id_ban)
        {
            lsvOrder.Items.Clear();
            List<OrderDTO> listTT = OrderDAO.Instance.ChitietOrderTheoBan(id_ban);

            float Tongtien = 0;

            foreach(OrderDTO item in listTT)
            {
                ListViewItem listViewItem = new ListViewItem(item.Ten_sp.ToString());
                listViewItem.SubItems.Add(item.Gia.ToString());
                listViewItem.SubItems.Add(item.Count.ToString());
                listViewItem.SubItems.Add(item.Thanhtien.ToString());

                Tongtien += item.Thanhtien;
                
                lsvOrder.Items.Add(listViewItem);
            }

            //Format language txt Tổng tiền - "c" - culture - Tiếng Việt
            CultureInfo culture = new CultureInfo("vi");
            //Thread.CurrentThread.CurrentCulture = culture;// chỉ áp dụng đối với luồng hiện tại

            txtTongtien.Text = Tongtien.ToString("c", culture); //Chỉ áp dụng đối với txtTongtien - luồng hiện tại 
                        
        }

        void Load_cboBan(ComboBox cbo)
        {
            cbo.DataSource = BanDAO.Instance.Load_DSBan();
            cbo.DisplayMember = "ten_ban";
        }
        #endregion


        #region Events
        //ShorcutKey
        private void thêmMónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnThemSP_Click(this, new EventArgs());
        }

        private void thanhToánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnThanhtoan_Click(this, new EventArgs());
        }
        private void chuyểnBànToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnChuyenban_Click(this, new EventArgs());
        }

        //Event click vào bàn thì hiển thị hóa đơn bàn đó
        private void Btn_Click(object sender, EventArgs e)
        {
            int id_ban = ((sender as Button).Tag as BanDTO).Id_ban; 
            lsvOrder.Tag = (sender as Button).Tag; //Mỗi khi click button thì listView sẽ Tag vào button đó
            Hienthi_Hoadon(id_ban);
        }

        private void đăngXuấtToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void thongtinTKToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProfile f = new frmProfile(loginAccount);

            //Bắt Event cập nhật tên hiển thị 
            f.CapnhatTenHienthi += F_CapnhatTenHienthi;
            f.ShowDialog();
        }
        

        private void managerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManager f = new frmManager();
            f.loginAccount = LoginAccount;

            //Bắt Event cập nhật sản phẩm
            f.InsertSP += F_InsertSP;
            f.DeleteSP += F_DeleteSP;
            f.UpdateSP += F_UpdateSP;

            //Bắt Event cập nhật bàn
            f.InsertBan += F_InsertBan;
            f.UpdateBan += F_UpdateBan;
            f.DeleteBan += F_DeleteBan;
            f.ShowDialog();
        }

        //Các Event tự động cập nhật thông tin form cha khi thay đổi thông tin ở form con
        void F_CapnhatTenHienthi(object sender, TaikhoanEvent e)
        {
            thongtinTKToolStripMenuItem.Text = "Thông tin tài khoản (" + e.Acc.Ten_nv + ")";
        }

        private void F_DeleteBan(object sender, EventArgs e)
        {
            Load_DSBan();
        }

        private void F_UpdateBan(object sender, EventArgs e)
        {
            Load_DSBan();
        }

        private void F_InsertBan(object sender, EventArgs e)
        {
            Load_DSBan();
        }

        private void F_UpdateSP(object sender, EventArgs e)
        {
            Load_Sanpham_TheoDMSanpham((cboDMSP.SelectedItem as DMSanphamDTO).Id_dmsp);
            if (lsvOrder.Tag != null)
            {
                Hienthi_Hoadon((lsvOrder.Tag as BanDTO).Id_ban);
            }
        }

        private void F_DeleteSP(object sender, EventArgs e)
        {
            Load_Sanpham_TheoDMSanpham((cboDMSP.SelectedItem as DMSanphamDTO).Id_dmsp);
            if (lsvOrder.Tag != null)
            {
                Hienthi_Hoadon((lsvOrder.Tag as BanDTO).Id_ban);
            }
            Load_DSBan();
        }

        private void F_InsertSP(object sender, EventArgs e)
        {
            Load_Sanpham_TheoDMSanpham((cboDMSP.SelectedItem as DMSanphamDTO).Id_dmsp);
            if (lsvOrder.Tag != null)
            {
                Hienthi_Hoadon((lsvOrder.Tag as BanDTO).Id_ban);
            }
        }

        //Lựa chọn danh mục
        //Mỗi lần lựa chọn danh mục thì sản phẩm tương ứng của danh mục đó sẽ tự động load theo
        private void cboDMSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;

            ComboBox cbo = sender as ComboBox;

            if (cbo.SelectedItem == null)
                return;

            DMSanphamDTO selected = cbo.SelectedItem as DMSanphamDTO;

            id = selected.Id_dmsp;

            Load_Sanpham_TheoDMSanpham(id);
        }

        //Thêm món
        private void btnThemSP_Click(object sender, EventArgs e)
        {
            BanDTO ban = lsvOrder.Tag as BanDTO;

            if(ban == null)
            {
                MessageBox.Show("Hãy chọn 1 bàn!");
                return;
            }

            int id_hoadon = HoadonDAO.Instance.LayBill_TuIDBan_ChuaCheckout(ban.Id_ban);
            int id_sp = (cboSP.SelectedItem as SanphamDTO).Id_sp; //Lấy id sản phẩm
            int count = (int)numCount.Value; // lấy số lượng sp

            if(id_hoadon == -1) //Bàn chưa có hóa đơn - Tạo mới hóa đơn
            {
                HoadonDAO.Instance.Them_Hoadon(ban.Id_ban);
                TTHoadonDAO.Instance.Them_TTHoadon(HoadonDAO.Instance.LayIDHoadon_Max(),id_sp,count);
            }
            else // Bàn đã có order - thay đổi hóa đơn đã tồn tại
            {
                TTHoadonDAO.Instance.Them_TTHoadon(id_hoadon, id_sp, count);
            }

            Hienthi_Hoadon(ban.Id_ban);

            Load_DSBan(); //Mỗi lần hiển thêm món thì load lại ds bàn
        }


        //Thanh toán
        private void btnThanhtoan_Click(object sender, EventArgs e)
        {
            BanDTO ban = lsvOrder.Tag as BanDTO;

            int id_hoadon = HoadonDAO.Instance.LayBill_TuIDBan_ChuaCheckout(ban.Id_ban);
            int giamgia = (int)numGiamgia.Value;

            double tongtien = Convert.ToDouble(txtTongtien.Text.Split(',')[0]);
            double tongtien1 = tongtien * 1000;
            double thucnhan = tongtien1 - (tongtien1 / 100) * giamgia;

            if(id_hoadon != -1)
            {
                if(MessageBox.Show(string.Format(" Bạn có chắc muốn thanh toán cho bàn {0}\n Tổng tiền - Tổng tiền x (Giảm giá/100) \n => {1} - {1} x ({2}/100) = {3} ", ban.Ten_ban, tongtien1, giamgia, thucnhan), "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK) //Nếu nhấn OK sẽ thanh toán
                {
                    HoadonDAO.Instance.Xuat_Hoadon(id_hoadon, giamgia, (float)thucnhan);

                    //Thanh toán xong load lại cái Order

                    Hienthi_Hoadon(ban.Id_ban); // Hiển thị theo bàn
                }
            }
            
            
            Load_DSBan(); //Mỗi lần thanh toán thì load lại trạng thái bàn
        }

        //Chuyển bàn
        private void btnChuyenban_Click(object sender, EventArgs e)
        {
            
            int id_bancu = (lsvOrder.Tag as BanDTO).Id_ban;

            int id_banmoi = (cboChuyenban.SelectedItem as BanDTO).Id_ban;

            if (MessageBox.Show("Bạn có thực sự muốn chuyển Bàn "+ id_bancu +" sang Bàn "+ id_banmoi +"", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                BanDAO.Instance.ChuyenBan(id_bancu, id_banmoi);
            }

            Load_DSBan();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void lsvOrder_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
