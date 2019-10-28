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
    public partial class fMain : Form
    {
        public fMain()
        {
            InitializeComponent();
            
        }

        private void NhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fNhanVien fnhanvien = new fNhanVien();
            fnhanvien.ShowDialog();
        }

        private void ĐăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void KháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fKhachHang fkhachhang = new fKhachHang();
            fkhachhang.ShowDialog();
        }

        private void HàngHóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fHangHoa fhanghoa = new fHangHoa();
            fhanghoa.ShowDialog();
        }

        private void FMain_Load(object sender, EventArgs e)
        {

        }

        private void FMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
