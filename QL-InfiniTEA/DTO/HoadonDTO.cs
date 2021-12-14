using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_InfiniTEA.DTO
{
    public class HoadonDTO
    {
        private int id_hoadon;
        private DateTime? dateCheckIn;
        private DateTime? dateCheckOut;
        private int giamgia;
        private int trangthai;

        public int Id_hoadon { get => id_hoadon; set => id_hoadon = value; }
        public DateTime? DateCheckIn { get => dateCheckIn; set => dateCheckIn = value; }
        public DateTime? DateCheckOut { get => dateCheckOut; set => dateCheckOut = value; }
        public int Trangthai { get => trangthai; set => trangthai = value; }
        public int Giamgia { get => giamgia; set => giamgia = value; }

        
        public HoadonDTO(int id_hoadon, DateTime? dateCheckIn, DateTime? dateCheckOut, int trangthai, int giamgia = 0)
        {
            this.Id_hoadon = id_hoadon;
            this.DateCheckIn = dateCheckIn;
            this.DateCheckOut = dateCheckOut;
            this.Giamgia = giamgia;
            this.Trangthai = trangthai;
        }

        public HoadonDTO(DataRow row)
        {
            this.Id_hoadon = (int)row["id_hoadon"];
            this.DateCheckIn = (DateTime?)row["dateCheckIn"];
            var dateCheckOutTemp = row["dateCheckOut"];
            if (dateCheckOutTemp.ToString() != "")
            {
                this.DateCheckOut = (DateTime?)dateCheckOutTemp;
            }

            this.Giamgia = (int)row["giamgia"];
            this.Trangthai = (int)row["trangthai"];
        }
    }
}
