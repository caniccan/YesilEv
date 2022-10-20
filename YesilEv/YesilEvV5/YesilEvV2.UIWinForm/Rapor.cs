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
using YesilEvV2.DAL;
using YesilEvV2.DAL.Concrete;
using YesilEvV2.DTOs.Sorgular;

namespace YesilEvV2.UIWinForm
{
    public partial class Rapor : Form
    {
        UrunDAL urunDAL = new UrunDAL();
        UyeDAL uyeDAL = new UyeDAL();
        RolDAL rolDAL = new RolDAL();
        RaporDAL raporDAL = new RaporDAL();
        FavorilerDAL favorilerDAL = new FavorilerDAL();
        KaralisteDAL karalisteDAL = new KaralisteDAL();
        public Rapor()
        {
            InitializeComponent();
        }

        private void Rapor_Load(object sender, EventArgs e)
        {

            //public List<UrunUrunIcerikAdetDTO> GetAllUrunUrunIcerikAdetRapor()
            //{
            //    List<UrunUrunIcerikAdetDTO> list = null;
            //    using (MyDbContext db = new MyDbContext())
            //    {
            //        list = (from u in db.Urun
            //                join uui in db.UrunUrunIcerik on u.Id equals uui.UrunId
            //                group new { u.Adi, uui } by u.Id into grp
            //                select new UrunUrunIcerikAdetDTO()
            //                {
            //                    UrunAdi = grp.Select(x => x.Adi).FirstOrDefault(),
            //                    IcerikAdet = grp.Count()
            //                }).ToList();
            //    }



                //    return list;
                //}





                //YorumOnayDAL yorumOnayDAL = new YorumOnayDAL();
                //var a = yorumOnayDAL.GetBy(x => x.OnaylandiMi == null && x.OlusturulmaTarihi.Value.Month == DateTime.Now.Month);




                FavorilerDAL favorilerDAL = new FavorilerDAL();
            FavorListeDAL favorListeDAL = new FavorListeDAL();
            //var a = favorilerDAL.GetBy()





        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<KullaniciUrunDTO> kullaniciUrunDTOs = new List<KullaniciUrunDTO>();


            

            using (MyDbContext db = new MyDbContext())
            {
                var sorgu1 = (from u in db.urun
                              join uy in db.uye on u.OluşturanKisi.Value equals uy.ID
                             select new { Olusturan = u.OluşturanKisi.Value, Urun = u.urunAdi }).ToList();

                foreach (var item in sorgu1)
                {
                    kullaniciUrunDTOs.Add(new KullaniciUrunDTO()
                    {
                        KullaniciAdi=uyeDAL.GetByID(item).KullaniciAdi,
                        EklemeSayisi=urunDAL.GetBy(x=>x.OluşturanKisi==item.Olusturan).Count()
                    });
                }
                dataGridView1.DataSource = kullaniciUrunDTOs;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = raporDAL.EtanolFavori();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            //using (MyDbContext db = new MyDbContext())
            //{
            //    var sorgu12 = (from u in db.uye
            //                   join r in db.rol on u.RolID equals r.ID
            //                   select new { r.RolAdi, u.AdSoyad });
            //}
            List<UyelerDTO> uyelerDTOs = new List<UyelerDTO>();
            foreach (var item in rolDAL.GetAll())
            {
                UyelerDTO uyelerDTO = new UyelerDTO()
                {
                    RolAdi = item.RolAdi,
                    RolSayisi = uyeDAL.GetBy(x => x.RolID == item.ID).Count()
                };
                uyelerDTOs.Add(uyelerDTO);
            }
            dataGridView1.DataSource = uyelerDTOs;
            

            
        }

        private void button11_Click(object sender, EventArgs e)
        {
            List<KaraListeFavoriDTO> karaListeFavoriDTOs = new List<KaraListeFavoriDTO>();


            karaListeFavoriDTOs.Add(new KaraListeFavoriDTO()
            {
                FavoriSayısı = favorilerDAL.GetAll().Count(),
                KaralisteSayısı = karalisteDAL.GetAll().Count()
            });

            dataGridView1.DataSource = karaListeFavoriDTOs;        }

        private void button10_Click(object sender, EventArgs e)
        {

            dataGridView1.DataSource = raporDAL.KaraListeFavoriBuAy();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = raporDAL.EnfavoriUrunler();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = raporDAL.EnCokFavoriUrunlerIlk3();
        }
    }
}
