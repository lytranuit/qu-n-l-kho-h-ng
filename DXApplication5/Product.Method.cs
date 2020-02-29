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
		private void addProductClick()
        {
            PopupProduct popup = new PopupProduct();
            DialogResult dialogresult = popup.ShowDialog();
            if (dialogresult == DialogResult.OK)
            {

                this.searchDataProduct();
            }
            else if (dialogresult == DialogResult.Cancel)
            {
                Console.WriteLine("You clicked either Cancel or X button in the top right corner");
            }
            popup.Dispose();
        }
        private void editProductClick()
        {
            if (dataGridView1.CurrentRow.Index != -1 && dataGridView1.CurrentRow.Index < dataGridView1.RowCount - 1)
            {
                int rowIndex = dataGridView1.CurrentRow.Index;

                int rowId = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells[0].Value);
                openPopupEdit(rowId);

            }
        }
        private void removeProductClick()
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                //get key
                int rowId = Convert.ToInt32(row.Cells[0].Value);
                if (rowId > 0)
                {
                    projectEntities db = new projectEntities();

                    product product = db.products.First(c => c.id == rowId);
                    db.products.Remove(product);
                    db.SaveChanges();
                }

            }

            this.searchDataProduct();
        }
        private void editProductDbClick()
        {
            if (dataGridView1.CurrentRow.Index != -1 && dataGridView1.CurrentRow.Index < dataGridView1.RowCount - 1)
            {
                int rowIndex = dataGridView1.CurrentRow.Index;

                    int rowId = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells[0].Value);
                    openPopupEdit(rowId);
                
            }
        }
		/// <summary>
        /// Method mở popup
        /// </summary>
        /// <param name="rowId"></param>
        private void openPopupEdit(int rowId)
        {
            projectEntities db = new projectEntities();

            product product = db.products.First(c => c.id == rowId);

            ///Mở popup
            PopupProduct popup = new PopupProduct();
            popup.bingdingData(product);
            DialogResult dialogresult = popup.ShowDialog();
            if (dialogresult == DialogResult.OK)
            {
                this.searchDataProduct();
            }
            else if (dialogresult == DialogResult.Cancel)
            {
                Console.WriteLine("You clicked either Cancel or X button in the top right corner");
            }
            popup.Dispose();

        }
        private void searchDataProduct()
        {
            string valueSearch = txtSearch.Text.Trim();
            string queryString = "SELECT * FROM dbo.product WHERE deleted = 0 and (code like @search OR name like @search)";
            string connectionString = "Data Source=.;Initial Catalog=project;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@search", "%" + valueSearch + "%");

                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                var ds = new DataSet();
                dataAdapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                connection.Close();
            }

        }



    }
}
