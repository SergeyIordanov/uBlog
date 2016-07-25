using Ninject.Modules;
using uBlog.DAL.Interfaces;
using uBlog.DAL.Repositories;

namespace uBlog.BLL.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        private string connectionString;
        public ServiceModule(string connection)
        {
            connectionString = connection;
        }
        public override void Load()
        {
            Bind<IUnitOfWork>().To<BlogUnitOfWork>().WithConstructorArgument(connectionString);
        }
    }
}
