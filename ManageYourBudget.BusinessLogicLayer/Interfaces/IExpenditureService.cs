using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManageYourBudget.Dtos.Expenditure;

namespace ManageYourBudget.BusinessLogicLayer.Interfaces
{
    public interface IExpenditureService: IService
    {
        ExpendituresDto GetUserExpendituresFromRange(string userId, DateTime? from, DateTime? to);
        void AddExpenditure(string userId, AddExpenditureDto expenditureDto);
        EditExpenditureDto GetExpenditure(int id);
        void EditExpenditure(EditExpenditureDto expenditureDto);
    }
}
