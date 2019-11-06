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
    public partial class fHoaDon : Form
    {
        public fHoaDon()
        {
            InitializeComponent();
            LoadData();
            ChangeHeader();
        }
        private void LoadData()
        {
            dgvHoaDon.DataSource = DataAccess.Instance.LoadData("select * from hoa_don");
        }
        private void ChangeHeader()
        {
            dgvHoaDon.Columns[0].HeaderText = "ID";
            dgvHoaDon.Columns[1].HeaderText = "Ngày Xuất";
            dgvHoaDon.Columns[2].HeaderText = "Trạng Thái";
        }

        private void TxtID_Leave(object sender, EventArgs e)
        {
            string id = txtID.Text;

            if (id.Trim().Equals(""))
                txtID.Text = "Mã Hóa Đơn";
        }

        private void TxtID_Enter(object sender, EventArgs e)
        {
            string id = txtID.Text;

            if (id.Trim().Equals("Mã Hóa Đơn"))
                txtID.Text = "";
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            if (txtID.Text.Equals("Mã Hóa Đơn"))
            {
                LoadData();
            }
            else
            {
                int id = Convert.ToInt32(txtID.Text);
                dgvHoaDon.DataSource = HoaDonBUS.Instance.searchWithID(id);
            }
        }
    }
}
