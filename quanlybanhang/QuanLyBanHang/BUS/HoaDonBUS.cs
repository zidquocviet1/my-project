using QuanLyBanHang.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang
{
    public class HoaDonBUS
    {
        private static HoaDonBUS instance;
        public static HoaDonBUS Instance { get { if (instance == null) instance = new HoaDonBUS(); return instance; } private set => instance = value; }

        private HoaDonBUS() { }

        public DataTable searchWithID(int id)
        {
            string query = "select * from hoa_don where id = " + id;

            return DataAccess.Instance.ExecuteQuery(query);
        }
        public int addHoaDon(double totalPrice)
        {
            int status;
            DateTime now = DateTime.Now;
            string query = "insert into hoa_don values(@now,@status,@totalprice)";
            SqlParameter para1 = new SqlParameter("@now", now.ToShortDateString());
            SqlParameter para2 = new SqlParameter("@status", "Thanh toán bằng tiền mặt");
            SqlParameter para3 = new SqlParameter("@totalprice", totalPrice);
            SqlParameter[] parameters = { para1, para2, para3 };

            status = DataAccess.Instance.ExecuteNonQuery(query, parameters);

            return status;
        }
    }
}
