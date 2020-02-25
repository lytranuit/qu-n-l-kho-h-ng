namespace DXApplication5
{
    partial class PopupGoodsReceipt
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cancle = new DevExpress.XtraEditors.SimpleButton();
            this.save = new DevExpress.XtraEditors.SimpleButton();
            this.date = new System.Windows.Forms.DateTimePicker();
            this.code = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.productBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.projectDataSet1 = new DXApplication5.projectDataSet1();
            this.quantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.receiptproductBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.receipt_productTableAdapter = new DXApplication5.projectDataSet1TableAdapters.receipt_productTableAdapter();
            this.productTableAdapter = new DXApplication5.projectDataSet1TableAdapters.productTableAdapter();
            this.deleted = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.receiptproductBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // cancle
            // 
            this.cancle.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancle.Location = new System.Drawing.Point(268, 453);
            this.cancle.Name = "cancle";
            this.cancle.Size = new System.Drawing.Size(75, 23);
            this.cancle.TabIndex = 32;
            this.cancle.Text = "Cancle";
            // 
            // save
            // 
            this.save.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.save.Location = new System.Drawing.Point(115, 453);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(75, 23);
            this.save.TabIndex = 31;
            this.save.Text = "Save";
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // date
            // 
            this.date.Location = new System.Drawing.Point(312, 19);
            this.date.Name = "date";
            this.date.Size = new System.Drawing.Size(200, 22);
            this.date.TabIndex = 29;
            // 
            // code
            // 
            this.code.Location = new System.Drawing.Point(115, 19);
            this.code.Name = "code";
            this.code.ReadOnly = true;
            this.code.Size = new System.Drawing.Size(100, 22);
            this.code.TabIndex = 27;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(245, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 17);
            this.label4.TabIndex = 25;
            this.label4.Text = "Ngày";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 17);
            this.label1.TabIndex = 22;
            this.label1.Text = "Mã hóa đơn";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.productidDataGridViewTextBoxColumn,
            this.quantityDataGridViewTextBoxColumn,
            this.deleted});
            this.dataGridView1.DataSource = this.receiptproductBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(12, 61);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(529, 365);
            this.dataGridView1.TabIndex = 35;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "id";
            this.idDataGridViewTextBoxColumn.HeaderText = "id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Visible = false;
            // 
            // productidDataGridViewTextBoxColumn
            // 
            this.productidDataGridViewTextBoxColumn.DataPropertyName = "product_id";
            this.productidDataGridViewTextBoxColumn.DataSource = this.productBindingSource;
            this.productidDataGridViewTextBoxColumn.DisplayMember = "name";
            this.productidDataGridViewTextBoxColumn.HeaderText = "Sản phẩm";
            this.productidDataGridViewTextBoxColumn.Name = "productidDataGridViewTextBoxColumn";
            this.productidDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.productidDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.productidDataGridViewTextBoxColumn.ValueMember = "id";
            // 
            // productBindingSource
            // 
            this.productBindingSource.DataMember = "product";
            this.productBindingSource.DataSource = this.projectDataSet1;
            // 
            // projectDataSet1
            // 
            this.projectDataSet1.DataSetName = "projectDataSet1";
            this.projectDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // quantityDataGridViewTextBoxColumn
            // 
            this.quantityDataGridViewTextBoxColumn.DataPropertyName = "quantity";
            dataGridViewCellStyle2.NullValue = null;
            this.quantityDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.quantityDataGridViewTextBoxColumn.HeaderText = "Số lượng";
            this.quantityDataGridViewTextBoxColumn.Name = "quantityDataGridViewTextBoxColumn";
            this.quantityDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // receiptproductBindingSource
            // 
            this.receiptproductBindingSource.DataMember = "receipt_product";
            this.receiptproductBindingSource.DataSource = this.projectDataSet1;
            // 
            // receipt_productTableAdapter
            // 
            this.receipt_productTableAdapter.ClearBeforeFill = true;
            // 
            // productTableAdapter
            // 
            this.productTableAdapter.ClearBeforeFill = true;
            // 
            // deleted
            // 
            this.deleted.HeaderText = "Xóa";
            this.deleted.Name = "deleted";
            // 
            // PopupGoodsReceipt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 542);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.cancle);
            this.Controls.Add(this.save);
            this.Controls.Add(this.date);
            this.Controls.Add(this.code);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Name = "PopupGoodsReceipt";
            this.Text = "Hóa đơn nhập";
            this.Load += new System.EventHandler(this.PopupGoodsReceipt_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.receiptproductBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton cancle;
        private DevExpress.XtraEditors.SimpleButton save;
        private System.Windows.Forms.DateTimePicker date;
        private System.Windows.Forms.TextBox code;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private projectDataSet1 projectDataSet1;
        private System.Windows.Forms.BindingSource receiptproductBindingSource;
        private projectDataSet1TableAdapters.receipt_productTableAdapter receipt_productTableAdapter;
        private System.Windows.Forms.BindingSource productBindingSource;
        private projectDataSet1TableAdapters.productTableAdapter productTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn productidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewImageColumn deleted;
    }
}
