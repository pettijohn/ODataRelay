using Microsoft.Data.Edm.Csdl;
using Microsoft.Data.Edm.Library;
using MvcApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.OData.Builder;
using System.Xml;

namespace MvcApp
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            ODataModelBuilder modelBuilder = new ODataConventionModelBuilder();
            modelBuilder.EntitySet<PublicODataDirect.Customer>("Customers");
            modelBuilder.EntitySet<PublicODataDirect.Order>("Orders");
            modelBuilder.EntitySet<PublicODataDirect.Order_Detail>("Order_Details");
            modelBuilder.EntitySet<PublicODataDirect.CustomerDemographic>("CustomerDemographics");

            Microsoft.Data.Edm.IEdmModel model = modelBuilder.GetEdmModel();
            config.Routes.MapODataRoute("ODataRoute", "odata", model);




            //var model = EdmxReader.Parse(new XmlTextReader(entities.GetMetadataUri().ToString()));
            //config.Routes.MapODataRoute("NorthwindRoute", "northwind", model);
            //var model = entities.GetMetadataUri();
            
        }
    }
}
