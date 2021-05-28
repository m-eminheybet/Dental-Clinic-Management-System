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
    public partial class receteEkrani : Form
    {
        public receteEkrani()
        {
            InitializeComponent();
        }
        ConnectionString MyCon = new ConnectionString();
        private void hastaDoldur()
        {
            SqlConnection Con = MyCon.GetCon();
            Con.Open();
            SqlCommand cmd = new SqlCommand("select hasta from randevuTbl", Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("hasta", typeof(string));
            dt.Load(rdr);
            cbHasta.ValueMember = "hasta";
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
            dt.Columns.Add("hasta", typeof(string));
            dt.Load(rdr);
            cbHasta.ValueMember = "hasta";
            cbHasta.DataSource = dt;
            Con.Close();
        }
        private void tedaviGetir()
        {
            SqlConnection Con = MyCon.GetCon();
            Con.Open();
            SqlCommand cmd = new SqlCommand("select * from randevuTbl where hasta='"+cbHasta.SelectedValue.ToString()+"'",Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                txtTedavi.Text = dr["tedavi"].ToString();
            }
            
            Con.Close();
        }
        private void ucretGetir()
        {
            SqlConnection Con = MyCon.GetCon();
            Con.Open();
            SqlCommand cmd = new SqlCommand("select * from tedaviTbl where tedaviAdi='" + txtTedavi.Text + "'", Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                txtUcret.Text = dr["tedaviUcreti"].ToString();
            }

            Con.Close();
        }
        private void receteEkrani_Load(object sender, EventArgs e)
        {
            tbldüzenleme();
            hastaDoldur();
           
        }

        private void cbHasta_SelectionChangeCommitted(object sender, EventArgs e)
        {
            tedaviGetir();
        }

        private void txtTedavi_TextChanged(object sender, EventArgs e)
        {
            ucretGetir();
        }
        void tbldüzenleme()
        {
            dizinler hasta = new dizinler();
            string query = "select * from receteTbl";
            DataSet ds = hasta.hastaGöster(query);
            receteDGV.DataSource = ds.Tables[0];
            txtMiktar.Text = null;
            txtilaclar.Text = null;
        }
        void arama()
        {
            dizinler hasta = new dizinler();
            string query = "select * from receteTbl where hastaAdi like '%" + txtAra.Text + "%'";
            DataSet ds = hasta.hastaGöster(query);
            receteDGV.DataSource = ds.Tables[0];

        }
        private void button6_Click(object sender, EventArgs e)
        {
            string query = "insert into receteTbl values('" + cbHasta.SelectedValue.ToString() + "','" + txtTedavi.Text + "','" + txtUcret.Text + "','"+txtilaclar.Text+"','"+txtMiktar.Text+"')";
            dizinler hasta = new dizinler();
            try
            {
                hasta.hastaEkle(query);
                MessageBox.Show("Reçete Başarıyla Eklendi");
                tbldüzenleme();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        int key = 0;
        private void receteDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int indexRow = e.RowIndex;
            DataGridViewRow row = receteDGV.Rows[indexRow];
            cbHasta.SelectedValue = row.Cells[1].Value.ToString();
            txtTedavi.Text = row.Cells[2].Value.ToString();
            txtUcret.Text = row.Cells[3].Value.ToString();
            txtilaclar.Text = row.Cells[4].Value.ToString();
            txtMiktar.Text = row.Cells[5].Value.ToString();

            if (txtTedavi.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(receteDGV.Rows[indexRow].Cells[0].Value.ToString());
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            dizinler hasta = new dizinler();
            if (key == 0)
            {
                MessageBox.Show("Lütfen Reçete Seçiniz");
            }
            else
            {
                try
                {
                    string query = "Delete from receteTbl where receteid=" + key + "";
                    hasta.hastaSil(query);
                    MessageBox.Show("Reçete Başarıyla Silindi");
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
        Bitmap bitmap;
        private void button8_Click(object sender, EventArgs e)
        {
            int height = receteDGV.Height;
            receteDGV.Height = receteDGV.RowCount * receteDGV.RowTemplate.Height * 2;
            bitmap = new Bitmap(receteDGV.Width, receteDGV.Height);
            receteDGV.DrawToBitmap(bitmap, new Rectangle(0, 10, receteDGV.Width, receteDGV.Height));
            receteDGV.Height = height;
            printPreviewDialog1.ShowDialog();

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bitmap, 0, 0);
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
