using System;
using System.Collections.Generic;
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
