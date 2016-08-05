using uBlog.Auth.BLL.Interfaces;
using uBlog.Auth.DAL.Repositories;

namespace uBlog.Auth.BLL.Services
{
    public class ServiceCreator : IServiceCreator
    {
        public IUserService CreateUserService(string connection)
        {
            return new UserService(new IdentityUnitOfWork(connection));
        }
    }
}
