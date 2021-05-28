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
    public partial class tedaviEkrani : Form
    {
        public tedaviEkrani()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string query = "insert into tedaviTbl values('" + txtTedaviAdi.Text + "','" + txtUcret.Text + "','" + txtAciklama.Text + "')";
            dizinler hasta = new dizinler();
            try
            {
                hasta.hastaEkle(query);
                MessageBox.Show("Tedavi Başarıyla Eklendi");
                tbldüzenleme();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        void tbldüzenleme()
        {
            dizinler hasta = new dizinler();
            string query = "select * from tedaviTbl";
            DataSet ds = hasta.hastaGöster(query);
            tedaviDGV.DataSource = ds.Tables[0];
            txtTedaviAdi.Text = null;
            txtAciklama.Text = null;
            txtUcret.Text = null;
            

        }
        void arama()
        {
            dizinler hasta = new dizinler();
            string query = "select * from tedaviTbl where tedaviAdi like '%" + txtAra.Text + "%'";
            DataSet ds = hasta.hastaGöster(query);
            tedaviDGV.DataSource = ds.Tables[0];

        }

        private void tedaviEkrani_Load(object sender, EventArgs e)
        {
            tbldüzenleme();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            dizinler hasta = new dizinler();
            if (key == 0)
            {
                MessageBox.Show("Lütfen Tedavi Seçiniz");
            }
            else
            {
                try
                {
                    string query = "Delete from tedaviTbl where tedaviid=" + key + "";
                    hasta.hastaSil(query);
                    MessageBox.Show("Tedavi Başarıyla Silindi");
                    tbldüzenleme();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            dizinler hasta = new dizinler();
            if (key == 0)
            {
                MessageBox.Show("Lütfen Tedavi Seçiniz");
            }
            else
            {
                try
                {
                    string query = "Update tedaviTbl set tedaviAdi='" + txtTedaviAdi.Text + "',tedaviUcreti='" + txtUcret.Text + "',tedaviAciklama='" + txtAciklama.Text + "' where tedaviid=" + key + ";";
                    hasta.hastaGuncelle(query);
                    MessageBox.Show("Tedavi Başarıyla Güncellendi");
                    tbldüzenleme();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        int key = 0;
        private void tedaviDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int indexRow = e.RowIndex;
            DataGridViewRow row = tedaviDGV.Rows[indexRow];
            txtTedaviAdi.Text = row.Cells[1].Value.ToString();
            txtUcret.Text = row.Cells[2].Value.ToString();
            txtAciklama.Text = row.Cells[3].Value.ToString();
            
            if (txtTedaviAdi.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(tedaviDGV.Rows[indexRow].Cells[0].Value.ToString());
            }
        }

        private void txtAra_KeyPress(object sender, KeyPressEventArgs e)
        {
            arama();
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

        private void txtAra_MouseClick(object sender, MouseEventArgs e)
        {
            txtAra.Text = null;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            anaEkran hasta = new anaEkran();
            hasta.Show();
            this.Hide();
        }
    }
}
