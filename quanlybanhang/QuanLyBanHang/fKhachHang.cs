using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyBanHang.BUS;
using QuanLyBanHang.DTO;

namespace QuanLyBanHang
{
    public partial class fKhachHang : Form
    {
        KhachHangBUS khachHang;
        
        public fKhachHang()
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
            DataGridViewRow row = dgvCustomer.Rows[index];

            String id = Convert.ToString(row.Cells[0].Value);
            String name = Convert.ToString(row.Cells[1].Value);
            String nameOfOrders = Convert.ToString(row.Cells[2].Value);
            String address = Convert.ToString(row.Cells[3].Value);
            String email = Convert.ToString(row.Cells[4].Value);
            String phonenumber = Convert.ToString(row.Cells[5].Value);
            String fax = Convert.ToString(row.Cells[6].Value);
            bool isMale = Convert.ToBoolean(row.Cells[7].Value);

            txtID.Text = id;
            txtName.Text = name;
            cbNameOfOrders.Text = nameOfOrders;
            cbAddress.Text = address;
            txtEmail.Text = email;
            radMale.Checked = isMale;
            radFemale.Checked = !isMale;
            mskPhoneNumber.Text = phonenumber;
            txtFax.Text = fax;
        }

        private void ChangeHeader()
        {
            dgvCustomer.Columns[0].HeaderText = "Mã Khách Hàng";
            dgvCustomer.Columns[1].HeaderText = "Tên Khách Hàng";
            dgvCustomer.Columns[2].HeaderText = "Tên Giao Dịch";
            dgvCustomer.Columns[4].HeaderText = "Email";
            dgvCustomer.Columns[3].HeaderText = "Địa Chỉ";
            dgvCustomer.Columns[5].HeaderText = "Điện Thoại";
            dgvCustomer.Columns[6].HeaderText = "Fax";
            dgvCustomer.Columns[7].HeaderText = "Giới Tính";
        }

        private void Clear()
        {
            txtID.Text = "";
            txtEmail.Text = "";
            cbAddress.Text = null;
            cbNameOfOrders.Text = null;
            radFemale.Checked = false;
            radMale.Checked = false;
            txtName.Text = "";
            mskPhoneNumber.Text = "";
            txtFax.Text = "";
            btnDelete.Enabled = false;
            btnAdd.Enabled = true;
            btnUnSelect.Enabled = false;
            btnEdit.Enabled = false;
            dgvCustomer.ClearSelection();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            Clear();
        }
        private void LoadData()
        {
            khachHang = new KhachHangBUS();
            dgvCustomer.DataSource = khachHang.LoadCustomerList();
        }

        private void DgvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            ChangeState(index);
            btnDelete.Enabled = true;
            btnAdd.Enabled = false;
            btnUnSelect.Enabled = true;
            btnEdit.Enabled = true;
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            KhachHang kh = getInfo();
            khachHang = new KhachHangBUS();
            int id = Convert.ToInt32(txtID.Text);

            if (khachHang.EditCustomer(kh, id) > 0)
            {
                LoadData();
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            khachHang = new KhachHangBUS();

            if (khachHang.AddCustomer(getInfo()) > 0)
            {
                LoadData();
            }
        }

        private KhachHang getInfo()
        {
            string name = txtName.Text;
            string nameOfOrders = cbNameOfOrders.Text;
            bool isMale = true ? radMale.Checked : false;
            string address = cbAddress.Text;
            string email = txtEmail.Text;
            string phoneNumber = mskPhoneNumber.Text;
            string fax = txtFax.Text;

            KhachHang kh = new KhachHang(name,nameOfOrders,email,address,phoneNumber,fax,isMale);
            return kh;
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            khachHang = new KhachHangBUS();
            int id = Convert.ToInt32(txtID.Text);

            if (khachHang.DelCustomer(id) > 0)
            {
                LoadData();
            }
        }

        private void CbNameOfOrders_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
