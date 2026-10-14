using System;
using System.Collections.Generic;
using System.Text;

namespace Lab02_OOPBasics
{
    public class HinhChuNhat
    {
        private double _chieuDai;
        private double _chieuRong;

        public double ChieuDai
        {
            get { return _chieuDai; }
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("ChieuDai", "Chiều dài phải lớn hơn 0.");
                _chieuDai = value;
            }
        }

        public double ChieuRong
        {
            get { return _chieuRong; }
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("ChieuRong", "Chiều rộng phải lớn hơn 0.");
                _chieuRong = value;
            }
        }

        // Constructor mặc định: hình chữ nhật 1 x 1 (trạng thái hợp lệ)
        public HinhChuNhat()
        {
            _chieuDai = 1;
            _chieuRong = 1;
        }

        // Constructor đầy đủ tham số (gán qua thuộc tính để được kiểm tra)
        public HinhChuNhat(double chieuDai, double chieuRong)
        {
            ChieuDai = chieuDai;
            ChieuRong = chieuRong;
        }

        public double TinhChuVi()
        {
            return 2 * (ChieuDai + ChieuRong);
        }

        public double TinhDienTich()
        {
            return ChieuDai * ChieuRong;
        }

        public void HienThi()
        {
            Console.WriteLine("HCN {0} x {1} | Chu vi = {2:N2} | Diện tích = {3:N2}",
                ChieuDai, ChieuRong, TinhChuVi(), TinhDienTich());
        }
    }
}
