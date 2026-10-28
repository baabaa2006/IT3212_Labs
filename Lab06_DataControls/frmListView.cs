using Lab02_OOPBasics;
using Lab06_DataControls.BUS;
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
    public partial class frmListView : Form
    {
        private List<SinhVien> _data;

        public frmListView()
        {
            InitializeComponent();
        }

        private void frmListView_Load(object sender, EventArgs e)
        {
            SinhVienBUS bus = new SinhVienBUS();
            _data = bus.GetAll();

            CauHinhCot();

            cboLoc.Items.Add("Tất cả");
            cboLoc.Items.AddRange(new object[]
            {
                bus.GetDanhSachKhoa().ToArray()
            });
            cboLoc.SelectedIndex = 0;

            LoadListView(_data);
        }

        // Tạo các cột một lần duy nhất
        private void CauHinhCot()
        {
            lvSinhVien.View = View.Details;
            lvSinhVien.Columns.Clear();
            lvSinhVien.Columns.Add("Mã SV", 80);
            lvSinhVien.Columns.Add("Họ và tên", 180);
            lvSinhVien.Columns.Add("Khoa", 200);
            lvSinhVien.Columns.Add("Điểm TB", 80, HorizontalAlignment.Right);
        }

        // Nạp dữ liệu: xóa Items cũ rồi thêm lại
        private void LoadListView(IEnumerable<SinhVien> data)
        {
            lvSinhVien.BeginUpdate();
            lvSinhVien.Items.Clear();

            foreach (SinhVien sv in data)
            {
                ListViewItem item = new ListViewItem(sv.MaSV);
                item.SubItems.Add(sv.HoTen);
                item.SubItems.Add(sv.Khoa);
                item.SubItems.Add(sv.DiemTB.ToString("N2"));
                item.Tag = sv;                    // giữ đối tượng gốc
                lvSinhVien.Items.Add(item);
            }

            lvSinhVien.EndUpdate();
            lblTong.Text = "Số sinh viên: " + lvSinhVien.Items.Count;
            lblChiTiet.Text = "Chọn một dòng để xem chi tiết";
        }

        private void cboLoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_data == null) return;

            string khoa = cboLoc.Text;
            IEnumerable<SinhVien> kq = (khoa == "Tất cả")
                ? _data
                : _data.Where(x => x.Khoa == khoa);

            LoadListView(kq);
        }

        private void lvSinhVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvSinhVien.SelectedItems.Count == 0) return;

            SinhVien sv = lvSinhVien.SelectedItems[0].Tag as SinhVien;
            if (sv == null) return;

            lblChiTiet.Text = sv.HoTen + " | Sinh: "
                + sv.NgaySinh.ToString("dd/MM/yyyy")
                + " | Xếp loại: " + sv.XepLoai();
        }
    }
}
