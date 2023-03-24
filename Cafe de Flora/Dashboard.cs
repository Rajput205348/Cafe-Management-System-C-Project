using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cafe_de_Flora
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }
        public Dashboard(String user)
        {
            InitializeComponent();
            if (user== "Guest")
            {
                btnAddItems.Hide();
                btnUpdate.Hide();
                btnRemove.Hide();


            }
        }

        private void gunaButton4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form5 fm = new Form5();

            fm.Show();
        }

        private void gunaGradientCircleButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

      

        

       

        private void txtLogOut_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Form1 fm = new Form1();

            fm.Show();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void btnAddItems_Click(object sender, EventArgs e)
        {

            this.Hide();
            Form2 fm = new Form2();

            fm.Show();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            
        }

        private void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 fm = new Form3();

            fm.Show();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 fm = new Form4();

            fm.Show();
        }
    }
}
