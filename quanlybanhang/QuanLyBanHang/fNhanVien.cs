using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyBanHang.BUS;
using QuanLyBanHang.DTO;

namespace QuanLyBanHang
{
    public partial class fNhanVien : Form
    {
        NhanVienBUS nhanvien = new NhanVienBUS();
        public fNhanVien()
        {
            InitializeComponent();
            LoadData();
            ChangeHeader();
            LoadFirstCell();
        }

        private void LoadData()
        {
            dgvEmployee.DataSource = nhanvien.LoadEmployeeList();
        }
        private void Button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void LoadFirstCell()
        {
            ChangeState(0);
            btnAdd.Enabled = false;
        }

        private void ChangeHeader()
        {
            dgvEmployee.Columns[0].HeaderText = "Mã Nhân Viên";
            dgvEmployee.Columns[1].HeaderText = "Tên Nhân Viên";
            dgvEmployee.Columns[2].HeaderText = "Ngày Sinh";
            dgvEmployee.Columns[3].HeaderText = "Ngày Làm Việc";
            dgvEmployee.Columns[4].HeaderText = "Địa Chỉ";
            dgvEmployee.Columns[5].HeaderText = "Điện Thoại";
            dgvEmployee.Columns[6].HeaderText = "Lương";
            dgvEmployee.Columns[7].HeaderText = "Phụ Cấp";
            dgvEmployee.Columns[8].HeaderText = "Giới Tính";
        }

        private void DgvEmployee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index < 0 || index >= dgvEmployee.RowCount)
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
        private void ChangeState(int index)
        {
            DataGridViewRow row = dgvEmployee.Rows[index];

            String id = Convert.ToString(row.Cells[0].Value);
            String name = Convert.ToString(row.Cells[1].Value);
            DateTime birth = Convert.ToDateTime(row.Cells[2].Value);
            DateTime dayOfWork = Convert.ToDateTime(row.Cells[3].Value);
            String address = Convert.ToString(row.Cells[4].Value);
            String phonenumber = Convert.ToString(row.Cells[5].Value);
            long salary = Convert.ToInt64(row.Cells[6].Value);
            int bonus = Convert.ToInt32(row.Cells[7].Value);
            bool isMale = Convert.ToBoolean(row.Cells[8].Value);

            txtID.Text = id;
            txtName.Text = name;
            cbAddress.Text = address;
            radMale.Checked = isMale;
            radFemale.Checked = !isMale;
            dtpBirthday.Value = birth;
            dtpWorkDay.Value = dayOfWork;
            mskSalary.Text = salary.ToString();
            mskPhoneNumber.Text = phonenumber;
            cbOTMoney.Text = bonus.ToString();
        }

        private NhanVien getInfo()
        {
            string address = cbAddress.Text;
            bool isMale = true ? radMale.Checked : false;
            string name = txtName.Text;
            DateTime birthDay = dtpBirthday.Value;
            DateTime dayOfWork = dtpWorkDay.Value;
            string phoneNumber = mskPhoneNumber.Text;
            int bonus = Convert.ToInt32(cbOTMoney.Text);
            double salary = Convert.ToDouble(mskSalary.Text);
            NhanVien nv = new NhanVien(name, isMale, birthDay, dayOfWork, address, phoneNumber, salary, bonus);
            return nv;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (IsNullValue())
            {
                MessageBox.Show("Không thể thêm nhân viên với tên rỗng!","Thông Báo",MessageBoxButtons.RetryCancel,MessageBoxIcon.Warning);
            }
            else
            {
                NhanVien nv = getInfo();
                if (nhanvien.AddEmployee(nv) > 0)
                {
                    LoadData();
                }
            }
            
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtID.Text);
            if (nhanvien.DelEmployee(id) > 0)
            {
                LoadData();
                Clear();
            }
        }
        private void Clear()
        {
            txtID.Text = "";
            cbAddress.Text = null;
            radFemale.Checked = false;
            radMale.Checked = false;
            txtName.Text = "";
            dtpBirthday.Value = System.DateTime.Now;
            dtpWorkDay.Value = DateTime.Now;
            mskPhoneNumber.Text = "";
            mskSalary.Text = "";
            cbOTMoney.Text = null;
            btnDelete.Enabled = false;
            btnAdd.Enabled = true;
            btnUnSelect.Enabled = false;
            btnEdit.Enabled = false;
            dgvEmployee.ClearSelection();
        }

        private void BtnUnSelect_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            NhanVien nv = getInfo();
            int id = Convert.ToInt32(txtID.Text);
            if (nhanvien.EditEmployee(nv, id) > 0)
            {
                LoadData();
            }
        }

        private bool IsNullValue()
        {
            if (txtName.Text.Equals(""))
                return true;
            return false;
        }
    }
}
