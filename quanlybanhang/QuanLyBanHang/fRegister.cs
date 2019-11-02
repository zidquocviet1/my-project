using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    public partial class fRegister : Form
    {
        public fRegister()
        {
            InitializeComponent();
        }

        private void TbUsername_Enter(object sender, EventArgs e)
        {
            String fname = tbUsername.Text;
            if(fname.ToLower().Trim().Equals("user name"))
            {
                tbUsername.Text = "";
                tbUsername.ForeColor = Color.Black;
            }
        }

        private void TbUsername_Leave(object sender, EventArgs e)
        {
            String fname = tbUsername.Text;
            if (fname.ToLower().Trim().Equals("user name") || fname.Trim().Equals(""))
            {
                tbUsername.Text = "user name";
                tbUsername.ForeColor = Color.Gray;
            }
        }

        private void TbDisplayname_Enter(object sender, EventArgs e)
        {
            String fname = tbDisplayname.Text;
            if (fname.ToLower().Trim().Equals("name"))
            {
                tbDisplayname.Text = "";
                tbDisplayname.ForeColor = Color.Black;
            }
        }

        private void TbDisplayname_Leave(object sender, EventArgs e)
        {
            String fname = tbDisplayname.Text;
            if (fname.ToLower().Trim().Equals("name") || fname.Trim().Equals(""))
            {
                tbDisplayname.Text = "name";
                tbDisplayname.ForeColor = Color.Gray;
            }
        }

        private void TbPass_Enter(object sender, EventArgs e)
        {
            String pass = tbPass.Text;
            if (pass.ToLower().Trim().Equals("password"))
            {
                tbPass.Text = "";
                tbPass.UseSystemPasswordChar = true;
                tbPass.ForeColor = Color.Black;
            }
        }

        private void TbPass_Leave(object sender, EventArgs e)
        {
            String fpass = tbPass.Text;
            if (fpass.ToLower().Trim().Equals("password") || fpass.Trim().Equals(""))
            {
                tbPass.Text = "password";
                tbPass.UseSystemPasswordChar = false;
                tbPass.ForeColor = Color.Gray;
            }
        }

        private void TbType_Enter(object sender, EventArgs e)
        {
            String ftype = tbType.Text;
            if (ftype.ToLower().Trim().Equals("0 : admin - 1: staff"))
            {
                tbType.Text = "";
                tbType.ForeColor = Color.Black;
            }
        }

        private void TbType_Leave(object sender, EventArgs e)
        {
            String ftype = tbType.Text;
            if (ftype.ToLower().Trim().Equals("0 : admin - 1: staff") || ftype.Trim().Equals(""))
            {
                tbType.Text = "0 : admin - 1: staff";
                tbType.ForeColor = Color.Gray;
            }
        }

        private void BtCreate_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=MAIVIET;Initial Catalog=QuanLyBanHang;Integrated Security=True");

            SqlCommand cmd = new SqlCommand("INSERT INTO Account (username,displayname,password,type) VALUES (@username,@displayname,@password,@type)", conn);

            conn.Open();
            cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = tbUsername.Text;
            cmd.Parameters.Add("@displayname", SqlDbType.VarChar).Value = tbDisplayname.Text;
            cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = tbPass.Text;
            cmd.Parameters.Add("@type", SqlDbType.VarChar).Value = tbType.Text;

            if (checkUsername())
            {
                MessageBox.Show("This User name exists");
            }
            else
            {
                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Account Created");
                }
                else
                {
                    MessageBox.Show("Error");
                }
            }
            

            conn.Close();    
        }

        public Boolean checkUsername()
        {
            string username = tbUsername.Text;

            SqlConnection conn = new SqlConnection("Data Source=MAIVIET;Initial Catalog=QuanLyBanHang;Integrated Security=True");
            DataTable table = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand cmd = new SqlCommand("SELECT * FROM Account WHERE username = @username",conn);

            cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = username;

            adapter.SelectCommand = cmd;

            adapter.Fill(table);

            if(table.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void BtClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
