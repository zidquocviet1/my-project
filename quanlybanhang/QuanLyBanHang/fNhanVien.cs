using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyBanHang.BUS;

namespace QuanLyBanHang
{
    public partial class fNhanVien : Form
    {
        NhanVienBUS nhanvien = new NhanVienBUS();
        public fNhanVien()
        {
            InitializeComponent();
            LoadData();
            ChangeHeader();
        }

        private void LoadData()
        {
            dgvEmployee.DataSource = nhanvien.LoadEmployeeList();
        }
        private void Button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TxtID_TextChanged(object sender, EventArgs e)
        {

        }

        private void ChangeHeader()
        {
            dgvEmployee.Columns[0].HeaderText = "Mã Nhân Viên";
            dgvEmployee.Columns[1].HeaderText = "Tên Nhân Viên";
            dgvEmployee.Columns[2].HeaderText = "Ngày Sinh";
            dgvEmployee.Columns[3].HeaderText = "Ngày Làm Việc";
            dgvEmployee.Columns[4].HeaderText = "Địa Chỉ";
            dgvEmployee.Columns[5].HeaderText = "Điện Thoại";
            dgvEmployee.Columns[6].HeaderText = "Lương";
            dgvEmployee.Columns[7].HeaderText = "Phụ Cấp";
        }
    }
}
