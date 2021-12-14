using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace QL_InfiniTEA.DTO
{
    public class SanphamDTO
    {
        private int id_sp;
        private string ten_sp;
        private int id_dmsp;
        private float gia;

        public int Id_sp { get => id_sp; set => id_sp = value; }
        public string Ten_sp { get => ten_sp; set => ten_sp = value; }
        public int Id_dmsp { get => id_dmsp; set => id_dmsp = value; }
        public float Gia { get => gia; set => gia = value; }

        public SanphamDTO(int id_sp, string ten_sp, int id_dmsp, float gia)
        {
            this.Id_sp = id_dmsp;
            this.Ten_sp = ten_sp;
            this.Id_dmsp = id_dmsp;
            this.Gia = gia;
        }

        public SanphamDTO (DataRow row)
        {
            this.Id_sp = (int)row["id_sp"];
            this.Ten_sp = row["ten_sp"].ToString();
            this.Id_dmsp = (int)row["id_dmsp"];
            this.Gia = (float)Convert.ToDouble(row["gia"].ToString());
        }
    }
}
