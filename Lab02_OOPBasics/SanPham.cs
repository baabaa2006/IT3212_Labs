using System;
using System.Collections.Generic;
using System.Text;

namespace Lab02_OOPBasics
{
    public class SanPham
    {
        private string _ma;
        private string _ten;
        private double _donGia;
        private int _soLuong;

        public string Ma
        {
            get { return _ma; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Mã sản phẩm không được rỗng.");
                _ma = value.Trim();
            }
        }

        public string Ten
        {
            get { return _ten; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Tên sản phẩm không được rỗng.");
                _ten = value.Trim();
            }
        }

        public double DonGia
        {
            get { return _donGia; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("DonGia", "Đơn giá không được âm.");
                _donGia = value;
            }
        }

        public int SoLuong
        {
            get { return _soLuong; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("SoLuong", "Số lượng không được âm.");
                _soLuong = value;
            }
        }

        public SanPham()
        {
            _ma = "Chưa có";
            _ten = "Chưa có";
            _donGia = 0;
            _soLuong = 0;
        }

        public SanPham(string ma, string ten, double donGia, int soLuong)
        {
            Ma = ma;
            Ten = ten;
            DonGia = donGia;
            SoLuong = soLuong;
        }

        public double TinhThanhTien()
        {
            return DonGia * SoLuong;
        }

        public void HienThi()
        {
            Console.WriteLine("{0,-8} {1,-20} {2,12:N0} {3,6} {4,14:N0}",
                Ma, Ten, DonGia, SoLuong, TinhThanhTien());
        }
    }
}
