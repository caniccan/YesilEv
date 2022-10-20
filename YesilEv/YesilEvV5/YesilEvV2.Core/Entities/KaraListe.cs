using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YesilEvV2.Core.Entities
{
    [Table("KaraListe")]
    public class KaraListe : BaseEntity
    {
        [Key]
        public int ID { get; set; }
        
        public int? UrunID { get; set; }
        public string EklemeSebebi { get; set; }


        public ICollection<Urun> Urunler { get; set; }
        public Hasta Hasta { get; set; }
        public Uye Uye { get; set; }


    }
}
