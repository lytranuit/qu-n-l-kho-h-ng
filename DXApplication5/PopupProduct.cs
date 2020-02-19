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
                product.name = product_name.Text;
                db.SaveChanges();
                XtraMessageBox.Show("Update Success!");
            }
            else
            {
                product product = new product();
                product.name = product_name.Text;
                db.products.Add(product);
                db.SaveChanges();
                XtraMessageBox.Show("Insert Success!");
            }
            

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
