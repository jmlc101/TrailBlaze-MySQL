using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading; // TODO - "System.Threading" by itself would actually cover the "using System.Threading.Tasks" statement. Therefore "System.Threading.Tasks" is un-
// necesarry. However trying "System.Threading.Interlocked" as a more targeted/narrow 'using' statement does not work.

namespace WebApplication1.Models
{
    public class Message
    {
        private static int globalMessageID; // TODO - I should probably move all these globals somewhere else.
        public int ID { get; set;} // TODO - I FEEL like this should be private. ID private and constructor public?
        public Message(){
            this.ID = Interlocked.Increment(ref globalMessageID);
        }
        public DateTime CreationTime { get; set; }
        public string Body { get; set; }
        public int ReceiverID { get; set; }
        public string ReceiverScreenName { get; set; }
        public int SendersID { get; set; }
        public string SenderScreenName { get; set; }
        public bool Viewed { get; set; }
    }
}
