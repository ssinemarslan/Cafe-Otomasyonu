using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace proje2
{
    public partial class Giris : Form
    {
        public Giris()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-9KURH7U\\SQLEXPRESS; Initial Catalog =Cafe;Integrated security=true;");
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand cmd = new SqlCommand("select * from Kullanicilar where KullaniciAdi=@KullaniciAdi and Sifre=@Sifre", baglan);
            cmd.Parameters.AddWithValue("@KullaniciAdi", textBox2.Text);
            cmd.Parameters.AddWithValue("@Sifre", textBox3.Text);

            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                MessageBox.Show("Giriş Başarılı");
                Kategoriler go = new Kategoriler();
                go.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("İşlem başarısız tekrar deneyiniz");
                textBox2.Clear();
                textBox3.Clear();
        }   }
    }
}
