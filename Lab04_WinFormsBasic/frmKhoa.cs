using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab04_WinFormsBasic
{
    public partial class frmKhoa : Form
    {
        public frmKhoa()
        {
            InitializeComponent();
        }

        private void lstKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmKhoa_Load(object sender, EventArgs e)
        {
            lstKhoa.Items.Add("Công nghệ thông tin");
            lstKhoa.Items.Add("Công nghệ kỹ thuật ô tô");
            lstKhoa.Items.Add("Kinh tế");
        }
    }
}
