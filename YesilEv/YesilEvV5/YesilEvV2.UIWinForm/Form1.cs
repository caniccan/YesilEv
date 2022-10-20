using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YesilEvV2.Core.Context;
using YesilEvV2.Core.Entities;
using YesilEvV2.Core.Repos;
using YesilEvV2.DAL;
using YesilEvV2.DAL.Interfaces;
using YesilEvV2.Mapping;
using YesilEvV2.Validation.Concrete;

namespace YesilEvV2.UIWinForm
{
    public partial class Form1 : Form
    {
        UyeDAL uyeDAL = new UyeDAL();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            groupBox2.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UyeEkleDTO uyeEkleDTO = new UyeEkleDTO()
            {
                ID = 0,
                AdSoyad = textBox3.Text,
                TelNo = textBox4.Text,
                KullaniciAdi = textBox5.Text,
                Sifre = textBox6.Text,
                Mail = textBox7.Text,
                OlusturulmaTarihi = DateTime.Now,
                DegistirilmeTarihi = DateTime.Now,
                AktifMi = null,
                DegistirenKisi = null,
                OluşturanKisi = null,
                RolID = null
            };
            UyeValidate uyeValidate = new UyeValidate(uyeEkleDTO);
            if (uyeValidate.uyeOlIsValid)
            {
                uyeDAL.Add(UyeMapping.UyeEkleDTOtoUye(uyeEkleDTO));
                MessageBox.Show(uyeDAL.MySaveChangesBackTF() ? "Üyelik Başarıyla Oluşturuldu" : "Üyelik Oluşturulurken Bir Hata Meydana Geldi.");
            }
            else
            {
                MessageBox.Show("Boş alan Bırakılmamalıdır...");
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            groupBox2.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UyeValidate uyeValidate = new UyeValidate(textBox1.Text, textBox2.Text);
            if (uyeValidate.girisIsValid)
            {
                var kullanici = uyeDAL.GetBy(x => x.KullaniciAdi == textBox1.Text && x.Sifre == textBox2.Text).FirstOrDefault();
                var girisYap = uyeDAL.UyeGiris(textBox1.Text, textBox2.Text);
                if (girisYap)
                {
                    MessageBox.Show("Giriş Başarılı...");
                    Form2 form2 = new Form2(kullanici);
                    form2.Show();
                    this.Hide();
                }
                else
                {

                    MessageBox.Show("Giriş Yaparken Bir Sorun Oluştu...");
                }
            }
            else
            {
                MessageBox.Show("Boş Alan Bırakılmamalıdır...");
            }
            
        }


    }
}
