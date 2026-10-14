using System;
using System.Collections.Generic;
using System.Text;

namespace Lab02_OOPBasics
{
    public class QuanLySinhVien
    {
        private readonly List<SinhVien> _ds = new List<SinhVien>();

        public QuanLySinhVien()
        {
            // Dữ liệu mẫu để kiểm thử
            _ds.Add(new SinhVien("SV01", "Nguyễn An", new DateTime(2005, 5, 12), 8.2));
            _ds.Add(new SinhVien("SV02", "Trần Bình", new DateTime(2005, 9, 3), 6.8));
            _ds.Add(new SinhVien("SV03", "Lê Cường", new DateTime(2004, 1, 25), 9.3));
            _ds.Add(new SinhVien("SV04", "Phạm Dung", new DateTime(2005, 11, 30), 5.4));
            _ds.Add(new SinhVien("SV05", "Hoàng Em", new DateTime(2004, 7, 8), 4.2));
            _ds.Add(new SinhVien("SV06", "Vũ Phương", new DateTime(2005, 3, 17), 7.5));
        }

        public void Chay()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("===== QUẢN LÝ SINH VIÊN =====");
                Console.WriteLine("1. Hiển thị danh sách");
                Console.WriteLine("2. Thêm sinh viên");
                Console.WriteLine("3. Sửa sinh viên");
                Console.WriteLine("4. Xóa sinh viên");
                Console.WriteLine("5. Tìm kiếm");
                Console.WriteLine("6. Sắp xếp");
                Console.WriteLine("7. Thống kê");
                Console.WriteLine("0. Quay lại");
                int chon = Nhap.SoNguyen("Chọn: ");
                try
                {
                    switch (chon)
                    {
                        case 1: HienThiDanhSach(_ds); break;
                        case 2: Them(); break;
                        case 3: Sua(); break;
                        case 4: Xoa(); break;
                        case 5: TimKiem(); break;
                        case 6: SapXep(); break;
                        case 7: ThongKe(); break;
                        case 0: return;
                        default: Console.WriteLine("Lựa chọn không hợp lệ."); break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi: " + ex.Message);
                }
            }
        }

        private static void HienThiDanhSach(List<SinhVien> ds)
        {
            if (ds.Count == 0)
            {
                Console.WriteLine("Danh sách rỗng.");
                return;
            }
            Console.WriteLine("{0,-6} {1,-20} {2,-12} {3,6} {4,5} {5,-12}",
                "Mã", "Họ tên", "Ngày sinh", "ĐTB", "Tuổi", "Xếp loại");
            foreach (SinhVien sv in ds)
                Console.WriteLine("{0,-6} {1,-20} {2,-12:dd/MM/yyyy} {3,6:N2} {4,5} {5,-12}",
                    sv.MaSV, sv.HoTen, sv.NgaySinh, sv.DiemTB, sv.TinhTuoi(), sv.XepLoai());
        }

        private SinhVien TimTheoMa(string ma)
        {
            return _ds.Find(x => x.MaSV.Equals(ma, StringComparison.OrdinalIgnoreCase));
        }

        private void Them()
        {
            string ma = Nhap.Chuoi("Mã SV: ");
            if (TimTheoMa(ma) != null)
            {
                Console.WriteLine("Mã đã tồn tại.");
                return;
            }
            string ten = Nhap.Chuoi("Họ tên: ");
            DateTime ns = Nhap.Ngay("Ngày sinh");
            double diem = Nhap.SoThuc("Điểm TB (0-10): ");
            _ds.Add(new SinhVien(ma, ten, ns, diem)); // ném lỗi nếu dữ liệu sai
            Console.WriteLine("Đã thêm.");
        }

        private void Sua()
        {
            SinhVien sv = TimTheoMa(Nhap.Chuoi("Mã SV cần sửa: "));
            if (sv == null)
            {
                Console.WriteLine("Không tìm thấy.");
                return;
            }
            Console.WriteLine("(Bỏ trống để giữ nguyên)");

            Console.Write("Họ tên mới [{0}]: ", sv.HoTen);
            string ten = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(ten)) sv.HoTen = ten;

            Console.Write("Điểm TB mới [{0:N2}]: ", sv.DiemTB);
            string d = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(d))
            {
                if (double.TryParse(d.Replace(',', '.'),
                    System.Globalization.NumberStyles.Float,
                    System.Globalization.CultureInfo.InvariantCulture, out double diem))
                    sv.DiemTB = diem;
                else
                    Console.WriteLine("Điểm không hợp lệ, giữ nguyên.");
            }
            Console.WriteLine("Đã cập nhật.");
        }

        private void Xoa()
        {
            SinhVien sv = TimTheoMa(Nhap.Chuoi("Mã SV cần xóa: "));
            if (sv == null)
            {
                Console.WriteLine("Không tìm thấy.");
                return;
            }
            _ds.Remove(sv);
            Console.WriteLine("Đã xóa.");
        }

        private void TimKiem()
        {
            Console.WriteLine("1. Theo mã   2. Theo tên (chứa từ khóa)");
            int c = Nhap.SoNguyen("Chọn: ");
            string kw = Nhap.Chuoi("Từ khóa: ");
            List<SinhVien> kq;
            if (c == 1)
                kq = _ds.Where(x => x.MaSV.Equals(kw, StringComparison.OrdinalIgnoreCase)).ToList();
            else
                kq = _ds.Where(x => x.HoTen.IndexOf(kw, StringComparison.OrdinalIgnoreCase) >= 0).ToList();

            if (kq.Count == 0) Console.WriteLine("Không tìm thấy.");
            else HienThiDanhSach(kq);
        }

        private void SapXep()
        {
            Console.WriteLine("1. Điểm TB giảm dần   2. Họ tên A-Z   3. Mã SV tăng dần");
            int c = Nhap.SoNguyen("Chọn: ");
            switch (c)
            {
                case 1: _ds.Sort((a, b) => b.DiemTB.CompareTo(a.DiemTB)); break;
                case 2: _ds.Sort((a, b) => string.Compare(a.HoTen, b.HoTen, StringComparison.CurrentCultureIgnoreCase)); break;
                case 3: _ds.Sort((a, b) => string.Compare(a.MaSV, b.MaSV, StringComparison.OrdinalIgnoreCase)); break;
                default: Console.WriteLine("Lựa chọn không hợp lệ."); return;
            }
            HienThiDanhSach(_ds);
        }

        private void ThongKe()
        {
            if (_ds.Count == 0)
            {
                Console.WriteLine("Danh sách rỗng.");
                return;
            }
            Console.WriteLine("Tổng số sinh viên : {0}", _ds.Count);
            Console.WriteLine("Điểm TB chung     : {0:N2}", _ds.Average(x => x.DiemTB));
            SinhVien max = _ds.OrderByDescending(x => x.DiemTB).First();
            SinhVien min = _ds.OrderBy(x => x.DiemTB).First();
            Console.WriteLine("Điểm cao nhất     : {0:N2} ({1})", max.DiemTB, max.HoTen);
            Console.WriteLine("Điểm thấp nhất    : {0:N2} ({1})", min.DiemTB, min.HoTen);
            Console.WriteLine("Thống kê theo xếp loại:");
            foreach (string loai in new[] { "Xuất sắc", "Giỏi", "Khá", "Trung bình", "Yếu" })
                Console.WriteLine("  {0,-11}: {1}", loai, _ds.Count(x => x.XepLoai() == loai));
        }
    }
}
