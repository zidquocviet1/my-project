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

namespace QuanLyBanHang
{
    public partial class fHangHoa : Form
    {
        public fHangHoa()
        {
            InitializeComponent();
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
    }
}
