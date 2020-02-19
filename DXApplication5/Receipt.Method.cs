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
        private void addReceiptClick()
        {
            PopupGoodsReceipt popup = new PopupGoodsReceipt();
            DialogResult dialogresult = popup.ShowDialog();
            if (dialogresult == DialogResult.OK)
            {
                this.searchDataProduct();
                this.searchReceipt();
            }
            else if (dialogresult == DialogResult.Cancel)
            {
                Console.WriteLine("you clicked either cancel or x button in the top right corner");
            }
            popup.Dispose();
        }
        private void editReceiptClick()
        {
            if (dataGridView3.CurrentRow.Index != -1 && dataGridView3.CurrentRow.Index < dataGridView3.RowCount - 1)
            {
                int rowIndex = dataGridView3.CurrentRow.Index;

                int rowId = Convert.ToInt32(dataGridView3.Rows[rowIndex].Cells[0].Value);
                openPopupEditReceipt(rowId);

            }
        }
        private void removeReceiptClick()
        {
            foreach (DataGridViewRow row in dataGridView3.SelectedRows)
            {
                //get key
                int rowId = Convert.ToInt32(row.Cells[0].Value);
                if (rowId > 0)
                {
                    projectEntities db = new projectEntities();

                    receipt receipt = db.receipts.First(c => c.id == rowId);
                    //var old_quantity = receipt.product_quantity;
                    //var product_selected = receipt.product_id;
                    //product product = db.products.First(c => c.id == product_selected);
                    //product.quantity = product.quantity - old_quantity;
                    receipt.deleted = 1;
                    db.SaveChanges();
                }

            }

            this.searchDataProduct();
            this.searchReceipt();
        }
        private void searchReceipt()
        {
            string valueSearch = textBox2.Text.Trim();
            string queryString = "SELECT * FROM dbo.receipt WHERE deleted = 0 and (code like @search)";
            string connectionString = "Data Source=.;Initial Catalog=project;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@search", "%" + valueSearch + "%");

                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                var ds = new DataSet();
                dataAdapter.Fill(ds);
                dataGridView3.DataSource = ds.Tables[0];
                /// 
                string queryString1 = "select CONCAT(DATEPART(Year, receipt.date) ,'-', DATEPART(Month, receipt.date)) as value from receipt where deleted = 0 ";
                queryString1 += "group by DATEPART(Month, receipt.date) ,DATEPART(Year, receipt.date)" ;
                SqlCommand command1 = new SqlCommand(queryString1, connection);

                SqlDataAdapter dataAdapter1 = new SqlDataAdapter(command1);
                DataTable ds1 = new DataTable();
                dataAdapter1.Fill(ds1);
                comboBox1.DataSource = ds1;
                connection.Close();
            }
        }
        private void editReceiptDbClick()
        {
            if (dataGridView3.CurrentRow.Index != -1 && dataGridView3.CurrentRow.Index < dataGridView3.RowCount - 1)
            {
                int rowIndex = dataGridView3.CurrentRow.Index;

                int rowId = Convert.ToInt32(dataGridView3.Rows[rowIndex].Cells[0].Value);
                openPopupEditReceipt(rowId);

            }
        }
        private void openPopupEditReceipt(int rowId)
        {
            projectEntities db = new projectEntities();

            receipt receipt = db.receipts.First(c => c.id == rowId);


            PopupGoodsReceipt popup = new PopupGoodsReceipt();

            popup.bingdingData(receipt);
            DialogResult dialogresult = popup.ShowDialog();
            if (dialogresult == DialogResult.OK)
            {
                this.searchDataProduct();
                this.searchReceipt();
            }
            else if (dialogresult == DialogResult.Cancel)
            {
                Console.WriteLine("you clicked either cancel or x button in the top right corner");
            }
            popup.Dispose();
            

        }
    }
}
