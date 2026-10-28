using System;
using System.Collections.Generic;
using Lab02_OOPBasics;

namespace Lab06_DataControls.DAL
{
    public static class DuLieuMau
    {
        public const string KhoaCNTT = "Công nghệ thông tin";
        public const string KhoaOTo = "Công nghệ kỹ thuật ô tô";
        public const string KhoaKT = "Kinh tế";

        public static List<SinhVien> Tao()
        {
            return new List<SinhVien>
            {
                // Khoa Công nghệ thông tin
                new SinhVien("SV01", "Nguyễn An",   new DateTime(2004, 3, 12), 8.2, KhoaCNTT),
                new SinhVien("SV02", "Trần Bình",   new DateTime(2004, 7, 25), 7.0, KhoaCNTT),
                new SinhVien("SV03", "Lê Chi",      new DateTime(2003, 11, 5), 9.1, KhoaCNTT),

                // Khoa Công nghệ kỹ thuật ô tô
                new SinhVien("SV04", "Phạm Dũng",   new DateTime(2004, 1, 18), 6.5, KhoaOTo),
                new SinhVien("SV05", "Hoàng Em",    new DateTime(2003, 9, 30), 7.8, KhoaOTo),
                new SinhVien("SV06", "Vũ Phúc",     new DateTime(2004, 5, 9),  5.4, KhoaOTo),

                // Khoa Kinh tế
                new SinhVien("SV07", "Đặng Giang",  new DateTime(2004, 12, 2), 8.8, KhoaKT),
                new SinhVien("SV08", "Bùi Hà",      new DateTime(2003, 6, 21), 4.7, KhoaKT),
                new SinhVien("SV09", "Ngô Khánh",   new DateTime(2004, 8, 14), 7.3, KhoaKT)
            };
        }
    }
}