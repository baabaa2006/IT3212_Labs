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
    public partial class frmDangNhap : Form
    {

        private const int SoLanToiDa = 3;
        private const int ThoiGianKhoa = 30;   

        private int _soLanSai = 0;
        private int _giayConLai = 0;

        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void txtTaiKhoan_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            // Kiểm tra tài khoản (tạm dùng admin / 123)
            if (txtTaiKhoan.Text == "admin" && txtMatKhau.Text == "123")
            {
                MessageBox.Show("Đăng nhập thành công");
                this.DialogResult = DialogResult.OK;
                this.Close();
                return;
            }

            _soLanSai++;

            if (_soLanSai >= SoLanToiDa)
            {
                KhoaDangNhap();
            }
            else
            {
                lblThongBao.Text = "Sai tài khoản hoặc mật khẩu. Còn "
                    + (SoLanToiDa - _soLanSai) + " lần thử.";
                txtMatKhau.Clear();
                txtMatKhau.Focus();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tmrKhoa_Tick(object sender, EventArgs e)
        {
            _giayConLai--;

            if (_giayConLai > 0)
            {
                btnDangNhap.Text = "Khóa (" + _giayConLai + "s)";
            }
            else
            {
                tmrKhoa.Stop();
                btnDangNhap.Enabled = true;
                btnDangNhap.Text = "Đăng nhập";
                _soLanSai = 0;
                lblThongBao.Text = "Bạn có thể thử lại.";
            }
        }

        private void KhoaDangNhap()
        {
            btnDangNhap.Enabled = false;
            _giayConLai = ThoiGianKhoa;
            btnDangNhap.Text = "Khóa (" + _giayConLai + "s)";
            lblThongBao.Text = "Sai quá " + SoLanToiDa + " lần. Vui lòng chờ.";
            tmrKhoa.Start();
        }
    }
}
