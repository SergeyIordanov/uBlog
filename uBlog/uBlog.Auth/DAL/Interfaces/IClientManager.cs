using System;
using uBlog.Entities.IdentityEntities;

namespace uBlog.Auth.DAL.Interfaces
{
    public interface IClientManager : IDisposable
    {
        void Create(ClientProfile item);
    }
}