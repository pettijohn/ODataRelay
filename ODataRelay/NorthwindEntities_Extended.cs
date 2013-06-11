using System;
using System.Collections.Generic;
using System.Data.Services;
using System.Linq;
using System.Web;

namespace ODataRelay.PublicNorthwind
{
    /// <summary>
    /// There are no comments for NorthwindEntities in the schema.
    /// </summary>
    public partial class NorthwindEntities : global::System.Data.Services.Client.DataServiceContext
    {
        public NorthwindEntities() : this(new Uri("http://services.odata.org/Northwind/Northwind.svc/"))
        {
        }

    }
}