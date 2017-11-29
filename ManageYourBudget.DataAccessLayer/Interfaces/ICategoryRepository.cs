using System.Collections.Generic;
using ManageYourBudget.DataAccessLayer.Models;

namespace ManageYourBudget.DataAccessLayer.Interfaces
{
    public interface ICategoryRepository: IRepository
    {
        IList<ExpenditureCategory> GetCategories(string userId);
        void AddRange(IList<ExpenditureCategory> category);
        void Update(ExpenditureCategory category);
        ExpenditureCategory Add(ExpenditureCategory category);
    }
}
