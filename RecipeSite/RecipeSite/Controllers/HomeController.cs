using RecipeSite.Models;
using System.Collections;
using System.Linq;
using System.Web.Mvc;

namespace RecipeSite.Controllers
{
    public class HomeController : Controller
    {
        private RecipeSiteContext _db = new RecipeSiteContext();

        public ActionResult Index(string searchTerm )
        {
            //var model =
            //_db.Recipes.Select(r => new 
            //{
            //    Id = r.Id,
            //    Name = r.Name,
            //    Description = r.Description
            //}).ToList();
            //var model = _db.Recipes.ToList();

            var model =
                _db.Recipes
                .OrderByDescending(r => r.Reviews.Average(review => review.Rating))
                .Where(r => searchTerm == null || r.Name.StartsWith(searchTerm))
                .Select(r => new RecipeListViewModel
                {
                    Id = r.Id,
                    Name = r.Name,
                    Description = r.Description,
                    CountOfReviews = r.Reviews.Count()
                });
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