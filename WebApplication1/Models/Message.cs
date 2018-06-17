using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Message
    {
        public int ID { get; set; }
        public DateTime CreationTime { get; set; }
        public string Body { get; set; }
        public int ReceiverID { get; set; }
        public string ReceiverScreenName { get; set; }
        public int SendersID { get; set; }
        public string SenderScreenName { get; set; }
        public bool Viewed { get; set; }
    }
}
