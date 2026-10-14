using Lab02_OOPBasics;
using System;
using System.Collections.Generic;

static void Bai5()
{
    Console.WriteLine("--- Bài 5: Quản lý danh sách SinhVien ---");

    // 1. Tạo List và thêm dữ liệu mẫu (tối thiểu 5 bản ghi)
    List<SinhVien> ds = new List<SinhVien>();
    ds.Add(new SinhVien("SV01", "Nguyễn An", new DateTime(2005, 5, 12), 8.2));
    ds.Add(new SinhVien("SV02", "Trần Bình", new DateTime(2005, 9, 3), 6.8));
    ds.Add(new SinhVien("SV03", "Lê Cường", new DateTime(2004, 1, 25), 9.3));
    ds.Add(new SinhVien("SV04", "Phạm Dung", new DateTime(2005, 11, 30), 5.4));
    ds.Add(new SinhVien("SV05", "Hoàng Em", new DateTime(2004, 7, 8), 4.2));

    // 2. In danh sách bằng foreach
    Console.WriteLine("Danh sách sinh viên:");
    foreach (SinhVien sv in ds)
        sv.HienThi();

    // 3. Tìm theo mã bằng Find (không phân biệt hoa thường)
    Console.Write("Mã cần tìm: ");
    string ma = Console.ReadLine() ?? "";
    SinhVien ketQua = ds.Find(x => x.MaSV.Equals(ma, StringComparison.OrdinalIgnoreCase));
    Console.WriteLine(ketQua == null ? "Không tìm thấy" : ketQua.HoTen);
}
