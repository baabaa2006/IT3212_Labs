using System;
using System.Collections.Generic;
using System.Text;

namespace Lab03.Bai_1
{
    public abstract class NhanVien
    {
        public string MaNV { get; set; }
        public string HoTen { get; set; }
        public decimal LuongCoBan { get; set; }

        public abstract decimal TinhLuong();

        public virtual string MoTa()
        {
            return MaNV + " - " + HoTen;
        }
    }

    public class NhanVienVanPhong : NhanVien
    {
        public int SoNgayCong { get; set; }

        public override decimal TinhLuong()
        {
            return LuongCoBan / 26 * SoNgayCong;
        }

        public override string MoTa()
        {
            return base.MoTa() + " (Văn phòng, " + SoNgayCong + " ngày công)";
        }
    }

    public class NhanVienKinhDoanh : NhanVien
    {
        public decimal DoanhSo { get; set; }

        public override decimal TinhLuong()
        {
            return LuongCoBan + DoanhSo * 0.05m;
        }

        public override string MoTa()
        {
            return base.MoTa() + " (Kinh doanh, doanh số " + DoanhSo.ToString("N0") + ")";
        }
    }

    public class GiangVien : NhanVien
    {
        public int SoGioGiang { get; set; }

        public override decimal TinhLuong()
        {
            return LuongCoBan + SoGioGiang * 200000m;
        }

        public override string MoTa()
        {
            return base.MoTa() + " (Giảng viên, " + SoGioGiang + " giờ giảng)";
        }
    }

    class Program1
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            List<NhanVien> dsNhanVien = new List<NhanVien>();
            dsNhanVien.Add(new NhanVienVanPhong { MaNV = "VP01", HoTen = "Lan", LuongCoBan = 10400000m, SoNgayCong = 24 });
            dsNhanVien.Add(new NhanVienKinhDoanh { MaNV = "KD01", HoTen = "Minh", LuongCoBan = 7000000m, DoanhSo = 120000000m });
            dsNhanVien.Add(new GiangVien { MaNV = "GV01", HoTen = "Hùng", LuongCoBan = 9000000m, SoGioGiang = 40 });

            decimal tong = 0;
            foreach (NhanVien nv in dsNhanVien)
            {
                decimal luong = nv.TinhLuong();
                tong += luong;
                Console.WriteLine("{0} => Lương: {1:N0}", nv.MoTa(), luong);
            }
            Console.WriteLine("Tổng lương: {0:N0}", tong);
        }
    }
}
