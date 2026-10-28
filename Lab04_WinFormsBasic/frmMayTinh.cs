using System;
using System.Windows.Forms;

namespace Lab06_DataControls
{
    public partial class frmMayTinh : Form
    {
        public frmMayTinh()
        {
            InitializeComponent();
        }

        // Đọc hai số từ TextBox, báo lỗi nếu nhập sai
        private bool DocHaiSo(out double a, out double b)
        {
            a = 0; b = 0;
            if (!double.TryParse(txtSo1.Text, out a))
            {
                MessageBox.Show("Số thứ nhất không hợp lệ.", "Lỗi");
                txtSo1.Focus();
                return false;
            }
            if (!double.TryParse(txtSo2.Text, out b))
            {
                MessageBox.Show("Số thứ hai không hợp lệ.", "Lỗi");
                txtSo2.Focus();
                return false;
            }
            return true;
        }

        private void btnCong_Click(object sender, EventArgs e)
        {
            double a, b;
            if (DocHaiSo(out a, out b)) txtKetQua.Text = (a + b).ToString();
        }

        private void btnTru_Click(object sender, EventArgs e)
        {
            double a, b;
            if (DocHaiSo(out a, out b)) txtKetQua.Text = (a - b).ToString();
        }

        private void btnNhan_Click(object sender, EventArgs e)
        {
            double a, b;
            if (DocHaiSo(out a, out b)) txtKetQua.Text = (a * b).ToString();
        }

        private void btnChia_Click(object sender, EventArgs e)
        {
            double a, b;
            if (!DocHaiSo(out a, out b)) return;
            if (b == 0)
            {
                MessageBox.Show("Không thể chia cho 0.", "Lỗi");
                txtSo2.Focus();
                return;
            }
            txtKetQua.Text = (a / b).ToString();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtSo1.Clear();
            txtSo2.Clear();
            txtKetQua.Clear();
            txtSo1.Focus();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}