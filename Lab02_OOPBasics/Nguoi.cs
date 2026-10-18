using System;
using System.Collections.Generic;
using System.Text;

namespace Lab02_OOPBasics
{
    public class Nguoi
    {
        public DateTime NgaySinh { get; set; }

        private string _hoTen;

        public Nguoi(string _hoTen,DateTime NgaySinh)
        {
            this._hoTen = _hoTen;
            this.NgaySinh = NgaySinh;
        }

        public virtual string MoTa()
        {
            return _hoTen + "-" + NgaySinh.ToString("dd/MM/yyyy");
        }
    }
}
