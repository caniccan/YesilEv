using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YesilEvV2.Core.Entities
{
    [Table("Bildirim")]
    public class Bildirim:BaseEntity
    {
        [Key]
        public int ID { get; set; }
        public int? UyeID { get; set; }
        public string BildirimIcerik { get; set; }


        public Uye Uye { get; set; }
    }
}
