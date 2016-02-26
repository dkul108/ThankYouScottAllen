
using RecipeSite.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Controllers
{
    public class ReviewsController : Controller
    {

        RecipeSiteDb _db = new RecipeSiteDb();

        public ActionResult Index([Bind(Prefix = "id")] int recipeId)
        {
            var recipe = _db.Recipe.Find(recipeId);
            if (recipe != null)
            {
                return View(recipe);
            }
            return HttpNotFound();
        }

        [HttpGet]
        public ActionResult Create(int recipeId)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(RecipeReview review)
        {
            if (ModelState.IsValid)
            {
                _db.Reviews.Add(review);
                _db.SaveChanges();
                return RedirectToAction("Index", new
                {
                    id = review.RecipeId
                });
            }
            return View(review);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = _db.Reviews.Find(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Exclude = "ReviewerName")]RecipeReview review)
        {
            if (ModelState.IsValid)
            {
                // the Entry APi says here is a review that i want you to start tracking for changes. but dont add it, just Update
                _db.Entry(review).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index", new
                {
                    id = review.RecipeId
                });
            }
            return View(review);
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }
    }
}
