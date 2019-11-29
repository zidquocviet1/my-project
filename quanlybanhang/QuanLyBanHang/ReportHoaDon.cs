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
    public partial class ReportHoaDon : Form
    {
        public ReportHoaDon()
        {
            InitializeComponent();
        }

        private void ReportHoaDon_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'QuanLyBanHangDataSet3.USP_GetBillInfo' table. You can move, or remove it, as needed.
            this.USP_GetBillInfoTableAdapter.Fill(this.QuanLyBanHangDataSet3.USP_GetBillInfo,HoaDonBUS.Instance.getMaxIDBill());

            this.reportViewer1.RefreshReport();
        }
    }
}
