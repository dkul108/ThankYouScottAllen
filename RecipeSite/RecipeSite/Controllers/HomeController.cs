using RecipeSite.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using PagedList;

namespace RecipeSite.Controllers
{
    public class HomeController : Controller
    {
        private RecipeSiteDb _db = new RecipeSiteDb();

        public ActionResult Autocomplete(string term)
        {
            //querry the db
            var model = _db.Recipe
                .Where(r => r.Name.StartsWith(term))
                .Take(10)
                //projection
                .Select(r => new
                {
                    label = r.Name
                });

            //serialize 
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index(string searchTerm = null, int page = 1 )
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

                         }).ToPagedList(page, 10);

            ViewBag.currentFilter = searchTerm;

            if (Request.IsAjaxRequest())
            {
                return PartialView("_Recipes", model);
            }

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