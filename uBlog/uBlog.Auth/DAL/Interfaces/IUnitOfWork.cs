using System;
using System.Threading.Tasks;
using uBlog.Auth.DAL.Identity;

namespace uBlog.Auth.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ApplicationUserManager UserManager { get; }
        IClientManager ClientManager { get; }
        ApplicationRoleManager RoleManager { get; }
        Task SaveAsync();
    }
}