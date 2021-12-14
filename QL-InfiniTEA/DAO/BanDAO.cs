using QL_InfiniTEA.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_InfiniTEA.DAO
{
    public class BanDAO
    {

        public static int chieurong = 85;
        public static int chieucao = 75;
        private static BanDAO instance;

        public static BanDAO Instance
        {
            get { if (instance == null) instance = new BanDAO(); return instance; }
            private set { instance = value; }
        }

        BanDAO() { }

        public List<BanDTO> Load_DSBan()
        {
            List<BanDTO> listBan = new List<BanDTO>();

            //DataTable dta = Ketnoi.Instance.ExecuteQuery("proc_LayDSBan");
            DataTable dta = Ketnoi.Instance.ExecuteQuery("Select * from DMBAN");

            foreach (DataRow item in dta.Rows)
            {
                BanDTO ban = new BanDTO(item);
                listBan.Add(ban);
            }

            return listBan;
        }

        public void ChuyenBan(int id_bancu, int id_banmoi)
        {
            Ketnoi.Instance.ExecuteQuery("exec proc_Chuyenban @idBan_moi , @idBan_cu", new object[] { id_bancu, id_banmoi });
        }

        public DataTable Load_DS_DMBan_ChoTabDMBan()
        {
            DataTable dta = Ketnoi.Instance.ExecuteQuery("Select * from view_DMBan");

            return dta;
        }

        public bool Them_Ban(string ten_ban)
        {
            string query = string.Format("insert into DMBAN values (N'{0}', N'Trống')", ten_ban);
            int result = Ketnoi.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool Sua_Ban(string ten_ban, int id_ban)
        {
            string query = string.Format("update DMBAN set ten_ban = N'{0}' where id_ban = {1}", ten_ban, id_ban);
            int result = Ketnoi.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool Xoa_Ban(int id_ban)
        {
            string query = string.Format("Delete DMBAN where id_ban = {0}", id_ban);
            int result = Ketnoi.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
    }
}
