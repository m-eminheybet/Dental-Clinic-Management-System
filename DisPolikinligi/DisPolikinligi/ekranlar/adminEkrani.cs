using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DisPolikinligi
{
    public partial class adminEkrani : Form
    {
        public adminEkrani()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtAdminPass.Text == "")
            {
                MessageBox.Show("Admin Şifresini Giriniz");
            }
            else if (txtAdminPass.Text == "Password")
            {
                kullaniciEkrani kullanici = new kullaniciEkrani();
                kullanici.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Yanlış Şifre. Lütfen adminle iletişime geçiniz.");
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            girisEkrani log = new girisEkrani();
            log.Show();
            this.Hide();
        }

        private void adminEkrani_Load(object sender, EventArgs e)
        {

        }
    }
}
