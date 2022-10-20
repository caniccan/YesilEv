using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YesilEvV2.Core.Entities
{
    [Table("YorumOnay")]
    public class YorumOnay:BaseEntity
    {
        [Key]
        public int ID { get; set; }
        public int? YorumID { get; set; }
        public int? UyeID { get; set; }
        public bool OnaylandiMi { get; set; }

        public Yorum Yorum { get; set; }
        public Uye Uye { get; set; }
    }
}
