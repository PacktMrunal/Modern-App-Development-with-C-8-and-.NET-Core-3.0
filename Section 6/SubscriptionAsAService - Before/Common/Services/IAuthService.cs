using Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Common.Services
{
    public interface IAuthService
    {
        event EventHandler<EventArgs> AccessTokenChanged;
        Task<string> SignUp(UserSignUpVM user);
        Task<string> SignIn(UserSignInVM user);
        string GetAccessToken();
    }
}
