using Lab02_OOPBasics;
using Lab06_DataControls.BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab06_DataControls.GUI
{
    public partial class frmListViewIcon : Form
    {
        private readonly Color[] _mau =
        {
            Color.Goldenrod, Color.ForestGreen, Color.DodgerBlue,
            Color.DarkOrange, Color.IndianRed
        };
        private readonly string[] _chu = { "S", "G", "K", "T", "Y" };
        public frmListViewIcon()
        {
            InitializeComponent();
        }

        private void frmListViewIcon_Load(object sender, EventArgs e)
        {
            // Gắn ImageList: ảnh lớn cho kiểu icon, ảnh nhỏ cho Details/List
            lvSinhVien.LargeImageList = TaoImageList(48);
            lvSinhVien.SmallImageList = TaoImageList(16);

            lvSinhVien.Columns.Add("Họ và tên", 180);
            lvSinhVien.Columns.Add("Mã SV", 80);
            lvSinhVien.Columns.Add("Khoa", 200);
            lvSinhVien.Columns.Add("Điểm TB", 80, HorizontalAlignment.Right);
            lvSinhVien.Columns.Add("Xếp loại", 100);

            cboKieuXem.Items.AddRange(new object[]
            {
                "Details", "LargeIcon", "SmallIcon", "List", "Tile"
            });
            cboKieuXem.SelectedIndex = 0;

            LoadListView(new SinhVienBUS().GetAll());
        }

        private ImageList TaoImageList(int size)
        {
            ImageList il = new ImageList();
            il.ImageSize = new Size(size, size);
            il.ColorDepth = ColorDepth.Depth32Bit;

            for (int i = 0; i < _mau.Length; i++)
            {
                Bitmap bmp = new Bitmap(size, size);
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.SmoothingMode = SmoothingMode.AntiAlias;
                    g.Clear(Color.Transparent);

                    using (Brush nen = new SolidBrush(_mau[i]))
                        g.FillEllipse(nen, 1, 1, size - 3, size - 3);

                    if (size >= 24)    // ảnh quá nhỏ thì không vẽ chữ
                    {
                        using (Font f = new Font("Segoe UI", size * 0.38f, FontStyle.Bold))
                        using (StringFormat sf = new StringFormat())
                        {
                            sf.Alignment = StringAlignment.Center;
                            sf.LineAlignment = StringAlignment.Center;
                            g.DrawString(_chu[i], f, Brushes.White,
                                new RectangleF(0, 0, size, size), sf);
                        }
                    }
                }
                il.Images.Add(bmp);
            }
            return il;
        }

        private int ChiSoAnh(SinhVien sv)
        {
            switch (sv.XepLoai())
            {
                case "Xuất sắc": return 0;
                case "Giỏi": return 1;
                case "Khá": return 2;
                case "Trung bình": return 3;
                default: return 4;
            }
        }
        private void LoadListView(IEnumerable<SinhVien> data)
        {
            lvSinhVien.BeginUpdate();
            lvSinhVien.Items.Clear();

            foreach (SinhVien sv in data)
            {
                ListViewItem item = new ListViewItem(sv.HoTen);
                item.ImageIndex = ChiSoAnh(sv);          // biểu tượng của dòng
                item.SubItems.Add(sv.MaSV);
                item.SubItems.Add(sv.Khoa);
                item.SubItems.Add(sv.DiemTB.ToString("N2"));
                item.SubItems.Add(sv.XepLoai());
                item.ToolTipText = sv.MaSV + " - " + sv.XepLoai();
                item.Tag = sv;
                lvSinhVien.Items.Add(item);
            }

            lvSinhVien.EndUpdate();
            lblTong.Text = "Số sinh viên: " + lvSinhVien.Items.Count;
        }


        private void cboKieuXem_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboKieuXem.SelectedIndex)
            {
                case 1: lvSinhVien.View = View.LargeIcon; break;
                case 2: lvSinhVien.View = View.SmallIcon; break;
                case 3: lvSinhVien.View = View.List; break;
                case 4: lvSinhVien.View = View.Tile; break;
                default: lvSinhVien.View = View.Details; break;
            }
        }

    }
}
