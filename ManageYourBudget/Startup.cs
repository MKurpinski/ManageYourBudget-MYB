using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ManageYourBudget.Startup))]
namespace ManageYourBudget
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
