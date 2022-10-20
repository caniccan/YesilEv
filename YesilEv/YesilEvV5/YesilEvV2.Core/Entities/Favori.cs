using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YesilEvV2.Core.Entities
{
    [Table("Favoriler")]
    public class Favori : BaseEntity
    {
        [Key]
        public int ID { get; set; }
        public int? UrunID { get; set; }
        public int? FavoriListeID { get; set; }




        public List<Urun> Urunler { get; set; }
        public FavoriListe FavoriListe { get; set; }
        public Uye Uye { get; set; }
        public Hasta Hasta { get; set; }

        public override string ToString()
        {
            return ID.ToString();
        }
    }
}
