using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YesilEvV2.Core.Entities;
using YesilEvV2.DTOs;

namespace YesilEvV2.Mapping
{
    public class KategoriMapping
    {
        public static Kategori KategoriEkleDTOtoKategori(KategoriEkleDTO kategoriEkleDTO)
        {
            return new Kategori()
            {
                ID=kategoriEkleDTO.ID,
                UstKategoriID=kategoriEkleDTO.UstKategoriID,
                KategoriAdi=kategoriEkleDTO.KategoriAdi,
                AktifMi=kategoriEkleDTO.AktifMi,
                DegistirenKisi=kategoriEkleDTO.DegistirenKisi,
                DegistirilmeTarihi=kategoriEkleDTO.DegistirilmeTarihi,
                OlusturulmaTarihi=kategoriEkleDTO.OlusturulmaTarihi,
                OluşturanKisi=kategoriEkleDTO.OluşturanKisi
            };
        }
    }
}
