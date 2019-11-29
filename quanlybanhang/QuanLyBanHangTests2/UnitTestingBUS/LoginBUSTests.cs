using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuanLyBanHang.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.DTO.Tests
{
    [TestClass()]
    public class LoginBUSTests
    {
        [TestMethod()]
        public void AccountExist()
        {
            string username = "vanlong";
            string password = "1234";
            LoginBUS login = new LoginBUS();

            int status = login.CheckLogin(username, password);

            Assert.IsTrue(status == 1);
        }
        [TestMethod()]
        public void AccountNotExist()
        {
            string username = "ty";
            string password = "1234";
            LoginBUS login = new LoginBUS();

            int status = login.CheckLogin(username, password);

            Assert.IsFalse(status == 1);
        }
        [TestMethod()]
        public void Null_Username()
        {
            string username = "";
            string password = "1234";
            LoginBUS login = new LoginBUS();

            int status = login.CheckLogin(username, password);

            Assert.IsFalse(status == 1);
        }
        [TestMethod()]
        public void Null_Password()
        {
            string username = "giakien";
            string password = "";
            LoginBUS login = new LoginBUS();

            int status = login.CheckLogin(username, password);

            Assert.IsFalse(status == 1);
        }

    }
}