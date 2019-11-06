using QuanLyBanHang.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.DTO
{
    public class LoginBUS
    {
        public LoginBUS() { }
        
        public int getType(string username)
        {
            int type;
            DataTable db = new DataTable();
            SqlParameter para = new SqlParameter("@username",username);

            type = DataAccess.Instance.getType("select type from Account where username = @username",para);

            return type;
        }
        public int CheckLogin(string username, string password)
        {
            int status;

            SqlParameter para1 = new SqlParameter("@username", username);
            SqlParameter para2 = new SqlParameter("@password", password);
            SqlParameter[] parameters = { para1, para2 };

            string query = "USP_Login @username, @password"; //cau lenh thuc thi store procedure

            status = DataAccess.Instance.CheckLogin(query, parameters);

            return status;
        }
    }

}
