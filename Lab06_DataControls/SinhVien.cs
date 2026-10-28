using System;

namespace Lab02_OOPBasics
{
    public class SinhVien
    {
        private string _hoTen;
        private double _diemTB;

        public string MaSV { get; set; }
        public DateTime NgaySinh { get; set; }
        public string Khoa { get; set; }

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

        public SinhVien() { }

        public SinhVien(string maSV, string hoTen, DateTime ngaySinh, double diemTB)
        {
            MaSV = maSV;
            HoTen = hoTen;
            NgaySinh = ngaySinh;
            DiemTB = diemTB;
        }


        public SinhVien(string maSV, string hoTen, DateTime ngaySinh, double diemTB, string khoa)
            : this(maSV, hoTen, ngaySinh, diemTB)
        {
            Khoa = khoa;
        }

        public string XepLoai()
        {
            if (DiemTB >= 9) return "Xuất sắc";
            if (DiemTB >= 8) return "Giỏi";
            if (DiemTB >= 6.5) return "Khá";
            if (DiemTB >= 5) return "Trung bình";
            return "Yếu";
        }

        public bool IsValid(out string message)
        {
            if (string.IsNullOrWhiteSpace(MaSV)) { message = "Thiếu mã"; return false; }
            if (string.IsNullOrWhiteSpace(HoTen)) { message = "Thiếu họ tên"; return false; }
            if (DiemTB < 0 || DiemTB > 10) { message = "Điểm sai"; return false; }
            message = ""; return true;
        }

        public string ToDisplayText()
        {
            return MaSV + "-" + HoTen;
        }
    }
}