using System;
using System.Collections.Generic;
using System.Text;

namespace Lab03.Bai8
{
    public class Bai8
    {
        public abstract class TaiLieu
        {
            public string MaTL { get; set; }
            public string TieuDe { get; set; }
            public int NamXuatBan { get; set; }

            public abstract string LoaiTaiLieu();

            public virtual string MoTa()
            {
                return "[" + LoaiTaiLieu() + "] " + MaTL + " - " + TieuDe + " (" + NamXuatBan + ")";
            }


            public virtual bool KhopTuKhoa(string tuKhoa)
            {
                return TieuDe.ToLowerInvariant().Contains(tuKhoa.ToLowerInvariant());
            }
        }

        public class Sach : TaiLieu
        {
            public string TacGia { get; set; }
            public string NhaXuatBan { get; set; }
            public int SoTrang { get; set; }

            public override string LoaiTaiLieu() { return "Sách"; }

            public override string MoTa()
            {
                return base.MoTa() + " | Tác giả: " + TacGia + " | NXB: " + NhaXuatBan + " | " + SoTrang + " trang";
            }

            public override bool KhopTuKhoa(string tuKhoa)
            {
                return base.KhopTuKhoa(tuKhoa)
                    || TacGia.ToLowerInvariant().Contains(tuKhoa.ToLowerInvariant());
            }
        }

        public class TapChi : TaiLieu
        {
            public int SoPhatHanh { get; set; }
            public string ChuyenNganh { get; set; }

            public override string LoaiTaiLieu() { return "Tạp chí"; }

            public override string MoTa()
            {
                return base.MoTa() + " | Số phát hành: " + SoPhatHanh + " | Chuyên ngành: " + ChuyenNganh;
            }
        }

        public class LuanVan : TaiLieu
        {
            public string TacGia { get; set; }
            public string GiangVienHuongDan { get; set; }
            public string BacHoc { get; set; }

            public override string LoaiTaiLieu() { return "Luận văn"; }

            public override string MoTa()
            {
                return base.MoTa() + " | Tác giả: " + TacGia + " | GVHD: " + GiangVienHuongDan + " | Bậc học: " + BacHoc;
            }

            public override bool KhopTuKhoa(string tuKhoa)
            {
                return base.KhopTuKhoa(tuKhoa)
                    || TacGia.ToLowerInvariant().Contains(tuKhoa.ToLowerInvariant());
            }
        }

        class Program
        {
            static void InDanhSach(string tieuDe, List<TaiLieu> ds)
            {
                Console.WriteLine(tieuDe);
                if (ds.Count == 0)
                {
                    Console.WriteLine("  (không có kết quả)");
                    return;
                }
                foreach (TaiLieu tl in ds)
                {
                    Console.WriteLine("  " + tl.MoTa());
                }
            }

            static List<TaiLieu> TimKiem(List<TaiLieu> ds, string tuKhoa)
            {
                return ds.Where(tl => tl.KhopTuKhoa(tuKhoa)).ToList();
            }

            static void Main()
            {
                Console.OutputEncoding = Encoding.UTF8;

                List<TaiLieu> thuVien = new List<TaiLieu>();
                thuVien.Add(new Sach
                {
                    MaTL = "S01",
                    TieuDe = "Lập trình C# cơ bản",
                    NamXuatBan = 2022,
                    TacGia = "Nguyễn Văn A",
                    NhaXuatBan = "Bách Khoa",
                    SoTrang = 350
                });
                thuVien.Add(new Sach
                {
                    MaTL = "S02",
                    TieuDe = "Cơ sở dữ liệu Oracle",
                    NamXuatBan = 2021,
                    TacGia = "Trần Thị B",
                    NhaXuatBan = "Giáo Dục",
                    SoTrang = 420
                });
                thuVien.Add(new TapChi
                {
                    MaTL = "TC01",
                    TieuDe = "Tạp chí Tin học",
                    NamXuatBan = 2023,
                    SoPhatHanh = 5,
                    ChuyenNganh = "Công nghệ thông tin"
                });
                thuVien.Add(new LuanVan
                {
                    MaTL = "LV01",
                    TieuDe = "Hệ thống quản lý thư viện",
                    NamXuatBan = 2024,
                    TacGia = "Lê Văn C",
                    GiangVienHuongDan = "TS. Phạm D",
                    BacHoc = "Thạc sĩ"
                });

                InDanhSach("=== Toàn bộ tài liệu ===", thuVien);

                Console.WriteLine();
                InDanhSach("=== Tìm kiếm: \"oracle\" ===", TimKiem(thuVien, "oracle"));

                Console.WriteLine();
                InDanhSach("=== Tìm kiếm: \"lê văn c\" ===", TimKiem(thuVien, "lê văn c"));

                Console.WriteLine();
                Console.WriteLine("=== Thống kê theo loại ===");
                Console.WriteLine("Sách: " + thuVien.OfType<Sach>().Count());
                Console.WriteLine("Tạp chí: " + thuVien.OfType<TapChi>().Count());
                Console.WriteLine("Luận văn: " + thuVien.OfType<LuanVan>().Count());
            }
        }
    }
}
