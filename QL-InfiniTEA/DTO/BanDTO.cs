using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_InfiniTEA.DTO
{
    public class BanDTO
    {
        private int id_ban;
        private string ten_ban;
        private string trangthai;

        public int Id_ban { get => id_ban; set => id_ban = value; }
        public string Ten_ban { get => ten_ban; set => ten_ban = value; }
        public string Trangthai { get => trangthai; set => trangthai = value; }

        //Hàm dựng
        public BanDTO(int id_ban, string ten_ban, string trangthai)
        {
            this.id_ban = Id_ban;
            this.ten_ban = Ten_ban;
            this.trangthai = Trangthai;
        }

        public BanDTO(DataRow row)
        {
            this.Id_ban = (int)row["id_ban"];
            this.Ten_ban = row["ten_ban"].ToString();
            this.Trangthai = row["trangthai"].ToString();
        }
    }
}
