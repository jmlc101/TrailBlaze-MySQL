using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.ViewModels
{
    public class AddReviewViewModel
    {
        [Required(ErrorMessage = "Write a review, before submitting.")]
        [Display(Name = "Review:")]
        public string NewReview { get; set; }

        public string ReviewAuthor { get; set; }
        
        [Required(ErrorMessage = "Select a Rating.")]
        [Display(Name = "Rating:")]
        public int Rating { get; set; }

        public int RouteId { get; set; }


    }
}
