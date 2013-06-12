using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace MvcApp.Identity
{
    public class GoogleUser : KnownUser
    {
        public GoogleUser(IEnumerable<Claim> claims)
        {
        }
    }
}