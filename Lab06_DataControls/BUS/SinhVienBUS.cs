using Lab02_OOPBasics;
using Lab06_DataControls.DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab06_DataControls.BUS
{
    public class SinhVienBUS
    {
        private readonly SinhVienDAL _dal = new SinhVienDAL();

        public List<SinhVien> GetAll()
        {
            return _dal.GetAll();
        }

        public List<SinhVien> GetByKhoa(string khoa)
        {
            return _dal.GetAll().Where(x => x.Khoa == khoa).ToList();
        }

        public List<string> GetDanhSachKhoa()
        {
            return new List<string>
            {
                DuLieuMau.KhoaCNTT, DuLieuMau.KhoaOTo, DuLieuMau.KhoaKT
            };
        }

        // Các quy tắc nghiệp vụ dùng chung cho Thêm và Sửa
        private void KiemTra(SinhVien sv)
        {
            if (sv == null)
                throw new ArgumentNullException("sv");
            if (string.IsNullOrWhiteSpace(sv.MaSV))
                throw new ArgumentException("Thiếu mã sinh viên");
            if (string.IsNullOrWhiteSpace(sv.HoTen))
                throw new ArgumentException("Thiếu họ tên");
            if (string.IsNullOrWhiteSpace(sv.Khoa))
                throw new ArgumentException("Chưa chọn khoa");
            if (sv.DiemTB < 0 || sv.DiemTB > 10)
                throw new ArgumentException("Điểm phải từ 0 đến 10");
        }

        public void Add(SinhVien sv)
        {
            KiemTra(sv);

            if (_dal.GetByMa(sv.MaSV) != null)
                throw new InvalidOperationException("Trùng mã sinh viên");

            _dal.Add(sv);
        }

        public void Update(string maCu, SinhVien moi)
        {
            KiemTra(moi);

            // Chỉ kiểm tra trùng khi người dùng đổi sang mã khác
            bool doiMa = !string.Equals(maCu, moi.MaSV,
                StringComparison.OrdinalIgnoreCase);
            if (doiMa && _dal.GetByMa(moi.MaSV) != null)
                throw new InvalidOperationException("Trùng mã sinh viên");

            if (!_dal.Update(maCu, moi))
                throw new InvalidOperationException("Không tìm thấy sinh viên");
        }

        public void Delete(string ma)
        {
            if (!_dal.Delete(ma))
                throw new InvalidOperationException("Không tìm thấy sinh viên");
        }
    }
}