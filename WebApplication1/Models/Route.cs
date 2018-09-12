using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading; // TODO - "System.Threading" by itself would actually cover the "using System.Threading.Tasks" statement. Therefore "System.Threading.Tasks" is un-
// necesarry. However trying "System.Threading.Interlocked" as a more targeted/narrow 'using' statement does not work.

namespace WebApplication1.Models
{
    [Serializable]
    public class Route
    {
        private static int globalRouteID;
        public int ID { get; set;} // TODO - I FEEL like this should be private. ID private and constructor public?
        public Route(){
            this.ID = Interlocked.Increment(ref globalRouteID);
        }
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
