using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;  

namespace Lab07_ADONET_Connection
{
    public partial class frmLab8 : Form
    {
        public frmLab8()
        {
            InitializeComponent();
        }

        private void frmLab8_Load(object sender, EventArgs e)
        {
            LoadKhoa();
        }

        private void LoadKhoa()
        {
            using (SqlConnection conn = DbConnectionFactory.Create())
            using (SqlDataAdapter da = new SqlDataAdapter("SELECT MaKhoa, TenKhoa FROM Khoa", conn))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                cboKhoa.DataSource = dt;
                cboKhoa.DisplayMember = "TenKhoa";
                cboKhoa.ValueMember = "MaKhoa";
            }
        }

        private int CountStudents()
        {
            using (SqlConnection conn = DbConnectionFactory.Create())
            using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM SinhVien", conn))
            {
                conn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        private void btnDem_Click(object sender, EventArgs e)
        {
            lblSoLuong.Text = "Số sinh viên: " + CountStudents();
        }

        private void btnDoc_Click(object sender, EventArgs e)
        {
            LoadDanhSach();
        }

        private void LoadDanhSach()
        {
            using (SqlConnection conn = DbConnectionFactory.Create())
            using (SqlCommand cmd = new SqlCommand(
                "SELECT MaSV, HoTen, DiemTB FROM SinhVien ORDER BY HoTen", conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    lstSinhVien.Items.Clear();
                    while (reader.Read())
                        lstSinhVien.Items.Add(string.Format("{0} - {1} - {2:N2}",
                            reader["MaSV"], reader["HoTen"], reader["DiemTB"]));
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra đầu vào
            if (string.IsNullOrWhiteSpace(txtMaSV.Text) || string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã SV và Họ tên.");
                return;
            }
            decimal diem;
            if (!decimal.TryParse(txtDiemTB.Text, out diem) || diem < 0 || diem > 10)
            {
                MessageBox.Show("Điểm TB phải là số từ 0 đến 10.");
                return;
            }
            if (cboKhoa.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn khoa.");
                return;
            }

            string sql = @"INSERT INTO SinhVien
        (MaSV, HoTen, NgaySinh, GioiTinh, MaKhoa, DiemTB, Email)
        VALUES (@MaSV, @HoTen, @NgaySinh, @GioiTinh, @MaKhoa, @DiemTB, @Email)";

            try
            {
                using (SqlConnection conn = DbConnectionFactory.Create())
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("@MaSV", SqlDbType.VarChar, 15).Value = txtMaSV.Text.Trim();
                    cmd.Parameters.Add("@HoTen", SqlDbType.NVarChar, 100).Value = txtHoTen.Text.Trim();
                    cmd.Parameters.Add("@NgaySinh", SqlDbType.Date).Value = dtpNgaySinh.Value.Date;
                    cmd.Parameters.Add("@GioiTinh", SqlDbType.Bit).Value = radNam.Checked;
                    cmd.Parameters.Add("@MaKhoa", SqlDbType.VarChar, 10).Value = cboKhoa.SelectedValue.ToString();
                    SqlParameter pDiem = cmd.Parameters.Add("@DiemTB", SqlDbType.Decimal);
                    pDiem.Precision = 4; pDiem.Scale = 2;
                    pDiem.Value = diem;
                    cmd.Parameters.Add("@Email", SqlDbType.VarChar, 100).Value =
                        string.IsNullOrWhiteSpace(txtEmail.Text) ? (object)DBNull.Value : txtEmail.Text.Trim();

                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    MessageBox.Show("Đã thêm " + rows + " bản ghi.");
                }
                LoadDanhSach();   // cập nhật lại ListBox (nếu bạn đã tạo hàm này ở Bài 2)
            }
            catch (SqlException ex) when (ex.Number == 2627)
            {
                MessageBox.Show("Mã sinh viên đã tồn tại.");
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi CSDL: " + ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql = "UPDATE SinhVien SET DiemTB=@DiemTB WHERE MaSV=@MaSV";
            using (SqlConnection conn = DbConnectionFactory.Create())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                SqlParameter pDiem = cmd.Parameters.Add("@DiemTB", SqlDbType.Decimal);
                pDiem.Precision = 4; pDiem.Scale = 2;
                pDiem.Value = decimal.Parse(txtDiemTB.Text);
                cmd.Parameters.Add("@MaSV", SqlDbType.VarChar, 15).Value = txtMaSV.Text.Trim();
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                MessageBox.Show(rows == 1 ? "Cập nhật thành công" : "Không tìm thấy mã");
            }
        }

        private void btnTheoKhoa_Click(object sender, EventArgs e)
        {
            string maKhoa = cboKhoa.SelectedValue.ToString();
            using (SqlConnection conn = DbConnectionFactory.Create())
            using (SqlCommand cmd = new SqlCommand("sp_SinhVien_TheoKhoa", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@MaKhoa", SqlDbType.VarChar, 10).Value = maKhoa;
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    lstSinhVien.Items.Clear();
                    while (reader.Read())
                        lstSinhVien.Items.Add(string.Format("{0} - {1} - {2:dd/MM/yyyy} - {3:N2}",
                            reader["MaSV"], reader["HoTen"], reader["NgaySinh"], reader["DiemTB"]));
                }
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string sql = @"SELECT MaSV, HoTen, NgaySinh, GioiTinh, MaKhoa, DiemTB, Email
                   FROM SinhVien WHERE MaSV = @MaSV";
            using (SqlConnection conn = DbConnectionFactory.Create())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add("@MaSV", SqlDbType.VarChar, 15).Value = txtMaSV.Text.Trim();
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        txtHoTen.Text = reader["HoTen"].ToString();
                        dtpNgaySinh.Value = Convert.ToDateTime(reader["NgaySinh"]);
                        bool nam = Convert.ToBoolean(reader["GioiTinh"]);
                        radNam.Checked = nam; radNu.Checked = !nam;
                        cboKhoa.SelectedValue = reader["MaKhoa"].ToString();
                        txtDiemTB.Text = Convert.ToDecimal(reader["DiemTB"]).ToString("0.00");
                        txtEmail.Text = reader["Email"] == DBNull.Value ? "" : reader["Email"].ToString();
                    }
                    else
                        MessageBox.Show("Không tìm thấy sinh viên có mã " + txtMaSV.Text);
                }
            }
        }
    }
}
