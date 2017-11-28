using System.Web.Mvc;
using System.Web.Routing;

namespace ManageYourBudget.Attributes
{
    public class AnonymousOnlyAttribute: AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                filterContext.Result = new RedirectToRouteResult(new
                    RouteValueDictionary(new { controller = "Expenditure", action = "Index" }));
            }
        }
    }
}