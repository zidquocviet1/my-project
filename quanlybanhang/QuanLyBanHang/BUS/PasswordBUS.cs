using QuanLyBanHang.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.BUS
{
    public class PasswordBUS
    {
        private static PasswordBUS instance;

        public static PasswordBUS Instance { get { if (instance == null) instance = new PasswordBUS(); return instance; } private set => instance = value; }

        private PasswordBUS() { }

        public int ChangePassword(string password, string username)
        {
            int status = 0;
            string query = "update Account set password = @newPass where username = @name";
            SqlParameter para1 = new SqlParameter("@newPass", password);
            SqlParameter para2 = new SqlParameter("@name", username);
            SqlParameter[] parameters = { para1, para2 };
            status = DataAccess.Instance.ExecuteNonQuery(query, parameters);

            return status;
        }
    }
}
