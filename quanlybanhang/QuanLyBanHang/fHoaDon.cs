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
            LoadFirstCellSelection();
            ChangeHeader();
        }
        private void LoadData()
        {
            dgvHoaDon.DataSource = DataAccess.Instance.LoadData("select * from hoa_don");
        }
        private void LoadBillInfoData(int id)
        {
            string query = "select m.ten_hang, hi.so_luong, m.don_vi_tinh, m.gia, m.so_luong*m.gia as thanh_tien from hoa_don as h, chi_tiet_hoa_don as hi, mat_hang as m where hi.id_hoa_don = h.id and hi.id_mat_hang = m.id_mat_hang and h.id = " + id;
            dgvBillInfo.DataSource = DataAccess.Instance.LoadData(query);
        }
        private void LoadFirstCellSelection()
        {
            txtMaHoaDon.Text = dgvHoaDon.Rows[0].Cells[0].Value.ToString();
            LoadBillInfoData((int)dgvHoaDon.Rows[0].Cells[0].Value);
        }
        private void ChangeHeader()
        {
            dgvHoaDon.Columns[0].HeaderText = "ID";
            dgvHoaDon.Columns[1].HeaderText = "Ngày Xuất";
            dgvHoaDon.Columns[2].HeaderText = "Trạng Thái";
            dgvHoaDon.Columns[3].HeaderText = "Tổng Tiền";

            dgvBillInfo.Columns[0].HeaderText = "Tên Hàng";
            dgvBillInfo.Columns[1].HeaderText = "Số Lượng";
            dgvBillInfo.Columns[2].HeaderText = "Đơn Vị Tính";
            dgvBillInfo.Columns[3].HeaderText = "Giá";
            dgvBillInfo.Columns[4].HeaderText = "Thành Tiền";

            dgvBillInfo.Columns[0].Width = 152;
            dgvBillInfo.Columns[1].Width = 75;
            dgvBillInfo.Columns[2].Width = 75;

            dgvHoaDon.Columns[0].Width = 30;
            dgvHoaDon.Columns[1].Width = 70;
            dgvHoaDon.Columns[3].Width = 70;
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

        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;

            if (index < 0 || index > dgvHoaDon.Rows.Count)
                return;

            int id = (int)dgvHoaDon.Rows[index].Cells[0].Value;
            txtMaHoaDon.Text = id.ToString();
            LoadBillInfoData(id);
        }
    }
}
