using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace MvcApp.Identity
{
    public class MicrosoftUser : KnownUser
    {
        public MicrosoftUser(IEnumerable<Claim> claims)
        {
        }
    }
}