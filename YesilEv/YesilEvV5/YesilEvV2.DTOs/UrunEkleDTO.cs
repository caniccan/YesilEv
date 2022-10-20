using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YesilEvV2.Core.Entities;

namespace YesilEvV2.DAL
{
    public class UrunEkleDTO : BaseEntity
    {
        public int ID { get; set; }
        public string BarkodNo { get; set; }
        public int? UreticiID { get; set; }
        public int? kategoriID { get; set; }
        public string urunAdi { get; set; }
        public string urunIcerik { get; set; }
        public string OnYuz { get; set; }
        public string ArkaYuz { get; set; }
        public string TakipNo { get; set; }
        public bool? DuzenlendiMi { get; set; }
    }
}
