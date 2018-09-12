using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading; // TODO - "System.Threading" by itself would actually cover the "using System.Threading.Tasks" statement. Therefore "System.Threading.Tasks" is un-
// necesarry. However trying "System.Threading.Interlocked" as a more targeted/narrow 'using' statement does not work.

namespace WebApplication1.Models
{
    [Serializable]
    public class Review
    {
        private static int globalReviewID;
        public int ID { get; set;} // TODO - I FEEL like this should be private. ID private and constructor public?
        public Review(){
            this.ID = Interlocked.Increment(ref globalReviewID);
        }
        public string ReviewBody { get; set; }
        public string ReviewByUser { get; set; }
        public int Rating { get; set; }

        public IList<RouteReview> RouteReviews { get; set; }

    }
}
