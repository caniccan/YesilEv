using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YesilEvV2.Validation.Abstract.Interfaces
{
    public interface IUrunValidate<T>
    {
        bool UrunEkleValidate(T value);
    }
}
