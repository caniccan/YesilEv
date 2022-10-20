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

namespace YesilEvV2.UIWinForm
{
    public partial class Form2 : Form
    {
        private Uye b;

        public Form2()
        {
            InitializeComponent();
        }

        public Form2(Uye b):this()
        {
            this.b = b;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Digerformlar();
            Form3 form3 = new Form3();
            form3.MdiParent = this;
            form3.StartPosition = FormStartPosition.CenterScreen;
            form3.Show();


        }

        private void button6_Click(object sender, EventArgs e)
        {
            Digerformlar();
            Form4 form4 = new Form4(b);
            form4.MdiParent = this;
            form4.StartPosition = FormStartPosition.CenterScreen;
            form4.Show();


        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if (b.RolID==1)
            {
                button20.Visible = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AnaForm();
        }

        private void AnaForm()
        {
            button4.Visible = true;
            button5.Visible = true;
            button6.Visible = true;
            button7.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Digerformlar();
            Form5 form5 = new Form5(b);
            form5.MdiParent = this;
            form5.StartPosition = FormStartPosition.CenterScreen;
            form5.Show();
 
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Digerformlar();
            Form6 form6 = new Form6();
            form6.MdiParent = this;
            form6.StartPosition = FormStartPosition.CenterScreen;
            form6.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            
            Digerformlar();
            Rapor rapor = new Rapor();
            rapor.MdiParent = this;
            rapor.StartPosition = FormStartPosition.CenterScreen;
            rapor.Show();
        }

        private void Digerformlar()
        {
            button4.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
            button7.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Digerformlar();
            ProfileForm form = new ProfileForm(b);
            form.MdiParent = this;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Visible = true;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Visible = false;
        }

        private void button20_Click(object sender, EventArgs e)
        {
            Digerformlar();
            YoneticiForm yoneticiForm = new YoneticiForm(b);
            yoneticiForm.MdiParent = this;
            yoneticiForm.StartPosition = FormStartPosition.CenterScreen;
            yoneticiForm.Show();
        }
    }
    
}
