using System.Threading.Tasks;
using ManageYourBudget.BusinessLogicLayer.Settings;
using Microsoft.Owin.Security.Facebook;
using Owin;

namespace ManageYourBudget.Configs
{
    public static class FacebookAppBuilderExtensions
    {
        public static void UseFacebook(this IAppBuilder app)
        {
            var facebookAuthenticationOptions = new FacebookAuthenticationOptions
            {
                AppId = FacebookSettings.FacebookAppId,
                AppSecret = FacebookSettings.FacebookAppSecret,
                Provider = new FacebookAuthenticationProvider
                {
                    OnAuthenticated = context =>
                    {
                        context.Identity.AddClaim(
                            new System.Security.Claims.Claim(FacebookSettings.FacebookTokenClaim, context.AccessToken));
                        return Task.FromResult(true);
                    }
                }
            };
            facebookAuthenticationOptions.Scope.Add(FacebookSettings.FacebookEmailScope);
            app.UseFacebookAuthentication(facebookAuthenticationOptions);
        }
    }
}