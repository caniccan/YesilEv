using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YesilEvV2.Core.Entities;
using YesilEvV2.DTOs;

namespace YesilEvV2.Mapping
{
    public class KaralisteMapping
    {
        public static KaraListe KaraListeEkleDTOtoKaraliste(KaralisteEkleDTO karaListeEkleDTO)
        {
            return new KaraListe()
            {
                ID = karaListeEkleDTO.ID,
                UrunID= karaListeEkleDTO.UrunID,
                EklemeSebebi= karaListeEkleDTO.EklemeSebebi,
                AktifMi = karaListeEkleDTO.AktifMi,
                DegistirenKisi = karaListeEkleDTO.DegistirenKisi,
                OluşturanKisi = karaListeEkleDTO.OluşturanKisi,
                DegistirilmeTarihi = karaListeEkleDTO.DegistirilmeTarihi,
                OlusturulmaTarihi = karaListeEkleDTO.OlusturulmaTarihi,
            };
        }
    }
}
