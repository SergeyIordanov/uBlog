namespace uBlog.BLL.DataTransferObjects
{
    public class UserInfoDTO
    {
        public int UserInfoID { get; set; }

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
