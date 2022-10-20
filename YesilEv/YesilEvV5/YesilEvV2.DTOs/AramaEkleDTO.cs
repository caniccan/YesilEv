using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YesilEvV2.Core.Entities;

namespace YesilEvV2.DTOs
{
    public class AramaEkleDTO : BaseEntity
    {
        public int ID { get; set; }
        public string AramaIcerik { get; set; }
        
    }
}
