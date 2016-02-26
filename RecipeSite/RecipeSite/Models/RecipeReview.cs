using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RecipeSite.Models
{
    public class RecipeReview
    {
        public int Id { get; set; }

        [Range(1,5)]
        public int Rating { get; set; }

        [Required]
        [StringLength(1024)]
        public string Body { get; set; }

        //this says that REviewname should show up on the front end as User Name and the default display text is anon
        [Display(Name ="User Name")]
        [DisplayFormat(NullDisplayText = "anonymous")]
        public string ReviewerName
        {
            get; set;
        }
        public int RecipeId
        {
            get; set;
        }
    }
}