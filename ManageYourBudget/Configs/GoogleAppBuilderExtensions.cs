using ManageYourBudget.BusinessLogicLayer.Settings;
using Microsoft.Owin.Security.Facebook;
using Microsoft.Owin.Security.Google;
using Owin;

namespace ManageYourBudget.Configs
{
    public static class GoogleAppBuilderExtensions
    {
        public static void UseGoogle(this IAppBuilder app)
        {
            app.UseGoogleAuthentication(
                clientId: GoogleSettings.GoogleClientId,
                clientSecret: GoogleSettings.GoogleClientSecret);
        }
    }
}
