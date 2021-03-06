﻿using QuanLyBanHang.BUS;
using QuanLyBanHang.DTO;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    public partial class fRegister : Form
    {
        static SignupBUS signUp = new SignupBUS();
        public fRegister()
        {
            InitializeComponent();
        }

        private void Label2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có thật sự muốn thoát không?","Thông Báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
                Application.Exit();
        }

        private void TxtFullName_Enter(object sender, EventArgs e)
        {
            String fullName = txtFullName.Text;
            if (fullName.Trim().Equals("Enter your full name"))
            {
                txtFullName.Text = "";
                txtFullName.ForeColor = Color.DarkGray;
            }
        }

        private void TxtFullName_Leave(object sender, EventArgs e)
        {
            String fullName = txtFullName.Text;
            if (fullName.Trim().Equals("Enter your full name") || fullName.Trim().Equals(""))
            {
                txtFullName.Text = "Enter your full name";
                txtFullName.ForeColor = Color.DarkGray;
            }
        }

        private void TxtUserName_Leave(object sender, EventArgs e)
        {
            String userName = txtUserName.Text;
            if (userName.Trim().Equals("Enter your user name") || userName.Trim().Equals(""))
            {
                txtUserName.Text = "Enter your user name";
                txtUserName.ForeColor = Color.DarkGray;
            }
        }

        private void TxtUserName_Enter(object sender, EventArgs e)
        {
            String userName = txtUserName.Text;
            if (userName.Trim().Equals("Enter your user name"))
            {
                txtUserName.Text = "";
                txtUserName.ForeColor = Color.DarkGray;
            }
        }

        private void TxtPassword_Leave(object sender, EventArgs e)
        {
            String passWord = txtPassword.Text;
            if (passWord.ToLower().Trim().Equals("password") || passWord.ToLower().Trim().Equals(""))
            {
                txtPassword.Text = "password";
                txtPassword.ForeColor = Color.DarkGray;
            }
        }

        private void TxtPassword_Enter(object sender, EventArgs e)
        {
            String passWord = txtPassword.Text;
            if (passWord.ToLower().Trim().Equals("password"))
            {
                txtPassword.Text = "";
                txtPassword.ForeColor = Color.DarkGray;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            int status;
            string fullName = txtFullName.Text;
            string userName = txtUserName.Text;
            string passWord = txtPassword.Text;

            if (signUp.IsUserNameExist(userName))
            {
                MessageBox.Show("Tài khoản đã tồn tại vui lòng thử lại!","Thông Báo");
            }
            else if (fullName.Equals("Enter your full name") || userName.Equals("Enter your user name") || passWord.Equals("password"))
            {
                MessageBox.Show("Hãy nhập đầy đủ tất cả thông tin!", "Thông Báo");
            }
            else if (fullName.Equals(userName))
            {
                MessageBox.Show("Không được phép trùng full name và user name!", "Thông Báo");
            }
            else
            {
                AccountDTO account = new AccountDTO(userName, fullName, passWord, "1");
                status = signUp.CreateAcc(account);
                if(status > 0)
                {
                    MessageBox.Show("Tạo tài khoản thành công!", "Thông Báo");
                }
                else
                {
                    MessageBox.Show("Thất bại vui lòng thử lại!", "Thông Báo");
                }
            }
        }

        private void LlLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            fLogin login = new fLogin();
            login.Show();
            this.Close();
        }
    }
}
