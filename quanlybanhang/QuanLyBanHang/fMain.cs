using QuanLyBanHang.BUS;
using QuanLyBanHang.DAO;
using QuanLyBanHang.DTO;
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
    public partial class fMain : Form
    {
        CultureInfo culture = new CultureInfo("vi-VN");
        public int type { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        double TotalPrice = 0;
        double ThanhTien = 0;

        public fMain(int type, string username, string password)
        {
            InitializeComponent();
            this.username = username;
            this.password = password;
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
            fHangHoa fhanghoa = new fHangHoa(this);
            fhanghoa.ShowDialog();
        }

        private void FMain_Load(object sender, EventArgs e)
        {
            if (this.type == 1)
            {
                menuNhanVien.Enabled = false;
                menuTaiKhoan.Enabled = false;
                menuNhaCC.Enabled = false;
                menuDoanhThu.Enabled = false;
            }
            LoadHangHoa();
            txtTienKhach.Enabled = false;
            btnClear.Enabled = false;
            btnSoLuong.Enabled = false;
            btnDelete.Enabled = false;
            btnThanhToan.Enabled = false;

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
            fPassword password = new fPassword(this.username, this.password);
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
            float tongTien = 0;
            lsvHoaDon.SelectedItems[0].SubItems[2].Text = nudSoLuong.Value.ToString();
            ThanhTien = (Convert.ToInt32(lsvHoaDon.SelectedItems[0].SubItems[2].Text) * Convert.ToInt32(lsvHoaDon.SelectedItems[0].SubItems[1].Text));
            lsvHoaDon.SelectedItems[0].SubItems[3].Text = ThanhTien.ToString();

            tongTien = getTongTien();
            if (nudSoLuong.Value > 0)
            {
                txtTongCong.Text = Convert.ToDouble(tongTien - (tongTien * Convert.ToInt32(cbKhuyenMai.Text) / 100)).ToString();
                tongTien -= tongTien * Convert.ToInt32(cbKhuyenMai.Text) / 100;
            }
            else
            {
                txtTongCong.Text = Convert.ToDouble(tongTien).ToString();
                lsvHoaDon.SelectedItems[0].Remove();
            }
            if (!txtTienKhach.Text.Equals(""))
            {
                txtTienThoi.Text = (Convert.ToDouble(txtTienKhach.Text) - tongTien).ToString("c", culture);
            }
            if (tongTien == 0)
            {
                txtTienKhach.Enabled = false;
            }
            else
            {
                txtTienKhach.Enabled = true;
            }
            TotalPrice = tongTien;

            lsvHoaDon.SelectedItems.Clear();
            btnDelete.Enabled = false;
            btnSoLuong.Enabled = false;
            nudSoLuong.Visible = false;
            btnOK.Visible = false;
        }
        private void lsvHoaDon_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            int index = e.ItemIndex;

            btnSoLuong.Enabled = true;
            btnDelete.Enabled = true;
            nudSoLuong.Visible = true;
            btnOK.Visible = true;
            nudSoLuong.Value = Convert.ToDecimal(lsvHoaDon.Items[index].SubItems[2].Text);

        }
        private void txtTienKhach_TextChanged(object sender, EventArgs e)
        {
            if (txtTienKhach.Text.Equals(""))
            {
                txtTienThoi.Text = "";
                btnThanhToan.Enabled = false;
                return;
            }
            else
            {
                double tienThoi = Convert.ToDouble(txtTienKhach.Text) - Convert.ToDouble(txtTongCong.Text);
                if (tienThoi < 0)
                {
                    btnThanhToan.Enabled = false;
                }
                else
                {
                    btnThanhToan.Enabled = true;
                }
                txtTienThoi.Text = tienThoi.ToString("c", culture);
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int phanTram = Convert.ToInt32(cbKhuyenMai.Text);
            double tongTien = 0;
            double tienThoi = 0;

            if (phanTram > 0 && txtTienKhach.Text.Equals(""))
            {
                tongTien = TotalPrice - (TotalPrice * phanTram / 100);
                txtTongCong.Text = tongTien.ToString();
                TotalPrice = tongTien;

                return;
            }
            if (!txtTienKhach.Text.Equals("") && phanTram > 0)
            {
                tongTien = TotalPrice - (TotalPrice * phanTram / 100);            
                txtTongCong.Text = tongTien.ToString();
                TotalPrice = tongTien;
                tienThoi = Convert.ToDouble(txtTienKhach.Text) - tongTien;

                if (tienThoi < 0)
                {
                    btnThanhToan.Enabled = false;
                }
                else
                {
                    btnThanhToan.Enabled = true;
                }
                txtTienThoi.Text = Convert.ToDouble(tienThoi).ToString("c", culture);

                return;
            }
            else
            {
                if (!txtTienKhach.Text.Equals(""))
                {
                    txtTongCong.Text = TotalPrice.ToString();
                    tienThoi = Convert.ToDouble(txtTienKhach.Text) - TotalPrice;
                    if (tienThoi < 0)
                    {
                        btnThanhToan.Enabled = false;
                    }
                    else
                    {
                        btnThanhToan.Enabled = true;
                    }
                    txtTienThoi.Text = Convert.ToDouble(tienThoi).ToString("c", culture);

                    return;
                }
                txtTongCong.Text = TotalPrice.ToString();
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            float tongTien = 0;

            lsvHoaDon.SelectedItems[0].Remove();
            cbKhuyenMai.Text = "0";
            btnDelete.Enabled = false;
            btnSoLuong.Enabled = false;
            nudSoLuong.Visible = false;
            btnOK.Visible = false;

            tongTien = getTongTien();
            if (tongTien == 0)
            {
                txtTongCong.Text = "";
            }
            else
            {
                txtTongCong.Text = Convert.ToDouble(tongTien).ToString();
            }
            if (txtTienKhach.Text.Equals(""))
            {
                txtTienThoi.Text = "";
            }
            else
            {
                txtTienThoi.Text = (Convert.ToDouble(txtTienKhach.Text) - tongTien).ToString("c",culture);
            }
            if (lsvHoaDon.Items.Count == 0)
            {
                txtTienKhach.Enabled = false;
                btnClear.Enabled = false;
            }
            TotalPrice = tongTien;
        }
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (txtTongCong.Text.Equals(""))
            {
                return;
            }
            if (MessageBox.Show("Bạn có thực sự muốn thanh toán không?","Thông Báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (HoaDonBUS.Instance.addHoaDon(TotalPrice, Convert.ToInt32(cbKhuyenMai.Text)) > 0)
                {
                    int idBill = HoaDonBUS.Instance.getMaxIDBill();

                    foreach (ListViewItem item in lsvHoaDon.Items)
                    {
                        HoaDonBUS.Instance.InsertBillInfo(idBill, HoaDonBUS.Instance.getIDByName(item.Text), Convert.ToInt32(item.SubItems[2].Text));
                        HoaDonBUS.Instance.UpdateSoLuongHang(HoaDonBUS.Instance.getIDByName(item.Text), Convert.ToInt32(item.SubItems[2].Text));
                    }
                    MessageBox.Show("Thanh Toán Thành Công","Thanh Toán",MessageBoxButtons.OK);
                    ClearFlow();
                    LoadHangHoa();
                }
                else
                {
                    MessageBox.Show("Thanh Toán Thất Bại","Thanh Toán",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                Clear();
                btnClear.Enabled = false;
                txtTienKhach.Enabled = false;
            }
        }
        private void xemBáoCáoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fDoanhThu doanhThu = new fDoanhThu();
            doanhThu.ShowDialog();
        }
        #endregion

        #region Methods
        private float getTongTien()
        {
            float tongTien = 0;

            for (int i = 0; i < lsvHoaDon.Items.Count; i++)
            {
                tongTien += (float)Convert.ToDouble(lsvHoaDon.Items[i].SubItems[3].Text);
            }

            return tongTien;
        }
        private void Clear()
        {
            lsvHoaDon.Items.Clear();
            txtTienKhach.Text = "";
            txtTienThoi.Text = "";
            cbKhuyenMai.Text = "0";
            txtTongCong.Text = "";
            txtTienKhach.Enabled = false;
            btnClear.Enabled = false;
            nudSoLuong.Visible = false;
            btnOK.Visible = false;
            btnSoLuong.Enabled = false;
            btnDelete.Enabled = false;
        }
        private void ShowInfo(int id)
        {
            DataTable data = DataAccess.Instance.ExecuteQuery("select * from mat_hang where id_mat_hang = " + id);
            double tongTien = 0;
            cbKhuyenMai.Text = "0";

            if (data.Rows[0][8].Equals("Hết hàng"))
            {
                return;
            }
            for (int i = 0; i < lsvHoaDon.Items.Count; i++)
            {
                if (data.Rows[0][1].Equals(lsvHoaDon.Items[i].Text) || data.Rows[0][8].Equals("Hết hàng"))
                {
                    int soLuong = Convert.ToInt32(lsvHoaDon.Items[i].SubItems[2].Text);
                    soLuong++;
                    double thanhTien = soLuong *Convert.ToDouble(lsvHoaDon.Items[i].SubItems[1].Text);

                    lsvHoaDon.Items[i].SubItems[2].Text = soLuong.ToString();
                    lsvHoaDon.Items[i].SubItems[3].Text = thanhTien.ToString();

                    for (int j = 0; j < lsvHoaDon.Items.Count; j++)
                    {
                        tongTien += Convert.ToDouble(lsvHoaDon.Items[j].SubItems[3].Text);
                    }
                    TotalPrice = tongTien;
                    txtTongCong.Text = tongTien.ToString();
                    txtTienKhach.Enabled = true;
                    return;
                }
            }

            ListViewItem lsvItem = new ListViewItem(data.Rows[0][1].ToString());
            lsvItem.SubItems.Add(data.Rows[0][6].ToString());
            lsvItem.SubItems.Add("1");
            lsvItem.SubItems.Add(data.Rows[0][6].ToString());
           
            lsvHoaDon.Items.Add(lsvItem);
            
            for (int i = 0; i < lsvHoaDon.Items.Count; i++)
            {
                tongTien += Convert.ToDouble(lsvHoaDon.Items[i].SubItems[3].Text);
            }
            txtTienKhach.Enabled = true;
            TotalPrice = tongTien;
            txtTongCong.Text = tongTien.ToString();
            btnClear.Enabled = true;
        }
        public void ClearFlow()
        {
            flpHangHoa.Controls.Clear();
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
                        btn.BackColor = Color.LightGreen;
                        break;
                    default:
                        btn.BackColor = Color.MediumVioletRed;
                        break;
                }
                flpHangHoa.Controls.Add(btn);
            }
        }
    }
}
#endregion