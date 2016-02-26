using RecipeSite.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace RecipeSite.Controllers
{
    public class HomeController : Controller
    {
        private RecipeSiteDb _db = new RecipeSiteDb();

        public ActionResult Index(string searchTerm = null )
        {
            var model = (from r in _db.Recipe
                         where r.Name.StartsWith(searchTerm)
                         select new
                         {
                             Id = r.Id,
                             Name = r.Name,
                             Description = r.Description,
                             CountOfReviews = r.Reviews.Count()
                         }).AsEnumerable().Select(x => new RecipeListViewModel
                         {
                             Id = x.Id,
                             Name = x.Name,
                             Description = x.Description,
                             CountOfReviews = x.CountOfReviews

                         }).ToList();

            return View(model);
        }

        public ActionResult About()
        {
            var model = new AboutModel();
            model.Name = "your name";
            model.Location = "someplace";

            ViewBag.Message = "Your application description page.";

            return View(model);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (_db != null)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}