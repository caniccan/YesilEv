using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YesilEvV2.Core.Entities;

namespace YesilEvV2.DTOs
{
    public class UreticiEkleDTO : BaseEntity
    {
        public int ID { get; set; }
        public string UreticiAdi { get; set; }
        public string UreticiAdres { get; set; }
        public string UreticiTelNo { get; set; }
        public string UreticiMail { get; set; }
    }
}
