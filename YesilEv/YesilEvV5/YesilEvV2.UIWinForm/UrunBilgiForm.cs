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

namespace YesilEvV2.UIWinForm
{
    public partial class UrunBilgiForm : Form
    {
        private Urun secilenUrun;

        public UrunBilgiForm()
        {
            InitializeComponent();
        }

        public UrunBilgiForm(Urun secilenUrun):this()
        {
            this.secilenUrun = secilenUrun;
        }

        private void UrunBilgiForm_Load(object sender, EventArgs e)
        {
            using (MyDbContext db = new MyDbContext())
            {
                var urunDetay = (from u in db.urun
                                 join ur in db.uretici on u.UreticiID equals ur.ID
                                 join k in db.kategori on u.kategoriID equals k.ID
                                 where u.BarkodNo == secilenUrun.BarkodNo
                                 select new
                                 {
                                     kategori = k.KategoriAdi,
                                     uretici = ur.UreticiAdi,
                                     urunAdi = u.urunAdi,
                                 }).FirstOrDefault(); ;

                label1.Text = urunDetay.kategori;
                label2.Text = urunDetay.uretici;
                label3.Text = urunDetay.urunAdi;
                try
                {
                    pictureBox1.Image = Image.FromFile(secilenUrun.OnYuz);
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                catch (Exception)
                {

                    MessageBox.Show("Resim yüklenirken bir hata oluştu...");
                }
                

            }
            string[] urunIcerik = secilenUrun.urunIcerik.Split(',');
            comboBox1.Items.AddRange(urunIcerik);
        }
    }
}
