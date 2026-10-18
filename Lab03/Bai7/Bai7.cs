using System;
using System.Collections.Generic;
using System.Text;

namespace Lab03.Bai7
{
    public class Bai7
    {

        public interface IMove
        {
            string Ten { get; }
            double TocDo { get; }             
            decimal TinhChiPhi(double km);       
        }

        public class XeMay : IMove
        {
            private const decimal GiaXang = 24000m;       
            private const decimal LitMoi100Km = 2m;       

            public string Ten { get { return "Xe máy"; } }
            public double TocDo { get { return 50; } }

            public decimal TinhChiPhi(double km)
            {
                return (decimal)km / 100m * LitMoi100Km * GiaXang;
            }
        }

        public class OTo : IMove
        {
            private const decimal GiaXang = 24000m;
            private const decimal LitMoi100Km = 8m;       

            public string Ten { get { return "Ô tô"; } }
            public double TocDo { get { return 70; } }

            public decimal TinhChiPhi(double km)
            {
                return (decimal)km / 100m * LitMoi100Km * GiaXang;
            }
        }

        public class XeDap : IMove
        {
            public string Ten { get { return "Xe đạp"; } }
            public double TocDo { get { return 15; } }

            public decimal TinhChiPhi(double km)
            {
                return 0m;   
            }
        }

        class Program
        {
            static void Main()
            {
                Console.OutputEncoding = Encoding.UTF8;

                List<IMove> dsPhuongTien = new List<IMove>();
                dsPhuongTien.Add(new XeMay());
                dsPhuongTien.Add(new OTo());
                dsPhuongTien.Add(new XeDap());

                double quangDuong = 100;   
                decimal tong = 0;

                Console.WriteLine("Mô phỏng di chuyển {0} km:", quangDuong);
                foreach (IMove pt in dsPhuongTien)
                {
                    double gio = quangDuong / pt.TocDo;
                    decimal chiPhi = pt.TinhChiPhi(quangDuong);
                    tong += chiPhi;
                    Console.WriteLine("{0}: {1} km/h | thời gian {2:F2} giờ | chi phí {3:N0}",
                                      pt.Ten, pt.TocDo, gio, chiPhi);
                }
                Console.WriteLine("Tổng chi phí vận hành: {0:N0}", tong);
            }
        }
    }
}
