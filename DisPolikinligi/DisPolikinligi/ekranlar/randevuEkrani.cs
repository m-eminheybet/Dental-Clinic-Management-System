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
namespace DisPolikinligi
{
    public partial class randevuEkrani : Form
    {
        public randevuEkrani()
        {
            InitializeComponent();
        }
        ConnectionString MyCon = new ConnectionString();
        private void hastaDoldur()
        {
            SqlConnection Con = MyCon.GetCon();
            Con.Open();
            SqlCommand cmd = new SqlCommand("select hastaAdi from hastaTbl", Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("hastaAdi", typeof(string));
            dt.Load(rdr);
            cbHasta.ValueMember = "hastaAdi";
            cbHasta.DataSource = dt;
            Con.Close();
        }
        private void tedaviDoldur()
        {
            SqlConnection Con = MyCon.GetCon();
            Con.Open();
            SqlCommand cmd = new SqlCommand("select tedaviAdi from tedaviTbl", Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("tedaviAdi", typeof(string));
            dt.Load(rdr);
            cbTedavi.ValueMember = "tedaviAdi";
            cbTedavi.DataSource = dt;
            Con.Close();
        }
        private void randevuEkrani_Load(object sender, EventArgs e)
        {
            hastaDoldur();
            tedaviDoldur();
            tbldüzenleme();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string query = "insert into randevuTbl values('" + cbHasta.SelectedValue.ToString() + "','" + cbTedavi.SelectedValue.ToString() + "','" + dateTarih.Value.ToShortDateString() + "','"+Saat.Value.TimeOfDay+"')";
            dizinler hasta = new dizinler();
            try
            {
                hasta.hastaEkle(query);
                MessageBox.Show("Randevu Başarıyla Kaydedildi");
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
            string query = "select * from randevuTbl";
            DataSet ds = hasta.hastaGöster(query);
            randevuDGV.DataSource = ds.Tables[0];      

        }
        void arama()
        {
            dizinler hasta = new dizinler();
            string query = "select * from randevuTbl where hasta like '%" + txtAra.Text + "%'";
            DataSet ds = hasta.hastaGöster(query);
            randevuDGV.DataSource = ds.Tables[0];

        }
        int key = 0;
        private void randevuDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int indexRow = e.RowIndex;
            DataGridViewRow row = randevuDGV.Rows[indexRow];
            cbHasta.SelectedValue = row.Cells[1].Value.ToString();
            cbTedavi.SelectedValue = row.Cells[2].Value.ToString();
            dateTarih.Text = row.Cells[3].Value.ToString();
            Saat.Text = row.Cells[4].Value.ToString();
            if (cbHasta.SelectedIndex == -1)
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(randevuDGV.Rows[indexRow].Cells[0].Value.ToString());
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            dizinler hasta = new dizinler();
            if (key == 0)
            {
                MessageBox.Show("Lütfen Çıkarmak İstediğiniz Randevuyu Seçiniz");
            }
            else
            {
                try
                {
                    string query = "Delete from randevuTbl where randevuid=" + key + "";
                    hasta.hastaSil(query);
                    MessageBox.Show("Randevu Başarıyla Çıkarıldı");
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
                MessageBox.Show("Lütfen Randevu Seçiniz");
            }
            else
            {
                try
                {
                    string query = "Update randevuTbl set hasta='" + cbHasta.SelectedValue.ToString() + "',tedavi='" + cbTedavi.SelectedValue.ToString() + "',randevuTarihi='" + dateTarih.Value.ToShortDateString() + "',randevuSaati='"+Saat.Value.TimeOfDay+"' where randevuid=" + key + ";";
                    hasta.hastaSil(query);
                    MessageBox.Show("Randevu Başarıyla Güncellendi");
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
    }
}
