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
    public partial class fProfile : Form
    {
        public fProfile()
        {
            InitializeComponent();
        }


        private void Label7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ChkMale_CheckStateChanged(object sender, EventArgs e)
        {
            chkFemale.Enabled = false;
            if (chkMale.Checked == false)
                chkFemale.Enabled = true;
        }

        private void ChkFemale_CheckStateChanged(object sender, EventArgs e)
        {
            chkMale.Enabled = false;
            if (chkFemale.Checked == false)
                chkMale.Enabled = true;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {

        }

        private void BtnSave_Click(object sender, EventArgs e)
        {

        }
    }
}
