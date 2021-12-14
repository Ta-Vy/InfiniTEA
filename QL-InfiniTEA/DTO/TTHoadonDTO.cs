using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_InfiniTEA.DTO
{
    public class TTHoadonDTO
    {
        private int id_tthoadon;
        private int id_hoadon;
        private int id_sp;
        private int count;

        public int Id_tthoadon { get => id_tthoadon; set => id_tthoadon = value; }
        public int Id_hoadon { get => id_hoadon; set => id_hoadon = value; }
        public int Id_sp { get => id_sp; set => id_sp = value; }
        public int Count { get => count; set => count = value; }

        public TTHoadonDTO(int id_tthoadon, int id_hoadon, int id_sp, int count)
        {
            this.Id_tthoadon = id_tthoadon;
            this.Id_hoadon = id_hoadon;
            this.Id_sp = id_sp;
            this.Count = count;
        }
         public TTHoadonDTO(DataRow row)
        {
            this.Id_tthoadon = (int)row["id_tthoadon"];
            this.Id_hoadon = (int)row["id_hoadon"];
            this.Id_sp = (int)row["id_sp"];
            this.Count = (int)row["count"];
        }
    }
}
