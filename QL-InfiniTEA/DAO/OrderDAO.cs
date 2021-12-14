using QL_InfiniTEA.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_InfiniTEA.DAO
{
    public class OrderDAO
    {
        private static OrderDAO instance;

        public static OrderDAO Instance
        {
            get { if (instance == null) instance = new OrderDAO(); return instance; }
            private set { instance = value; }
        }

        private OrderDAO() { }

        public List<OrderDTO> ChitietOrderTheoBan(int id_ban)
        {
            List<OrderDTO> listOrder = new List<OrderDTO>();
            
            string query = "select sp.ten_sp, sp.gia,th.count, sp.gia*th.count as thanhtien from HOADON as h, TTHOADON as th, SANPHAM as sp where h.id_hoadon = th.id_hoadon and th.id_sp = sp.id_sp and h.trangthai = 0 and h.id_ban =" + id_ban;
            DataTable dta = Ketnoi.Instance.ExecuteQuery(query);

            foreach(DataRow item in dta.Rows)
            {
                OrderDTO order = new OrderDTO(item);
                listOrder.Add(order);
            }

            return listOrder;
        }
    }
}