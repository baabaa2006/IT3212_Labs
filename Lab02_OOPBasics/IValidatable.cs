using System;
using System.Collections.Generic;
using System.Text;

namespace Lab02_OOPBasics
{
    public interface IValidatable
    {
        bool IsValid(out string message);
    }
}
