using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YesilEvV2.Core.Entities
{
    [Table("RolYetki")]
    public class RolYetki : BaseEntity
    {
        [Key]
        public int ID { get; set; }
        public string Yetki { get; set; }

        public ICollection<Rol> Rol { get; set; }


    }
}
