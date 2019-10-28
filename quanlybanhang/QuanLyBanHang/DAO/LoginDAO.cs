using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.DAO
{
    public class LoginDAO
    {
        private static LoginDAO instance;

        public static LoginDAO Instance
        {
            get{ if (instance == null) instance = new LoginDAO(); return instance; }
            private set => instance = value;
        }

        private LoginDAO() { }

        private string STRconn = "Data Source=MAIVIET;Initial Catalog=QuanLyBanHang;Integrated Security=True";
        private SqlConnection conn;

        public int CheckLogin(string query, SqlParameter[] parameters)
        {
            int status;
            conn = new SqlConnection(STRconn);
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddRange(parameters);
            conn.Open();

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);

            conn.Close();
            status = ds.Tables[0].Rows.Count;

            return status;
        }
    }
}
