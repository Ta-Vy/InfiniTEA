using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_InfiniTEA.DTO
{
    public class NhanvienDTO
    {
        private int id_nv;
        private string ten_nv;
        private string sdt;
        private string diachi;
        private string cccd;

        public int Id_nv { get => id_nv; set => id_nv = value; }
        public string Ten_nv { get => ten_nv; set => ten_nv = value; }
        public string Sdt { get => sdt; set => sdt = value; }
        public string Diachi { get => diachi; set => diachi = value; }
        public string Cccd { get => cccd; set => cccd = value; }

        public NhanvienDTO (int id_nv, string ten_nv, string sdt, string diachi, string cccd)
        {
            this.Id_nv = id_nv;
            this.Ten_nv = ten_nv;
            this.Sdt = sdt;
            this.Diachi = diachi;
            this.Cccd = cccd;
        }

        public NhanvienDTO(DataRow row)
        {
            this.Id_nv = (int)row["id_nv"];
            this.Ten_nv = row["ten_nv"].ToString();
            this.Sdt = row["sdt"].ToString();
            this.Diachi = row["diachi"].ToString();
            this.Cccd = row["cccd"].ToString();
        }
    }
}
