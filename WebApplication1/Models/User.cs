using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class User
    {
        public int ID { get; set; }
        public string ScreenName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        // TODO - Make sure password Hash.
        public string Password { get; set; }
    }
}
