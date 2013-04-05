using ODataRelay.ODataReadWrite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ODataRelay
{
    public partial class PublicRead : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UpdateGrid();
        }

        /// <summary>
        /// Has a session identifier to support writes. 
        /// </summary>
        public const string Endpoint = "http://services.odata.org/V3/(S(j0wnzs5jcmedqpofhigwq5ce))/OData/OData.svc/";

        private void UpdateGrid()
        {
            var svc = new ODataReadWrite.DemoService(new Uri(Endpoint));

            var products = (from prod in svc.Products
                            select prod);
            this.customers.DataSource = products;

            this.customers.DataBind();
        }

        protected void myButton_Click(object sender, EventArgs e)
        {
            var svc = new ODataReadWrite.DemoService(new Uri(Endpoint));
            var prod = Product.CreateProduct(11, DateTime.Now, 4, 10);
            prod.Name = "My new product";
            svc.AddToProducts(prod);
            svc.SaveChanges();

            UpdateGrid();
        }
    }
}