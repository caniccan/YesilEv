using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YesilEvV2.Core.Entities;
using YesilEvV2.DTOs;

namespace YesilEvV2.Mapping
{
    public class UreticiMapping
    {
        public static Uretici UreticiEkleDTOtoUretici(UreticiEkleDTO ureticiEkleDTO)
        {
            return new Uretici()
            {
                ID = ureticiEkleDTO.ID,
                UreticiAdi = ureticiEkleDTO.UreticiAdi,
                UreticiAdres = ureticiEkleDTO.UreticiAdres,
                UreticiMail = ureticiEkleDTO.UreticiMail,
                UreticiTelNo = ureticiEkleDTO.UreticiTelNo,
                AktifMi = ureticiEkleDTO.AktifMi,
                DegistirenKisi = ureticiEkleDTO.DegistirenKisi,
                DegistirilmeTarihi = ureticiEkleDTO.DegistirilmeTarihi,
                OlusturulmaTarihi = ureticiEkleDTO.OlusturulmaTarihi,
                OluşturanKisi = ureticiEkleDTO.OluşturanKisi
            };
        }
    }
}
