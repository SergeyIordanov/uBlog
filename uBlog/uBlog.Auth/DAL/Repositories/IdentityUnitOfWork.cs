using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using uBlog.Auth.DAL.EF;
using uBlog.Auth.DAL.Identity;
using uBlog.Auth.DAL.Interfaces;
using uBlog.Entities.IdentityEntities;

namespace uBlog.Auth.DAL.Repositories
{
    public class IdentityUnitOfWork : IUnitOfWork
    {
        private readonly AuthContext _db;

        private readonly ApplicationUserManager _userManager;
        private readonly ApplicationRoleManager _roleManager;
        private readonly IClientManager _clientManager;

        public IdentityUnitOfWork(string connectionString)
        {
            _db = new AuthContext(connectionString);
            _userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(_db));
            _roleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(_db));
            _clientManager = new ClientManager(_db);
        }

        public ApplicationUserManager UserManager => _userManager;

        public IClientManager ClientManager => _clientManager;

        public ApplicationRoleManager RoleManager => _roleManager;

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private bool _disposed;

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _userManager.Dispose();
                    _roleManager.Dispose();
                    _clientManager.Dispose();
                }
                _disposed = true;
            }
        }
    }
}