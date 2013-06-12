using MvcApp.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using System.Web.Http.OData;

namespace MvcApp.Controllers
{
    public class CustomersController : EntitySetController<PublicODataDirect.Customer, string>
    {
        public CustomersController()
        {
            _context = new PublicODataDirect.NorthwindEntities(new Uri("http://services.odata.org/Northwind/Northwind.svc/"));
            _knownUser = KnownUser.FromClaims(((ClaimsPrincipal)User).Claims);
            _context.BuildingRequest += _context_BuildingRequest;
        }

        PublicODataDirect.NorthwindEntities _context;
        KnownUser _knownUser;


        void _context_BuildingRequest(object sender, System.Data.Services.Client.BuildingRequestEventArgs e)
        {
            e.Headers.Add("ClaimProvider", _knownUser.Provider);
            e.Headers.Add("ClaimNameIdentifier", _knownUser.NameIdentifier);
        }
        
        protected override PublicODataDirect.Customer GetEntityByKey(string key)
        {
            return (from c in _context.Customers where c.CustomerID == key select c).FirstOrDefault();
        }

        public override IQueryable<PublicODataDirect.Customer> Get()
        {
            return _context.Customers;
        }
    }
}
