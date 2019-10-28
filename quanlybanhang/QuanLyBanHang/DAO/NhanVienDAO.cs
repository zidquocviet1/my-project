using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.DAO
{
    public class NhanVienDAO
    {
        private static NhanVienDAO instance;

        public static NhanVienDAO Instance
        {
            get { if (instance == null) instance = new NhanVienDAO(); return instance; }
            private set => instance = value;
        }

        private NhanVienDAO() { }

        private string STRconn = "Data Source=MAIVIET;Initial Catalog=QuanLyBanHang;Integrated Security=True";
        private SqlConnection conn;

        public DataTable LoadEmployeeList(string query)
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

    }
}
