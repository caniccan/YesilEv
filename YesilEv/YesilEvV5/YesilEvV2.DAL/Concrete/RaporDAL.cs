using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YesilEvV2.Core.Context;
using YesilEvV2.DTOs.Sorgular;

namespace YesilEvV2.DAL.Concrete
{
    public class RaporDAL
    {
        FavorilerDAL favorilerDAL = new FavorilerDAL();
        KaralisteDAL karalisteDAL = new KaralisteDAL();
        UrunDAL urunDAL = new UrunDAL();
        RolDAL RolDAL = new RolDAL();
        UyeDAL uyeDAL = new UyeDAL();
        public List<KaraListeFavoriBuAyDTO> KaraListeFavoriBuAy()
        {
            List<KaraListeFavoriBuAyDTO> list = null;
            using (MyDbContext db = new MyDbContext())
            {
                var a = (from u in db.uye
                         join ur in db.urun on u.ID equals ur.OluşturanKisi
                         join f in db.favoriler on u.ID equals f.OluşturanKisi
                         join k in db.karaListe on u.ID equals k.OluşturanKisi
                         where (f.OlusturulmaTarihi.Value.Month == DateTime.Now.Month || k.OlusturulmaTarihi.Value.Month == DateTime.Now.Month)
                         select new KaraListeFavoriBuAyDTO()
                         {
                             UrunAdi= ur.urunAdi,
                             TarihFavori=f.OlusturulmaTarihi.Value,
                             TarihKaraliste=k.OlusturulmaTarihi.Value

                         }).ToList();

                return a;
            }
        }

        public List<EtanolFavoriDTO> EtanolFavori()
        {
            List<EtanolFavoriDTO> list = null;
            using (MyDbContext db =new MyDbContext())
            {

                //todo normalizasyon hatası var örnek olarak yapıldı

                var kacKisideEtanolVar = (from u in db.uye
                                          join f in db.favoriler on u.ID equals f.OluşturanKisi
                                          join ur in db.urun on f.UrunID equals ur.ID
                                          where (ur.urunIcerik.Contains("Etanol"))
                                          select new EtanolFavoriDTO()
                                          {
                                              IcerikAdi=ur.urunIcerik,              
                                              Sayi=f.Urunler.Count()
                                             
                                          }).ToList();
                return kacKisideEtanolVar;
            }
        }



        public List<EnFavoriUrunlerDTO> EnfavoriUrunler()
        {
            List<EnFavoriUrunlerDTO> list = null;
            using (MyDbContext db = new MyDbContext())
            {
                var enFavoriUrunler = db.favoriler.GroupBy(x => x.ID).Where(x => x.Count() > 1).Select(s => new EnFavoriUrunlerDTO()
                {
                    UrunAdi=s.FirstOrDefault().ID.ToString(),
                    Sayi= s.Count()
                }).Distinct().OrderByDescending(x => x.Sayi).ToList();

                return enFavoriUrunler;
            }
        }

        public List<EnFavoriUrunlerDTO> EnCokFavoriUrunlerIlk3()
        {
            List<EnFavoriUrunlerDTO> list = null;
            using (MyDbContext db = new MyDbContext())
            {
                var enFavoriUrunler = db.favoriler.GroupBy(x => x.ID).Where(x => x.Count() > 1).Select(s => new EnFavoriUrunlerDTO()
                {
                    UrunAdi = s.FirstOrDefault().ID.ToString(),
                    Sayi = s.Count()
                }).Distinct().Take(3).OrderByDescending(x => x.Sayi).ToList();

                return enFavoriUrunler;
            }
        }









        //public List<EnFavoriUrunlerDTO> enFavoriUrunler()
        //{
        //    List<EnFavoriUrunlerDTO> list = null;
        //    using (MyDbContext db = new MyDbContext())
        //    {
        //        var favoriUrun =(from u in db.urun
        //                         join f in db.favoriler on u.ID equals f.uruns)
        //    }
        //}

        
        
    }
}
