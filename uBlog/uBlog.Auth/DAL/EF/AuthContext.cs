using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Microsoft.AspNet.Identity.EntityFramework;
using uBlog.Entities.IdentityEntities;

namespace uBlog.Auth.DAL.EF
{
    public class AuthContext : IdentityDbContext<ApplicationUser>
    {
        public AuthContext() : base("BlogContext")
        {
        }

        public AuthContext(string conectionString) : base(conectionString)
        {
        }

        public DbSet<ClientProfile> ClientProfiles { get; set; }
    }
}
