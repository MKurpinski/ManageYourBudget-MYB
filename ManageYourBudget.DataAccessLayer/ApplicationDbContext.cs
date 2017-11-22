using ManageYourBudget.DataAccessLayer.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ManageYourBudget.DataAccessLayer
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
    }
}