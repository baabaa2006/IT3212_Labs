using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Lab07_ADONET_Connection
{
    public partial class frmTrangThai : Form
    {
        public frmTrangThai()
        {
            InitializeComponent();
        }

        private void frmTrangThai_Load(object sender, EventArgs e)
        {
            KiemTra();
        }

        private void btnKiemTra_Click(object sender, EventArgs e)
        {
            KiemTra();
        }

        private void XoaThongTin()
        {
            lblDataSource.Text = "";
            lblDatabase.Text = "";
            lblServerVersion.Text = "";
            lblState.Text = "";
            lblStateSauDong.Text = "";
            lblThoiGian.Text = "";
            lblThoiDiem.Text = "";
            lblLoi.Text = "";
        }

        private void KiemTra()
        {
            XoaThongTin();
            Cursor = Cursors.WaitCursor;

            SqlConnection conn = null;
            Stopwatch sw = new Stopwatch();

            try
            {
                conn = DbConnectionFactory.Create();

                using (conn)
                {
                    sw.Start();
                    conn.Open();                 
                    sw.Stop();

                    lblDataSource.Text = conn.DataSource;
                    lblDatabase.Text = conn.Database;
                    lblServerVersion.Text = conn.ServerVersion;
                    lblState.Text = conn.State.ToString();
                    lblState.ForeColor = Color.Green;
                    lblThoiGian.Text = sw.Elapsed.TotalMilliseconds.ToString("N1") + " ms";
                }

                lblStateSauDong.Text = conn.State.ToString();
            }
            catch (ConfigurationErrorsException ex)
            {
                HienLoi("Lỗi cấu hình: " + ex.Message, sw);
            }
            catch (SqlException ex)
            {
                HienLoi("Không kết nối được: " + ex.Message, sw);
            }
            finally
            {
                lblThoiDiem.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                Cursor = Cursors.Default;
            }
        }

        private void HienLoi(string thongBao, Stopwatch sw)
        {
            sw.Stop();
            lblState.Text = "Không mở được";
            lblState.ForeColor = Color.Red;
            lblThoiGian.Text = sw.Elapsed.TotalMilliseconds.ToString("N1") + " ms (thất bại)";
            lblLoi.Text = thongBao;
        }

    }
}