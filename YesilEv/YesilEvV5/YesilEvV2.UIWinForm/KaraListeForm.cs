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

namespace YesilEvV2.UIWinForm
{
    public partial class Karaliste : Form
    {
        KaralisteDAL karalisteDAL = new KaralisteDAL();
        UrunDAL urunDAL = new UrunDAL();
        private Uye b;

        public Karaliste()
        {
            InitializeComponent();
        }

        public Karaliste(Uye b):this()
        {
            this.b = b;
        }

        private void Karaliste_Load(object sender, EventArgs e)
        {
            using (MyDbContext db = new MyDbContext())
            {
                var karaListedekiUrunAdlari = (from k in db.karaListe
                                            join u in db.urun on k.UrunID equals u.ID
                                            select u.urunAdi).ToArray();

                listBox1.Items.AddRange(karaListedekiUrunAdlari);

            }
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
             if (b.RolID==1)
            {
                karalisteDAL.Delete(karalisteDAL.GetBy(x => x.UrunID == urunDAL.GetBy(y => y.urunAdi == listBox1.SelectedItem.ToString()).FirstOrDefault().ID).FirstOrDefault());
                MessageBox.Show(karalisteDAL.MySaveChangesBackTF() ? "Kara Listeden Ürün Başarıyla Silindi" : "Kara Listeden Ürün Silinirken Bir Hata Meydana Geldi.");
                listBox1.Items.Clear();
                var karaListedekiUrunler = karalisteDAL.GetAll().ToArray();
                listBox1.Items.AddRange(karaListedekiUrunler);
            }
            else
            {
                MessageBox.Show("Yetersiz Yetki...");
            }
        }
    }
}
