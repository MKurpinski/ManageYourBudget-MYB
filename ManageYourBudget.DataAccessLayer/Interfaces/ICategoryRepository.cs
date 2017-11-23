using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManageYourBudget.DataAccessLayer.Models;

namespace ManageYourBudget.DataAccessLayer.Interfaces
{
    public interface ICategoryRepository: IRepository
    {
        IList<ExpenditureCategory> GetCategories();
    }
}
