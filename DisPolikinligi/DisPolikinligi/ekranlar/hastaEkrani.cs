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
    public partial class hastaEkrani : Form
    {
        public hastaEkrani()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string query = "insert into hastaTbl values('"+txtHastaAdi.Text+"','"+txtTelNo.Text+"','"+txtAdres.Text+"','"+dateDogumTarihi.Value.ToShortDateString()+"','" + cbCinsiyet.SelectedItem.ToString() + "','" + txtAlerji.Text + "')";
            dizinler hasta = new dizinler();
            try
            {
                hasta.hastaEkle(query);
                MessageBox.Show("Hasta Başarıyla Eklendi.");
                tbldüzenleme();
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        void tbldüzenleme()
        {
            dizinler hasta = new dizinler();
            string query = "select * from hastaTbl";
            DataSet ds = hasta.hastaGöster(query);
            hastaDGV.DataSource = ds.Tables[0];
            txtAdres.Text = null;
            txtAlerji.Text = null;
            txtHastaAdi.Text = null;
            txtTelNo.Text = null;
            cbCinsiyet.SelectedItem = null;
        }
        void arama()
        {
            dizinler hasta = new dizinler();
            string query = "select * from hastaTbl where hastaAdi like '%" + txtAra.Text + "%'";
            DataSet ds = hasta.hastaGöster(query);
            hastaDGV.DataSource = ds.Tables[0];

        }

        private void hastaEkrani_Load(object sender, EventArgs e)
        {
            tbldüzenleme();
            dizinler hasta = new dizinler();
            string query = "select * from hastaTbl";
            DataSet ds = hasta.hastaGöster(query);
            hastaDGV.DataSource = ds.Tables[0];

        }
        int key = 0;
        private void hastaDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int indexRow = e.RowIndex;
            DataGridViewRow row = hastaDGV.Rows[indexRow];
            txtHastaAdi.Text = row.Cells[1].Value.ToString();
            txtTelNo.Text = row.Cells[2].Value.ToString();
            txtAdres.Text = row.Cells[3].Value.ToString();
            dateDogumTarihi.Text = row.Cells[4].Value.ToString();
            cbCinsiyet.SelectedItem = row.Cells[5].Value.ToString();
            txtAlerji.Text = row.Cells[6].Value.ToString();
            if (txtHastaAdi.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(hastaDGV.Rows[indexRow].Cells[0].Value.ToString());
            }

        }

        
        private void button7_Click(object sender, EventArgs e)
        {
            dizinler hasta = new dizinler();
            if (key == 0)
            {
                MessageBox.Show("Lütfen Hasta Seçiniz");
            }
            else
            {
                try
                {
                    string query = "Delete from hastaTbl where hastaid=" + key + "";
                    hasta.hastaSil(query);
                    MessageBox.Show("Hasta Başarıyla Silindi");
                    tbldüzenleme();
                }
                catch(Exception Ex)
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
                MessageBox.Show("Lütfen Hasta Seçiniz");
            }
            else
            {
                try
                {
                    string query = "Update hastaTbl set hastaAdi='" + txtHastaAdi.Text + "',hastaTelNo='" + txtTelNo.Text + "',hastaAdres='" + txtAdres.Text + "',hastaDG='" + dateDogumTarihi.Value.ToShortDateString() + "',hastaCinsiyet='" + cbCinsiyet.SelectedItem.ToString() + "',hastaAlerji='" + txtAlerji.Text + "' where hastaid=" + key + ";";
                    hasta.hastaGuncelle(query);
                    MessageBox.Show("Hasta Başarıyla Güncellendi");
                    tbldüzenleme();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
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

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
