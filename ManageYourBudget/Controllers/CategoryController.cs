using System.Net;
using System.Web.Mvc;
using ManageYourBudget.BusinessLogicLayer.Interfaces;
using ManageYourBudget.Dtos.Expenditure;
using Microsoft.AspNet.Identity;

namespace ManageYourBudget.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public ActionResult Index()
        {
            var categories = _categoryService.GetCategories(User.Identity.GetUserId());
            return View(categories);
        }

        [HttpPost]
        public ActionResult Edit(ExpenditureCategoryDto category)
        {
            if (!ModelState.IsValid)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            _categoryService.Edit(category);
            return new HttpStatusCodeResult(HttpStatusCode.NoContent);
        }

        [HttpPost]
        public ActionResult Add(ExpenditureCategoryDto category)
        {
            if (!ModelState.IsValid)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var addedCategory = _categoryService.Add(category, User.Identity.GetUserId());
            return PartialView("_CategoryPartial", addedCategory);
        }
    }
}