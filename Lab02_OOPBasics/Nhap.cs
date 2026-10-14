using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Lab02_OOPBasics
{
    public static class Nhap
    {
        public static string Chuoi(string thongBao)
        {
            while (true)
            {
                Console.Write(thongBao);
                string s = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(s)) return s.Trim();
                Console.WriteLine("  -> Không được để trống, nhập lại.");
            }
        }

        public static double SoThuc(string thongBao)
        {
            while (true)
            {
                Console.Write(thongBao);
                string s = Console.ReadLine();
                if (double.TryParse(s?.Replace(',', '.'), NumberStyles.Float,
                    CultureInfo.InvariantCulture, out double kq))
                    return kq;
                Console.WriteLine("  -> Giá trị không hợp lệ, nhập lại.");
            }
        }

        public static int SoNguyen(string thongBao)
        {
            while (true)
            {
                Console.Write(thongBao);
                if (int.TryParse(Console.ReadLine(), out int kq)) return kq;
                Console.WriteLine("  -> Giá trị không hợp lệ, nhập lại.");
            }
        }

        public static DateTime Ngay(string thongBao)
        {
            while (true)
            {
                Console.Write(thongBao + " (dd/MM/yyyy): ");
                if (DateTime.TryParseExact(Console.ReadLine(), "d/M/yyyy",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime kq))
                    return kq;
                Console.WriteLine("  -> Ngày không hợp lệ, nhập lại.");
            }
        }
    }
}
