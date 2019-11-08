using QuanLyBanHang.DAO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.BUS
{
    public class NhaCungCapBUS
    {
        private static NhaCungCapBUS instance;

        public static NhaCungCapBUS Instance
        {
            get { if (instance == null) instance = new NhaCungCapBUS(); return instance; }
            private set => instance = value;
        }
        private NhaCungCapBUS() { }
        public int Add(DTO.NhaCungCapDTO H)
        {
            string query = "insert into nha_cung_cap values(@name, @address, @email, @phoneNuber, @fax)";

            SqlParameter para1 = new SqlParameter("@name", H.name);
            SqlParameter para2 = new SqlParameter("@address", H.address);
            SqlParameter para3 = new SqlParameter("@email", H.email);
            SqlParameter para4 = new SqlParameter("@phoneNuber", H.phoneNumber);
            SqlParameter para5 = new SqlParameter("@fax", H.fax);

            SqlParameter[] parameters = { para1, para2, para3, para4, para5 };

            int status = DataAccess.Instance.ExecuteNonQuery(query, parameters);
            return status;
        }
        public int Edit(DTO.NhaCungCapDTO E, int id)
        {
            string query = "USP_UpdateProvider @id, @name, @address, @email, @phoneNumber,@fax";

            SqlParameter para0 = new SqlParameter("@id", id);
            SqlParameter para1 = new SqlParameter("@name", E.name);
            SqlParameter para2 = new SqlParameter("@address", E.address);
            SqlParameter para3 = new SqlParameter("@email", E.email);
            SqlParameter para4 = new SqlParameter("@phoneNumber", E.phoneNumber);
            SqlParameter para5 = new SqlParameter("@fax", E.fax);

            SqlParameter[] parameters = { para0, para1, para2, para3, para4, para5};

            int status = DataAccess.Instance.ExecuteNonQuery(query, parameters);
            return status;
        }
    }
}
