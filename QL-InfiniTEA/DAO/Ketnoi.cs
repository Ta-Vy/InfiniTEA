using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_InfiniTEA
{
    public class Ketnoi
    {
        public SqlConnection cnn;
        public SqlCommand cmd;
        public DataTable dta;
        public SqlDataAdapter ada;
        private string str = @"Data Source=TCV\SQLEXPRESS;Initial Catalog=INFINITEA;Integrated Security=True";

        private static Ketnoi instance;
        private Ketnoi() { }

        public static Ketnoi Instance {
            get { 
                if (instance == null) instance = new Ketnoi(); 
                return instance; 
            }
            private set { instance = value; }
        }



        public void KetNoi_DuLieu()
        {            
            cnn = new SqlConnection(str);
            cnn.Open();
        }

        public void HuyKetNoi()
        {
            if (cnn.State == ConnectionState.Open);
            cnn.Close();
        }
        //--------------------------------------------------------------
 
        //Hàm lấy dữ liệu khi select, trả ra DataTable
        public DataTable ExecuteQuery(string sql, object[] parameter = null) //object tham số có thể null
        {
            KetNoi_DuLieu();
            DataTable dta = new DataTable();
            cmd = new SqlCommand(sql, cnn);
            if (parameter != null) //Nếu object khác null, tức à có tham số
            {
                string[] list = sql.Split(' '); //Băm chuỗi sql theo khoảng trống -> gán vào mảng string
                int i = 0;
                foreach (string item in list) 
                {
                    if (item.Contains('@')) //Nếu mỗi item trong list 
                    {
                        cmd.Parameters.AddWithValue(item, parameter[i]);
                        i++;
                    }
                }
            }
            SqlDataAdapter ada = new SqlDataAdapter(cmd);
            ada.Fill(dta);
            HuyKetNoi();
            return dta;
        }

        //Hàm trả ra số dòng thực thi thành công khi insert, update
        public int ExecuteNonQuery(string sql, object[] parameter = null)
        {
            int dta = 0;
            KetNoi_DuLieu();
            SqlCommand cmd = new SqlCommand(sql, cnn);
            if (parameter != null)
            {
                string[] list = sql.Split(' ');
                int i = 0;
                foreach (string item in list)
                {
                    if (item.Contains('@'))
                    {
                        cmd.Parameters.AddWithValue(item, parameter[i]);
                        i++;
                    }
                }
            }
            dta = cmd.ExecuteNonQuery();
            HuyKetNoi();
            return dta;
        }
        
        //Hàm trả ra Select count(*) - ô đầu tiên của dòng đầu và cột đầu
        public object ExecuteScalar(string sql)
        {
            KetNoi_DuLieu();
            object dta = 0;
            cmd = new SqlCommand(sql, cnn);
            dta = cmd.ExecuteScalar();
            HuyKetNoi();
            return dta;
        }
    }
}
