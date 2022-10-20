using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YesilEvV2.Core.Entities;
using YesilEvV2.DTOs;

namespace YesilEvV2.Mapping
{
    public class FavoriMapping
    {
        public static Favori FavoriEkleDTOtoFavoriler(FavoriEkleDTO favoriEkleDTO)
        {
            return new Favori()
            {
               ID=favoriEkleDTO.ID,
               FavoriListeID= favoriEkleDTO.FavoriListeID,
               UrunID=favoriEkleDTO.UrunID,
               AktifMi =favoriEkleDTO.AktifMi,
               DegistirenKisi=favoriEkleDTO.DegistirenKisi,
               OluşturanKisi=favoriEkleDTO.OluşturanKisi,
               DegistirilmeTarihi=favoriEkleDTO.DegistirilmeTarihi,
               OlusturulmaTarihi=favoriEkleDTO.OlusturulmaTarihi,
            };
        }
    }
}
