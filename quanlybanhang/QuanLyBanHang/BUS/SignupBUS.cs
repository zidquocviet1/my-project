using QuanLyBanHang.DAO;
using QuanLyBanHang.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.BUS
{
    public class SignupBUS
    {
        public SignupBUS() { }

        public int CreateAcc(AccountDTO A)
        {
            int status;
            string query = "INSERT INTO Account (username,displayname,password,type) VALUES (@username,@displayname,@password,@type)";
            SqlParameter para1 = new SqlParameter("@username", A.userName);
            SqlParameter para2 = new SqlParameter("@displayname", A.displayName);
            SqlParameter para3 = new SqlParameter("@password", A.passWord);
            SqlParameter para4 = new SqlParameter("@type", A.type);

            SqlParameter[] parameters = { para1, para2, para3, para4 };

            status = DataAccess.Instance.ExecuteNonQuery(query, parameters);
            return status;
        }

        public bool IsUserNameExist(string userName)
        {
            string query = "select * from Account where username = @username";
            SqlParameter para = new SqlParameter("@username", userName);

            if (DataAccess.Instance.IsUserNameExist(query, para))
                return true;
            return false;
        }
    }
}
