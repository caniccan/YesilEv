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

namespace YesilEvV2.UIWinForm
{
    public partial class Form6 : Form
    {
        FavorListeDAL favorListeDAL = new FavorListeDAL();
        AramaGecmisiDAL aramaGecmisiDAL = new AramaGecmisiDAL();
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            listBox3.Items.AddRange(aramaGecmisiDAL.GetAll().ToArray());
            comboBox1.Items.AddRange(favorListeDAL.GetAll().ToArray());

            using (MyDbContext db = new MyDbContext())
            {
                var favoriUrunler = (from f in db.favoriler
                             join u in db.urun on f.UrunID equals u.ID
                             select (u.urunAdi)).ToArray();

                listBox2.Items.AddRange(favoriUrunler);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox2.Items.Clear();

            using (MyDbContext db = new MyDbContext())
            {
                var favoriListeIDsi = favorListeDAL.GetBy(x => x.FavoriListeAdi == comboBox1.SelectedItem.ToString()).FirstOrDefault().ID;
                var listedekiUrunler = (from fl in db.favoriListe
                                        join f in db.favoriler on fl.ID equals f.FavoriListeID
                                        join u in db.urun on f.UrunID equals u.ID
                                        where f.FavoriListeID==favoriListeIDsi
                                        select u.urunAdi ).ToArray();

                listBox2.Items.AddRange(listedekiUrunler);
            }
        }
    }
}
