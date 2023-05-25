using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proje2
{
    public partial class Kategoriler : Form
    {
        public Kategoriler()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           Musteriler m1=new Musteriler();
            m1.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Urunler u1 = new Urunler();
            u1.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Saticilar s1 = new Saticilar();
            s1.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Siparisler s2 = new Siparisler();
            s2.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Raporlar r1 = new Raporlar();
            r1.Show();
            this.Hide();
        }

        private void Kategoriler_Load(object sender, EventArgs e)
        {

        }
    }
}
