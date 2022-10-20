using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YesilEvV2.Core.Entities;
using YesilEvV2.DTOs;

namespace YesilEvV2.Mapping
{
    public class UrunIcerikMapping
    {
        public static UrunIcerik UrunIcerikEkleDTOtoUrunIcerik(UrunIcerikEkleDTO urunIcerikEkleDTO)
        {
            return new UrunIcerik()
            {
                ID=urunIcerikEkleDTO.ID,
                MaddeAdi=urunIcerikEkleDTO.MaddeAdi,
                UrunID=urunIcerikEkleDTO.UrunID,
                MaddeYuzde=urunIcerikEkleDTO.MaddeYuzde,
                TehlikeliMi=urunIcerikEkleDTO.TehlikeliMi,
                AktifMi = urunIcerikEkleDTO.AktifMi,
                DegistirenKisi = urunIcerikEkleDTO.DegistirenKisi,
                OluşturanKisi = urunIcerikEkleDTO.OluşturanKisi,
                DegistirilmeTarihi = urunIcerikEkleDTO.DegistirilmeTarihi,
                OlusturulmaTarihi = urunIcerikEkleDTO.OlusturulmaTarihi,
            };
        }
    }
}
