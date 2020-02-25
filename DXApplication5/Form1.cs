using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DXApplication5
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void navigationPane1_Click(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.searchDataProduct();
            this.searchReceipt();
            this.searchIssue();
        }

       

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void popupControlContainer1_Paint(object sender, PaintEventArgs e)
        {

        }

       
        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void navigationPage2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void navigationPage1_Paint(object sender, PaintEventArgs e)
        {

        }

       
        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

      
        private void simpleButton11_Click(object sender, EventArgs e)
        {
            addReceiptClick();
        }

      /// <summary>
        /// Nút add
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            addProductClick();
        }
		/// <summary>
        /// Nút Edit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            editProductClick();

        }
		/// <summary>
        /// Nút Remove
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            removeProductClick();
            
        }
		/// <summary>
        /// Double Click cell
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            editProductDbClick();
        }

        private void search_Click(object sender, EventArgs e)
        {
            this.searchDataProduct();
        }

        private void simpleButton10_Click(object sender, EventArgs e)
        {
            editReceiptClick();
        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            removeReceiptClick();
        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            this.searchReceipt();
        }

        private void dataGridView3_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            editReceiptDbClick();
        }

        private void dataGridView3_CellMouseDoubleClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.editReceiptDbClick();
        }

        private void simpleButton15_Click(object sender, EventArgs e)
        {
            addIssueClick();
        }

        private void simpleButton14_Click(object sender, EventArgs e)
        {
            editIssueClick();
        }

        private void simpleButton13_Click(object sender, EventArgs e)
        {
            removeIssueClick();
        }

        private void simpleButton12_Click(object sender, EventArgs e)
        {
            searchIssue();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView4_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataGridView4_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            editIssueDbClick();
        }

        private void navigationPage5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void simpleButton16_Click(object sender, EventArgs e)
        {
            string valueSearch = dateTimePicker1.Value.ToString("yyyy-M").Trim();
            string queryString = "SELECT a.id as product_id,CONCAT(a.code,a.name) as product_name,b.quantity as inventory FROM dbo.product as a JOIN dbo.inventory as b ON a.id = b.product_id WHERE a.deleted = 0 and b.deleted = 0 and b.month = @search";
            string connectionString = "Data Source=.;Initial Catalog=project;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@search", valueSearch);

                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);
                dataGridView5.DataSource = dt;
                connection.Close();
            }
       }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton17_Click(object sender, EventArgs e)
        {
            string valueSearch = dateTimePicker1.Value.ToString("yyyy-M").Trim();
            string queryString = "SELECT b.id as product_id,CONCAT(b.code,b.name) as product_name,SUM(a.quantity) as inventory FROM (select b.product_id,SUM(b.quantity) as quantity ";
            queryString += " from receipt as a Join receipt_product as b ON a.id = b.receipt_id";
            queryString += " where a.deleted = 0 and b.deleted = 0 and CONCAT(DATEPART(Year, a.date) ,'-', DATEPART(Month, a.date)) = @search ";
            queryString += " GROUP BY product_id";
            queryString += " UNION";
            queryString += " select b.product_id,SUM(-b.quantity) as quantity";
            queryString += " from issue as a Join issue_product as b ON a.id = b.issue_id";
            queryString += " where a.deleted = 0 and b.deleted = 0 and CONCAT(DATEPART(Year, a.date) ,'-', DATEPART(Month, a.date)) = @search ";
            queryString += " GROUP BY product_id) as a JOIN product as b ON a.product_id = b.id where b.deleted = 0 GROUP BY b.id,b.code,b.name";
            
            string connectionString = "Data Source=.;Initial Catalog=project;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@search", valueSearch);

                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);
                dataGridView5.DataSource = dt;
                ////SAVE DATA

                projectEntities db = new projectEntities();
                var list_deleted = db.inventories.Where(c => c.month == valueSearch).ToList();
                list_deleted.ForEach(a => a.deleted = 1);
                foreach (DataRow row in dt.Rows)
                {
                    inventory inventory = new inventory();
                    inventory.product_id = Convert.ToInt32(row["product_id"]);
                    inventory.quantity = Convert.ToInt32(row["inventory"]);
                    inventory.month = valueSearch;
                    db.inventories.Add(inventory);
                }
                db.SaveChanges();
                connection.Close();
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
