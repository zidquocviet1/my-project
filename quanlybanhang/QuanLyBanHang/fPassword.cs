using QuanLyBanHang.BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    public partial class fPassword : Form
    {
        private string password;
        private string name;

        public fPassword(string username, string password)
        {
            InitializeComponent();
            this.password = password;
            this.name = username;
        }

        private void Label7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (txtCurrentPassword.Text == "")
                MessageBox.Show("Chưa nhập mật khẩu cũ.");
            else if (txtNewPassword.Text == "")
                MessageBox.Show("Chưa nhập mật khẩu mới.");
            else if (txtConfirmPassword.Text == "")
                MessageBox.Show("Chưa nhập lại mật khẩu.");
            else if (txtCurrentPassword.Text != password)
                MessageBox.Show("Mật khẩu hiện tại không chính xác.","Lỗi");
            else if (txtNewPassword.Text != txtConfirmPassword.Text)
                MessageBox.Show("Mật khẩu không trùng khớp.", "Lỗi");

            else
            {
                int status = PasswordBUS.Instance.ChangePassword(txtNewPassword.Text, name);
                if (status > 0)
                {
                    MessageBox.Show("Thay đổi thành công.","Thông Báo",MessageBoxButtons.OK);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Cập nhật mật khẩu thất bại.","Lỗi",MessageBoxButtons.RetryCancel,MessageBoxIcon.Error);
                }
            }
        }
    }
}
