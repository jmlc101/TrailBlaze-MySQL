using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading; // TODO - "System.Threading" by itself would actually cover the "using System.Threading.Tasks" statement. Therefore "System.Threading.Tasks" is un-
// necesarry. However trying "System.Threading.Interlocked" as a more targeted/narrow 'using' statement does not work.

namespace WebApplication1.Models
{
    public class FriendRequest
    {
        private static int globalFriendRequestID; // TODO - I should probably move all these globals somewhere else.
        public int ID { get; set;} // TODO - I FEEL like this should be private. ID private and constructor public?
        public FriendRequest(){
            this.ID = Interlocked.Increment(ref globalFriendRequestID);
        }
        public int RequestingUserID { get; set; }
        public string RequestingUserScreenName { get; set; }
        public int RequestedUserID { get; set; }
        public string RequestedUserScreenName { get; set; }
        public DateTime CreationTime { get; set; }

    }
}
