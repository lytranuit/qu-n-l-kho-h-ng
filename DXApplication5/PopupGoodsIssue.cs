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
    public partial class PopupGoodsIssue : Form
    {
        private int data_id = 0;
        public PopupGoodsIssue()
        {
            InitializeComponent();
        }
        public void bingdingData(issue issue)
        {
            data_id = issue.id;
            code.Text = issue.code;
            date.Value = issue.date.Value;
        }

        private void PopupGoodsIssue_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'projectDataSet1.product' table. You can move, or remove it, as needed.
            this.productTableAdapter.Fill(this.projectDataSet1.product);
            // TODO: This line of code loads data into the 'projectDataSet1.issue_product' table. You can move, or remove it, as needed.
            this.issue_productTableAdapter.Fill(this.projectDataSet1.issue_product);
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
                    string queryString2 = "SELECT * FROM dbo.issue_product WHERE deleted = 0 and issue_id = @issue_id";
                    SqlCommand command2 = new SqlCommand(queryString2, connection);

                    command2.Parameters.AddWithValue("@issue_id", data_id);
                    SqlDataAdapter dataAdapter2 = new SqlDataAdapter(command2);
                    DataTable ds2 = new DataTable();
                    dataAdapter2.Fill(ds2);
                    dataGridView1.DataSource = ds2;
                }
                connection.Close();
            }
        }
        

        private void save_Click_1(object sender, EventArgs e)
        {
            projectEntities db = new projectEntities();
            if (data_id > 0)
            {

                issue issue = db.issues.First(c => c.id == data_id);
                issue.date = date.Value;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {

                    int id = !(row.Cells[0].Value is DBNull) ? Convert.ToInt32(row.Cells[0].Value) : 0;
                    int product_id = Convert.ToInt32(row.Cells[1].Value);
                    int new_quanity = Convert.ToInt32(row.Cells[2].Value);
                    ////
                    if (id > 0)
                    {
                        issue_product issue_product = db.issue_product.First(c => c.id == id);

                        if (product_id > 0 && new_quanity > 0)
                        {
                            issue_product.product_id = product_id;
                            issue_product.quantity = new_quanity;
                            issue_product.issue_id = issue.id;
                        }
                        else
                        {
                            issue_product.deleted = 1;
                        }
                    }
                    else
                    {
                        issue_product issue_product = new issue_product();
                        if (product_id > 0 && new_quanity > 0)
                        {
                            issue_product.product_id = product_id;
                            issue_product.quantity = new_quanity;
                            issue_product.issue_id = issue.id;
                            db.issue_product.Add(issue_product);
                        }

                    }
                    //////

                }
                db.SaveChanges();
            }
            else
            {
                issue issue = new issue();
                issue.date = date.Value;
                db.issues.Add(issue);
                db.SaveChanges();

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    int product_id = Convert.ToInt32(row.Cells[1].Value);
                    int new_quanity = Convert.ToInt32(row.Cells[2].Value);
                    if (product_id > 0 && new_quanity > 0)
                    {
                        issue_product issue_product = new issue_product();
                        issue_product.product_id = product_id;
                        issue_product.quantity = new_quanity;
                        issue_product.issue_id = issue.id;
                        db.issue_product.Add(issue_product);
                    }

                }
                db.SaveChanges();
                MessageBox.Show("Insert Success!");
            }

        }
    }
}
