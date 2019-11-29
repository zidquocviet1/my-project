using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuanLyBanHang.BUS;
using QuanLyBanHang.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.BUS.Tests
{
    [TestClass()]
    public class SignupBUSTests
    {

        [TestMethod()]
        public void CreateAccTest()
        {
            string username = "tax";
            string displayname = "t";
            string password = "1234";
            string type = "1";
            AccountDTO A = new AccountDTO(username, displayname, password, type);
            SignupBUS Signup = new SignupBUS();

            int status = Signup.CreateAcc(username, displayname, A);

            Assert.IsTrue(status > 0);
        }

  
        
    }
}