using System;
using System.Collections.Generic;
using System.Text;

namespace Lab03.Bai9
{
    public class Bai9
    {
        public interface IPayment
        {
            string TenPhuongThuc { get; }
            bool KiemTra(decimal soTien, out string thongBao);
            string ThucHien(decimal soTien);    
        }

        public class ThanhToanTienMat : IPayment
        {
            public string TenPhuongThuc { get { return "Tiền mặt"; } }

            public bool KiemTra(decimal soTien, out string thongBao)
            {
                if (soTien <= 0) { thongBao = "Số tiền phải lớn hơn 0"; return false; }
                if (soTien > 20000000m) { thongBao = "Tiền mặt tối đa 20.000.000 đồng"; return false; }
                thongBao = "";
                return true;
            }

            public string ThucHien(decimal soTien)
            {
                return "Đã thu tiền mặt tại quầy";
            }
        }

        public class ChuyenKhoan : IPayment
        {
            public string SoTaiKhoan { get; set; }
            public string NganHang { get; set; }

            public string TenPhuongThuc { get { return "Chuyển khoản"; } }

            public bool KiemTra(decimal soTien, out string thongBao)
            {
                if (string.IsNullOrWhiteSpace(SoTaiKhoan)) { thongBao = "Thiếu số tài khoản"; return false; }
                if (soTien <= 0) { thongBao = "Số tiền phải lớn hơn 0"; return false; }
                if (soTien < 10000m) { thongBao = "Chuyển khoản tối thiểu 10.000 đồng"; return false; }
                thongBao = "";
                return true;
            }

            public string ThucHien(decimal soTien)
            {
                return "Chuyển đến " + NganHang + " - " + SoTaiKhoan;
            }
        }

        public class ViDienTu : IPayment
        {
            public decimal SoDu { get; set; }

            public string TenPhuongThuc { get { return "Ví điện tử"; } }

            public bool KiemTra(decimal soTien, out string thongBao)
            {
                if (soTien <= 0) { thongBao = "Số tiền phải lớn hơn 0"; return false; }
                if (soTien > SoDu)
                {
                    thongBao = "Số dư không đủ (hiện có " + SoDu.ToString("N0") + ")";
                    return false;
                }
                thongBao = "";
                return true;
            }

            public string ThucHien(decimal soTien)
            {
                SoDu -= soTien;
                return "Số dư còn lại: " + SoDu.ToString("N0");
            }
        }

        public class GiaoDich
        {
            public string MaGD { get; set; }
            public string PhuongThuc { get; set; }
            public decimal SoTien { get; set; }
            public DateTime ThoiGian { get; set; }
            public bool ThanhCong { get; set; }
            public string GhiChu { get; set; }

            public override string ToString()
            {
                return string.Format("{0} | {1} | {2:N0} | {3} | {4}",
                    MaGD, PhuongThuc, SoTien, ThanhCong ? "Thành công" : "Thất bại", GhiChu);
            }
        }

        public class QuanLyGiaoDich
        {
            private List<GiaoDich> lichSu = new List<GiaoDich>();

            public void XuLy(IPayment phuongThuc, decimal soTien)
            {
                GiaoDich gd = new GiaoDich
                {
                    MaGD = "GD" + (lichSu.Count + 1).ToString("000"),
                    PhuongThuc = phuongThuc.TenPhuongThuc,
                    SoTien = soTien,
                    ThoiGian = DateTime.Now
                };

                string thongBao;
                if (phuongThuc.KiemTra(soTien, out thongBao))
                {
                    gd.ThanhCong = true;
                    gd.GhiChu = phuongThuc.ThucHien(soTien);
                }
                else
                {
                    gd.ThanhCong = false;
                    gd.GhiChu = thongBao;
                }

                lichSu.Add(gd);
                Console.WriteLine(gd);
            }

            public void ThongKe()
            {
                int thanhCong = lichSu.Count(g => g.ThanhCong);
                decimal tongThu = lichSu.Where(g => g.ThanhCong).Sum(g => g.SoTien);
                Console.WriteLine("Thành công: {0}/{1} giao dịch", thanhCong, lichSu.Count);
                Console.WriteLine("Tổng tiền đã thu: {0:N0}", tongThu);
            }
        }

        class Program
        {
            static void Main()
            {
                Console.OutputEncoding = Encoding.UTF8;

                IPayment tienMat = new ThanhToanTienMat();
                IPayment chuyenKhoan = new ChuyenKhoan { SoTaiKhoan = "0123456789", NganHang = "Vietcombank" };
                IPayment viDienTu = new ViDienTu { SoDu = 500000m };

                QuanLyGiaoDich ql = new QuanLyGiaoDich();

                Console.WriteLine("=== Ghi nhận giao dịch ===");
                ql.XuLy(tienMat, 1500000m);
                ql.XuLy(tienMat, 25000000m);
                ql.XuLy(chuyenKhoan, 5000000m);
                ql.XuLy(chuyenKhoan, 5000m);
                ql.XuLy(viDienTu, 300000m);
                ql.XuLy(viDienTu, 300000m);

                Console.WriteLine();
                Console.WriteLine("=== Thống kê ===");
                ql.ThongKe();
            }
        }
    }
}
