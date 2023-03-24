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
    public partial class Form4 : Form
    {
        function fn = new function();
        string query;
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            
            LoadData();
        }
        public void LoadData()
        {
            query = "select * from Items";
            DataSet ds = fn.getData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtSearchItem_TextChanged(object sender, EventArgs e)
        {
            query = "Select * from Items where name like '" + txtSearchItem.Text + "%'";
            DataSet ds = fn.getData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }
        int id;
        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = int.Parse(guna2DataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            String category = guna2DataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            String name = guna2DataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            int price= int.Parse(guna2DataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());

            txtCategory.Text = category;
            txtName.Text = name;
            txtPrice.Text = price.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            query = "update Items set name='" + txtName.Text + "',category='" + txtCategory.Text + "',price=" + txtPrice.Text + "where Id =" + id + "";
            fn.setData(query);
            LoadData();
            txtName.Clear();
            txtCategory.Clear();
            txtPrice.Clear();

        }

        private void gunaGradientCircleButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard fm = new Dashboard();

            fm.Show();
        }
    }
}
