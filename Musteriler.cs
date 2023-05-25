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
    public partial class Musteriler : Form
    {
        public Musteriler()
        {
            InitializeComponent();
        }
        SqlConnection baglan=new SqlConnection("Data Source=DESKTOP-9KURH7U\\SQLEXPRESS; Initial Catalog=Cafe; Integrated security=true;");
        //SqlConnection veritabanı = new SqlConnection("data source=LAPTOP-7TGINDST\\SQLEXPRESS; Initial Catalog=Hastane; Integrated security=true;");
        private void Musteriler_Load(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("select * from Musteriler", baglan);
            SqlDataReader dr = komut.ExecuteReader();
            
            baglan.Close();

        }
        public void Listele(string komutkod)
        {
            SqlDataAdapter dr = new SqlDataAdapter(komutkod,baglan);
            DataTable doldur = new DataTable();
            dr.Fill(doldur);
            dataGridView1.DataSource = doldur;
        }
        //listeleme butonu
        private void button1_Click(object sender, EventArgs e)
        {
            Listele("select *from Musteriler");

        }
        //musteri ekle butonu
        private void button2_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("insert into Musteriler(MusteriAdSoyad,MusteriTelefon,MusteriAdres)values(@MusteriAdSoyad,@MusteriTelefon,@MusteriAdres)", baglan);
            komut.Parameters.AddWithValue("@MusteriAdSoyad", textBox2.Text);
            komut.Parameters.AddWithValue("@MusteriTelefon", maskedTextBox1.Text);
            komut.Parameters.AddWithValue("@MusteriAdres", textBox1.Text);
            komut.ExecuteNonQuery();
            baglan.Close();
            Listele("select * from Musteriler");
            //baglan.Open();
            //SqlCommand komut = new SqlCommand("insert into Kitaplar(KitapAdi,YazarAdi,SayfaSayisi,Konu,Fiyat,YayineviNo)values(@KitapAdi, @YazarAdi, @SayfaSayisi,@Konu, @Fiyat, @YayineviNo)", baglan);
            //komut.Parameters.AddWithValue("@KitapAdi", textBox1.Text);
            //komut.Parameters.AddWithValue("@YazarAdi", textBox2.Text);
            // komut.Parameters.AddWithValue("@SayfaSayisi", textBox3.Text);
            //komut.Parameters.AddWithValue("@Konu", textBox4.Text);
            //komut.Parameters.AddWithValue("@Fiyat", textBox5.Text);
            //komut.Parameters.AddWithValue("@YayineviNo", comboBox1.Text);
            //komut.ExecuteNonQuery();
            //baglan.Close();
            //Listele("select*from Kitaplar");

        }
        //yenile butonu
        private void button4_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("update Musteriler set MusteriAdSoyad='" + textBox2.Text.ToString() + "',MusteriTelefon='" + maskedTextBox1.Text.ToString() + "',MusteriAdres='" + textBox1.Text.ToString() + "'where MusteriNo='" + textBox2.Tag + "'", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            Listele("select* from Musteriler");

        }
        //Musteriler sil butonu
        private void button3_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand cmd = new SqlCommand("Delete from Musteriler where MusteriNo=@MusteriNo", baglan);
            cmd.Parameters.AddWithValue("@MusteriNo", textBox2.Tag);
            cmd.ExecuteNonQuery();
            baglan.Close();
            Listele("select*from Musteriler");
        }
        //ara butonu
        private void button5_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand cmd = new SqlCommand("select*from Musteriler where MusteriAdSoyad like '%" + textBox2.Text + "%'", baglan);
            SqlDataAdapter dr = new SqlDataAdapter(cmd);
            DataTable doldur = new DataTable();
            dr.Fill(doldur);
            dataGridView1.DataSource = doldur;
            baglan.Close();
            //baglan.Open();
            //SqlCommand cmd = new SqlCommand("select *from Kitaplar where KitapAdi like '%" + textBox1.Text + "%'", baglan);
            //SqlDataAdapter dr = new SqlDataAdapter(cmd);
            //DataTable doldur = new DataTable();
            //dr.Fill(doldur);
            //dataGridView1.DataSource = doldur;
            //baglan.Close();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;
            textBox2.Tag = satir.Cells["MusteriNo"].Value.ToString();
            textBox2.Text = satir.Cells["MusteriAdSoyad"].Value.ToString();
            maskedTextBox1.Text = satir.Cells["MusteriTelefon"].Value.ToString();
            textBox1.Text = satir.Cells["MusteriAdres"].Value.ToString();

        }
    }
}
