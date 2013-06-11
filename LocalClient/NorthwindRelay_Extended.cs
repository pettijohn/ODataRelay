using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace LocalClient.NorthwindRelay
{

    /// <summary>
    /// There are no comments for NorthwindEntities in the schema.
    /// </summary>
    public partial class NorthwindEntities : global::System.Data.Services.Client.DataServiceContext
    {

        partial void OnContextCreated()
        {
            //if(_token == null || _tokenExpires < DateTime.UtcNow)
            //    _token = GetToken("webservicerelay", "owner", "[secret goes here]");

            this.SendingRequest += NorthwindEntities_SendingRequest;
        }

        void NorthwindEntities_SendingRequest(object sender, System.Data.Services.Client.SendingRequestEventArgs e)
        {
            //e.RequestHeaders.Add();
        }

        static string GetToken(string serviceNamespace, string issuerName, string issuerPassword)
        {
            if (_token == null)
            {
                string acsEndpoint = "https://" + serviceNamespace + "-sb.accesscontrol.windows.net/WRAPv0.9";
                string relyingPartyAddress = "http://" + serviceNamespace + ".servicebus.windows.net";

                NameValueCollection postData = new NameValueCollection
                {
                    { "wrap_scope", relyingPartyAddress },
                    { "wrap_name", issuerName },
                    { "wrap_password", issuerPassword },
                };

                WebClient webClient = new WebClient();
                byte[] responseBuffer = webClient.UploadValues(acsEndpoint, "POST", postData);
                string response = Encoding.UTF8.GetString(responseBuffer);

                string token = response.Split('&')
                    .Single(value => value.StartsWith("wrap_access_token="))
                    .Split('=')[1];
                var expiresInSeconds = Int32.Parse(response.Split('&')
                    .Single(value => value.StartsWith("wrap_access_token_expires_in="))
                    .Split('=')[1]);
                _tokenExpires = DateTime.UtcNow.AddSeconds(expiresInSeconds);

                _token = HttpUtility.UrlDecode(token);
            }

            return _token;
        }
        static string _token = null;
        static DateTime _tokenExpires;
    }
}
