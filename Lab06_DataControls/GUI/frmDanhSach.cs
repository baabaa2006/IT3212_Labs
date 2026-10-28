using Lab02_OOPBasics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lab06_DataControls.BUS;

namespace Lab06_DataControls.GUI
{
    public partial class frmDanhSach : Form
    {
        private readonly SinhVienBUS _bus = new SinhVienBUS();
        private BindingList<SinhVien> _ds = new BindingList<SinhVien>();

        public frmDanhSach()
        {
            InitializeComponent();
        }

        private void frmDanhSach_Load(object sender, EventArgs e)
        {
            CauHinhCot();

            cboKhoa.Items.AddRange(_bus.GetDanhSachKhoa().ToArray());
            cboKhoa.SelectedIndex = 0;

            dgvSinhVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            NapLai();
        }

        private void NapLai(string maChon = null)
        {
            _ds = new BindingList<SinhVien>(_bus.GetAll());
            dgvSinhVien.DataSource = _ds;

            if (maChon == null) return;
            foreach (DataGridViewRow row in dgvSinhVien.Rows)
            {
                SinhVien sv = row.DataBoundItem as SinhVien;
                if (sv != null && sv.MaSV == maChon)
                {
                    dgvSinhVien.CurrentCell = row.Cells[0];
                    break;
                }
            }
        }

        private void CauHinhCot()
        {
            dgvSinhVien.AutoGenerateColumns = false;   // tự kiểm soát cột
            dgvSinhVien.Columns.Clear();

            ThemCot("MaSV", "Mã SV", 80);
            ThemCot("HoTen", "Họ và tên", 160);
            ThemCot("NgaySinh", "Ngày sinh", 100, "dd/MM/yyyy");
            ThemCot("Khoa", "Khoa", 180);
            ThemCot("DiemTB", "Điểm TB", 80, "N2");
        }

        private void ThemCot(string tenThuocTinh, string tieuDe, int doRong,
                             string dinhDang = null)
        {
            DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
            col.DataPropertyName = tenThuocTinh;   
            col.HeaderText = tieuDe;              
            col.Name = "col" + tenThuocTinh;
            col.Width = doRong;
            if (dinhDang != null)
                col.DefaultCellStyle.Format = dinhDang;
            dgvSinhVien.Columns.Add(col);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            SinhVien sv;
            if (!DocTuForm(out sv)) return;

            try
            {
                _bus.Add(sv);
                NapLai(sv.MaSV);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            SinhVien hienTai = LayDangChon();
            if (hienTai == null)
            {
                MessageBox.Show("Hãy chọn sinh viên cần sửa");
                return;
            }

            SinhVien moi;
            if (!DocTuForm(out moi)) return;

            try
            {
                _bus.Update(hienTai.MaSV, moi);
                NapLai(moi.MaSV);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            SinhVien sv = LayDangChon();
            if (sv == null)
            {
                MessageBox.Show("Hãy chọn sinh viên cần xóa");
                return;
            }

            if (MessageBox.Show("Xóa sinh viên " + sv.HoTen + "?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                _bus.Delete(sv.MaSV);
                NapLai();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtDiemTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar)) return;
            if (char.IsDigit(e.KeyChar)) return;
            if (e.KeyChar == '.' && !txtDiemTB.Text.Contains(".")) return;
            e.Handled = true;
        }

        // Lấy sinh viên đang chọn trên lưới (null nếu không có)
        private SinhVien LayDangChon()
        {
            return dgvSinhVien.CurrentRow == null
                ? null
                : dgvSinhVien.CurrentRow.DataBoundItem as SinhVien;
        }

        // Đọc dữ liệu từ các ô nhập và kiểm tra hợp lệ
        private bool DocTuForm(out SinhVien sv)
        {
            sv = null;

            double diem;
            if (!double.TryParse(txtDiemTB.Text, NumberStyles.Any,
                    CultureInfo.InvariantCulture, out diem))
            {
                MessageBox.Show("Điểm phải là một số");
                txtDiemTB.Focus();
                return false;
            }

            try
            {
                sv = new SinhVien(txtMaSV.Text.Trim(), txtHoTen.Text,
                                  dtpNgaySinh.Value, diem, cboKhoa.Text);
                return true;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        private void dgvSinhVien_SelectionChanged(object sender, EventArgs e)
        {
            SinhVien sv = LayDangChon();
            if (sv == null) return;

            txtMaSV.Text = sv.MaSV;
            txtHoTen.Text = sv.HoTen;
            dtpNgaySinh.Value = sv.NgaySinh;
            cboKhoa.SelectedItem = sv.Khoa;
            txtDiemTB.Text = sv.DiemTB.ToString(CultureInfo.InvariantCulture);
        }

    }
}
