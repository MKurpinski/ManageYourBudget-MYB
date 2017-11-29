using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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

        public IList<ExpenditureCategory> GetCategories(string userId)
        {
            var categories = _dbContext.Categories.Where(x=>x.UserId == userId).ToList();
            return categories;
        }

        public void AddRange(IList<ExpenditureCategory> categories)
        {
            _dbContext.Categories.AddRange(categories);
            _dbContext.SaveChanges();
        }

        public void Update(ExpenditureCategory category)
        {
            _dbContext.Entry(category).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public ExpenditureCategory Add(ExpenditureCategory category)
        {
            _dbContext.Categories.Add(category);
            _dbContext.SaveChanges();
            return category;
        }
    }
}
