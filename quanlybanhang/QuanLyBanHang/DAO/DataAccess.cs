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

        private SqlCommand getCMD(string query)
        {
            conn = new SqlConnection(STRconn);
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);

            return cmd;
        }

        public DataTable LoadData(string query)
        {
            DataTable db = new DataTable();
            SqlCommand cmd = getCMD(query);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            adapter.Fill(db);
            conn.Close();

            return db;
        }

        public int CheckLogin(string query, SqlParameter[] parameters)
        {
            int status;
            SqlCommand cmd = getCMD(query);
            cmd.Parameters.AddRange(parameters);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);

            conn.Close();
            status = ds.Tables[0].Rows.Count;

            return status;
        }
        public int ExecuteNonQuery(string query, SqlParameter[] parameters)
        {
            SqlCommand cmd = getCMD(query);
            cmd.Parameters.AddRange(parameters);

            int status = cmd.ExecuteNonQuery();
            conn.Close();
            return status;
        }

        public DataTable ExecuteQuery(string query)
        {
            SqlCommand cmd = getCMD(query);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable data = new DataTable();
            adapter.Fill(data);

            return data;
        }
        public int getType(string query, SqlParameter para)
        {
            SqlCommand cmd = getCMD(query);
            cmd.Parameters.Add(para);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable data = new DataTable();
            adapter.Fill(data);

            return (int)data.Rows[0][0];
        }

        public bool IsUserNameExist(string query, SqlParameter para)
        {
            SqlCommand cmd = getCMD(query);
            cmd.Parameters.Add(para);
            DataTable db = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(db);

            if (db.Rows.Count > 0)
                return true;
            return false;
        }

    }
}
