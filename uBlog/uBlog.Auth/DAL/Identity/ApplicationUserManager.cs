using Microsoft.AspNet.Identity;
using uBlog.Entities.IdentityEntities;

namespace uBlog.Auth.DAL.Identity
{
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store)
                : base(store)
        {
        }
    }
}