using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.ViewModels
{
    public class SendMessageViewModel
    {
        
        public int SendersID { get; set; }
        
        public int RecieversID { get; set; }
        
        public string Body { get; set; }

        public string ProfileUserScreenName { get; set; }

        public string SendAMessageButtonCheck { get; set; }
    }
}
