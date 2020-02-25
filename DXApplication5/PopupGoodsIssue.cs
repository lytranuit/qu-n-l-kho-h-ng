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
                var list_deleted = db.issue_product.Where(c=>c.issue_id == data_id).ToList();
                list_deleted.ForEach(a => a.deleted = 1);

                var count_product = 0;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    
                    int product_id = Convert.ToInt32(row.Cells[1].Value);
                    int new_quanity = Convert.ToInt32(row.Cells[2].Value);
                    issue_product issue_product = new issue_product();
                    if (product_id > 0 && new_quanity > 0)
                    {
                        issue_product.product_id = product_id;
                        issue_product.quantity = new_quanity;
                        issue_product.issue_id = issue.id;
                        db.issue_product.Add(issue_product);
                        count_product++;
                    }

                }

                if (count_product == 0)
                {
                    issue.deleted = 1;
                }
                db.SaveChanges();
                MessageBox.Show("Update Success!");
            }
            else
            {
                issue issue = new issue();
                issue.date = date.Value;
                db.issues.Add(issue);
                db.SaveChanges();
                var count_product = 0;
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
                        count_product++;
                    }

                }

                if (count_product == 0)
                {
                    issue.deleted = 1;
                }
                db.SaveChanges();
                MessageBox.Show("Insert Success!");
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == dataGridView1.NewRowIndex || e.RowIndex < 0)
                return;
            
            //Check if click is on specific column 
            if (e.ColumnIndex == dataGridView1.Columns["deleted"].Index)
            {
                //Put some logic here, for example to remove row from your binding list.
                dataGridView1.Rows.RemoveAt(e.RowIndex);

                // Or
                // var data = (Product)dataGridView1.Rows[e.RowIndex].DataBoundItem;
                // do something 
            }
        }
    }
}
