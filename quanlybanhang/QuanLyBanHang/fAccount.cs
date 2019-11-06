using QuanLyBanHang.BUS;
using QuanLyBanHang.DAO;
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
    public partial class fAccount : Form
    {
        public fAccount()
        {
            InitializeComponent();
            LoadData();
            changeHeader();
        }
        private void LoadData()
        {
            dgvAccount.DataSource = DataAccess.Instance.LoadData("select * from Account");
        }
        private void changeHeader()
        {
            dgvAccount.Columns[0].HeaderText = "User Name";
            dgvAccount.Columns[1].HeaderText = "Full Name";
            dgvAccount.Columns[2].HeaderText = "Password";
            dgvAccount.Columns[3].HeaderText = "Type";
        }

        private void TxtUsername_Leave(object sender, EventArgs e)
        {
            string userName = txtUsername.Text;
            
            if (userName.ToLower().Trim().Equals(""))
            {
                txtUsername.Text = "User Name";
            }
        }

        private void TxtUsername_Enter(object sender, EventArgs e)
        {
            string userName = txtUsername.Text;

            if (userName.Trim().Equals("User Name"))
            {
                txtUsername.Text = "";
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            string userName = txtUsername.Text;

            dgvAccount.DataSource = AccountBUS.Instance.searchWithUserName(userName);

            if (userName.Equals("") || userName.Equals("User Name"))
            {
                LoadData();
            }
        }

        private void TxtUsername_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
