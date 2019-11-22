using QuanLyBanHang.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    public partial class fDoanhThu : Form
    {
        public fDoanhThu()
        {
            InitializeComponent();
            LoadData();
            ChangeHeader();
            LoadTienTheoNgay();
        }

        private void LoadData()
        {
            dgvDoanhThu.DataSource = DataAccess.Instance.LoadData("select id, ngay_ban, status, khuyen_mai, tong_tien from hoa_don");
        }

        private void ChangeHeader()
        {
            dgvDoanhThu.Columns[0].HeaderText = "Mã Hóa Đơn";
            dgvDoanhThu.Columns[1].HeaderText = "Ngày Bán";
            dgvDoanhThu.Columns[2].HeaderText = "Trạng Thái";
            dgvDoanhThu.Columns[3].HeaderText = "Khuyến Mãi";
            dgvDoanhThu.Columns[4].HeaderText = "Tổng Tiền";

            dgvDoanhThu.Columns[0].Width = 100;

            DateTime now = DateTime.Now;
            dtpFromDay.Value = new DateTime(now.Year, now.Month, 1);
            dtpToDay.Value = dtpFromDay.Value.AddMonths(1).AddDays(-1);
        }
        private void LoadTienTheoNgay()
        {
            CultureInfo culture = new CultureInfo("vi-VN");
            string query = "USP_DoanhThu @fromDate, @toDate";
            double tongDoanhThu = 0;

            SqlParameter para1 = new SqlParameter("@fromDate", dtpFromDay.Value);
            SqlParameter para2 = new SqlParameter("@toDate", dtpToDay.Value);
            SqlParameter[] parameters = { para1, para2 };

            dgvDoanhThu.DataSource = DataAccess.Instance.LoadDoanhThu(query, parameters);

            foreach (DataGridViewRow row in dgvDoanhThu.Rows)
            {
                tongDoanhThu += Convert.ToDouble(row.Cells[4].Value);
            }
            txtDoanhThu.Text = tongDoanhThu.ToString("c", culture);
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (dtpFromDay.Value > dtpToDay.Value)
            {
                MessageBox.Show("Ngày không chính xác!","Lỗi",MessageBoxButtons.RetryCancel,MessageBoxIcon.Error);
                return;
            }
            LoadTienTheoNgay();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fReportDoanhThu report = new fReportDoanhThu(this);
            report.ShowDialog();
            this.Close();
        }
    }
}
