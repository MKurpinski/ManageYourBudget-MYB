using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Chart.Mvc.SimpleChart;
using ManageYourBudget.BusinessLogicLayer.Interfaces;
using ManageYourBudget.DataAccessLayer.Interfaces;
using ManageYourBudget.DataAccessLayer.Models;
using ManageYourBudget.Dtos;
using ManageYourBudget.Dtos.Expenditure;
using ManageYourBudget.Dtos.Statistics;

namespace ManageYourBudget.BusinessLogicLayer.Concrete
{
    public class ExpenditureService : IExpenditureService
    {
        private readonly IExpenditureRepository _expenditureRepository;
        private readonly IDataService _dataService;
        private readonly IMapper _mapper;
        private const int NUMBER_OF_MOST_EXPENSIVE_EXPENDITURES = 3;

        public ExpenditureService(IExpenditureRepository expenditureRepository, IDataService dataService, IMapper mapper)
        {
            _expenditureRepository = expenditureRepository;
            _dataService = dataService;
            _mapper = mapper;
        }

        public ExpendituresDto GetUserExpendituresFromRange(string userId, DateTime? @from, DateTime? to)
        {
            var calculatedDateRange = _dataService.CalculateDateRange(from, to);
            var listOfExpenditures = _expenditureRepository.GetExpendituresOfUserFromRange(userId, calculatedDateRange.From, calculatedDateRange.To);
            var ependituresDto = CreateExpendituresDto(listOfExpenditures, calculatedDateRange);

            return ependituresDto;
        }

        public void AddExpenditure(string userId, AddExpenditureDto expenditureDto)
        {
            var expenditure = _mapper.Map<Expenditure>(expenditureDto);
            expenditure.UserId = userId;
            _expenditureRepository.AddExpenditure(expenditure);
        }

        public EditExpenditureDto GetExpenditureToEdit(int id)
        {
            var expenditure = _expenditureRepository.Get(id);
            var expeditureDto = _mapper.Map<EditExpenditureDto>(expenditure);
            return expeditureDto;
        }

        public ExpenditureDto GetExpenditure(int id)
        {
            var expenditure = _expenditureRepository.Get(id);
            var expeditureDto = _mapper.Map<ExpenditureDto>(expenditure);
            return expeditureDto;
        }

        public void EditExpenditure(EditExpenditureDto expenditureDto)
        {
            var expenditure = _mapper.Map<Expenditure>(expenditureDto);
            _expenditureRepository.UpdateExpenditure(expenditure);
        }

        public bool Delete(int id)
        {
            return _expenditureRepository.Delete(id);
        }

        public StatisticsDto GetStatistics(string id, DateRangeDto dataRange)
        {
            var expendirues = _expenditureRepository.GetExpendituresOfUserFromRange(id, dataRange.From, dataRange.To);
            var statisticsDto = new StatisticsDto
            {
                ExpidituresCount = expendirues.Count,
                SumOfExpenditures = expendirues.Sum(x => x.Amount),
                MostExpensiveExpenditures = _mapper.Map<List<ExpenditureDto>>(expendirues.OrderBy(x => x.Amount).Take(NUMBER_OF_MOST_EXPENSIVE_EXPENDITURES).ToList())
            };
            return statisticsDto;
        }

        public IList<SimpleData> GetChartData(string userId, DateRangeDto dataRange)
        {
            var experditures =
                _expenditureRepository.GetExpendituresOfUserFromRange(userId, dataRange.From, dataRange.To);

            var data = experditures.GroupBy(x => x.Category)
                                   .Select(x => new SimpleData
                                   {
                                       Color = x.Key.ChartColor,
                                       Label = x.Key.Name,
                                       Value = x.Sum(y => (double)y.Amount)
                                   });
            return data.ToList();
        }

        private ExpendituresDto CreateExpendituresDto(IList<Expenditure> listOfExpenditures, DateRangeDto calculatedDateRange)
        {
            return new ExpendituresDto
            {
                Expenditures = _mapper.Map<List<ExpenditureDto>>(listOfExpenditures),
                From = calculatedDateRange.From,
                To = calculatedDateRange.To
            };
        }
    }
}
