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
    }
}