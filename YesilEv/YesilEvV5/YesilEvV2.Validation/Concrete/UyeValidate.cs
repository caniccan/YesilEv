using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YesilEvV2.DAL;
using YesilEvV2.Validation.Abstract;
using YesilEvV2.Validation.Interfaces;

namespace YesilEvV2.Validation.Concrete
{
    public class UyeValidate : AbstractUyeValidate<UyeEkleDTO>
    {
        public bool uyeOlIsValid = false;
        public bool girisIsValid = false;
        public UyeValidate()
        {

        }
        public UyeValidate(UyeEkleDTO value)
        {
            uyeOlIsValid = UyeEkleValidate(value);
        }
        public UyeValidate(string kullaniciAdi, string sifre)
        {
            girisIsValid = UyeGirisValidate(kullaniciAdi, sifre);
        }
        public override bool UyeEkleValidate(UyeEkleDTO value)
        {
            if (string.IsNullOrEmpty(value.KullaniciAdi) || string.IsNullOrEmpty(value.Sifre) || string.IsNullOrEmpty(value.AdSoyad) ||
                string.IsNullOrEmpty(value.TelNo) || string.IsNullOrEmpty(value.Mail))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public override bool UyeGirisValidate(string kullaniciAdi, string sifre)
        {
            if (string.IsNullOrEmpty(kullaniciAdi) || string.IsNullOrEmpty(sifre))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
