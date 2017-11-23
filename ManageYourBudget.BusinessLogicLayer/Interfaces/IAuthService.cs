using System.Threading.Tasks;
using ManageYourBudget.Dtos.Auth;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace ManageYourBudget.BusinessLogicLayer.Interfaces
{
    public interface IAuthService : IService
    {
        Task<SignInStatus> PasswordSignInAsync(string email, string password, bool rememberMe);
        Task<SignInStatus> ExternalSignInAsync(ExternalLoginInfo loginInfo);
        Task SignUserAsync(RegisterUserDto user);
        Task<IdentityResult> CreateUserWithPasswordAsync(RegisterUserDto user, string password);
        Task LogInOrRegisterUserAsync(ExternalLoginInfo loginInfo);
    }
}
