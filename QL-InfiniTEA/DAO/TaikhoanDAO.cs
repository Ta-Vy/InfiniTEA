using QL_InfiniTEA.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_InfiniTEA.DAO
{
    public class TaikhoanDAO
    {

        private static TaikhoanDAO instance;

        public static TaikhoanDAO Instance
        {
            get { if (instance == null) instance = new TaikhoanDAO(); return instance; }
            private set { instance = value; }
        }

        private TaikhoanDAO() { }

        public bool Login(string taikhoan, string matkhau)
        {
            string query = "proc_Login @taikhoan , @matkhau";

            //string query = "select * from TAIKHOAN where taikhoan = '"+taikhoan+"' and matkhau ='"+matkhau+"'"; SQL injection

            DataTable ketqua = Ketnoi.Instance.ExecuteQuery(query, new object[] { taikhoan, matkhau });

            return ketqua.Rows.Count > 0; // tồn tại tài khoản mật khẩu
        }

        public TaikhoanDTO LayTaiKhoan(string taikhoan) //Lấy tài khoản nếu có username ngược lại thì trả về null
        {
            DataTable dta = Ketnoi.Instance.ExecuteQuery("Select * from TAIKHOAN where taikhoan =  '" + taikhoan + "'");

            foreach (DataRow item in dta.Rows)
            {
                return new TaikhoanDTO(item);
            }

            return null;
        }

        public bool Capnhat_TaiKhoan(string tk, string tennv, string pass, string newpass)
        {
            int ketqua = Ketnoi.Instance.ExecuteNonQuery("exec proc_CapnhatTK @TK , @TenNV , @MK , @MK_moi ", new object[] { tk, tennv, pass, newpass });

            return ketqua > 0;
        }

        public DataTable Lay_DS_Taikhoan()
        {
            return Ketnoi.Instance.ExecuteQuery("Select * from view_ThongtinTK");
        }

        public bool Them_TK(string taikhoan,int id_nv, string ten_nv, int loai)
        {
            string query = string.Format("insert into TAIKHOAN values (N'{0}',0,{1}, N'{2}',N'{3}')", taikhoan,id_nv, ten_nv, loai);
            int result = Ketnoi.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool Sua_TK(string taikhoan, string ten_nv, int loai)
        {
            string query = string.Format("update TAIKHOAN set ten_nv = N'{0}', loai = N'{1}' where taikhoan = N'{2}'", ten_nv, loai, taikhoan);
            int result = Ketnoi.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool Xoa_TK(string taikhoan)
        {

            string query = string.Format("Delete taikhoan where taikhoan = N'{0}'", taikhoan);
            int result = Ketnoi.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool Reset_Password(string taikhoan)
        {
            string query = string.Format("update TAIKHOAN set matkhau = 0 where taikhoan = N'{0}'",taikhoan);
            int result = Ketnoi.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public DataTable Tim_TK(string taikhoan)
        {
            DataTable dta = Ketnoi.Instance.ExecuteQuery("Select * from view_ThongtinTK where [Tài khoản] like '%"+taikhoan+"%'");

            return dta;
        }
    }
}
