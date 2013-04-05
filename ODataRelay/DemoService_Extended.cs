using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ODataRelay.ODataReadWrite
{

    /// <summary>
    /// There are no comments for DemoService in the schema.
    /// </summary>
    public partial class DemoService : global::System.Data.Services.Client.DataServiceContext
    {
        public DemoService()
            : base(new Uri(PublicRead.Endpoint))
        {
        }


    }
}