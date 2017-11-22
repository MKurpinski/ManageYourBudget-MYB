using ManageYourBudget.DataAccessLayer;
using ManageYourBudget.DataAccessLayer.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataProtection;

namespace ManageYourBudget.BusinessLogicLayer.Concrete
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


    public class ApplicationSignInManager : SignInManager<User, string>
    {
        public ApplicationSignInManager(ApplicationUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }
    }

    public class ApplicationUserStore : UserStore<User>
    {
        public ApplicationUserStore(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}
