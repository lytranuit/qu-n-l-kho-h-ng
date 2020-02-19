using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DXApplication5
{
    public partial class PopupGoodsReceipt : Form
    {
        private int data_id = 0;
        public PopupGoodsReceipt()
        {
            InitializeComponent();
        }

        private void PopupGoodsReceipt_Load(object sender, EventArgs e)
        {

            string queryString = "SELECT id,CONCAT(code,' ',name) as name FROM dbo.product WHERE deleted = 0";
            string connectionString = "Data Source=.;Initial Catalog=project;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);

                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataTable ds = new DataTable();
                dataAdapter.Fill(ds);
                productidDataGridViewTextBoxColumn.DataSource = ds;
                if (data_id > 0)
                {
                    string queryString2 = "SELECT * FROM dbo.receipt_product WHERE deleted = 0 and receipt_id = @receipt_id";
                    SqlCommand command2 = new SqlCommand(queryString2, connection);

                    command2.Parameters.AddWithValue("@receipt_id", data_id);
                    SqlDataAdapter dataAdapter2 = new SqlDataAdapter(command2);
                    DataTable ds2 = new DataTable();
                    dataAdapter2.Fill(ds2);
                    dataGridView1.DataSource = ds2;
                }
                connection.Close();
            }
            
        }

        private void save_Click(object sender, EventArgs e)
        {
            projectEntities db = new projectEntities();
            if (data_id > 0)
            {

                receipt receipt = db.receipts.First(c =>c.id == data_id);
                receipt.date = date.Value;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {

                    int id = !(row.Cells[0].Value is DBNull) ? Convert.ToInt32(row.Cells[0].Value) : 0;
                    int product_id = Convert.ToInt32(row.Cells[1].Value);
                    int new_quanity = Convert.ToInt32(row.Cells[2].Value);
                    ////
                    if (id > 0)
                    {
                        receipt_product receipt_product = db.receipt_product.First(c=>c.id == id);

                        if (product_id > 0 && new_quanity > 0)
                        {
                            receipt_product.product_id = product_id;
                            receipt_product.quantity = new_quanity;
                            receipt_product.receipt_id = receipt.id;
                        }
                        else
                        {
                            receipt_product.deleted = 1;
                        }
                    }
                    else
                    {
                        receipt_product receipt_product = new receipt_product();
                        if (product_id > 0 && new_quanity > 0)
                        {
                            receipt_product.product_id = product_id;
                            receipt_product.quantity = new_quanity;
                            receipt_product.receipt_id = receipt.id;
                            db.receipt_product.Add(receipt_product);
                        }
                        
                    }
                    //////

                }
                db.SaveChanges();
            }
            else
            {
                receipt receipt = new receipt();
                receipt.date = date.Value; 
                db.receipts.Add(receipt);
                db.SaveChanges();

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    int product_id = Convert.ToInt32(row.Cells[1].Value);
                    int new_quanity = Convert.ToInt32(row.Cells[2].Value);
                    if (product_id > 0 && new_quanity > 0)
                    {
                        receipt_product receipt_product = new receipt_product();
                        receipt_product.product_id = product_id;
                        receipt_product.quantity = new_quanity;
                        receipt_product.receipt_id = receipt.id;
                        db.receipt_product.Add(receipt_product);
                    }
                    
                }
                db.SaveChanges();
                MessageBox.Show("Insert Success!");
            }

        }

        public void bingdingData(receipt receipt)
        {
            data_id = receipt.id;
            code.Text = receipt.code;
            date.Value = receipt.date.Value;
        }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
