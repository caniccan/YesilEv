using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YesilEvV2.Core.Context;
using YesilEvV2.Core.Entities;
using YesilEvV2.DAL;
using YesilEvV2.DAL.Concrete;
using YesilEvV2.DTOs;
using YesilEvV2.Mapping;

namespace YesilEvV2.UIWinForm
{
    public partial class Form5 : Form
    {
        AramaGecmisiDAL aramaGecmisiDAL = new AramaGecmisiDAL();
        FavorListeDAL favorListeDAL = new FavorListeDAL();
        UrunDAL urunDAL = new UrunDAL();
        FavorilerDAL favorilerDAL = new FavorilerDAL();
        KaralisteDAL karalisteDAL = new KaralisteDAL();
        private Uye b;

        public Form5()
        {
            InitializeComponent();
        }

        public Form5(Uye b):this()
        {
            this.b = b;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            AramaEkleDTO aramaEkleDTO = new AramaEkleDTO()
            {
                ID=0,
                AramaIcerik=textBox1.Text,
                AktifMi=true,
                DegistirenKisi=b.ID,
                DegistirilmeTarihi=DateTime.Now,
                OlusturulmaTarihi=DateTime.Now,
                OluşturanKisi=b.ID
            };
            listBox1.Items.Clear();
            if (textBox1.Text!=string.Empty)
            {               
                var urunArama = urunDAL.GetBy(x => x.urunAdi.Contains(textBox1.Text) && x.AktifMi == true).ToArray();
                listBox1.Items.AddRange(urunArama);
                aramaGecmisiDAL.Add(AramaMapping.AramaEkleDTOtoArama(aramaEkleDTO));
                MessageBox.Show(aramaGecmisiDAL.MySaveChangesBackTF() ? "Arama sonuçları listelenmiştir..." : "Arama Yapılamadı...");
            }
            else
            {
                MessageBox.Show("Arama metni giriniz...");
            }           
        }

        private void favoriEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FavoriEkleDTO favoriEkleDTO = new FavoriEkleDTO()
            {
                ID = 0,
                UrunID = urunDAL.GetBy(x => x.urunAdi == listBox1.SelectedItem.ToString()).FirstOrDefault().ID,
                FavoriListeID = favorListeDAL.GetBy(x => x.FavoriListeAdi == comboBox1.SelectedItem.ToString()).FirstOrDefault().ID,
                HastaID = 0,
                AktifMi = true,
                DegistirenKisi = b.ID,
                OluşturanKisi = b.ID,
                DegistirilmeTarihi = DateTime.Now,
                OlusturulmaTarihi = DateTime.Now
            };

            if (listBox1.SelectedItem!=null && comboBox1.SelectedItem!=null)
            {
                favorilerDAL.Add(FavoriMapping.FavoriEkleDTOtoFavoriler(favoriEkleDTO));
                MessageBox.Show(favorilerDAL.MySaveChangesBackTF() ? "Ürün Başarıyla Favori Listesine Eklendi..." : "Ürün Favori Listesine Eklenirken Bir Hata Meydana Geldi...");
            }
            else
            {
                MessageBox.Show("Favoriye eklenecek ürünü ve Favori Listesini Seçiniz...");
            }
            
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            var favoriListeler = favorListeDAL.GetAll().ToArray();
            comboBox1.Items.AddRange(favoriListeler);
        }


        private void karalisteEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KaralisteEkleDTO karalisteEkleDTO = new KaralisteEkleDTO()
            {
                ID = 0,
                UrunID = urunDAL.GetBy(x => x.urunAdi == listBox1.SelectedItem.ToString()).FirstOrDefault().ID,
                EklemeSebebi = null,
                AktifMi = true,
                DegistirenKisi = b.ID,
                OluşturanKisi = b.ID,
                OlusturulmaTarihi = DateTime.Now,
                DegistirilmeTarihi = DateTime.Now
            };

            if (listBox1.SelectedItem != null)
            {
                karalisteDAL.Add(KaralisteMapping.KaraListeEkleDTOtoKaraliste(karalisteEkleDTO));
                MessageBox.Show(karalisteDAL.MySaveChangesBackTF() ? "Ürün Başarıyla Karalisteye Eklendi..." : "Ürün Kara Listeye Eklenirken Bir Hata Meydana Geldi...");
            }
           
        }
    }
}
