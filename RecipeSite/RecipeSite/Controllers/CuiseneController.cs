using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RecipeSite.Controllers
{
    public class CuiseneController : Controller
    {
        // GET: Cuisene
        [Authorize]
        public ActionResult Search(string name = "all")
        {
            var message = Server.HtmlEncode(name);
            return Content(name);
        }

        
    }
}