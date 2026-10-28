using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace Lab07_ADONET_Connection
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnKiemTra_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = DbConnectionFactory.Create())
                {
                    conn.Open();

                    string login;
                    using (SqlCommand cmd = new SqlCommand("SELECT SUSER_SNAME()", conn))
                    {
                        login = (string)cmd.ExecuteScalar();
                    }

                    MessageBox.Show("Kết nối thành công\nDatabase: " + conn.Database
                        + "\nĐăng nhập bằng: " + login);
                    lblKetQua.Text = "Thành công. Tài khoản: " + login;
                }
            }
            catch (ConfigurationErrorsException ex)
            {
                MessageBox.Show("Lỗi cấu hình: " + ex.Message);
                lblKetQua.Text = "Lỗi cấu hình: " + ex.Message;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message);
                lblKetQua.Text = "Thất bại: " + ex.Message;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnTrangThai_Click(object sender, EventArgs e)
        {

            using (frmTrangThai f = new frmTrangThai())
            {
                f.ShowDialog();
            }
        }
    }
}
