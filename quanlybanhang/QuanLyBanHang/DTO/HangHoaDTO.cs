using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.DTO
{
    public class HangHoaDTO
    {
        public HangHoaDTO(string name, int idCongTy, int idLoaiHang, int soLuong, string donViTinh, double gia, string imagePath, string ghiChu)
        {
            this.name = name;
            this.idCongTy = idCongTy;
            this.idLoaiHang = idLoaiHang;
            this.soLuong = soLuong;
            this.donViTinh = donViTinh;
            this.gia = gia;
            this.imagePath = imagePath;
            this.ghiChu = ghiChu;
        }
        public HangHoaDTO(int idMatHang, string name, double gia, string ghiChu)
        {
            this.idMatHang = idMatHang;
            this.name = name;
            this.gia = gia;
            this.ghiChu = ghiChu;
        }

        public HangHoaDTO(DataRow row)
        {
            this.idMatHang = (int)row["id_mat_hang"];
            this.name = (string)row["ten_hang"];
            this.gia = Convert.ToDouble(row["gia"]);
            this.ghiChu = row["ghi_chu"].ToString();
        }
        public int idMatHang { get; set; }

        public string name { get; set; }
        public int idCongTy { get; set; }
        public int idLoaiHang { get; set; }
        public int soLuong { get; set; }
        public string donViTinh { get; set; }
        public double gia { get; set; }
        public string imagePath { get; set; }
        public string ghiChu { get; set; }
    }
}
