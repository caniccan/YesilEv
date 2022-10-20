using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YesilEvV2.Core.Entities;

namespace YesilEvV2.DTOs
{
    public class KaralisteEkleDTO : BaseEntity
    {
        public int ID { get; set; }
        public int? UrunID { get; set; }
        public string EklemeSebebi { get; set; }

    }
}
