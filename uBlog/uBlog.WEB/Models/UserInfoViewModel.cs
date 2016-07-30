using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace uBlog.WEB.Models
{
    public class UserInfoViewModel
    {
        [Required]
        public int UserInfoId { get; set; }

        [Required]
        [DisplayName("First name")]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Last name")]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public string Gender { get; set; }

        public string About { get; set; }

        public string Interest { get; set; }

        [Required]
        public bool IsSubscribed { get; set; }
    }
}