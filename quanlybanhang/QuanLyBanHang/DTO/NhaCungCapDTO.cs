using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.DTO
{
    public class NhaCungCapDTO
    {
        public NhaCungCapDTO(int id,string name, string address, string email, string phoneNumber, string fax)
        {
            this.id = id;
            this.name = name;
            this.address = address;
            this.email = email;
            this.phoneNumber = phoneNumber;
            this.fax = fax;
        }

        public int id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public string fax { get; set; }
    }
}
