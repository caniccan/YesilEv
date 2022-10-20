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
    public partial class ProfileForm : Form
    {
        UrunDAL urunDAL = new UrunDAL();
        AramaGecmisiDAL aramaGecmisiDAL = new AramaGecmisiDAL();
        private Uye b;
        public ProfileForm()
        {
            InitializeComponent();
        }

        public ProfileForm(Uye b):this()
        {
            this.b = b;
        }

        private void ProfileForm_Load(object sender, EventArgs e)
        {
            label1.Text = b.AdSoyad;
            label3.Text = b.OlusturulmaTarihi.Value.ToShortDateString();
            label6.Text = urunDAL.GetBy(x => x.OluşturanKisi == b.ID).Count().ToString();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UyeBilgisiDegistir form = new UyeBilgisiDegistir(b);
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();
            form6.StartPosition = FormStartPosition.CenterScreen;
            form6.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Karaliste karaliste = new Karaliste(b);
            karaliste.StartPosition = FormStartPosition.CenterScreen;
            karaliste.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Tüm Arama Geçmişini silmek istediğinden emin misin?", "Tüm Veriler Silinecek", MessageBoxButtons.YesNo)==DialogResult.Yes)
            {
                var silinecekAramalar = aramaGecmisiDAL.GetAll().ToList();
                aramaGecmisiDAL.DeleteRange(silinecekAramalar);
                MessageBox.Show(aramaGecmisiDAL.MySaveChangesBackTF() ? "Arama Geçmişi Başarıyla Silindi..." : "Arama Geçmişi Silinirken Bir hata Meydana Geldi...");
            }
        }
    }
}
