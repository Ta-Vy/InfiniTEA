using QL_InfiniTEA.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_InfiniTEA.DAO
{
    public class HoadonDAO
    {
        private static HoadonDAO instance;

        public static HoadonDAO Instance 
        { get { if (instance == null) instance = new HoadonDAO(); return instance; }
          private set { instance = value; } 
        }

        private HoadonDAO() { }


        //Hàm thành công -> return id_hoadon
        //Thất bại -> return -1
        public int LayBill_TuIDBan_ChuaCheckout(int id_ban) //Lấy id hóa đơn từ bàn chưa checkout
        {
            DataTable dta = Ketnoi.Instance.ExecuteQuery("Select * from HOADON where trangthai = 0 and id_ban = " + id_ban);
            if (dta.Rows.Count > 0)
            {
                HoadonDTO hoadon = new HoadonDTO(dta.Rows[0]);
                return hoadon.Id_hoadon;
            }
            else
            {
                return -1;
            }
            
        }

        public void Them_Hoadon(int id_ban)
        {
            //Ketnoi.Instance.ExecuteQuery("exec proc_ThemHoadon @id_ban", new object[] { id_ban });
            Ketnoi.Instance.ExecuteQuery("Insert into HOADON(dateCheckIn, dateCheckOut, id_ban, trangthai, giamgia) values(Getdate(), NULL, " + id_ban + ", 0, 0)");


        }

        public int LayIDHoadon_Max() //Lấy id hóa đơn lớn nhất
        {
            try
            {
                return (int)Ketnoi.Instance.ExecuteScalar("Select max(id_hoadon) from HOADON");
            }
            catch
            {
                return 1;
            }
            
        }

        public void Xuat_Hoadon(int id, int giamgia, float tongtien)
        {
            Ketnoi.Instance.ExecuteNonQuery("Update HOADON set dateCheckOut = GETDATE(), trangthai = 1, " + " giamgia = " + giamgia + ", tongtien = " + tongtien + " where id_hoadon = " + id);
        }

        //Hiển thị doanh thu
        public DataTable Hienthi_Doanhthu(DateTime checkIn, DateTime checkOut)
        {
            return Ketnoi.Instance.ExecuteQuery("exec proc_HienThiDoanhThu @checkIn , @checkOut", new object[] { checkIn, checkOut });
        }
        public DataTable Hienthi_DoanhthuNgay(DateTime date)
        {
            return Ketnoi.Instance.ExecuteQuery("exec proc_DoanhthuTheoNgay @date", new object[] { date });
        }

        //Báo cáo thống kê doanh thu

        public DataTable DoanhThuTheoNgay(DateTime date)
        {
            return Ketnoi.Instance.ExecuteQuery("Select * from view_TK_DoanhThuNgay where [Ngày] = '"+ date.ToString("yyyy-MM-dd") +"'");
        }
        public DataTable ThongKeSanPham(DateTime start, DateTime end)
        {
            
            return Ketnoi.Instance.ExecuteQuery
            ("select * from view_DTTheoSanPham where [Ngày] >= '" + start.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture.DateTimeFormat) + "' and [Ngày] <= '" + end.ToString("yyyy/MM/dd", System.Globalization.CultureInfo.InvariantCulture.DateTimeFormat) + "'");
        }
    }
}
