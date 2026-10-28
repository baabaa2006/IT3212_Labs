using Lab02_OOPBasics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Lab06_DataControls
{
    public partial class frmSinhVien : Form
    {
        private string _tuKhoaTim = "";
        public frmSinhVien()
        {
            InitializeComponent();
        }

        // Nạp danh sách khoa và đặt trạng thái mặc định khi Form mở
        private readonly string[] dsKhoa =
        {
            "Công nghệ thông tin",
            "Công nghệ kỹ thuật ô tô",
            "Kinh tế"
        };

        private void frmSinhVien_Load(object sender, EventArgs e)
        {
            cboKhoa.Items.AddRange(dsKhoa);
            cboKhoa.DropDownStyle = ComboBoxStyle.DropDownList;
            if (cboKhoa.Items.Count > 0) cboKhoa.SelectedIndex = 0;
            radNam.Checked = true;
            lblTuoi.Text = "Tuổi: " + TinhTuoi(dtpNgaySinh.Value);
            Input_TextChanged(null, EventArgs.Empty);
        }

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            string gioiTinh = radNam.Checked ? "Nam" : "Nữ";
            string thongTin = string.Format(
                "Mã: {0}\nHọ tên: {1}\nNgày sinh: {2:dd/MM/yyyy}\nKhoa: {3}\nGiới tính: {4}",
                txtMaSV.Text, txtHoTen.Text, dtpNgaySinh.Value,
                cboKhoa.Text, gioiTinh);
            MessageBox.Show(thongTin, "Thông tin sinh viên");
        }

        private int TinhTuoi(DateTime ngaySinh)
        {
            int tuoi = DateTime.Today.Year - ngaySinh.Year;
            if (ngaySinh.Date > DateTime.Today.AddYears(-tuoi)) tuoi--;
            return tuoi;
        }
        private void dtpNgaySinh_ValueChanged(object sender, EventArgs e)
        {
            lblTuoi.Text = "Tuổi: " + TinhTuoi(dtpNgaySinh.Value);
        }

        private void btnSoThich_Click(object sender, EventArgs e)
        {
            List<string> ds = new List<string>();
            if (chkDocSach.Checked) ds.Add("Đọc sách");
            if (chkTheThao.Checked) ds.Add("Thể thao");
            if (chkLapTrinh.Checked) ds.Add("Lập trình");
            lblSoThich.Text = ds.Count == 0 ? "Chưa chọn" : string.Join(", ", ds);
        }

        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.InitialDirectory = Path.Combine(Application.StartupPath, "Image");
                dlg.Filter = "Image files|*.jpg;*.jpeg;*.png;*.bmp";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    if (!File.Exists(dlg.FileName))
                    {
                        MessageBox.Show("Không tìm thấy tệp ảnh.", "Lỗi");
                        return;
                    }
                    picAnh.SizeMode = PictureBoxSizeMode.Zoom;
                    picAnh.ImageLocation = dlg.FileName;
                    txtDuongDanAnh.Text = dlg.FileName;
                }
            }
        }

        private void btnChiTiet_Click(object sender, EventArgs e)
        {

            double diem;
            if (!double.TryParse(txtDiemTB.Text, System.Globalization.NumberStyles.Any,
        System.Globalization.CultureInfo.InvariantCulture, out diem))
            {
                MessageBox.Show("Điểm không hợp lệ");
                return;
            }

            try
            {
                SinhVien sv = new SinhVien
                {
                    MaSV = txtMaSV.Text,
                    HoTen = txtHoTen.Text,
                    DiemTB = diem,
                    NgaySinh = dtpNgaySinh.Value
                };

                frmChiTietSinhVien frm = new frmChiTietSinhVien(sv);
                frm.ShowDialog();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private bool ValidateInput()
        {
            errorProvider1.Clear();
            bool valid = true;

            if (string.IsNullOrWhiteSpace(txtMaSV.Text))
            {
                errorProvider1.SetError(txtMaSV, "Nhập mã sinh viên");
                valid = false;
            }

            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                errorProvider1.SetError(txtHoTen, "Nhập họ tên");
                valid = false;
            }
            double diem;
            if (!double.TryParse(txtDiemTB.Text, System.Globalization.NumberStyles.Any,
                    System.Globalization.CultureInfo.InvariantCulture, out diem)
                || diem < 0 || diem > 10)
            {
                errorProvider1.SetError(txtDiemTB, "Điểm phải từ 0 đến 10");
                valid = false;
            }
            return valid;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            MessageBox.Show("Lưu thành công");
        }

        private void txtDiemTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar)) return;
            if (char.IsDigit(e.KeyChar)) return;
            if (e.KeyChar == '.' && !txtDiemTB.Text.Contains(".")) return;
            e.Handled = true;
        }

        private void Input_TextChanged(object sender, EventArgs e)
        {
            double diem;
            bool hopLe = double.TryParse(txtDiemTB.Text,
                    System.Globalization.NumberStyles.Any,
                    System.Globalization.CultureInfo.InvariantCulture, out diem)
                && diem >= 0 && diem <= 10;

            lblXemTruoc.Text = txtMaSV.Text + " - " + txtHoTen.Text;
            lblTrangThai.Text = hopLe ? "Dữ liệu điểm hợp lệ" : "Kiểm tra điểm";
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            using (frmTimKiem frm = new frmTimKiem(_tuKhoaTim))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    _tuKhoaTim = frm.TuKhoa;
                    lblKetQuaTim.Text = "Từ khóa: " + _tuKhoaTim;

                    // Ví dụ dùng kết quả: chọn khoa có chứa từ khóa
                    for (int i = 0; i < cboKhoa.Items.Count; i++)
                    {
                        if (cboKhoa.Items[i].ToString()
                            .IndexOf(_tuKhoaTim, StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            cboKhoa.SelectedIndex = i;
                            return;
                        }
                    }
                    lblKetQuaTim.Text += " (không tìm thấy khoa)";
                }
            }
        }

        private void btnChonKhoa_Click(object sender, EventArgs e)
        {
            List<string> ds = new List<string>(dsKhoa);   // dsKhoa là mảng có sẵn trong frmSinhVien

            using (frmChonKhoa frm = new frmChonKhoa(ds, cboKhoa.Text))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    cboKhoa.SelectedItem = frm.KhoaDuocChon;
                }
            }
        }
    }
}