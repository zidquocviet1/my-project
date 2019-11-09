using QuanLyBanHang.BUS;
using QuanLyBanHang.DAO;
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
        public int type { get; set; }
        public static float TotalPrice = 0;
        public fMain(int type)
        {
            InitializeComponent();
            this.type = type;
        }
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
            int id = ((sender as Button).Tag as HangHoaDTO).idMatHang;
            ShowInfo(id);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            nudSoLuong.Visible = true;
            btnOK.Visible = true;
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            int soLuong = Convert.ToInt32(nudSoLuong.Value);
            nudSoLuong.Visible = false;
            nudSoLuong.Value = 0;
            btnOK.Visible = false;
        }
        private void lsvHoaDon_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            //int index = e.ItemIndex;
            //if (index < 0 || index >= lsvHoaDon.Items.Count)
            //    return;
            //nudSoLuong.Value = Convert.ToDecimal(lsvHoaDon.SelectedItems[index].SubItems[2].Text);
        }
        private void txtTienKhach_TextChanged(object sender, EventArgs e)
        {
            float tienThoi = (float)Convert.ToDouble(txtTienKhach.Text) - (float)Convert.ToDouble(txtTongCong.Text);
            txtTienThoi.Text = tienThoi.ToString();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int phanTram = Convert.ToInt32(cbKhuyenMai.Text);
            float tongTien = 0;
            if (phanTram > 0)
            {
                tongTien = (float)Convert.ToDouble(txtTongCong.Text) - ((float)Convert.ToDouble(txtTongCong.Text) * phanTram) / 100;
                txtTongCong.Text = tongTien.ToString();
            }
            else
            {
                txtTongCong.Text = TotalPrice.ToString();
            }
        }
        #endregion

        #region Methods
        void ShowInfo(int id)
        {
            DataTable data = DataAccess.Instance.ExecuteQuery("select * from mat_hang where id_mat_hang = " + id);
            float tongTien = 0;
            cbKhuyenMai.Text = "0";

            for (int i = 0; i < lsvHoaDon.Items.Count; i++)
            {
                if (data.Rows[0][1].Equals(lsvHoaDon.Items[i].Text))
                    return;
            }

            ListViewItem lsvItem = new ListViewItem(data.Rows[0][1].ToString());
            lsvItem.SubItems.Add(data.Rows[0][6].ToString());
            lsvItem.SubItems.Add("6");
            lsvItem.SubItems.Add("100000");
           
            lsvHoaDon.Items.Add(lsvItem);
            for (int i = 0; i < lsvHoaDon.Items.Count; i++)
            {
                tongTien += (float)Convert.ToDouble(lsvItem.SubItems[3].Text);
            }
            txtTongCong.Text = tongTien.ToString();
            TotalPrice = tongTien;
        }
        
        public void LoadHangHoa()
        {
            List<HangHoaDTO> hangHoaList = HangHoaBUS.Instance.LoadHangHoa();

            foreach (HangHoaDTO hangHoa in hangHoaList)
            {
                Button btn = new Button() { Width = HangHoaBUS.HangHoaWidth, Height = HangHoaBUS.HangHoaHeight };

                btn.Text = hangHoa.name + Environment.NewLine + hangHoa.gia + Environment.NewLine + hangHoa.ghiChu;
                btn.Font = new Font("Segoe UI", 11f);
                btn.Tag = hangHoa;
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
        private void lsvHoaDon_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

    }
}
#endregion