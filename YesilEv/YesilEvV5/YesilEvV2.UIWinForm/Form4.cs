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
using YesilEvV2.Log;
using YesilEvV2.Mapping;
using YesilEvV2.Validation.Concrete;

namespace YesilEvV2.UIWinForm
{
    public partial class Form4 : Form
    {
        UrunDAL urunDAL = new UrunDAL();
        UreticiDAL ureticiDAL = new UreticiDAL();
        KategoriDAL kategoriDAL = new KategoriDAL();
        private string gidenVeri;
        private Uye b;
        public Urun duzenlenenUrun;
        string onYuz, arkaYuz;

        public Form4()
        {
            InitializeComponent();
        }

        public Form4(string gidenVeri):this()
        {
            
            this.gidenVeri = gidenVeri;
        }

        public Form4(Uye b):this()
        {
            this.b = b;
        }

        private void Form4_Load(object sender, EventArgs e)
        {

            using (MyDbContext db = new MyDbContext())
            {
                var urun = (from u in db.urun
                            join k in db.kategori on u.kategoriID equals k.ID
                            join ur in db.uretici on u.UreticiID equals ur.ID
                            where (u.BarkodNo==gidenVeri)
                            select new
                            {
                                barkodNo=u.BarkodNo,
                                kategoriAdi=k.KategoriAdi,
                                ureticiAdi=ur.UreticiAdi,
                                urunAdi=u.urunAdi,
                                urunIcerik=u.urunIcerik,
                                urunOnYuz=u.OnYuz,
                                urunArkaYuz=u.ArkaYuz
                            }).FirstOrDefault();

                if (urun!=null)
                {
                    textBox2.Text = urun.barkodNo;
                    comboBox1.Text = urun.ureticiAdi;
                    comboBox2.Text = urun.kategoriAdi;
                    textBox3.Text = urun.urunAdi;
                    textBox4.Text = urun.urunIcerik;
                    onYuz = urun.urunOnYuz;
                    arkaYuz = urun.urunArkaYuz;
                    try
                    {
                        ResimEkle(pictureBox1, onYuz);
                        ResimEkle(pictureBox2, arkaYuz);
                    }
                    catch (Exception)
                    {

                        MessageBox.Show("Resim eklenirken bir hata oluştu...");
                    }
                }
                else
                {
                    textBox2.Text = gidenVeri;
                }
            }
            var aktifUrunler= urunDAL.GetBy(x => x.AktifMi == true).ToArray();
            listBox1.Items.AddRange(aktifUrunler);
            var kategoriler = kategoriDAL.GetAll().OrderBy(x=>x.KategoriAdi).Distinct().ToArray();
            comboBox2.Items.AddRange(kategoriler);
            var ureticiler = ureticiDAL.GetAll().OrderBy(x=>x.UreticiAdi).Distinct().ToArray();
            comboBox1.Items.AddRange(ureticiler);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            UrunEkleDTO urunEkleDTO = new UrunEkleDTO()
            {
                ID = 0,
                BarkodNo = textBox2.Text,
                UreticiID = ureticiDAL.GetBy(x => x.UreticiAdi == comboBox1.Text.ToString()).FirstOrDefault().ID,
                kategoriID = kategoriDAL.GetBy(x => x.KategoriAdi == comboBox2.Text.ToString()).FirstOrDefault().ID,
                urunAdi = textBox3.Text,
                urunIcerik = textBox4.Text,
                OnYuz = onYuz,
                ArkaYuz = arkaYuz,
                AktifMi = false,
                DegistirenKisi = b.ID,
                OluşturanKisi = b.ID,
                DegistirilmeTarihi = DateTime.Now,
                OlusturulmaTarihi = DateTime.Now,
                DuzenlendiMi = false,
                TakipNo = textBox2.Text.Reverse().ToString(),
            };

            UrunValidate urunValidate = new UrunValidate(urunEkleDTO);
            if (urunValidate.isValid)
            {
                if (checkBox2.Checked==false)
                {
                    urunDAL.Add(UrunMapping.UrunEkleDTOtoUrun(urunEkleDTO));
                    MessageBox.Show(urunDAL.MySaveChangesBackTF() ? "Ürün Başarıyla Oluşturuldu ve onay aşamasına gönderildi..." : "Ürün Oluşturulurken Bir Hata Meydana Geldi.");
                    MyLogger.GetInstance().Info($"{urunEkleDTO.BarkodNo} lu ürün eklendi...");
                }
                else
                {
                    using (MyDbContext db = new MyDbContext())
                    {
                        duzenlenenUrun.BarkodNo = urunEkleDTO.BarkodNo;
                        duzenlenenUrun.UreticiID = urunEkleDTO.UreticiID;
                        duzenlenenUrun.kategoriID = urunEkleDTO.kategoriID;
                        duzenlenenUrun.urunAdi = urunEkleDTO.urunAdi;
                        duzenlenenUrun.urunIcerik = urunEkleDTO.urunIcerik;
                        duzenlenenUrun.OnYuz = urunEkleDTO.OnYuz;
                        duzenlenenUrun.ArkaYuz = urunEkleDTO.ArkaYuz;
                        duzenlenenUrun.DegistirenKisi = urunEkleDTO.DegistirenKisi;
                        duzenlenenUrun.OluşturanKisi = urunEkleDTO.OluşturanKisi;
                        duzenlenenUrun.DegistirilmeTarihi = urunEkleDTO.DegistirilmeTarihi;
                        duzenlenenUrun.DuzenlendiMi = true;
                        duzenlenenUrun.TakipNo = urunEkleDTO.TakipNo;
                        MessageBox.Show(urunDAL.MySaveChangesBackTF() ? "Ürün Başarıyla Güncellendi..." : "Ürün Güncellenirken Bir Hata Meydana Geldi.");
                        MyLogger.GetInstance().Info($"{urunEkleDTO.BarkodNo} lu ürün Güncellendi...");
                    } 
                }
            }
            else
            {
                MessageBox.Show("Boş Alan Bırakılmamalıdır...");
            }
            listBoxYenile();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Duzenle();
            duzenlenenUrun = urunDAL.GetBy(x => x.urunAdi == listBox1.SelectedItem.ToString()).FirstOrDefault();
        }
        private void Duzenle()
        {
            pictureBox1.Image = null;
            pictureBox2.Image = null;
            var listBoxSecilenItem = urunDAL.GetBy(x => x.urunAdi == listBox1.SelectedItem.ToString()).FirstOrDefault();
            textBox2.Text = listBoxSecilenItem.BarkodNo;
            textBox3.Text = listBoxSecilenItem.urunAdi;
            comboBox1.Text = ureticiDAL.GetByID(listBoxSecilenItem.UreticiID).UreticiAdi;
            comboBox2.Text = kategoriDAL.GetByID(listBoxSecilenItem.kategoriID).KategoriAdi;
            textBox4.Text = listBoxSecilenItem.urunIcerik;
            onYuz = listBoxSecilenItem.OnYuz;
            arkaYuz = listBoxSecilenItem.ArkaYuz;
            try
            {
                ResimEkle(pictureBox1,onYuz);
                ResimEkle(pictureBox2,arkaYuz);
            }
            catch (Exception)
            {

                MessageBox.Show("Resim eklenirken bir hata oluştu...");
            }



        }

