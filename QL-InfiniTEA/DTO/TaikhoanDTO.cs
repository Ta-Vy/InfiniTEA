using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_InfiniTEA.DTO
{
    public class TaikhoanDTO
    {
        private string taikhoan;
        private string matkhau;
        private int id_nv;
        private string ten_nv;
        private int loai;

        public string Taikhoan { get => taikhoan; set => taikhoan = value; }
        public string Matkhau { get => matkhau; set => matkhau = value; }
        public int Id_nv { get => id_nv; set => id_nv = value; }
        public int Loai { get => loai; set => loai = value; }
        public string Ten_nv { get => ten_nv; set => ten_nv = value; }

        public TaikhoanDTO(string taikhoan, int id_nv, int loai,string ten_nv, string matkhau = null)
        {
            this.Taikhoan = taikhoan;
            this.Matkhau = matkhau;
            this.Id_nv = id_nv;
            this.Ten_nv = ten_nv;
            this.Loai = loai;
        }

        public TaikhoanDTO(DataRow row)
        {
            this.Taikhoan = row["taikhoan"].ToString();
            this.Matkhau = row["matkhau"].ToString();
            this.Id_nv = (int)row["id_nv"];
            this.Ten_nv = row["ten_nv"].ToString();
            this.Loai = (int)row["loai"];
        }
    }
}
