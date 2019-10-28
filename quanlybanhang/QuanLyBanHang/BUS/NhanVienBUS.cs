using QuanLyBanHang.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.BUS
{
    public class NhanVienBUS
    {
        public NhanVienBUS() { }
        public DataTable LoadEmployeeList()
        {
            DataTable db = new DataTable();
            string query = "select * from nhan_vien";

            db = NhanVienDAO.Instance.LoadEmployeeList(query);
            return db;
        }

    }
}
