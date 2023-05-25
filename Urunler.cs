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
    public partial class Urunler : Form
    {
        public Urunler()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-9KURH7U\\SQLEXPRESS; Initial Catalog =Cafe;Integrated security=true;");
        private void Urunler_Load(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("select *from Saticilar", baglan);
            SqlDataReader dr = komut.ExecuteReader();
            while(dr.Read())
            {
                comboBox1.Items.Add(dr["SaticiNo"]);
            }
            baglan.Close();
        }
        public void Listele(string komutkod)
        {
            SqlDataAdapter dr = new SqlDataAdapter(komutkod, baglan);
            DataTable doldur = new DataTable();
            dr.Fill(doldur);
            dataGridView1.DataSource = doldur;

        }
        //urunler listele butonu
        private void button8_Click(object sender, EventArgs e)
        {
            Listele("select * from Urunler");
        }
        //urun ekle butonu
        private void button6_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("insert into Urunler(Urunadi,UrunFiyati,KullanimTarihi,UretimTarihi,SaticiNo)values(@UrunAdi,@UrunFiyati,@KullanimTarihi,@UretimTarihi,@SaticiNo)", baglan);
            komut.Parameters.AddWithValue("@UrunAdi", textBox2.Text);
            komut.Parameters.AddWithValue("@UrunFiyati", textBox3.Text);
            komut.Parameters.AddWithValue("@KullanimTarihi", maskedTextBox1.Text);
            komut.Parameters.AddWithValue("@UretimTarihi", maskedTextBox2.Text);
            komut.Parameters.AddWithValue("@SaticiNo", comboBox1.Text);
            komut.ExecuteNonQuery();
            baglan.Close();
            Listele("select * from Urunler");


        }
        //urun sil butonu
        private void button9_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand cmd = new SqlCommand("delete from Urunler where UrunNo=@UrunNo",baglan);
            cmd.Parameters.AddWithValue("@UrunNo", textBox2.Tag);
            cmd.ExecuteNonQuery();
            baglan.Close();
            Listele("select * from Urunler");

        }
        //urun yenile
        private void button10_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("update Urunler set UrunAdi='" + textBox2.Text.ToString() + "',UrunFiyati='" + textBox3.Text.ToString() + "',KullanimTarihi='" + maskedTextBox1.Text.ToString() + "',UretimTarihi='" + maskedTextBox2.Text.ToString() + "',SaticiNo='" + comboBox1.Text.ToString() + "'where UrunNo='" + textBox2.Tag + "'", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            Listele("select*from Urunler");
        }
        //urun ara
        private void button11_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand cmd = new SqlCommand("select*from Urunler where UrunAdi like '%" + textBox2.Text + "%'", baglan);
            SqlDataAdapter dr = new SqlDataAdapter(cmd);
            DataTable doldur = new DataTable();
            dr.Fill(doldur);
            dataGridView1.DataSource = doldur;
            baglan.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;
            textBox2.Tag = satir.Cells["UrunNo"].Value.ToString();
            textBox2.Text = satir.Cells["UrunAdi"].Value.ToString();
            textBox3.Text = satir.Cells["UrunFiyati"].Value.ToString();
            maskedTextBox1.Text = satir.Cells["KullanimTarihi"].Value.ToString();
            maskedTextBox2.Text = satir.Cells["UretimTarihi"].Value.ToString();
            comboBox1.Text = satir.Cells["SaticiNo"].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
