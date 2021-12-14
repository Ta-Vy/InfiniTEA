using QL_InfiniTEA.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_InfiniTEA.DAO
{
    public class TTHoadonDAO
    {
        private static TTHoadonDAO instance;

        public static TTHoadonDAO Instance 
        {   get {if (instance == null) instance = new TTHoadonDAO(); return instance; }
            private set { instance = value; }
        }

        private TTHoadonDAO() { }

        public List<TTHoadonDTO> LayDSTTHoadon(int id_hoadon)
        {
            List<TTHoadonDTO> listTThoadon = new List<TTHoadonDTO>();

            DataTable dta = Ketnoi.Instance.ExecuteQuery("Select * from TTHOADON where id_hoadon = " + id_hoadon);

            foreach(DataRow item in dta.Rows)
            {
                TTHoadonDTO thongtin = new TTHoadonDTO(item);
                listTThoadon.Add(thongtin);
            }

            return listTThoadon;
        }

        public void Them_TTHoadon(int id_hoadon, int id_sp, int count )
        {
            Ketnoi.Instance.ExecuteQuery("exec proc_ThemTTHoadon @id_hoadon , @id_sp , @count", new object[] {id_hoadon, id_sp, count });
        }

        public void Xoa_TTHoadon_KhiXoaSP(int id_sp)
        {
            Ketnoi.Instance.ExecuteQuery("Delete TTHOADON where id_sp = " + id_sp);
        }
    }
}
