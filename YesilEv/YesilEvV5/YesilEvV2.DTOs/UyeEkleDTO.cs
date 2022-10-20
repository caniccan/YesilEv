using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YesilEvV2.Core.Entities;

namespace YesilEvV2.DAL
{
    public class UyeEkleDTO : BaseEntity
    {
        public int ID { get; set; }
        public int? RolID { get; set; }
        public string AdSoyad { get; set; }
        public string TelNo { get; set; }
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
        public string Mail { get; set; }
    }
}
