using System;
using System.Threading;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class User
    {
        // a test
        // another test
        private static int globalID;
        public int ID { get; set;} // TODO - I FEEL like this should be private. ID private and constructor public?
        public User(){
            this.ID = Interlocked.Increment(ref globalID);
        }
        public string ScreenName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public string PasswordHash { get; set; }
        public string HashCode { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime ModificationTime { get; set; }

        public int TrailsBlazed { get; set; }
        public int ReviewsMade { get; set; }

        public IList<UserRoute> UserRoutes { get; set; }
    }
}
