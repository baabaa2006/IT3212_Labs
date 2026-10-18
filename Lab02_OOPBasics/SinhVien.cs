using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;

namespace Lab02_OOPBasics
{
    public class SinhVien : Nguoi, IValidatable, IPrintable
    {
        public string MaSV { get; set; }
        private double _diemTB;
        public string HoTen
        {
            get { return HoTen; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Họ tên không được rỗng.");
                HoTen = value.Trim();
            }
        }
        public double DiemTB
        {
            get { return _diemTB; }
            set
            {
                if (value < 0 || value > 10)
                    throw new ArgumentOutOfRangeException("DiemTB");
                _diemTB = value;
            }
        }
        public void HienThi()
        {
            Console.WriteLine("{0} - {1} - {2:dd/MM/yyyy} - {3:N2}",
            MaSV, HoTen, NgaySinh, DiemTB);
        }
        public SinhVien(string maSV, string hoTen, DateTime ngaySinh, double diemTB)
            :base(hoTen,ngaySinh)
        {
            NgaySinh = ngaySinh;
            DiemTB = diemTB;
        }

        public int TinhTuoi()
        {
            int tuoi = DateTime.Today.Year - NgaySinh.Year;
            if (NgaySinh.Date > DateTime.Today.AddYears(-tuoi)) tuoi--;
            return tuoi;
        }

        public string XepLoai()
        {
            if (DiemTB >= 9) return "Xuất sắc";
            if (DiemTB >= 8) return "Giỏi";
            if (DiemTB >= 6.5) return "Khá";
            if (DiemTB >= 5) return "Trung bình";
            return "Yếu";
        }
        public override string ToString()
        {
            return base.MoTa() + "-" + MaSV + "-" + DiemTB.ToString("N2");
        }

        public bool IsValid(out string message)
        {
            if (string.IsNullOrWhiteSpace(MaSV)) { message = "Thiếu mã"; return false; }
            if (DiemTB < 0 || DiemTB > 10) { message = "Điểm sai"; return false; }
            message = ""; return true;
        }

        public string ToDisplayText()
        {
            return MaSV + "-" + HoTen;
        }
        
    }


}
