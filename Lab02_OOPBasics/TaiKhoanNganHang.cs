using System;
using System.Collections.Generic;
using System.Text;

namespace Lab02_OOPBasics
{
    public class TaiKhoanNganHang
    {
        private string _soTK;
        private string _chuTK;
        private double _soDu;

        public string SoTK
        {
            get { return _soTK; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Số tài khoản không được rỗng.");
                _soTK = value.Trim();
            }
        }

        public string ChuTK
        {
            get { return _chuTK; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Tên chủ tài khoản không được rỗng.");
                _chuTK = value.Trim();
            }
        }

        // Chỉ đọc từ bên ngoài: số dư chỉ thay đổi qua NapTien / RutTien / ChuyenTien
        public double SoDu
        {
            get { return _soDu; }
            private set
            {
                if (value < 0)
                    throw new InvalidOperationException("Số dư không được âm.");
                _soDu = value;
            }
        }

        public TaiKhoanNganHang(string soTK, string chuTK, double soDuBanDau = 0)
        {
            SoTK = soTK;
            ChuTK = chuTK;
            SoDu = soDuBanDau;
        }

        public void NapTien(double soTien)
        {
            if (soTien <= 0)
                throw new ArgumentException("Số tiền nạp phải lớn hơn 0.");
            SoDu += soTien;
        }

        public void RutTien(double soTien)
        {
            if (soTien <= 0)
                throw new ArgumentException("Số tiền rút phải lớn hơn 0.");
            if (soTien > SoDu)
                throw new InvalidOperationException("Số dư không đủ để rút.");
            SoDu -= soTien;
        }

        public void ChuyenTien(TaiKhoanNganHang taiKhoanNhan, double soTien)
        {
            if (taiKhoanNhan == null)
                throw new ArgumentNullException("taiKhoanNhan");
            if (ReferenceEquals(this, taiKhoanNhan))
                throw new InvalidOperationException("Không thể chuyển tiền cho chính mình.");

            RutTien(soTien);              // rút trước: nếu lỗi thì chưa cộng vào TK nhận
            taiKhoanNhan.NapTien(soTien);
        }

        public void HienThi()
        {
            Console.WriteLine("TK {0} - {1} - Số dư: {2:N0}", SoTK, ChuTK, SoDu);
        }
    }
}
