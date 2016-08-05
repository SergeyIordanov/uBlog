using Microsoft.AspNet.Identity.EntityFramework;

namespace uBlog.Entities.IdentityEntities
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ClientProfile ClientProfile { get; set; }
    }
}
