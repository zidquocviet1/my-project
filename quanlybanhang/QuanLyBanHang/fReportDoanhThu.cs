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
    public partial class fReportDoanhThu : Form
    {
        fDoanhThu doanhthu;
        public fReportDoanhThu(fDoanhThu doanhthu)
        {
            InitializeComponent();
            this.doanhthu = doanhthu;
        }

        private void fReportDoanhThu_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'QuanLyBanHangDataSet1.USP_DoanhThu' table. You can move, or remove it, as needed.
            this.USP_DoanhThuTableAdapter.Fill(this.QuanLyBanHangDataSet1.USP_DoanhThu,doanhthu.dtpFromDay.Value, doanhthu.dtpToDay.Value);

            this.reportViewer1.RefreshReport();
        }
    }
}
