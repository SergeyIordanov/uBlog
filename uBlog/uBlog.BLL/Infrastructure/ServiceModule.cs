using Ninject.Modules;
using uBlog.DAL.Interfaces;
using uBlog.DAL.Repositories;

namespace uBlog.BLL.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        private readonly string _connectionString;
        public ServiceModule(string connection)
        {
            _connectionString = connection;
        }
        public override void Load()
        {
            Bind<IUnitOfWork>().To<BlogUnitOfWork>().WithConstructorArgument(_connectionString);
        }
    }
}
