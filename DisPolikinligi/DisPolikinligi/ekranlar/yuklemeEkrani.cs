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
    public partial class yuklemeEkrani : Form
    {
        public yuklemeEkrani()
        {
            InitializeComponent();
        }
        int startpoint = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            startpoint += 5;
            MyProgress.Value = startpoint;
            if (MyProgress.Value == 100)
            {
                MyProgress.Value = 0;
                timer1.Stop();
                anaEkran ana= new anaEkran();
                this.Hide();
                ana.Show();

            }
        }

        private void yuklemeEkrani_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
