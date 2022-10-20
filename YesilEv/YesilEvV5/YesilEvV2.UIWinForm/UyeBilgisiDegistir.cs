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
using YesilEvV2.Mapping;

namespace YesilEvV2.UIWinForm
{
    public partial class UyeBilgisiDegistir : Form
    {
        private Uye b;
        UyeDAL uyeDAL=new UyeDAL();
        public UyeBilgisiDegistir()
        {
            InitializeComponent();
        }

        public UyeBilgisiDegistir(Uye b):this()
        {
            this.b = b;
        }

        private void UyeBilgisiDegistir_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = uyeDAL.GetBy(x => x.ID == b.ID);

            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[8].Visible = false;
            dataGridView1.Columns[9].Visible = false;
            dataGridView1.Columns[10].Visible = false;
            dataGridView1.Columns[11].Visible = false;
            dataGridView1.Columns[12].Visible = false;
            dataGridView1.Columns[13].Visible = false;
            dataGridView1.Columns[14].Visible = false;
            dataGridView1.Columns[15].Visible = false;
            dataGridView1.Columns[16].Visible = false;
            dataGridView1.Columns[17].Visible = false;
            dataGridView1.Columns[18].Visible = false;
            dataGridView1.Columns[19].Visible = false;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            uyeDAL.MySaveChanges();
            MessageBox.Show("Değişiklikler Kaydedilmiştir...");
        }
    }
}
