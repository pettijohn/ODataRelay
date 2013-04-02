using ODataRelay.PublicNorthwind;
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
            var svc = new PublicNorthwind.NorthwindEntities(new Uri("http://services.odata.org/Northwind/Northwind.svc/"));
            
            var customers = (from customer in svc.Customers
                     select customer).Take(10);
            this.customers.DataSource = customers;
            this.customers.DataBind();
        }

        protected void myButton_Click(object sender, EventArgs e)
        {
            var svc = new PublicNorthwind.NorthwindEntities(new Uri("http://services.odata.org/Northwind/Northwind.svc/"));
            svc.AddToCustomers(Customer.CreateCustomer("1234", "My Company"));
            svc.SaveChanges();
        }
    }
}