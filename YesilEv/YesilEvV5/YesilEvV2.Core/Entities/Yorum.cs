using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YesilEvV2.Core.Entities
{
    [Table("Yorum")]
    public class Yorum:BaseEntity
    {
        [Key]
        public int ID { get; set; }

        public int? UyeID { get; set; }

        public int? UrunID { get; set; }
        public string YorumIcerik { get; set; }


        public ICollection<Puan> Puanlar { get; set; }
        public Uye Uye { get; set; }
        public Urun Urun { get; set; }
    }
}
