using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManageYourBudget.DataAccessLayer.Interfaces;
using ManageYourBudget.DataAccessLayer.Models;

namespace ManageYourBudget.DataAccessLayer.Concrete
{
    public class CategoryRepository: ICategoryRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CategoryRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IList<ExpenditureCategory> GetCategories()
        {
            var categories = _dbContext.Categories.ToList();
            return categories;
        }
    }
}
