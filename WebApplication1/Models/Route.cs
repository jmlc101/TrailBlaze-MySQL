using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    [Serializable]
    public class Route
    {
        public int ID { get; set; }
        public string RouteName { get; set; }
        public string Origin { get; set; }
        public string Waypoints { get; set; }
        public string Destination { get; set; }
        public string CreatedByUser { get; set; }
        public string BriefDescription { get; set; }

        public IList<UserRoute> UserRoutes { get; set; }

        public IList<RouteReview> RouteReviews { get; set; }
    }
}
