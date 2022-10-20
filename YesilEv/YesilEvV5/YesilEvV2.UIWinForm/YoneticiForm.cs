using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YesilEvV2.Core.Entities;
using YesilEvV2.DAL;
using YesilEvV2.DAL.Concrete;
using YesilEvV2.DTOs;
using YesilEvV2.Mapping;

namespace YesilEvV2.UIWinForm
{
    public partial class YoneticiForm : Form
    {
        UrunDAL urunDAL = new UrunDAL();
        KategoriDAL kategoriDAL = new KategoriDAL();
        UreticiDAL ureticiDAL = new UreticiDAL();
        private Uye b;

        public YoneticiForm()
        {
            InitializeComponent();
        }

        public YoneticiForm(Uye b):this()
        {
            this.b = b;
        }

        private void YoneticiForm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = urunDAL.GetBy(x=>x.AktifMi!=true);
            groupBox1.Visible = true;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(urunDAL.MySaveChangesBackTF() ? "Değişiklikler onaylanmıştır..." : "Bir hata meydana geldi.");

        }

        private void urunOnaylaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            groupBox2.Visible = false;
            groupBox3.Visible = false;

        }

        private void kategoriEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            groupBox1.Visible = false;
            groupBox3.Visible=false;
            groupBox2.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text!=null)
            {
                KategoriEkleDTO kategoriEkleDTO = new KategoriEkleDTO()
                {
                    ID = 0,
                    KategoriAdi = textBox1.Text,
                    AktifMi = true,
                    DegistirenKisi = b.ID,
                    DegistirilmeTarihi = DateTime.Now,
                    OlusturulmaTarihi = DateTime.Now,
                    OluşturanKisi = b.ID,
                    UstKategoriID = 0
                };

                kategoriDAL.Add(KategoriMapping.KategoriEkleDTOtoKategori(kategoriEkleDTO));
                MessageBox.Show(kategoriDAL.MySaveChangesBackTF() ? "Kategori Başarıyla oluşturuldu..." : "Kategori oluşturulurken bir hata meydana geldi...");


            }
            else
            {
                MessageBox.Show("Kategori eklerken bir hata oluştu...");
            }
            




        }

        private void ureticiEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox2.Text))
            {
                UreticiEkleDTO ureticiEkleDTO = new UreticiEkleDTO()
                {
                    ID = 0,
                    UreticiAdi = textBox2.Text,
                    UreticiAdres = textBox3.Text,
                    UreticiMail = textBox5.Text,
                    UreticiTelNo = textBox4.Text,
                    AktifMi = true,
                    DegistirenKisi = b.ID,
                    OluşturanKisi = b.ID,
                    DegistirilmeTarihi = DateTime.Now,
                    OlusturulmaTarihi = DateTime.Now
                };

                ureticiDAL.Add(UreticiMapping.UreticiEkleDTOtoUretici(ureticiEkleDTO));
                MessageBox.Show(ureticiDAL.MySaveChangesBackTF() ? "Uretici Başarıyla oluşturuldu..." : "Uretici oluşturulurken bir hata meydana geldi...");

            }
            else
            {
                MessageBox.Show("Uretici Adı boş bırakılamaz...");
            }
        }
    }
}
