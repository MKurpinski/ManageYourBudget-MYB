using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ManageYourBudget.BusinessLogicLayer.Interfaces;
using ManageYourBudget.DataAccessLayer.Interfaces;
using ManageYourBudget.DataAccessLayer.Models;
using ManageYourBudget.Dtos;
using ManageYourBudget.Dtos.Expenditure;

namespace ManageYourBudget.BusinessLogicLayer.Concrete
{
    public class ExpenditureService: IExpenditureService
    {
        private readonly IExpenditureRepository _expenditureRepository;
        private readonly IDataService _dataService;
        private readonly IMapper _mapper;

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

        public EditExpenditureDto GetExpenditure(int id)
        {
            var expenditure = _expenditureRepository.Get(id);
            var expeditureDto = _mapper.Map<EditExpenditureDto>(expenditure);
            return expeditureDto;
        }

        public void EditExpenditure(EditExpenditureDto expenditureDto)
        {
            var expenditure = _mapper.Map<Expenditure>(expenditureDto);
            _expenditureRepository.UpdateExpenditure(expenditure);
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
