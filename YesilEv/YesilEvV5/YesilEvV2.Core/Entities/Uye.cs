using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YesilEvV2.Core.Entities
{
    [Table("Uye")]
    public class Uye : BaseEntity
    {
        [Key]
        public int ID { get; set; }
        public int? RolID { get; set; }
        public string AdSoyad { get; set; }
        public string TelNo { get; set; }
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
        public string Mail { get; set; }
        
        public ICollection<Yorum> Yorum { get; set; }
        
        
        
        public ICollection<Arama> Aramalar { get; set; }
        public ICollection<Bildirim> Bildirimler { get; set; }
        public ICollection<Duzenleme> Duzenlemeler { get; set; }
        public ICollection<Favori> Favoriler { get; set; }
        public ICollection<KaraListe> KaraListeler { get; set; }
        public ICollection<Rol> Roller { get; set; }
        public ICollection<YorumOnay> YorumOnaylar { get; set; }



    }
}
