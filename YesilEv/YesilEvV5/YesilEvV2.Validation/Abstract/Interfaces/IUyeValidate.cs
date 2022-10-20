using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YesilEvV2.DAL;

namespace YesilEvV2.Validation.Interfaces
{
    public interface IUyeValidate<T>
    {
        bool UyeEkleValidate(T value);
        bool UyeGirisValidate(string kullaniciAdi,string sifre);
    }
}
