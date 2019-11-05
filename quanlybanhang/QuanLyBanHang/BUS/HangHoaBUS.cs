using QuanLyBanHang.DAO;
using QuanLyBanHang.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.BUS
{
    public class HangHoaBUS
    {
        private static HangHoaBUS instance;

        public static HangHoaBUS Instance
        {
            get { if (instance == null) instance = new HangHoaBUS(); return instance; }
            private set => instance = value;
        }
        private HangHoaBUS() { }

        public static int HangHoaWidth = 100;
        public static int HangHoaHeight = 100;
        public DataTable LoadData()
        {
            string query = "select * from mat_hang";
            DataTable db = DataAccess.Instance.LoadCategoryList(query);

            return db;
        }

        public int AddCategory(DTO.HangHoaDTO H)
        {
            string query = "USP_AddCategory @ten_hang, @id_cong_ty, @id_loai_hang, @so_luong, @don_vi_tinh, @gia, @image_path, @ghi_chu";

            SqlParameter para1 = new SqlParameter("@ten_hang", H.name);
            SqlParameter para2 = new SqlParameter("@id_cong_ty", H.idCongTy);
            SqlParameter para3 = new SqlParameter("@id_loai_hang", H.idLoaiHang);
            SqlParameter para4 = new SqlParameter("@so_luong", H.soLuong);
            SqlParameter para5 = new SqlParameter("@don_vi_tinh", H.donViTinh);
            SqlParameter para6 = new SqlParameter("@gia", H.gia);
            SqlParameter para7 = new SqlParameter("@image_path", H.imagePath);
            SqlParameter para8 = new SqlParameter("@ghi_chu", H.ghiChu);

            SqlParameter[] parameters = { para1, para2, para3, para4, para5, para6, para7, para8 };

            int status = DataAccess.Instance.ExecuteNonQuery(query, parameters);
            return status;
        }
        public int DelCategory(int ID)
        {
            string query = "delete mat_hang where id_mat_hang = @id";

            SqlParameter para = new SqlParameter("@id", ID);

            SqlParameter[] parameters = { para };

            int status = DataAccess.Instance.ExecuteNonQuery(query, parameters);
            return status;
        }
        public int EditCategory(DTO.HangHoaDTO E, int id)
        {
            string query = "USP_UpdateCategory @id, @ten_hang, @id_cong_ty, @id_loai_hang, @so_luong,@don_vi_tinh, @gia, @image_path , @ghi_chu";

            SqlParameter para0 = new SqlParameter("@id", id);
            SqlParameter para1 = new SqlParameter("@ten_hang", E.name);
            SqlParameter para2 = new SqlParameter("@id_cong_ty", E.idCongTy);
            SqlParameter para3 = new SqlParameter("@id_loai_hang", E.idLoaiHang);
            SqlParameter para4 = new SqlParameter("@so_luong", E.soLuong);
            SqlParameter para5 = new SqlParameter("@don_vi_tinh", E.donViTinh);
            SqlParameter para6 = new SqlParameter("@gia", E.gia);
            SqlParameter para7 = new SqlParameter("@image_path", E.imagePath);
            SqlParameter para8 = new SqlParameter("@ghi_chu", E.ghiChu);

            SqlParameter[] parameters = { para0, para1, para2, para3, para4, para5, para6, para7, para8 };

            int status = DataAccess.Instance.ExecuteNonQuery(query, parameters);
            return status;
        }
        public List<HangHoaDTO> LoadHangHoa()
        {
            List<HangHoaDTO> hangHoaList = new List<HangHoaDTO>();
            DataTable data = DataAccess.Instance.ExecuteQuery("USP_LoadHangHoa");

            foreach(DataRow item in data.Rows)
            {
                HangHoaDTO hangHoa = new HangHoaDTO(item);
                hangHoaList.Add(hangHoa);
            }

            return hangHoaList;
        }
    }
}
