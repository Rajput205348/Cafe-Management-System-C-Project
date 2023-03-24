using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DGVPrinterHelper;

namespace Cafe_de_Flora
{
    public partial class Form3 : Form
    {
        function fn = new function();
        string query;
        protected int n, total = 0;

        int amount;
        public Form3()
        {
            InitializeComponent();
        }

        private void comboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            string category = comboCategory.Text;
            query = "select name  from Items where category='" + category + "'";
            showItemlist(query);
        }
       

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string category = comboCategory.Text;
            query = "select name  from Items where category='" + category + "'and name like'" + txtSearch.Text + "%'";
            showItemlist(query);
        }
        public void showItemlist(string query)
        {
            listBox1.Items.Clear();
            DataSet ds = fn.getData(query);

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                listBox1.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            }
        }


        private void gunaGradientCircleButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard fm = new Dashboard();

            fm.Show();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtQuantityUpDown.ResetText();
            txtTotal.Clear();
            string text = listBox1.GetItemText(listBox1.SelectedItem);
            txtItemName.Text = text;
            query = "select price from Items where name='" + text + "'";
            DataSet ds = fn.getData(query);

            try
            {
                txtPrice.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            catch { }
        }

        private void txtQuantityUpDown_ValueChanged(object sender, EventArgs e)
        {
            Int64 quan = Int64.Parse(txtQuantityUpDown.Value.ToString());
            Int64 price = Int64.Parse(txtPrice.Text);
            txtTotal.Text = (quan * price).ToString();
        }

        private void gunaDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                amount = int.Parse(gunaDataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
            }
            catch { }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                gunaDataGridView1.Rows.RemoveAt(this.gunaDataGridView1.SelectedRows[0].Index);
            }
            catch { }
            total -= amount;
            labelTotalAmount.Text = "Rs." + total;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();
            printer.Title = "Customer Bill";
            printer.SubTitle = string.Format("Date:{0}", DateTime.Now.Date);
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "Total Payable Amount:" + labelTotalAmount.Text;
            printer.FooterSpacing = 15;
            printer.PrintDataGridView(gunaDataGridView1);

            total = 0;
            gunaDataGridView1.Rows.Clear();
            labelTotalAmount.Text = "Rs." + total;
        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            if (txtTotal.Text != "0" && txtTotal.Text != "")
            {
                n = gunaDataGridView1.Rows.Add();
                gunaDataGridView1.Rows[n].Cells[0].Value = txtItemName.Text;
                gunaDataGridView1.Rows[n].Cells[1].Value = txtPrice.Text;
                gunaDataGridView1.Rows[n].Cells[2].Value = txtQuantityUpDown.Value;
                gunaDataGridView1.Rows[n].Cells[3].Value = txtTotal.Text;

                total += int.Parse(txtTotal.Text);
                labelTotalAmount.Text = "Rs." + total;
            }
            else
            {
                MessageBox.Show("Minimum Quantity need to be 1", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
    }
    
}
