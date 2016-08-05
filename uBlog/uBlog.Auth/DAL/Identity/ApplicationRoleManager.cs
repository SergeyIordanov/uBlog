using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using uBlog.Entities.IdentityEntities;

namespace uBlog.Auth.DAL.Identity
{
    public class ApplicationRoleManager : RoleManager<ApplicationRole>
    {
        public ApplicationRoleManager(RoleStore<ApplicationRole> store)
                    : base(store)
        { }
    }
}
