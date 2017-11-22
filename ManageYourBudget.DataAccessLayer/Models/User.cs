using Microsoft.AspNet.Identity.EntityFramework;

namespace ManageYourBudget.DataAccessLayer.Models
{
    public class User: IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
