using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RecipeSite.Models
{
    public class RecipeSiteDb : DbContext
    {
        public RecipeSiteDb() : base("name=DefaultConnection")
        {

        }

        //properties of type DbSet represent the entities that you want to query and persist
        public DbSet<UserProfile> UserProfiles
        {
            get; set;
        }//is like SELECT *
        public DbSet<Recipe> Recipe
        {
            get; set;
        }
        public DbSet<RecipeReview> Reviews
        {
            get; set;
        }

        public System.Data.Entity.DbSet<RecipeSite.Models.RecipeListViewModel> RecipeListViewModels { get; set; }
    }
}