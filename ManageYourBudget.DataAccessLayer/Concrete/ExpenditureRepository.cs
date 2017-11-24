using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using ManageYourBudget.DataAccessLayer.Interfaces;
using ManageYourBudget.DataAccessLayer.Models;

namespace ManageYourBudget.DataAccessLayer.Concrete
{
    public class ExpenditureRepository: IExpenditureRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ExpenditureRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IList<Expenditure> GetExpendituresOfUserFromRange(string userId, DateTime from, DateTime to)
        {
            var expenditures = _dbContext.Expenditures.Include(x=>x.Category).Where(x => x.UserId == userId && x.Date >= from && x.Date <= to).ToList();
            return expenditures;
        }

        public void AddExpenditure(Expenditure expenditure)
        {
            _dbContext.Expenditures.Add(expenditure);
            _dbContext.SaveChanges();
        }

        public void UpdateExpenditure(Expenditure expenditure)
        {
            _dbContext.Entry(expenditure).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public Expenditure Get(int id)
        {
            return _dbContext.Expenditures.Include(x=>x.Category).SingleOrDefault(x => x.Id == id);
        }

        public void Delete(int id)
        {
            var expenditureToDelete = Get(id);
            if (expenditureToDelete == null)
            {
                return;
            }
            _dbContext.Expenditures.Remove(expenditureToDelete);
            _dbContext.SaveChanges();
        }
    }
}
