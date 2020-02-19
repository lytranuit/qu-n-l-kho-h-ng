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

    public partial class Form1
    {

        private void addIssueClick()
        {
            PopupGoodsIssue popup = new PopupGoodsIssue();
            DialogResult dialogresult = popup.ShowDialog();
            if (dialogresult == DialogResult.OK)
            {
                this.searchDataProduct();
                this.searchIssue();
            }
            else if (dialogresult == DialogResult.Cancel)
            {
                Console.WriteLine("you clicked either cancel or x button in the top right corner");
            }
            popup.Dispose();
        }
        private void editIssueClick()
        {
            if (dataGridView4.CurrentRow.Index != -1 && dataGridView4.CurrentRow.Index < dataGridView4.RowCount - 1)
            {
                int rowIndex = dataGridView4.CurrentRow.Index;

                int rowId = Convert.ToInt32(dataGridView4.Rows[rowIndex].Cells[0].Value);
                openPopupEditIssue(rowId);

            }
        }
        private void removeIssueClick()
        {
            foreach (DataGridViewRow row in dataGridView4.SelectedRows)
            {
                //get key
                int rowId = Convert.ToInt32(row.Cells[0].Value);
                if (rowId > 0)
                {
                    projectEntities db = new projectEntities();

                    issue issue = db.issues.First(c => c.id == rowId);
                    //var old_quantity = receipt.product_quantity;
                    //var product_selected = receipt.product_id;
                    //product product = db.products.First(c => c.id == product_selected);
                    //product.quantity = product.quantity - old_quantity;
                    issue.deleted = 1;
                    db.SaveChanges();
                }

            }

            this.searchDataProduct();
            this.searchIssue();
        }
        private void searchIssue()
        {
            string valueSearch = textBox3.Text.Trim();
            string queryString = "SELECT * FROM dbo.issue WHERE deleted = 0 and (code like @search)";
            string connectionString = "Data Source=.;Initial Catalog=project;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@search", "%" + valueSearch + "%");

                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                var ds = new DataSet();
                dataAdapter.Fill(ds);
                dataGridView4.DataSource = ds.Tables[0];
                connection.Close();
            }
        }
        private void editIssueDbClick()
        {
            if (dataGridView4.CurrentRow.Index != -1 && dataGridView4.CurrentRow.Index < dataGridView4.RowCount - 1)
            {
                int rowIndex = dataGridView4.CurrentRow.Index;

                int rowId = Convert.ToInt32(dataGridView4.Rows[rowIndex].Cells[0].Value);
                openPopupEditIssue(rowId);

            }
        }
        private void openPopupEditIssue(int rowId)
        {
            projectEntities db = new projectEntities();

            issue issue = db.issues.First(c => c.id == rowId);


            PopupGoodsIssue popup = new PopupGoodsIssue();

            popup.bingdingData(issue);
            DialogResult dialogresult = popup.ShowDialog();
            if (dialogresult == DialogResult.OK)
            {
                this.searchDataProduct();
                this.searchIssue();
            }
            else if (dialogresult == DialogResult.Cancel)
            {
                Console.WriteLine("you clicked either cancel or x button in the top right corner");
            }
            popup.Dispose();


        }
    }
}
