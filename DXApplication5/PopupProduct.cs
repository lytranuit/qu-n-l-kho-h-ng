using DevExpress;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Win;
using DevExpress.ExpressApp.Win.Templates;
using System.Collections.Generic;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Win.Core;
using DevExpress.ExpressApp.Win.Layout;
using DevExpress.ExpressApp.Win.Templates.ActionContainers;
using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Linq;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Data.Entity.Validation;

namespace DXApplication5
{
    public partial class PopupProduct : PopupFormBase
    {
        public int product_id = 0;
        protected override XafLayoutControl BottomPanel
        {
            get { return bottomPanel; }
        }
        protected override PanelControl ViewSitePanel
        {
            get { return viewSitePanel; }
        }
        protected override ViewSiteManager ViewSiteManager
        {
            get { return viewSiteManager; }
        }
        protected override FormStateModelSynchronizer FormStateModelSynchronizer
        {
            get { return formStateModelSynchronizer; }
        }
        public override ICollection<IActionContainer> GetContainers()
        {
            return actionContainersManager.GetContainers();
        }
        public override IActionContainer DefaultContainer
        {
            get { return actionContainersManager.DefaultContainer; }
        }
        public override object ViewSiteControl
        {
            get { return viewSitePanel; }
        }
        public override DevExpress.XtraBars.BarManager BarManager
        {
            get { return xafBarManager; }
        }
        public PopupProduct()
        {
            InitializeComponent();

        }
        public void bingdingData(product product)
        {

            product_code.ReadOnly = true;
            product_id = product.id;
            product_code.Text = product.code.Trim();
            product_name.Text = product.name.Trim();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            projectEntities db = new projectEntities();
            if(product_id > 0)
            {
                product product = db.products.First(c => c.id == product_id);
                product.name = product_name.Text.Trim();
                if (product.name == "")
                {
                    XtraMessageBox.Show("Nhập đầy đủ tên và mã sản phẩm");
                    return;
                }
                db.SaveChanges();
                XtraMessageBox.Show("Update Success!");
            }
            else
            {
                try
                {
                    product product = new product();
                    product.code = product_code.Text.Trim();
                    product.name = product_name.Text.Trim();
                    if (product.code == "" || product.name == "")
                    {

                        XtraMessageBox.Show("Nhập đầy đủ tên và mã sản phẩm");
                        return;
                    }
                    db.products.Add(product);
                    db.SaveChanges();
                    XtraMessageBox.Show("Insert Success!");
                }
                catch (DbEntityValidationException ex)
                {
                    // Retrieve the error messages as a list of strings.
                    var errorMessages = ex.EntityValidationErrors
                            .SelectMany(x => x.ValidationErrors)
                            .Select(x => x.ErrorMessage);

                    // Join the list to a single string.
                    var fullErrorMessage = string.Join("; ", errorMessages);
                    XtraMessageBox.Show(fullErrorMessage);
                    return;
                }
                
                catch (DbUpdateException ex)
                {
                    if (ex.InnerException != null && ex.InnerException.InnerException != null)
                    {
                        SqlException sqlexception = ex.InnerException.InnerException as SqlException;
                        switch (sqlexception.Number)
                        {
                            case 2627:  // Unique constraint error
                            case 547:   // Constraint check violation
                            case 2601:  // Duplicated key row error
                                        // Constraint violation exception
                                        // A custom exception of yours for concurrency issues
                                XtraMessageBox.Show("Mã sản phẩm đã tồn tại");
                                return;
                            default:
                                XtraMessageBox.Show("Error while trying to populate databases. " + ex.Message);
                                return;

                        }
                    }
                       
                }
               
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;

        }

        private void label1_Click(object sender, System.EventArgs e)
        {


        }

        private void label2_Click(object sender, System.EventArgs e)
        {

        }

        private void product_code_TextChanged(object sender, EventArgs e)
        {

        }
      
    }

}
