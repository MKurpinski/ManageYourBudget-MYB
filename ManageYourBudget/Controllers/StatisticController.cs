using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ManageYourBudget.BusinessLogicLayer.Interfaces;
using ManageYourBudget.Dtos;
using Microsoft.AspNet.Identity;

namespace ManageYourBudget.Controllers
{
    [Authorize]
    public class StatisticController : Controller
    {
        private readonly IDataService _dataService;
        private readonly IExpenditureService _expenditureService;

        public StatisticController(IDataService dataService, IExpenditureService expenditureService)
        {
            _dataService = dataService;
            _expenditureService = expenditureService;
        }

        public ActionResult Index(DateTime? from, DateTime? to)
        {
            var dataRange = _dataService.CalculateDateRange(from, to);
            return View(dataRange);
        }

        [HttpPost]
        public ActionResult Index(DateRangeDto viewModel)
        {
            return RedirectToAction("Index",
                new { to = viewModel.To, from = viewModel.From });
        }

        [ChildActionOnly]
        public ActionResult GetDataForChart(DateRangeDto dataRange)
        {
            var statistics = _expenditureService.GetChartData(User.Identity.GetUserId(), dataRange);
            return View("_ChartPartial", statistics);
        }

        [ChildActionOnly]
        public ActionResult GetStatistics(DateRangeDto dataRange)
        {
            var statistics = _expenditureService.GetStatistics(User.Identity.GetUserId(), dataRange);
            return View("_StatisticsPartial", statistics);
        }
    }
}