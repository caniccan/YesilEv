using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YesilEvV2.Core.Context;
using YesilEvV2.Core.Entities;
using YesilEvV2.Core.Repos;
using YesilEvV2.DAL.Interfaces;
using YesilEvV2.DAL;
using YesilEvV2.Mapping;

namespace YesilEvV2.DAL
{
    public class UyeDAL:EFRepoBase<MyDbContext, Uye>, IUyeDAL
    {
        public UyeDAL()
        {

        }
        public UyeDAL(MyDbContext context):base(context)
        {

        }
        public bool UyeGiris(string kullaniciAdi, string sifre)
        {
            var uyeVarMi = GetBy(x => x.KullaniciAdi == kullaniciAdi && x.Sifre == sifre).Any();
            return uyeVarMi;
        }
    }
}
