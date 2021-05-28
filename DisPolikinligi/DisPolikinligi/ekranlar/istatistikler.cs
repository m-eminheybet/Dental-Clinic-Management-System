using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Data.SqlClient;

namespace DisPolikinligi
{
    public partial class istatistikler : Form
    {
       
        public istatistikler()
        {
            InitializeComponent();
        }
        ConnectionString MyConnection = new ConnectionString();
        private void istatistikler_Load(object sender, EventArgs e)
        {
            PendingAppProgress.Value = 100;
            UsersProgress.Value = 100;
            Patients.Value = 100;
            SqlConnection Con = MyConnection.GetCon();
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select count(*) from randevuTbl", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            Pendinglbl.Text = dt.Rows[0][0].ToString();
            SqlDataAdapter sda1 = new SqlDataAdapter("select count(*) from hastaTbl", Con);
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            lblhasta.Text = dt1.Rows[0][0].ToString();
            SqlDataAdapter sda2 = new SqlDataAdapter("select count(*) from kullaniciTbl", Con);
            DataTable dt2 = new DataTable();
            sda2.Fill(dt2);
            lblkullanici.Text = dt2.Rows[0][0].ToString();
            Con.Close();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            anaEkran ana = new anaEkran();
            ana.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            anaEkran ana = new anaEkran();
            ana.Show();
            this.Hide();
        }

        private void lblkullanici_Click(object sender, EventArgs e)
        {

        }
    }
}
