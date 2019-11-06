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
    public class AccountBUS
    {
        private static AccountBUS instance;
        public static AccountBUS Instance { get { if (instance == null) instance = new AccountBUS(); return instance; } private set => instance = value; }

        private AccountBUS() { }

        public DataTable searchWithUserName(string userName)
        {
            string query = "select * from Account where username = @userName";
            SqlParameter para = new SqlParameter("@userName", userName);

            return DataAccess.Instance.searchData(query, para);
        }
    }
}
