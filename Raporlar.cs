using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace proje2
{
    public partial class Raporlar : Form
    {
        public Raporlar()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-9KURH7U\\SQLEXPRESS; Initial Catalog =Cafe;Integrated security=true;");
        private void Raporlar_Load(object sender, EventArgs e)
        {

        }
        public void Listele(string komut)
        {
            SqlDataAdapter dr = new SqlDataAdapter(komut, baglan);
            DataTable dt = new DataTable();
            dr.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Listele("select UrunAdi,UrunFiyati from Urunler ");
            
            

            //baglan.Open();
            //SqlCommand komut = new SqlCommand("select *from Saticilar", baglan);
            //SqlDataReader dr = komut.ExecuteReader();
            //while (dr.Read())
            //{
            //    comboBox1.Items.Add(dr["SaticiNo"]);
            //}
            //baglan.Close();







        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Listele("select SaticiAdSoyad,SaticiAdres from Saticilar");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Listele("select *from Siparisler order by siparisadet asc");
        }
    }
}
