using QuanLyBanHang.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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
            string query = "select m.ten_hang, hi.so_luong, m.don_vi_tinh, m.gia, hi.so_luong*m.gia as thanh_tien from hoa_don as h, chi_tiet_hoa_don as hi, mat_hang as m where hi.id_hoa_don = h.id and hi.id_mat_hang = m.id_mat_hang and h.id = " + id;
            dgvBillInfo.DataSource = DataAccess.Instance.LoadData(query);
        }
        private void LoadFirstCellSelection()
        {
            CultureInfo culture = new CultureInfo("vi-VN");

            txtMaHoaDon.Text = dgvHoaDon.Rows[0].Cells[0].Value.ToString();
            LoadBillInfoData((int)dgvHoaDon.Rows[0].Cells[0].Value);

            double TongTien = getTongTien();

            txtThanhTien.Text = Convert.ToDouble(dgvHoaDon.Rows[0].Cells[3].Value).ToString("c", culture);
            txtTongCong.Text = TongTien.ToString("c", culture);
            cbKhuyenMai.Text = dgvHoaDon.Rows[0].Cells[4].Value.ToString();
        }
        private void ChangeHeader()
        {
            dgvHoaDon.Columns[0].HeaderText = "ID";
            dgvHoaDon.Columns[1].HeaderText = "Ngày Xuất";
            dgvHoaDon.Columns[2].HeaderText = "Trạng Thái";
            dgvHoaDon.Columns[3].HeaderText = "Tổng Tiền";
            dgvHoaDon.Columns[4].HeaderText = "Khuyến Mãi";

            dgvBillInfo.Columns[0].HeaderText = "Tên Hàng";
            dgvBillInfo.Columns[1].HeaderText = "Số Lượng";
            dgvBillInfo.Columns[2].HeaderText = "Đơn Vị Tính";
            dgvBillInfo.Columns[3].HeaderText = "Giá";
            dgvBillInfo.Columns[4].HeaderText = "Thành Tiền";

            dgvBillInfo.Columns[0].Width = 152;
            dgvBillInfo.Columns[1].Width = 55;
            dgvBillInfo.Columns[2].Width = 55;

            dgvHoaDon.Columns[0].Width = 30;
            dgvHoaDon.Columns[1].Width = 60;
            dgvHoaDon.Columns[3].Width = 60;
            dgvHoaDon.Columns[4].Width = 40;
        }
        private double getTongTien()
        {
            double tongTien = 0;

            foreach (DataGridViewRow row in dgvBillInfo.Rows)
            {
                tongTien += Convert.ToDouble(row.Cells[4].Value);
            }
            return tongTien;
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
            CultureInfo culture = new CultureInfo("vi-VN");

            if (index < 0 || index > dgvHoaDon.Rows.Count)
                return;

            int id = (int)dgvHoaDon.Rows[index].Cells[0].Value;

            txtMaHoaDon.Text = id.ToString();
            txtThanhTien.Text = Convert.ToDouble(dgvHoaDon.Rows[index].Cells[3].Value).ToString("c", culture);
            cbKhuyenMai.Text = dgvHoaDon.Rows[index].Cells[4].Value.ToString();

            LoadBillInfoData(id);
            double TongTien = getTongTien();
            txtTongCong.Text = TongTien.ToString("c", culture);
        }
    }
}
