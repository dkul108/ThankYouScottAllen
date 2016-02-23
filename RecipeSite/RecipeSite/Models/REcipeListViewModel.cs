using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecipeSite.Models
{
    public class RecipeListViewModel 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CountOfReviews { get; set; }
    }
}