using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_InfiniTEA.DTO
{
    public class DMSanphamDTO
    {
        private int id_dmsp;
        private string ten_dmsp;

        public int Id_dmsp { get => id_dmsp; set => id_dmsp = value; }
        public string Ten_dmsp { get => ten_dmsp; set => ten_dmsp = value; }

        public DMSanphamDTO(int id_dmsp, string ten_dmsp)
        {
            this.Id_dmsp = id_dmsp;
            this.Ten_dmsp = ten_dmsp;
        }

        public DMSanphamDTO(DataRow row)
        {
            this.Id_dmsp = (int)row["id_dmsp"];
            this.Ten_dmsp = row["ten_dmsp"].ToString();

        }
    }
}
