using Lab06_DataControls.GUI;
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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        // Hàm dùng chung: mở Form con, nếu đã mở rồi thì chỉ kích hoạt lại
        private void OpenChildForm(Form child)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == child.GetType())
                {
                    f.Activate();
                    child.Dispose();
                    return;
                }
            }
            child.MdiParent = this;
            child.FormClosed += (s, e) => tsslTrangThai.Text = "Sẵn sàng";
            child.Show();
            tsslTrangThai.Text = "Đang mở: " + child.Text;
        }

        private void mnuSinhVien_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmSinhVien());
        }

        private void mnuGioiThieu_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmGioiThieu());
        }

        private void mnuThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            tmrDongHo_Tick(null, EventArgs.Empty);
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.WindowsShutDown) return;
            DialogResult kq = MessageBox.Show(
       "Bạn có chắc muốn thoát chương trình?",
       "Xác nhận",
       MessageBoxButtons.YesNo,
       MessageBoxIcon.Question);

            if (kq == DialogResult.No)
            {
                e.Cancel = true;   // hủy việc đóng Form
            }
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void tmrDongHo_Tick(object sender, EventArgs e)
        {
            tsslDongHo.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private void mnuKhoa_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmKhoa());
        }

        private void mnuDanhSach_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmDanhSach());
        }

        private void mnuListView_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmListView());
        }

        private void mnuListViewIcon_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmListViewIcon());
        }
    }
}
