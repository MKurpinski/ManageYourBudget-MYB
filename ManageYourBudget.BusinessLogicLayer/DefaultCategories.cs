using System.Collections.Generic;
using System.Drawing;
using ManageYourBudget.DataAccessLayer.Models;

namespace ManageYourBudget.BusinessLogicLayer
{
    public static class DefaultCategories
    {
        public static IList<ExpenditureCategory> GetDefaultCategories()
        {
            return new List<ExpenditureCategory>
            {
                new ExpenditureCategory
                {
                    Name = "Bill",
                    ChartColor = "#cc99ff"
                },
                new ExpenditureCategory
                {
                    Name = "Eating",
                    ChartColor = "#cc0099"
                },
                new ExpenditureCategory
                {
                    Name = "Car",
                    ChartColor = "#66ff99"
                },
                new ExpenditureCategory
                {
                    Name = "Entertainment",
                    ChartColor = "#000080"
                },
                new ExpenditureCategory
                {
                    Name = "Education",
                    ChartColor = "#ccccff"
                },
                new ExpenditureCategory { Name = "Other",
                    ChartColor = "#ffff4d"
                }
            };
        }
    }
}
