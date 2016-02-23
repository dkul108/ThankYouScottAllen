using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RecipeSite.Models
{
    public class RecipeSiteContext : DbContext
    {
        public RecipeSiteContext() : base("name=DefaultConnection")
        {

        }

        //properties of type DbSet represent the entities that you want to query and persist
        public DbSet<Recipe> Recipes { get; set; } //is like a select *
        public DbSet<RecipeReview> Reviews { get; set; }

        public System.Data.Entity.DbSet<RecipeSite.Models.RecipeListViewModel> RecipeListViewModels { get; set; }
    }
}