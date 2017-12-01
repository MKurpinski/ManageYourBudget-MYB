using System;
using System.Net;
using System.Web.Mvc;
using AutoMapper;
using ManageYourBudget.BusinessLogicLayer.Interfaces;
using ManageYourBudget.Dtos.Expenditure;
using ManageYourBudget.Models;
using Microsoft.AspNet.Identity;

namespace ManageYourBudget.Controllers
{
    [Authorize]
    public class ExpenditureController : Controller
    {
        private readonly IExpenditureService _expenditureService;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        private const string ADD_KEY = "add_key";

        public ExpenditureController(IExpenditureService expenditureService, ICategoryService categoryService, IMapper mapper)
        {
            _expenditureService = expenditureService;
            _categoryService = categoryService;
            _mapper = mapper;
        }

        public ActionResult Index(DateTime? from, DateTime? to)
        {
            var userId = User.Identity.GetUserId();

            var expendituresDto = _expenditureService.GetUserExpendituresFromRange(userId, from, to);
            var allCategories = _categoryService.GetCategories(userId);

            var expendituresViewModel = new ExpendituresViewModel
            {
                ExpendituresDto = expendituresDto,
                AvailableCategories = allCategories
            };

            return View(expendituresViewModel);
        }

        [HttpPost]
        public ActionResult Index(ExpendituresViewModel viewModel)
        {
            return RedirectToAction("Index",
                new {to = viewModel.ExpendituresDto.To, from = viewModel.ExpendituresDto.From});
        }

        public ActionResult Add()
        {
            var allCategories = _categoryService.GetCategories(User.Identity.GetUserId());

            var viewModel = TempData[ADD_KEY] as AddExpenditureViewModel;

            if (viewModel == null)
            {
                return View(new AddExpenditureViewModel
                {
                    Categories = allCategories
                });
            }

            viewModel.Categories = allCategories;
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Add(AddExpenditureViewModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData[ADD_KEY] = model;
                return RedirectToAction("Add");
            }

            var expenditureDto = _mapper.Map<AddExpenditureDto>(model);
            _expenditureService.AddExpenditure(User.Identity.GetUserId(), expenditureDto);

            return RedirectToAction("Index", new { from = new DateTime(model.Date.Year, model.Date.Month, 1)});
        }

        public ActionResult Edit(int id)
        {
            var expenditureToEdit = _expenditureService.GetExpenditureToEdit(id);
            if (expenditureToEdit == null)
            {
                return RedirectToAction("NotFound", "Error");
            }
            var allCategories = _categoryService.GetCategories(User.Identity.GetUserId());

            var expenditureViewModel = _mapper.Map<EditExpenditureViewModel>(expenditureToEdit);
            expenditureViewModel.Categories = allCategories;

            return View(expenditureViewModel);
        }

        [HttpPost]
        public ActionResult Edit(EditExpenditureViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Edit", new { id = model.Id });
            }

            var expenditureDto = _mapper.Map<EditExpenditureDto>(model);
            _expenditureService.EditExpenditure(expenditureDto);

            return RedirectToAction("Index", new { from = model.Date });
        }

        public ActionResult Details(int id)
        {
            var expenditure = _expenditureService.GetExpenditure(id);
            if (expenditure == null)
            {
                return RedirectToAction("NotFound", "Error");
            }
            return View(expenditure);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var result = _expenditureService.Delete(id);
            return new HttpStatusCodeResult(result ? HttpStatusCode.NoContent : HttpStatusCode.BadRequest);
        }
    }
}