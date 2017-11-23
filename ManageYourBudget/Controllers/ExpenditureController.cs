using System;
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

        public ExpenditureController(IExpenditureService expenditureService, ICategoryService categoryService, IMapper mapper)
        {
            _expenditureService = expenditureService;
            _categoryService = categoryService;
            _mapper = mapper;
        }

        public ActionResult Index(DateTime? from, DateTime? to)
        {
            var expendituresDto = _expenditureService.GetUserExpendituresFromRange(User.Identity.GetUserId(), from, to);
            var allCategories = _categoryService.GetCategories();

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
            var allCategories = _categoryService.GetCategories();
            return View(new AddExpenditureViewModel
            {
                Categories = allCategories
            });
        }

        [HttpPost]
        public ActionResult Add(AddExpenditureViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = _categoryService.GetCategories();
                return View(model);
            }
            var expenditureDto = _mapper.Map<AddExpenditureDto>(model);
            _expenditureService.AddExpenditure(User.Identity.GetUserId(), expenditureDto);

            return RedirectToAction("Index", new { from = model.Date});
        }

        public ActionResult Edit(int id)
        {
            var expenditureToEdit = _expenditureService.GetExpenditure(id);
            var allCategories = _categoryService.GetCategories();
            var expenditureViewModel = _mapper.Map<EditExpenditureViewModel>(expenditureToEdit);
            expenditureViewModel.Categories = allCategories;
            return View(expenditureViewModel);
        }

        [HttpPost]
        public ActionResult Edit(EditExpenditureViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = _categoryService.GetCategories();
                return View(model);
            }
            var expenditureDto = _mapper.Map<EditExpenditureDto>(model);
            _expenditureService.EditExpenditure(expenditureDto);

            return RedirectToAction("Index", new { from = model.Date });
        }
    }
}