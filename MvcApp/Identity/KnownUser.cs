using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace MvcApp.Identity
{
    /// <summary>
    /// Parses claims and strongly-types them.
    /// </summary>
    public abstract class KnownUser
    {
        public string NameIdentifier { get; set; }
        public string Provider { get; set; }

        public static KnownUser FromClaims(IEnumerable<Claim> claims)
        {
            //Determine provider
            KnownUser user;
            var provider = claims.Where(c => c.Type == "http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider").First().Value;
            //Create a strongly-typed instance
            switch (provider)
            {
                case "uri:WindowsLiveID":
                    user = new MicrosoftUser(claims);
                    break;
                case "Google":
                    user = new GoogleUser(claims);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Unknown claim provider", "claims");
            }

            //Populate default values
            user.Provider = provider;
            user.NameIdentifier = claims.Where(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").First().Value;
            return user;
        }
    }
}