        private void ResimEkle(PictureBox pictureBox,string path)
        {
            pictureBox.Image = Image.FromFile(path);
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {  
                textBox1.Enabled = true;
            }
            else
            {
                textBox1.Enabled = false;
            }
        }

        private void düzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Duzenle();
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (b.RolID==1)
            {
                if (listBox1.SelectedItem!=null)
                {
                    var silinecekUrun = urunDAL.GetBy(x => x.urunAdi == listBox1.SelectedItem.ToString()).FirstOrDefault();
                    urunDAL.Delete(silinecekUrun);
                    MessageBox.Show(urunDAL.MySaveChangesBackTF() ? "Ürün Başarıyla Silindi" : "Ürün Silinirken Bir Hata Meydana Geldi.");
                    MyLogger.GetInstance().Info($"{silinecekUrun.BarkodNo} lu ürün Silindi...");
                    listBoxYenile();
                }
                else
                {
                    MessageBox.Show("Ürün seçilmeden bu işlem yapılamaz...");
                }
                
            }
            else
            {
                MessageBox.Show("Yetersiz Yetki...");
            }
        }

        private void listBoxYenile()
        {
            listBox1.Items.Clear();
            var aktifUrunler = urunDAL.GetBy(x => x.AktifMi == true).ToArray();
            listBox1.Items.AddRange(aktifUrunler);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                button5.Enabled = true;
            }
            else
            {
                button5.Enabled = false;
            }
            
        }

        private void açToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem!=null)
            {
                var secilenUrun = urunDAL.GetBy(x => x.urunAdi == listBox1.SelectedItem.ToString()).FirstOrDefault();
                UrunBilgiForm form = new UrunBilgiForm(secilenUrun);
                form.StartPosition = FormStartPosition.CenterScreen;
                form.Show();
            }
            else
            {
                MessageBox.Show("Listeden bir ürün seçiniz...");
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            onYuz = ResimSec();
            ResimEkle(pictureBox1, onYuz);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            arkaYuz= ResimSec();
            ResimEkle(pictureBox2, arkaYuz);
        }

        private string ResimSec()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string dosyaYolu = openFileDialog.FileName;
                return dosyaYolu;
            }
            else
            {
                return "";
            }
        }
    }
}
