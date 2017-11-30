using System.Web.Mvc;

namespace ManageYourBudget.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult NotFound()
        {
            return View();
        }
    }
}