using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using uBlog.Auth.BLL.DTO;
using uBlog.Auth.BLL.Infrastructure;

namespace uBlog.Auth.BLL.Interfaces
{
    public interface IUserService : IDisposable
    {
        Task<OperationDetails> Create(UserDTO userDto);
        Task<ClaimsIdentity> Authenticate(UserDTO userDto);
        Task SetInitialData(UserDTO adminDto, List<string> roles);
    }
}