using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cafe_de_Flora
{
    public partial class splashscreen : Form
    {
        public splashscreen()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

      

        private void splashscreen_Load(object sender, EventArgs e)
        {
           
            timer1.Start();
        }

       

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i > 99; i++)
            {
                
                Thread.Sleep(20);
               
            }
            timer1.Stop();
            this.Hide();
            Form1 form1 = new Form1();
            form1.ShowDialog();
        }
    }
}
