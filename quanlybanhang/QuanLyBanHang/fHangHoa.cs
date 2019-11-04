using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using QuanLyBanHang.BUS;
using QuanLyBanHang.DTO;

namespace QuanLyBanHang
{
    public partial class fHangHoa : Form
    {
        static HangHoaBUS hangHoaBUS = new HangHoaBUS();
        public fHangHoa()
        {
            InitializeComponent();
            LoadData();
            ChangeHeader();
            LoadFirstCell();
        }

        private void LoadFirstCell()
        {
            ChangeState(0);
            btnAdd.Enabled = false;
        }
        private void ChangeState(int index)
        {
            DataGridViewRow row = dgvHangHoa.Rows[index];

            String idMatHang = Convert.ToString(row.Cells[0].Value);
            String name = Convert.ToString(row.Cells[1].Value);
            String idCongTy = Convert.ToString(row.Cells[2].Value);
            String idLoaiHang = Convert.ToString(row.Cells[3].Value);
            int soLuong = Convert.ToInt32(row.Cells[4].Value);
            String donViTinh = Convert.ToString(row.Cells[5].Value);
            String gia = Convert.ToString(row.Cells[6].Value);
            String imagePath = Convert.ToString(row.Cells[7].Value);
            String ghiChu = Convert.ToString(row.Cells[8].Value);

            txtIDMatHang.Text = idMatHang;
            txtIDLoaiHang.Text = idLoaiHang;
            txtIDCongTy.Text = idCongTy;
            nudSoLuong.Value = soLuong;
            cbDonViTinh.Text = donViTinh;
            txtGiaBan.Text = gia;
            txtImagePath.Text = imagePath;
            txtName.Text = name;
            pcbImage.Image = new Bitmap(imagePath);
            rtbGhiChu.Text = ghiChu;
            
        }
        private void LoadData()
        {
            HangHoaBUS hangHoa  = new HangHoaBUS();
            dgvHangHoa.DataSource = hangHoa.LoadData();
        }

        private void ChangeHeader()
        {
            dgvHangHoa.Columns[0].HeaderText = "Mã Mặt Hàng";
            dgvHangHoa.Columns[1].HeaderText = "Tên Mặt Hàng";
            dgvHangHoa.Columns[2].HeaderText = "Mã Công Ty";
            dgvHangHoa.Columns[4].HeaderText = "Mã Loại Hàng";
            dgvHangHoa.Columns[3].HeaderText = "Số Lượng";
            dgvHangHoa.Columns[5].HeaderText = "Đơn Vị Tính";
            dgvHangHoa.Columns[6].HeaderText = "Giá";
            dgvHangHoa.Columns[7].HeaderText = "Đường Dẫn Ảnh";
            dgvHangHoa.Columns[8].HeaderText = "Ghi Chú";
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FolderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {
            
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pcbImage.Image = new Bitmap(ofd.FileName);
                string imgpath = ofd.FileName;
                txtImagePath.Text = imgpath;
            }
        }

        private void DgvHangHoa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index < 0 || index >= dgvHangHoa.RowCount)
            {
                return;
            }
            else
            {
                ChangeState(index);
                btnDelete.Enabled = true;
                btnAdd.Enabled = false;
                btnUnSelect.Enabled = true;
                btnEdit.Enabled = true;
            }
        }

        private void Clear()
        {
            txtIDMatHang.Text = "";
            txtIDLoaiHang.Text = "";
            txtIDCongTy.Text = "";
            nudSoLuong.Value = 0;
            cbDonViTinh.Text = "";
            txtGiaBan.Text = "";
            txtImagePath.Text = "";
            txtName.Text = "";
            pcbImage.Image = null;
            rtbGhiChu.Text = "";
            btnDelete.Enabled = false;
            btnAdd.Enabled = true;
            btnUnSelect.Enabled = false;
            btnEdit.Enabled = false;
            dgvHangHoa.ClearSelection();
        }
        private void BtnUnSelect_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private bool IsNullValue()
        {
            if (txtName.Text.Equals(""))
                return true;
            return false;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (IsNullValue())
            {
                MessageBox.Show("Không thể thêm hàng hóa với tên rỗng!", "Thông Báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
            }
            else
            {
                HangHoaDTO hangHoa = getInfo();

                if (hangHoaBUS.AddCategory(hangHoa) > 0)
                {
                    LoadData();
                }
            }
        }
        private HangHoaDTO getInfo()
        {
            String name = txtName.Text;
            int idCongTy = Convert.ToInt32(txtIDCongTy.Text);
            int idLoaiHang = Convert.ToInt32(txtIDLoaiHang.Text);
            int soLuong = Convert.ToInt32(nudSoLuong.Text);
            String donViTinh = cbDonViTinh.Text;
            double gia = Convert.ToDouble(txtGiaBan.Text);
            String imagePath = txtImagePath.Text;
            String ghiChu = rtbGhiChu.Text;

            HangHoaDTO hangHoa = new HangHoaDTO(name, idCongTy, idLoaiHang, soLuong, donViTinh, gia, imagePath, ghiChu);
            return hangHoa;
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtIDMatHang.Text);
            if (hangHoaBUS.DelCategory(id) > 0)
            {
                LoadData();
                Clear();
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            HangHoaDTO hangHoa = getInfo();
            int id = Convert.ToInt32(txtIDMatHang.Text);
            if (hangHoaBUS.EditCategory(hangHoa, id) > 0)
            {
                LoadData();
            }
        }
    }
}
