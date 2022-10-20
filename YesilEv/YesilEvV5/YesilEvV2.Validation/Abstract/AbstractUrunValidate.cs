using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YesilEvV2.Validation.Abstract.Interfaces;

namespace YesilEvV2.Validation.Abstract
{
    public abstract class AbstractUrunValidate<T> : IUrunValidate<T> where T : class, new()
    {
        public abstract bool UrunEkleValidate(T value);

    }
}
