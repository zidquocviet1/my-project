using QuanLyBanHang.DAO;
using QuanLyBanHang.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace QuanLyBanHang
{
    public partial class fLogin : Form
    {
        
        public fLogin()
        {
            InitializeComponent();

            if (Properties.Settings.Default.username != string.Empty)
            {
                txtUsername.Text = Properties.Settings.Default.username;
                txtPassword.Text = Properties.Settings.Default.password;
            }
        }


        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Label2_Click(object sender, EventArgs e)
        {
            chbLogin.Checked = true;
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
        
        private void Label4_Click(object sender, EventArgs e)
        {
            //fRegister register = new fRegister();
            //this.Hide();
            //register.ShowDialog();

        }

        private void PictureBox5_Click(object sender, EventArgs e)
        {
            LoginDTO login = new LoginDTO();

            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Hay nhap day du thong tin");
                return;
            }

            int status = login.CheckLogin(txtUsername.Text, txtPassword.Text);

            if (status == 1)
            {
                fMain fmain = new fMain();
                this.Hide();
                fmain.ShowDialog();
            }
            else
            {
                MessageBox.Show("Ten tai khoan hoac mat khau khong dung","Login Page");
            }

        }

        private void CheckBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chbLogin.Checked)
            {
                Properties.Settings.Default.username = txtUsername.Text;
                Properties.Settings.Default.password = txtPassword.Text;
                Properties.Settings.Default.Save();
            }
        }
    }
}
