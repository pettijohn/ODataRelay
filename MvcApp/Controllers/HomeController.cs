using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Xml.Serialization;

namespace MvcApp.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Default/

        public ActionResult Index()
        {
            var claimedUser = (ClaimsPrincipal)User;
            ViewData["claims"] = claimedUser.Claims.ToArray();

            return View();
        }

    }
}
