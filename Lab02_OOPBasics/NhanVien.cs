using System;
using System.Collections.Generic;
using System.Text;

namespace Lab02_OOPBasics
{
    public class NhanVien
    {
        private string _maNV;
        private string _hoTen;
        private double _luongCoBan;
        private double _heSo;
        private double _phuCap;

        public string MaNV
        {
            get { return _maNV; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Mã nhân viên không được rỗng.");
                _maNV = value.Trim();
            }
        }

        public string HoTen
        {
            get { return _hoTen; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Họ tên không được rỗng.");
                _hoTen = value.Trim();
            }
        }

        public double LuongCoBan
        {
            get { return _luongCoBan; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("LuongCoBan", "Lương cơ bản không được âm.");
                _luongCoBan = value;
            }
        }

        public double HeSo
        {
            get { return _heSo; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("HeSo", "Hệ số không được âm.");
                _heSo = value;
            }
        }

        public double PhuCap
        {
            get { return _phuCap; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("PhuCap", "Phụ cấp không được âm.");
                _phuCap = value;
            }
        }

        public NhanVien(string maNV, string hoTen, double luongCoBan, double heSo, double phuCap)
        {
            MaNV = maNV;
            HoTen = hoTen;
            LuongCoBan = luongCoBan;
            HeSo = heSo;
            PhuCap = phuCap;
        }

        public double TinhLuong()
        {
            return LuongCoBan * HeSo + PhuCap;
        }

        public static void InBangLuong(List<NhanVien> ds)
        {
            Console.WriteLine("{0,-8} {1,-20} {2,12} {3,6} {4,10} {5,14}",
                "Mã NV", "Họ tên", "Lương CB", "Hệ số", "Phụ cấp", "Thực lĩnh");
            Console.WriteLine(new string('-', 76));

            double tong = 0;
            foreach (NhanVien nv in ds)
            {
                Console.WriteLine("{0,-8} {1,-20} {2,12:N0} {3,6:N2} {4,10:N0} {5,14:N0}",
                    nv.MaNV, nv.HoTen, nv.LuongCoBan, nv.HeSo, nv.PhuCap, nv.TinhLuong());
                tong += nv.TinhLuong();
            }

            Console.WriteLine(new string('-', 76));
            Console.WriteLine("{0,-62} {1,14:N0}", "Tổng quỹ lương:", tong);
        }
    }
}
