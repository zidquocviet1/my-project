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
    public class KhachHangBUS
    {
        public KhachHangBUS() { }

        public DataTable LoadCustomerList()
        {
            string query = "select * from khach_hang";

            DataTable db = DataAccess.Instance.LoadData(query);
            return db;
        }

        public int AddCustomer(DTO.KhachHang C)
        {
            string query = "USP_AddCustomer @name,@ten_giao_dich,@dia_chi,@gioi_tinh,@email,@dien_thoai,@fax";

            SqlParameter para1 = new SqlParameter("@name", C.name);
            SqlParameter para2 = new SqlParameter("@ten_giao_dich", C.nameOfOrders);
            SqlParameter para3 = new SqlParameter("@dia_chi", C.address);
            SqlParameter para4 = new SqlParameter("@email", C.email);
            SqlParameter para5 = new SqlParameter("@dien_thoai", C.phoneNumber);
            SqlParameter para6 = new SqlParameter("@fax", C.fax);
            SqlParameter para7 = new SqlParameter("@gioi_tinh", C.gender);


            SqlParameter[] parameters = { para1, para2, para3, para4, para5, para6, para7};

            int status = DataAccess.Instance.ExecuteNonQuery(query, parameters);
            return status;
        }
        public int DelCustomer(int ID)
        {
            string query = "delete khach_hang where id_khach_hang = @id";

            SqlParameter para = new SqlParameter("@id", ID);

            SqlParameter[] parameters = { para };

            int status = DataAccess.Instance.ExecuteNonQuery(query, parameters);
            return status;
        }
        public int EditCustomer(DTO.KhachHang C, int id)
        {
            string query = "USP_UpdateCustomer @id, @ten, @ten_giao_dich, @dia_chi, @email, @dien_thoai, @fax";

            SqlParameter para0 = new SqlParameter("@id", id);
            SqlParameter para1 = new SqlParameter("@ten", C.name);
            SqlParameter para2 = new SqlParameter("@ten_giao_dich", C.nameOfOrders);
            SqlParameter para3 = new SqlParameter("@dia_chi", C.address);
            SqlParameter para4 = new SqlParameter("@email", C.email);
            SqlParameter para5 = new SqlParameter("@dien_thoai", C.phoneNumber);
            SqlParameter para6 = new SqlParameter("@fax", C.fax);


            SqlParameter[] parameters = { para0, para1, para2, para3, para4, para5, para6};

            int status = DataAccess.Instance.ExecuteNonQuery(query, parameters);
            return status;
        }
    }
}
