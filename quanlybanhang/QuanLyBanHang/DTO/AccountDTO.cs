using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.DTO
{
    public class AccountDTO
    {
        public AccountDTO(string userName, string displayName, string passWord, string type)
        {
            this.userName = userName;
            this.displayName = displayName;
            this.passWord = passWord;
            this.type = type;
        }

        public int id { get; set; }
        public string userName { get; set; }
        public string displayName { get; set; }
        public string passWord { get; set; }

        public string type { get; set; }
    }
}
