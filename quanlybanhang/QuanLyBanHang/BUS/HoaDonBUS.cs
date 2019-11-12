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
        public int addHoaDon(double totalPrice, int discount)
        {
            int status;
            DateTime now = DateTime.Now;
            string query = "insert into hoa_don values(@now,@status,@totalprice,@discount)";
            SqlParameter para1 = new SqlParameter("@now", now.ToShortDateString());
            SqlParameter para2 = new SqlParameter("@status", "Thanh toán bằng tiền mặt");
            SqlParameter para3 = new SqlParameter("@totalprice", totalPrice);
            SqlParameter para4 = new SqlParameter("@discount", discount);
            SqlParameter[] parameters = { para1, para2, para3, para4 };

            status = DataAccess.Instance.ExecuteNonQuery(query, parameters);

            return status;
        }
        public int getMaxIDBill()
        {
            string query = "select MAX(id) from hoa_don";
            return (int)DataAccess.Instance.ExecuteScalar(query);
        }
        public int getIDByName(string CategoryName)
        {
            string query = "select * from mat_hang where ten_hang = @CategoryName";
            SqlParameter para = new SqlParameter("@CategoryName", CategoryName);

            return (int)DataAccess.Instance.getIDByName(query, para);
        }
        public void InsertBillInfo(int idBill, int idCategory, int soLuong)
        {
            string query = "insert into chi_tiet_hoa_don values(@idBill, @idCategory, @soLuong)";

            SqlParameter para1 = new SqlParameter("@idBill", idBill);
            SqlParameter para2 = new SqlParameter("@idCategory", idCategory);
            SqlParameter para3 = new SqlParameter("@soLuong", soLuong);
            SqlParameter[] parameters = { para1, para2, para3 };

            DataAccess.Instance.ExecuteNonQuery(query,parameters);
        }
        public void UpdateSoLuongHang(int id, int soLuong)
        {
            string query = "USP_UpdateSoLuong @id, @soLuong";

            SqlParameter para1 = new SqlParameter("@id", id);
            SqlParameter para2 = new SqlParameter("@soLuong", soLuong);
            SqlParameter[] parameters = { para1, para2 };

            DataAccess.Instance.ExecuteNonQuery(query, parameters);
        }
    }
}
