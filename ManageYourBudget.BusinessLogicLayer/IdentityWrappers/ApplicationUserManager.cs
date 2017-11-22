using ManageYourBudget.DataAccessLayer.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security.DataProtection;

namespace ManageYourBudget.BusinessLogicLayer.IdentityWrappers
{
    public class ApplicationUserManager : UserManager<User>
    {
        public ApplicationUserManager(IUserStore<User> store)
            : base(store)
        {
            CreateUserValidator();

            CreatePasswordValidator();

            UserLockoutEnabledByDefault = false;

            UserTokenProvider =
                new DataProtectorTokenProvider<User>(new DpapiDataProtectionProvider().Create("ASP.NET Identity"));
        }

        private void CreatePasswordValidator()
        {
            PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
            };
        }

        private void CreateUserValidator()
        {
            UserValidator = new UserValidator<User>(this)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };
        }
    }
}
