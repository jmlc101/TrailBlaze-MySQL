using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    [Serializable]
    public class Review
    {
        public int ID { get; set; }
        public string ReviewBody { get; set; }
        public string ReviewByUser { get; set; }
        public int Rating { get; set; }

        public IList<RouteReview> RouteReviews { get; set; }

    }
}
