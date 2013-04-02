using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalClient.NorthwindRelay
{
    
    /// <summary>
    /// There are no comments for NorthwindEntities in the schema.
    /// </summary>
    public partial class NorthwindEntities : global::System.Data.Services.Client.DataServiceContext
    {
        partial void OnContextCreated()
        {
            this.SendingRequest += NorthwindEntities_SendingRequest;
        }

        void NorthwindEntities_SendingRequest(object sender, System.Data.Services.Client.SendingRequestEventArgs e)
        {
            //e.RequestHeaders.Add();
        }
    }
}
