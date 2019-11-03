using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.DAO
{
    public class KhachHangDAO
    {
        private static KhachHangDAO instance;

        public static KhachHangDAO Instance
        {
            get { if (instance == null) instance = new KhachHangDAO(); return instance; }
            private set => instance = value;
        }

        private KhachHangDAO() { }

        private string STRconn = "Data Source=MAIVIET;Initial Catalog=QuanLyBanHang;Integrated Security=True";
        private SqlConnection conn;

        public DataTable LoadCustomerList(string query)
        {
            DataTable db = new DataTable();
            conn = new SqlConnection(STRconn);

            conn.Open();

            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            adapter.Fill(db);
            conn.Close();

            return db;
        }

        public int ExecuteNonQuery(string query, SqlParameter[] parameters)
        {
            conn = new SqlConnection(STRconn);
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddRange(parameters);

            int status = cmd.ExecuteNonQuery();
            conn.Close();
            return status;
        }
    }
}
