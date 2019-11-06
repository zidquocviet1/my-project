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
            string query = "select * from hoa_don where id = @id";
            SqlParameter para = new SqlParameter("@id", id);

            return DataAccess.Instance.searchData(query, para);
        }
    }
}
