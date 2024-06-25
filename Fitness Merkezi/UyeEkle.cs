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

namespace Fitness_Merkezi
{
    public partial class UyeEkle : Form
    {
        public UyeEkle()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-SLE0JBB\MSQLSERVER1;Initial Catalog=DESKTOP-SLE0JBB\MSQLSERVER1;Integrated Security=True");
        private void UyeEkle_Load(object sender, EventArgs e)
        {
         
        }

        private void EkleBtn_Click(object sender, EventArgs e)
        {
            if (UyeAdSoyad.Text == "" || UyeTelefon.Text == "" || UyeYas.Text == "")
            {
                MessageBox.Show("Eksik bilgi girdiniz; lütfen hepsini doldurunuz!");
            }
            else
            {
                try
                {
                    baglanti.Open();
                    string query = "insert into UyeTBl values('" + UyeAdSoyad.Text.Trim() + "','" + UyeTelefon.Text.Trim() + "','"+UyeYas.Text.Trim()+"','" + comboCinsiyet.SelectedItem.ToString() + "', '" + UyeAylik.Text.Trim() + "','" + UyeZamanlama.SelectedItem.ToString() + "')";
                    SqlCommand komut = new SqlCommand(query, baglanti);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Üye Başarıyla Eklendi!");
                    baglanti.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
