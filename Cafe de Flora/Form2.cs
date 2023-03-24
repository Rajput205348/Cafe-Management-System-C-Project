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
    public partial class Form2 : Form
    {
        function fn = new function();
        string query;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            query = "insert into Items(name,category,price) values('" + textBox2.Text + "','" + comboBox1.Text + "','" + textBox1.Text + "')";
            fn.setData(query);
            MessageBox.Show("Data Inserted Successfully");
        }
    


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard fm = new Dashboard();

            fm.Show();
        }

        private void gunaGradientCircleButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard fm = new Dashboard();

            fm.Show();
        }
    }
}
