using System.Drawing;
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
                  new ExpenditureCategory
                  {
                      Name = "Bill",
                      ChartColor = ColorTranslator.ToHtml(Color.Aqua)
                  },
                  new ExpenditureCategory
                  {
                      Name = "Eating",
                      ChartColor = ColorTranslator.ToHtml(Color.Green)
                  },
                  new ExpenditureCategory
                  {
                      Name = "Car",
                      ChartColor = ColorTranslator.ToHtml(Color.Black)
                  },
                  new ExpenditureCategory
                  {
                      Name = "Entertainment",
                      ChartColor = ColorTranslator.ToHtml(Color.Chocolate)
                  },
                  new ExpenditureCategory
                  {
                      Name = "Education",
                      ChartColor = ColorTranslator.ToHtml(Color.Red)
                  },
                  new ExpenditureCategory { Name = "Other",
                      ChartColor = ColorTranslator.ToHtml(Color.RoyalBlue)
                  }
                );

        }
    }
}
