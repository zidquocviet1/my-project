using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.DAO
{
    public class DataAccess
    {
        private static DataAccess instance;

        public static DataAccess Instance
        {
            get { if (instance == null) instance = new DataAccess(); return instance; }
            private set => instance = value;
        }

        private string STRconn = "Data Source=MAIVIET;Initial Catalog=QuanLyBanHang;Integrated Security=True";
        private SqlConnection conn;
        private DataAccess() { }

        public DataSet ExecuteQuery(string query, SqlParameter[] parameters)
        {
            conn = new SqlConnection(STRconn);
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddRange(parameters);

            conn.Open();

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            adapter.Fill(ds);
            conn.Close();

            return ds;
        }
 
    }
}
