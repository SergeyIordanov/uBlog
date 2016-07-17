using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EPAM_MVC_2.Models
{
    public class UserInfo
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string About { get; set; }
        public string Interest { get; set; }
        public bool isSubscribed { get; set; }
    }
}