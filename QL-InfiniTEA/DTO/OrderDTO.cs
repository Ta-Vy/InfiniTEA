using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_InfiniTEA.DTO
{
    public class OrderDTO
    {
        private string ten_sp;
        private int count;
        private float gia;
        private float thanhtien;

        public string Ten_sp { get => ten_sp; set => ten_sp = value; }
        public int Count { get => count; set => count = value; }
        public float Gia { get => gia; set => gia = value; }
        public float Thanhtien { get => thanhtien; set => thanhtien = value; }

        public OrderDTO(string ten_sp, int count, float gia, float tongtien)
        {
            this.Ten_sp = ten_sp;
            this.Count = count;
            this.Thanhtien = tongtien;
            this.Gia = gia;
        }

        public OrderDTO(DataRow row)
        {
            this.Ten_sp = row["ten_sp"].ToString();
            this.Count = (int)row["count"];
            this.Thanhtien = (float)Convert.ToDouble(row["thanhtien"].ToString());
            this.Gia = (float)Convert.ToDouble(row["gia"].ToString());
        }
    }
}
