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
    public partial class anaEkran : Form
    {
        public anaEkran()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            hastaEkrani hasta = new hastaEkrani();
            hasta.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            randevuEkrani hasta = new randevuEkrani();
            hasta.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tedaviEkrani hasta = new tedaviEkrani();
            hasta.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            receteEkrani hasta = new receteEkrani();
            hasta.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            istatistikler hasta = new istatistikler();
            hasta.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            girisEkrani hasta = new girisEkrani();
            hasta.Show();
            this.Hide();
        }
    }
}
