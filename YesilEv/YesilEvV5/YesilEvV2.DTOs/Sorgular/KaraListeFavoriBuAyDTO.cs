using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YesilEvV2.Core.Entities;

namespace YesilEvV2.DTOs.Sorgular
{
    public class KaraListeFavoriBuAyDTO
    {
        public string UrunAdi { get; set; }

        public DateTime TarihFavori { get; set; }
        public DateTime TarihKaraliste { get; set; }
    }
}
