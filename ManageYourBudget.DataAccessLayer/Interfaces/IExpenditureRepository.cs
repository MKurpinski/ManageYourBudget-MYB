using System;
using System.Collections.Generic;
using ManageYourBudget.DataAccessLayer.Models;

namespace ManageYourBudget.DataAccessLayer.Interfaces
{
    public interface IExpenditureRepository: IRepository
    {
        IList<Expenditure> GetExpendituresOfUserFromRange(string userId, DateTime from, DateTime to);
        void AddExpenditure(Expenditure expenditure);
        void UpdateExpenditure(Expenditure expenditure);
        Expenditure Get(int id);
        bool Delete(int id);
    }
}
