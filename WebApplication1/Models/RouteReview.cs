using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading; // TODO - "System.Threading" by itself would actually cover the "using System.Threading.Tasks" statement. Therefore "System.Threading.Tasks" is un-
// necesarry. However trying "System.Threading.Interlocked" as a more targeted/narrow 'using' statement does not work.

namespace WebApplication1.Models
{
    public class RouteReview
    {
        private static int globalRouteReviewID; // TODO - I should probably move all these globals somewhere else.
        public int ID { get; set;} // TODO - I FEEL like this should be private. ID private and constructor public?
        public RouteReview(){
            this.ID = Interlocked.Increment(ref globalRouteReviewID);
        }

        public int RouteID { get; set; }
        public Route Route { get; set; }

        public int ReviewID { get; set; }
        public Review Review { get; set; }

    }
}
