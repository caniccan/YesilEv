using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YesilEvV2.Validation.Interfaces;

namespace YesilEvV2.Validation.Abstract
{
    public abstract class AbstractUyeValidate<T> : IUyeValidate<T> where T : class, new()
    {
        public abstract bool UyeEkleValidate(T value);
        public abstract bool UyeGirisValidate(string kullaniciAdi, string sifre);

    }
}
