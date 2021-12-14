using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_InfiniTEA.DAO
{
    public class NhanvienDAO
    {
        private static NhanvienDAO instance;

        public static NhanvienDAO Instance
        {
            get { if (instance == null) instance = new NhanvienDAO(); return instance; }
            private set { instance = value; }  
        }

        NhanvienDAO() {  }

        public DataTable LayDS_Nhanvien()
        {
            DataTable dta = Ketnoi.Instance.ExecuteQuery("select * from view_NHANVIEN");

            return dta;
        }

        public bool Them_NV(string ten_nv, string sdt, string diachi, string cccd)
        {
            string query = string.Format("insert into NHANVIEN values (N'{0}', {1}, N'{2}', {3})", ten_nv, sdt,diachi, cccd);
            int result = Ketnoi.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool Sua_NV(int id_nv, string ten_nv, string sdt, string diachi, string cccd)
        {
            string query = string.Format("update NHANVIEN set ten_nv = N'{0}', sdt = N'{1}', diachi = N'{2}', cccd = N'{3}' where id_nv = {4}", ten_nv, sdt, diachi, cccd, id_nv);
            int result = Ketnoi.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool Xoa_NV(int id_nv)
        {
            //TTHoadonDAO.Instance.Xoa_TTHoadon_KhiXoaSP(id_nv);

            string query = string.Format("Delete NHANVIEN where id_nv = {0}", id_nv);
            int result = Ketnoi.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public DataTable Tim_NV_TheoTen(string ten_nv)
        {
            DataTable dta = Ketnoi.Instance.ExecuteQuery("Select * from view_NHANVIEN where [Tên nhân viên] like N'%" + ten_nv + "%'");

            return dta;
        }
    }
}
