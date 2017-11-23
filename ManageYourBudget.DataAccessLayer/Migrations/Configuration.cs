using ManageYourBudget.DataAccessLayer.Models;

namespace ManageYourBudget.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ManageYourBudget.DataAccessLayer.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ManageYourBudget.DataAccessLayer.ApplicationDbContext context)
        {
                context.Categories.AddOrUpdate(
                  p => p.Name,
                  new ExpenditureCategory { Name = "Bill" },
                  new ExpenditureCategory { Name = "Eating" },
                  new ExpenditureCategory { Name = "Car" },
                  new ExpenditureCategory { Name = "Entertainment" },
                  new ExpenditureCategory { Name = "Education" },
                  new ExpenditureCategory { Name = "Other" }
                );

        }
    }
}
