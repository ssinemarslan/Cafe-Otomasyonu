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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace proje2
{
    public partial class Saticilar : Form
    {
        public Saticilar()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-9KURH7U\\SQLEXPRESS; Initial Catalog = Cafe;Integrated security=true;");
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Saticilar_Load(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("select*from Saticilar", baglan);
           baglan.Close();
            
        }
        public void Listele(string komutkod)
        {
            SqlDataAdapter dr=new SqlDataAdapter(komutkod,baglan);
            DataTable doldur= new DataTable();
            dr.Fill(doldur);
            dataGridView1.DataSource= doldur;
        }
        //listeleme butonu
        private void button1_Click(object sender, EventArgs e)
        {
            Listele("select*from Saticilar");
        }
        //satıcı ekle
        private void button4_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut=new SqlCommand("insert into Saticilar(SaticiAdSoyad,SaticiAdres,Saticiil,Saticiilce)values(@SaticiAdSoyad,@SaticiAdres,@Saticiil,@Saticiilce)",baglan);
            komut.Parameters.AddWithValue("@SaticiAdSoyad", textBox2.Text);
            komut.Parameters.AddWithValue("@SaticiAdres", textBox3.Text);
            komut.Parameters.AddWithValue("Saticiil", textBox4.Text);
            komut.Parameters.AddWithValue("@Saticiilce", textBox5.Text);
            komut.ExecuteNonQuery();
            baglan.Close();
            Listele("select *from Saticilar");
            //baglan.Open();
            //SqlCommand komut = new SqlCommand("insert into Urunler(Urunadi,UrunFiyati,KullanimTarihi,UretimTarihi,SaticiNo)values(@UrunAdi,@UrunFiyati,@KullanimTarihi,@UretimTarihi,@SaticiNo)", baglan);
            //komut.Parameters.AddWithValue("@UrunAdi", textBox2.Text);
            //komut.Parameters.AddWithValue("@UrunFiyati", textBox3.Text);
            //komut.Parameters.AddWithValue("@KullanimTarihi", maskedTextBox1.Text);
            //komut.Parameters.AddWithValue("@UretimTarihi", maskedTextBox2.Text);
            //komut.Parameters.AddWithValue("@SaticiNo", comboBox1.Text);
            //komut.ExecuteNonQuery();
            //baglan.Close();
            //Listele("select * from Urunler");
        }
        //satici sil
        private void button5_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand cmd = new SqlCommand("delete from Saticilar where SaticiNo=@SaticiNo", baglan);
            cmd.Parameters.AddWithValue("@SaticiNo", textBox2.Tag);
            cmd.ExecuteNonQuery();
            baglan.Close();
            Listele("select *from Saticilar");
            //baglan.Open();
            //SqlCommand cmd = new SqlCommand("delete from Urunler where UrunNo=@UrunNo", baglan);
            //cmd.Parameters.AddWithValue("@UrunNo", textBox2.Tag);
            //cmd.ExecuteNonQuery();
            //baglan.Close();
            //Listele("select * from Urunler");
        }
        //yenile butonu
        private void button6_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand cmd = new SqlCommand("update Saticilar set SaticiAdSoyad='" + textBox2.Text.ToString() + "',SaticiAdres='" + textBox3.Text.ToString() + "',Saticiil='" + textBox4.Text.ToString() + "',Saticiilce='" + textBox5.Text.ToString()+"'where SaticiNo='"+textBox2.Tag+"'",baglan);
            cmd.ExecuteNonQuery();
            baglan.Close();
            Listele("select*from Saticilar");
            //baglan.Open();
            //SqlCommand komut = new SqlCommand("update Urunler set UrunAdi='" + textBox2.Text.ToString() + "',UrunFiyati='" + textBox3.Text.ToString() + "',KullanimTarihi='" + maskedTextBox1.Text.ToString() + "',UretimTarihi='" + maskedTextBox2.Text.ToString() + "',SaticiNo='" + comboBox1.Text.ToString() + "'where UrunNo='" + textBox2.Tag + "'", baglan);
            //komut.ExecuteNonQuery();
            //baglan.Close();
            //Listele("select*from Urunler");

        }
        //satici ara
        private void button7_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand cmd = new SqlCommand("select*from Saticilar where SaticiAdSoyad like '%" + textBox2.Text + "%'", baglan);
            SqlDataAdapter dr=new SqlDataAdapter(cmd);
            DataTable doldur=new DataTable();
            dr.Fill(doldur);
            dataGridView1.DataSource= doldur;
            baglan.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;
            textBox2.Tag = satir.Cells["SaticiNo"].Value.ToString();
            textBox2.Text = satir.Cells["SaticiAdSoyad"].Value.ToString();
            textBox3.Text = satir.Cells["SaticiAdres"].Value.ToString();
            textBox4.Text = satir.Cells["Saticiil"].Value.ToString();
            textBox5.Text = satir.Cells["Saticiilce"].Value.ToString();
        }
    }
}
