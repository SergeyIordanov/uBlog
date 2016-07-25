namespace uBlog.BLL.DataTransferObjects
{
    public class UserInfoDto
    {
        public int UserInfoId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public int Age { get; set; }

        public string Gender { get; set; }

        public string About { get; set; }

        public string Interest { get; set; }

        public bool IsSubscribed { get; set; }
    }
}
