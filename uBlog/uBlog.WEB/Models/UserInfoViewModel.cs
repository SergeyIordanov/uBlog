using System.ComponentModel;

namespace uBlog.WEB.Models
{
    public class UserInfoViewModel
    {
        public int UserInfoID { get; set; }

        [DisplayName("First name")]
        public string FirstName { get; set; }

        [DisplayName("Last name")]
        public string LastName { get; set; }

        public string Email { get; set; }

        public int Age { get; set; }

        public string Gender { get; set; }

        public string About { get; set; }

        public string Interest { get; set; }

        public bool isSubscribed { get; set; }
    }
}