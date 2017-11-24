using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManageYourBudget.DataAccessLayer.Models;

namespace ManageYourBudget.DataAccessLayer.Interfaces
{
    public interface IExpenditureRepository: IRepository
    {
        IList<Expenditure> GetExpendituresOfUserFromRange(string userId, DateTime from, DateTime to);
        void AddExpenditure(Expenditure expenditure);
        void UpdateExpenditure(Expenditure expenditure);
        Expenditure Get(int id);
        void Delete(int id);
    }
}
