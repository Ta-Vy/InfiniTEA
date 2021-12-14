using QL_InfiniTEA.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_InfiniTEA.DAO
{
    public class DMSanphamDAO
    {
        private static DMSanphamDAO instance;

        public static DMSanphamDAO Instance 
        {   get { if (instance == null) instance = new DMSanphamDAO(); return instance; }
            private set { instance = value; } 
        }

        private DMSanphamDAO() { }

        public List<DMSanphamDTO> LayDS_DMSanpham()
        {
            List<DMSanphamDTO> listDMSP = new List<DMSanphamDTO>();

            DataTable dta = Ketnoi.Instance.ExecuteQuery("Select * from DMSANPHAM");

            foreach(DataRow item in dta.Rows)
            {
                DMSanphamDTO dmsp = new DMSanphamDTO(item);
                listDMSP.Add(dmsp);
            }

            return listDMSP;
        }

        public DataTable Lay_DS_DMSP_TabDMSP()
        {
            DataTable dta = Ketnoi.Instance.ExecuteQuery("Select * from view_DMSP");

            return dta;
        }

        public bool Them_DMSP(string ten_dmsp)
        {
            string query = string.Format("insert into DMSANPHAM values (N'{0}')", ten_dmsp);
            int result = Ketnoi.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool Sua_DMSP(int id_dmsp, string ten_dmsp)
        {
            string query = string.Format("update DMSANPHAM set ten_dmsp = N'{0}' where id_dmsp = {1}", ten_dmsp, id_dmsp);
            int result = Ketnoi.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool Xoa_DMSP(int id_dmsp)
        {
            string query = string.Format("Delete DMSANPHAM where id_dmsp = {0}", id_dmsp);
            int result = Ketnoi.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public DataTable Tim_DMSP_TheoTen(string ten_dmsp)
        {
            DataTable dta = Ketnoi.Instance.ExecuteQuery("Select * from view_DMSP where [Tên danh mục] like N'%" + ten_dmsp + "%'");

            return dta;
        }
    }
}
