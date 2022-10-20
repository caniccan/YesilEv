using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YesilEvV2.Core.Entities
{
    [Table("Urun")]
    public class Urun : BaseEntity
    {
        [Key]
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



        public ICollection<Duzenleme> Duzenlemeler { get; set; }
        public Favori Favori{ get; set; }
        public ICollection<FavoriListe> FavoriListeler { get; set; }
        public KaraListe KaraListe { get; set; }
        public Kategori Kategori { get; set; }
        public Uretici Uretici { get; set; }
        public ICollection<UrunIcerik> UrunIcerikler { get; set; }
        public ICollection<Yorum> Yorumlar { get; set; }
        public override string ToString()
        {
            return this.urunAdi;
        }


    }
}
