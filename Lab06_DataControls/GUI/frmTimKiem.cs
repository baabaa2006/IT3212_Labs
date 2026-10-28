using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab06_DataControls
{
    public partial class frmTimKiem : Form
    {
        public string TuKhoa { get; private set; }
        public frmTimKiem(string tuKhoaBanDau)
        {
            InitializeComponent();
            txtTuKhoa.Text = tuKhoaBanDau;
            TuKhoa = tuKhoaBanDau;
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTuKhoa.Text))
            {
                MessageBox.Show("Nhập từ khóa cần tìm");
                txtTuKhoa.Focus();
                return;
            }

            TuKhoa = txtTuKhoa.Text.Trim();
            this.DialogResult = DialogResult.OK;

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
