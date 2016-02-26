namespace RecipeSite.Migrations
{
    using Models;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<RecipeSite.Models.RecipeSiteDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;//to allow/dissallow entity make changes unless you want it to
            ContextKey = "RecipeSite.Models.RecipeSiteDB";
        }

        protected override void Seed(RecipeSite.Models.RecipeSiteDb context)
        {
            context.Recipe.AddOrUpdate(r => r.Name,
                new Recipe { Name = "apple1", Description = "Desc1" },
                new Recipe { Name = "banana2", Description = "Desc2" },
                new Recipe { Name = "orange3", Description = "Desc3" },
                new Recipe
                {
                    Name = "Name4",
                    Description = "Desc4",
                    Reviews =
                    new List<RecipeReview> {
                        new RecipeReview { Rating = 5, Body = "Delicious!" }
                    }
                });

            for (int i = 0; i < 1000; i++)
            {
                context.Recipe.AddOrUpdate(r => r.Name,
                new Recipe
                {
                    Name = "Recipe Name " + i.ToString(),
                    Description = "Description for Recipe Name " + i.ToString()
                });
            }
        }
    }
}