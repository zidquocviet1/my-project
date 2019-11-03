using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.DTO
{
    public class KhachHang
    {

        public KhachHang(string name, string nameOfOrders, string email, string address, string phoneNumber, string fax, bool gender)
        {
            this.name = name;
            this.nameOfOrders = nameOfOrders;
            this.email = email;
            this.address = address;
            this.phoneNumber = phoneNumber;
            this.fax = fax;
            this.gender = gender;
        }

        public int id { get; set; }
        public string name { get; set; }
        public string nameOfOrders { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public string phoneNumber { get; set; }

        public string fax { get; set; }
        public bool gender { get; set; }
    }
}
