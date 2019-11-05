using QuanLyBanHang.DAO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.DTO
{
    public class LoginBUS
    {
        public LoginBUS() { }
        
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
