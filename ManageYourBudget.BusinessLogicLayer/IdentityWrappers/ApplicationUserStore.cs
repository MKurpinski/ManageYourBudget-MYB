using ManageYourBudget.DataAccessLayer;
using ManageYourBudget.DataAccessLayer.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ManageYourBudget.BusinessLogicLayer.IdentityWrappers
{
    public class ApplicationUserStore : UserStore<User>
    {
        public ApplicationUserStore(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}
