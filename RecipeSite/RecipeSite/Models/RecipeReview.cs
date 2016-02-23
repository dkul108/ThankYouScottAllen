using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecipeSite.Models
{
    public class RecipeReview
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public string ReviewBody { get; set; }
        public int RecipeId { get; set; }
    }
}