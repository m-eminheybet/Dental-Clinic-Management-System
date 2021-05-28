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
    public partial class kullaniciEkrani : Form
    {
        public kullaniciEkrani()
        {
            InitializeComponent();
        }
        void tbldüzenleme()
        {
            dizinler hasta = new dizinler();
            string query = "select * from kullaniciTbl";
            DataSet ds = hasta.hastaGöster(query);
            kullaniciDGV.DataSource = ds.Tables[0];
            txtKullaniciAdi.Text = null;
            txtSifre.Text = null;
            txtTelefon.Text = null;


        }

        private void button6_Click(object sender, EventArgs e)
        {
            string query = "insert into kullaniciTbl values('" + txtKullaniciAdi.Text + "','" + txtSifre.Text + "','" + txtTelefon.Text + "')";
            dizinler hasta = new dizinler();
            try
            {
                hasta.hastaEkle(query);
                MessageBox.Show("Kullanıcı Başarıyla Eklendi.");
                tbldüzenleme();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void kullaniciEkrani_Load(object sender, EventArgs e)
        {
            tbldüzenleme();
        }
        int key = 0;
        private void kullaniciDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int indexRow = e.RowIndex;
            DataGridViewRow row = kullaniciDGV.Rows[indexRow];
            txtKullaniciAdi.Text = row.Cells[1].Value.ToString();
            txtSifre.Text = row.Cells[2].Value.ToString();
            txtTelefon.Text = row.Cells[3].Value.ToString();
            if (txtKullaniciAdi.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(kullaniciDGV.Rows[indexRow].Cells[0].Value.ToString());
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            dizinler hasta = new dizinler();
            if (key == 0)
            {
                MessageBox.Show("Lütfen Silmek İstediğiniz Kullanıcıyı Seçiniz");
            }
            else
            {
                try
                {
                    string query = "Delete from kullaniciTbl where kullaniciid=" + key + "";
                    hasta.hastaSil(query);
                    MessageBox.Show("Kullanıcı Başarıyla Silindi");
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
                MessageBox.Show("Lütfen Güncellemek İstediğiniz Kullanıcıyı Seçiniz");
            }
            else
            {
                try
                {
                    string query = "Update kullaniciTbl set kullaniciAdi='" + txtKullaniciAdi.Text + "',kullaniciSif='" + txtSifre.Text + "',kullaniciTel='" + txtTelefon.Text + "' where kullaniciid=" + key + ";";
                    hasta.hastaGuncelle(query);
                    MessageBox.Show("Kullanıcı Başarıyla Güncellendi");
                    tbldüzenleme();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            adminEkrani log = new adminEkrani();
            log.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
