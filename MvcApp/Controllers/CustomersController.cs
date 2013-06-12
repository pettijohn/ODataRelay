using MvcApp.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web;
using System.Web.Http;
using System.Web.Http.OData;

namespace MvcApp.Controllers
{
    public class CustomersController : EntitySetController<ServiceBusOData.Customer, string>
    {
        public CustomersController()
        {
            _context = new ServiceBusOData.NorthwindEntities(new Uri("https://webservicerelay.servicebus.windows.net/northwindrelay/"));
            
            //Require a claims-based user & parse
            _knownUser = KnownUser.FromClaims(((ClaimsPrincipal)User).Claims);
            _context.BuildingRequest += _context_BuildingRequest;
            _context.ReceivingResponse += _context_ReceivingResponse;
        }

        void _context_ReceivingResponse(object sender, System.Data.Services.Client.ReceivingResponseEventArgs e)
        {
            var value = e.ResponseMessage.Headers.Where(h => h.Key == "X-PassThrough").First().Value;
            HttpContext.Current.Response.Headers["X-PassThrough"] = value;
        }

        ServiceBusOData.NorthwindEntities _context;
        KnownUser _knownUser;


        void _context_BuildingRequest(object sender, System.Data.Services.Client.BuildingRequestEventArgs e)
        {
            e.Headers.Add("X-PassThrough", _knownUser.NameIdentifier);
        }

        protected override ServiceBusOData.Customer GetEntityByKey(string key)
        {
            return (from c in _context.Customers where c.CustomerID == key select c).FirstOrDefault();
        }

        public override IQueryable<ServiceBusOData.Customer> Get()
        {
            return _context.Customers;
        }
    }
}
