using System.ComponentModel.DataAnnotations;

namespace uBlog.DAL.Entities
{
    public class UserInfo
    {
        [Required]
        public int UserInfoID { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public int Age { get; set; }

        [Required]
        public string Gender { get; set; }

        public string About { get; set; }

        public string Interest { get; set; }

        [Required]
        public bool isSubscribed { get; set; }
    }
}
