using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chart.Mvc.SimpleChart;
using ManageYourBudget.Dtos;
using ManageYourBudget.Dtos.Expenditure;
using ManageYourBudget.Dtos.Statistics;

namespace ManageYourBudget.BusinessLogicLayer.Interfaces
{
    public interface IExpenditureService: IService
    {
        ExpendituresDto GetUserExpendituresFromRange(string userId, DateTime? from, DateTime? to);
        void AddExpenditure(string userId, AddExpenditureDto expenditureDto);
        EditExpenditureDto GetExpenditureToEdit(int id);
        ExpenditureDto GetExpenditure(int id);
        void EditExpenditure(EditExpenditureDto expenditureDto);
        void Delete(int id);
        StatisticsDto GetStatistics(string id, DateRangeDto dataRange);
        IList<SimpleData> GetChartData(string userId, DateRangeDto dataRange);
    }
}
