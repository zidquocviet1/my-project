using QuanLyBanHang.BUS;
using QuanLyBanHang.DTO;
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
        public fMain(int type)
        {
            InitializeComponent();
            this.type = type;
        }
        public int type { get; set; }
        #region Events
        private void MenuNhaCC_Click(object sender, EventArgs e)
        {
            fNhaCungCap nhaCC = new fNhaCungCap();
            nhaCC.ShowDialog();
        }
        private void DanhSáchHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fHoaDon hoaDon = new fHoaDon();
            hoaDon.ShowDialog();
        }
        private void NhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fNhanVien fnhanvien = new fNhanVien();
            fnhanvien.ShowDialog();
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
            if (this.type == 1)
            {
                menuNhanVien.Enabled = false;
                menuTaiKhoan.Enabled = false;
                menuNhaCC.Enabled = false;
            }
            LoadHangHoa();
        }

        private void FMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void ĐăngXuấtToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có thật sự muốn đăng xuất không?","Thông Báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Hide();
                fLogin login = new fLogin();
                login.Show();
            }
        }
        private void ThôngTinTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fProfile profile = new fProfile();
            profile.ShowDialog();
        }

        private void MenuTaiKhoan_Click(object sender, EventArgs e)
        {
            fAccount account = new fAccount();
            account.ShowDialog();
        }
        private void ĐổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fPassword password = new fPassword();
            password.ShowDialog();
        }
        private void GiớiThiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Phần mềm được viết bởi Trương Văn Long và Mai Quốc Việt: " + "51800954", "Thông Tin Sản Phẩm", MessageBoxButtons.OK);
        }

        private void LiênHệAdminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Liên Hệ Mai Quốc Việt: " + "51800954" + " hoặc Trương Văn Long", "Trợ Giúp", MessageBoxButtons.OK);
        }
        private void Btn_Click(object sender, EventArgs e)
        {

            ListViewItem lsvItem = new ListViewItem("mai quoc viet");
            lsvItem.SubItems.Add("100000");

            lsvHoaDon.Items.Add(lsvItem);
        }
        #endregion

        #region Methods
        public void LoadHangHoa()
        {
            List<HangHoaDTO> hangHoaList = HangHoaBUS.Instance.LoadHangHoa();

            foreach (HangHoaDTO hangHoa in hangHoaList)
            {
                Button btn = new Button() { Width = HangHoaBUS.HangHoaWidth, Height = HangHoaBUS.HangHoaHeight };

                btn.Text = hangHoa.name + Environment.NewLine + hangHoa.gia + Environment.NewLine + hangHoa.ghiChu;
                btn.Font = new Font("Segoe UI", 11f);
                btn.Click += Btn_Click;

                switch (hangHoa.ghiChu)
                {
                    case "Còn hàng":
                        btn.BackColor = Color.Azure;
                        break;
                    default:
                        btn.BackColor = Color.LightPink;
                        break;
                }
                flpHangHoa.Controls.Add(btn);
            }
        }
        #endregion


    }
}
