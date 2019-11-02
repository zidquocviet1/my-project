using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.DTO
{
    public class NhanVien
    {
        public NhanVien(int id, string name, bool gender, DateTime birthDay, DateTime startDay, string address, string phoneNumber, double salary, int bonus)
        {
            this.id = id;
            this.name = name;
            this.gender = gender;
            this.birthDay = birthDay;
            this.startDay = startDay;
            this.address = address;
            this.phoneNumber = phoneNumber;
            this.salary = salary;
            this.bonus = bonus;
        }

        public int id { get; set; }

        public string name { get; set; }
        public bool gender { get; set; }
        public DateTime birthDay { get; set; } //dat ten bien theo coding convention, bien la danh tu va theo chuan Camel
        public DateTime startDay { get; set; }

        public string address { get; set; }
        public string phoneNumber { get; set; }
        public double salary { get; set; }
        public int bonus { get; set; }
    }
}
