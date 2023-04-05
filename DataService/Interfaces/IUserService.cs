
using CoreDomain.ResponseModels;
using CoreDomain.ViewModels.AuthModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataService.Interfaces
{
    public interface IUserService
    {
        Task<Response> RegisterUserAsync(RegisterModel model);
        Task<Response> LoginUserAsync(LoginModel model);
    }
}
