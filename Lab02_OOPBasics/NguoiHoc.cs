using System;
using System.Collections.Generic;
using System.Text;

namespace Lab02_OOPBasics
{
    public abstract class NguoiHoc
    {
        public string HoTen { get; set; }
        public int SoTinChi { get; set; }
        public abstract decimal TinhHocPhi();
    }
}
