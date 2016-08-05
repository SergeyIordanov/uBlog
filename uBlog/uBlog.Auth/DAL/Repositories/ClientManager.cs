using uBlog.Auth.DAL.EF;
using uBlog.Auth.DAL.Interfaces;
using uBlog.Entities.IdentityEntities;

namespace uBlog.Auth.DAL.Repositories
{
    class ClientManager : IClientManager
    {
        public AuthContext Database { get; set; }

        public ClientManager(AuthContext db)
        {
            Database = db;
        }

        public void Create(ClientProfile item)
        {
            Database.ClientProfiles.Add(item);
            Database.SaveChanges();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}