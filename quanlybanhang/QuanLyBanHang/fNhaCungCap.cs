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
    public partial class fNhaCungCap : Form
    {
        public fNhaCungCap()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            dgvNhaCC.DataSource = DataAccess.Instance.LoadData("select * from nha_cung_cap");
        }

        private void ChangeHeader()
        {
            dgvNhaCC.Columns[0].HeaderText = "ID";
            dgvNhaCC.Columns[1].HeaderText = "Tên công ty";
            dgvNhaCC.Columns[2].HeaderText = "Địa chỉ";
            dgvNhaCC.Columns[3].HeaderText = "Email";
            dgvNhaCC.Columns[4].HeaderText = "Số điện thoại";
            dgvNhaCC.Columns[5].HeaderText = "Fax";
            dgvNhaCC.Columns[0].Width = 30;
        }
        private void ChangeState(int index)
        {
            DataGridViewRow row = dgvNhaCC.Rows[index];

            String id = Convert.ToString(row.Cells[0].Value);
            String name = Convert.ToString(row.Cells[1].Value);
            String address = Convert.ToString(row.Cells[2].Value);
            String email = Convert.ToString(row.Cells[3].Value);
            String phoneNumber = Convert.ToString(row.Cells[4].Value);
            String fax = Convert.ToString(row.Cells[5].Value);

            txtIDCongTy.Text = id;
            txtName.Text = name;
            txtEmail.Text = email;
            txtFax.Text = fax;
            txtAddress.Text = address;
            mskPhoneNumber.Text = phoneNumber;
        }

        private bool IsNullValue()
        {
            if (txtName.Text.Equals(""))
                return true;
            return false;
        }
        private void Clear()
        {
            txtIDCongTy.Text = "";
            txtName.Text = "";
            txtEmail.Text = "";
            txtFax.Text = "";
            txtAddress.Text = "";
            mskPhoneNumber.Text = "";

            btnAdd.Enabled = true;
            btnUnSelect.Enabled = false;
            btnEdit.Enabled = false;
            dgvNhaCC.ClearSelection();
        }
        private NhaCungCapDTO getInfo()
        {

            String name = txtName.Text;
            int idCongTy = Convert.ToInt32(txtIDCongTy.Text);
            String address = txtAddress.Text;
            String email = txtEmail.Text;
            String phoneNumber = mskPhoneNumber.Text;
            String fax = txtFax.Text;

            NhaCungCapDTO nhaCC = new NhaCungCapDTO(idCongTy,name, address, email, phoneNumber, fax);
            return nhaCC;
        }

        private void FNhaCungCap_Load(object sender, EventArgs e)
        {
            LoadData();
            ChangeHeader();
            ChangeState(0);
            btnAdd.Enabled = false;
        }
        private void DgvNhaCC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index < 0 || index >= dgvNhaCC.Rows.Count)
                return;

            btnAdd.Enabled = false;
            btnUnSelect.Enabled = true;
            btnEdit.Enabled = true;
            ChangeState(index);
        }
        private void BtnUnSelect_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (IsNullValue())
            {
                MessageBox.Show("Không thể thêm nhà cung cấp với tên rỗng!", "Thông Báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
            }
            else
            {
                NhaCungCapDTO nhaCC = getInfo();

                if (NhaCungCapBUS.Instance.Add(nhaCC) > 0)
                {
                    LoadData();
                }
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            NhaCungCapDTO nhaCC = getInfo();
            int id = Convert.ToInt32(txtIDCongTy.Text);
            if (NhaCungCapBUS.Instance.Edit(nhaCC, id) > 0)
            {
                LoadData();
            }
        }
    }
}
