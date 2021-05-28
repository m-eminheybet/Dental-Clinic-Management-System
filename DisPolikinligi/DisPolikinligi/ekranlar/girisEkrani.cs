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

namespace DisPolikinligi
{
    public partial class girisEkrani : Form
    {
        public girisEkrani()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            adminEkrani log = new adminEkrani();
            log.Show();
            this.Hide();
        }
        ConnectionString MyConnection = new ConnectionString();
        
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection Con = MyConnection.GetCon();
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select count(*) from kullaniciTbl where kullaniciAdi='" + txtKullaniciAdi.Text + "' and kullaniciSif='" + txtSifre.Text + "'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                yuklemeEkrani yuk = new yuklemeEkrani();
                yuk.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Yanlış Kullanıcı Adı veya Şifre");
                txtKullaniciAdi.Text = "";
                txtSifre.Text = "";
            }

            Con.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
