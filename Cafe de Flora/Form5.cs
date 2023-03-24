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
    public partial class Form5 : Form
    {
        function fn = new function();
        String query;
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            DelLabel.Text = "HOW TO DELETE?";
            DelLabel.ForeColor = Color.Blue;
            loadData();

        }
        public void loadData()
        {
            query = "select * from items ";
            DataSet ds = fn.getData(query);
            gunaDataGridView1.DataSource = ds.Tables[0];
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            query = "select * from Items where name like '"+txtSearch.Text+"%'";
            DataSet ds = fn.getData(query);
            gunaDataGridView1.DataSource = ds.Tables[0];

        }

        private void gunaDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(MessageBox.Show("Delete Item?","Important Message",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning)==DialogResult.OK)
            {
                int id = int.Parse(gunaDataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                query = "delete from Items where Id="+id+"";
                fn.setData(query);
                loadData();
            }
        }

        private void DelLabel_Click(object sender, EventArgs e)
        {
            DelLabel.Text = "*CLICK ON ROW TO DELETE THE ITEM";
        }

        private void gunaGradientCircleButton1_Click(object sender, EventArgs e)
        {

            this.Hide();
            Dashboard fm = new Dashboard();

            fm.Show();
        }
    }
}
