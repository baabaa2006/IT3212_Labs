using Lab02_OOPBasics;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab06_DataControls.DAL
{
    public class SinhVienDAL
    {
        // static: mọi Form dùng chung một kho, giống như cùng một CSDL
        private static readonly List<SinhVien> _data = DuLieuMau.Tao();

        public List<SinhVien> GetAll()
        {
            return new List<SinhVien>(_data);
        }

        public SinhVien GetByMa(string ma)
        {
            return _data.FirstOrDefault(x => string.Equals(
                x.MaSV, ma, StringComparison.OrdinalIgnoreCase));
        }

        public void Add(SinhVien sv)
        {
            _data.Add(sv);
        }

        // Thay sinh viên có mã cũ bằng bản mới; trả về false nếu không thấy
        public bool Update(string maCu, SinhVien moi)
        {
            int index = _data.FindIndex(x => string.Equals(
                x.MaSV, maCu, StringComparison.OrdinalIgnoreCase));
            if (index < 0) return false;

            _data[index] = moi;
            return true;
        }

        public bool Delete(string ma)
        {
            return _data.RemoveAll(x => string.Equals(
                x.MaSV, ma, StringComparison.OrdinalIgnoreCase)) > 0;
        }
    }
}