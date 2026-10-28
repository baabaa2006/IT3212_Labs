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
    public partial class frmChonKhoa : Form
    {
        public string KhoaDuocChon { get; private set; }

        public frmChonKhoa(List<string> dsKhoa, string khoaHienTai)
        {
            InitializeComponent();
            lstKhoa.DataSource = dsKhoa;

            int viTri = dsKhoa.IndexOf(khoaHienTai);
            if (viTri >= 0) lstKhoa.SelectedIndex = viTri;
        }

        private void frmChonKhoa_Load(object sender, EventArgs e)
        {
           
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void lstKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnChon_Click(sender, e);
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            if (lstKhoa.SelectedItem == null)
            {
                MessageBox.Show("Hãy chọn một khoa");
                return;
            }

            KhoaDuocChon = lstKhoa.SelectedItem.ToString();
            this.DialogResult = DialogResult.OK;
        }
    }
}
