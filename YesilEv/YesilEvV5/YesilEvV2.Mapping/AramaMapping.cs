using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YesilEvV2.Core.Entities;
using YesilEvV2.DTOs;

namespace YesilEvV2.Mapping
{
    public class AramaMapping
    {
        public static Arama AramaEkleDTOtoArama(AramaEkleDTO aramaEkleDTO)
        {
            return new Arama()
            {
                ID= aramaEkleDTO.ID,
                AramaIcerik= aramaEkleDTO.AramaIcerik,
                AktifMi= aramaEkleDTO.AktifMi,
                DegistirenKisi= aramaEkleDTO.DegistirenKisi,
                DegistirilmeTarihi= aramaEkleDTO.DegistirilmeTarihi,
                OlusturulmaTarihi= aramaEkleDTO.OlusturulmaTarihi,
                OluşturanKisi= aramaEkleDTO.OluşturanKisi,
            };
        }
    }
}
