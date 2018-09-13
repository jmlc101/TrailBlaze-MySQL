using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading; // TODO - "System.Threading" by itself would actually cover the "using System.Threading.Tasks" statement. Therefore "System.Threading.Tasks" is un-
// necesarry. However trying "System.Threading.Interlocked" as a more targeted/narrow 'using' statement does not work.

namespace WebApplication1.Models
{
    public class Friendships
    {
        private static int globalFriendshipsID; // TODO - I should probably move all these globals somewhere else.
        public int ID { get; set;} // TODO - I FEEL like this should be private. ID private and constructor public?
        public Friendships(){
            this.ID = Interlocked.Increment(ref globalFriendshipsID);
        }

        public string ScreenNameA { get; set; }
        public string ScreenNameB { get; set; }

    }
}
