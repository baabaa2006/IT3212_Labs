using Lab02_OOPBasics;
using Lab06_DataControls.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Lab06_DataControls
{
    public partial class frmTreeView : Form
    {
        public frmTreeView()
        {
            InitializeComponent();
        }

        private void frmTreeView_Load(object sender, EventArgs e)
        {
            // Gom sinh viên theo khoa thành Dictionary<khoa, danh sách>
            Dictionary<string, List<SinhVien>> data = DuLieuMau.Tao()
                .GroupBy(sv => sv.Khoa)
                .ToDictionary(g => g.Key, g => g.ToList());

            LoadTree(data);
            XoaChiTiet();
        }

        private void LoadTree(Dictionary<string, List<SinhVien>> data)
        {
            tvKhoa.Nodes.Clear();

            foreach (var group in data)
            {
                TreeNode khoaNode = new TreeNode(
                    group.Key + " (" + group.Value.Count + ")");

                foreach (SinhVien sv in group.Value)
                {
                    TreeNode svNode = new TreeNode(sv.MaSV + " - " + sv.HoTen);
                    svNode.Tag = sv;               // lưu đối tượng vào node
                    khoaNode.Nodes.Add(svNode);
                }

                tvKhoa.Nodes.Add(khoaNode);
            }

            tvKhoa.ExpandAll();
        }

        private void tvKhoa_AfterSelect(object sender, TreeViewEventArgs e)
        {
            SinhVien sv = e.Node.Tag as SinhVien;   // node khoa thì Tag = null

            if (sv == null)
            {
                XoaChiTiet();
                lblThongBao.Text = "Đã chọn khoa: " + e.Node.Text;
                return;
            }

            lblMa.Text = sv.MaSV;
            lblHoTen.Text = sv.HoTen;
            lblNgaySinh.Text = sv.NgaySinh.ToString("dd/MM/yyyy");
            lblDiem.Text = sv.DiemTB.ToString("N2");
            lblXepLoai.Text = sv.XepLoai();
            lblThongBao.Text = "Khoa: " + sv.Khoa;
        }

        private void XoaChiTiet()
        {
            lblMa.Text = "";
            lblHoTen.Text = "";
            lblNgaySinh.Text = "";
            lblDiem.Text = "";
            lblXepLoai.Text = "";
            lblThongBao.Text = "Chọn một sinh viên trên cây";
        }
    }
}