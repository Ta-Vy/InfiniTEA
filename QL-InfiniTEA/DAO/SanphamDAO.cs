using QL_InfiniTEA.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_InfiniTEA.DAO
{
    public class SanphamDAO
    {
        private static SanphamDAO instance;

        public static SanphamDAO Instance
        {
            get { if (instance == null) instance = new SanphamDAO(); return instance; }
            private set { instance = value; }
        }

        private SanphamDAO() { }

        public List<SanphamDTO> LayDS_SanphamTheoDMSP(int id_dmsp)
        {
            List<SanphamDTO> listSP = new List<SanphamDTO>();

            DataTable dta = Ketnoi.Instance.ExecuteQuery("Select * from SANPHAM where id_dmsp ="+id_dmsp);

            foreach(DataRow item in dta.Rows)
            {
                SanphamDTO sp = new SanphamDTO(item);
                listSP.Add(sp);
            }

            return listSP;
        }

        public DataTable LayDS_Sanpham()
        {
            DataTable dta = Ketnoi.Instance.ExecuteQuery("Select * from view_SANPHAM");

            return dta;
        }

        public bool Them_SP(string ten_sp, int id_dmsp, float gia)
        {
            string query = string.Format("insert into SANPHAM values (N'{0}', {1}, {2})", ten_sp, id_dmsp, gia);
            int result = Ketnoi.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool Sua_SP(int id_sp, string ten_sp, int id_dmsp, float gia)
        {
            string query = string.Format("update SANPHAM set ten_sp = N'{0}', id_dmsp = {1}, gia = {2} where id_sp = {3}", ten_sp, id_dmsp, gia, id_sp);
            int result = Ketnoi.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool Xoa_SP(int id_sp)
        {
            TTHoadonDAO.Instance.Xoa_TTHoadon_KhiXoaSP(id_sp);

            string query = string.Format("Delete SANPHAM where id_sp = {0}", id_sp);
            int result = Ketnoi.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public DataTable Tim_SP_TheoTen(string ten_sp)
        {
            DataTable dta = Ketnoi.Instance.ExecuteQuery("Select * from view_SANPHAM where [Tên sản phẩm] like N'%" + ten_sp + "%'");

            return dta;
        }
    }
}
