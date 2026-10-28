using Lab02_OOPBasics;
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
    public partial class frmChiTietSinhVien : Form
    {
        private readonly SinhVien _sinhVien;
        public frmChiTietSinhVien(SinhVien _sinhVien)
        {
            InitializeComponent();
            this._sinhVien = _sinhVien;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmChiTietSinhVien_Load(object sender, EventArgs e)
        {
            lblMa.Text = _sinhVien.MaSV;
            lblHoTen.Text = _sinhVien.HoTen;
            lblDiem.Text = _sinhVien.DiemTB.ToString("N2");
            lblXepLoai.Text = _sinhVien.XepLoai();
        }
    }
}
