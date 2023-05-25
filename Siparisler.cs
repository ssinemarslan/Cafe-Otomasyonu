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
    public partial class Siparisler : Form
    {
        public Siparisler()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-9KURH7U\\SQLEXPRESS; Initial Catalog =Cafe;Integrated security=true;");
        private void Siparisler_Load(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("select*from Musteriler", baglan);
            SqlDataReader dr=komut.ExecuteReader();
            while(dr.Read())
            {
                comboBox1.Items.Add(dr["MusteriNo"]);
            }
            baglan.Close();
            
        }
        public void Listele(string komutkod)
        {
            SqlDataAdapter dr=new SqlDataAdapter(komutkod,baglan);
            DataTable doldur = new DataTable();
            dr.Fill(doldur);
            dataGridView1.DataSource = doldur;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Listele("select*from Siparisler");
        }
        //sipaeiş ekle
        private void button2_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("insert into Siparisler(SiparisAdi,SiparisAdres,SiparisAdet,MusteriNo)values(@SiparisAdi,@SiparisAdres,@SiparisAdet,@MusteriNo)", baglan);
            komut.Parameters.AddWithValue("@SiparisAdi", textBox2.Text);
            komut.Parameters.AddWithValue("@SiparisAdres",textBox3.Text);
            komut.Parameters.AddWithValue("@SiparisAdet", textBox4.Text);
            komut.Parameters.AddWithValue("@MusteriNo", comboBox1.Text);
            komut.ExecuteNonQuery();
            baglan.Close();
            Listele("select*from Siparisler");
        }
        //siparis sil
        private void button3_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand cmd = new SqlCommand("delete from Siparisler where SiparisNo=@SiparisNo", baglan);
            cmd.Parameters.AddWithValue("@SiparisNo", textBox2.Tag);
            cmd.ExecuteNonQuery();
            baglan.Close();
            Listele("select*from Siparisler");
        }
        //sipariş yenile
        private void button4_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("update Siparisler set SiparisAdi='" + textBox2.Text.ToString() + "',SiparisAdres='" + textBox3.Text.ToString() + "',SiparisAdet='" + textBox4.Text.ToString() + "'where SiparisNo='" + textBox2.Tag + "'", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            Listele("select*from Siparisler");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;
            textBox2.Tag = satir.Cells["SiparisNo"].Value.ToString();
            textBox2.Text = satir.Cells["SiparisAdi"].Value.ToString();
            textBox3.Text = satir.Cells["SiparisAdres"].Value.ToString();
            textBox4.Text = satir.Cells["SiparisAdet"].Value.ToString();
            comboBox1.Text = satir.Cells["MusteriNo"].Value.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //baglan.Open();
            //SqlCommand cmd = new SqlCommand("select*from Saticilar where SaticiAdSoyad like '%" + textBox2.Text + "%'", baglan);
            //SqlDataAdapter dr = new SqlDataAdapter(cmd);
            //DataTable doldur = new DataTable();
            //dr.Fill(doldur);
            //dataGridView1.DataSource = doldur;
            //baglan.Close();
            baglan.Open();
            SqlCommand komut = new SqlCommand("select *from Siparisler where SiparisAdi Like '%" + textBox2.Text + "%'", baglan);
            SqlDataAdapter dr= new SqlDataAdapter(komut);
            DataTable doldur= new DataTable();
            dr.Fill(doldur);
            dataGridView1.DataSource = doldur;
            baglan.Close();
        }
    }
}
