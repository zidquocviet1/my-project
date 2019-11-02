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
        public int AddEmployee(DTO.NhanVien E)
        {
            string query = "insert into nhan_vien values(@name,@ngay_sinh,@ngay_lam_viec,@dia_chi,@dien_thoai,@luong,@phu_cap,@gioi_tinh)";

            SqlParameter para1 = new SqlParameter("@name", E.name);
            SqlParameter para2 = new SqlParameter("@ngay_sinh", E.birthDay);
            SqlParameter para3 = new SqlParameter("@ngay_lam_viec", E.startDay);
            SqlParameter para4 = new SqlParameter("@dia_chi", E.address);
            SqlParameter para5 = new SqlParameter("@dien_thoai", E.phoneNumber);
            SqlParameter para6 = new SqlParameter("@luong", E.salary);
            SqlParameter para7 = new SqlParameter("@phu_cap", E.bonus);
            SqlParameter para8 = new SqlParameter("@gioi_tinh", E.gender);

            SqlParameter[] parameters = { para1, para2, para3, para4, para5, para6, para7,para8};

            int status = NhanVienDAO.Instance.ExecuteNonQuery(query, parameters);
            return status;
        }
        public int DelEmployee(int ID)
        {
            string query = "delete nhan_vien where id_nhan_vien = @id";

            SqlParameter para = new SqlParameter("@id", ID);

            SqlParameter[] parameters = { para};

            int status = NhanVienDAO.Instance.ExecuteNonQuery(query, parameters);
            return status;
        }
        public int EditEmployee(DTO.NhanVien E)
        {
            string query = "USP_Update @id, @ten, @ngay_sinh, @ngay_lam_viec, @dia_chi, @dien_thoai, @luong, @phu_cap, @gioi_tinh";

            SqlParameter para0 = new SqlParameter("@id", E.id);
            SqlParameter para1 = new SqlParameter("@ten", E.name);
            SqlParameter para2 = new SqlParameter("@ngay_sinh", E.birthDay);
            SqlParameter para3 = new SqlParameter("@ngay_lam_viec", E.startDay);
            SqlParameter para4 = new SqlParameter("@dia_chi", E.address);
            SqlParameter para5 = new SqlParameter("@dien_thoai", E.phoneNumber);
            SqlParameter para6 = new SqlParameter("@luong", E.salary);
            SqlParameter para7 = new SqlParameter("@phu_cap", E.bonus);
            SqlParameter para8 = new SqlParameter("@gioi_tinh", E.gender);

            SqlParameter[] parameters = { para0, para1, para2, para3, para4, para5, para6, para7, para8 };

            int status = NhanVienDAO.Instance.ExecuteNonQuery(query, parameters);
            return status;
        }

    }
}
