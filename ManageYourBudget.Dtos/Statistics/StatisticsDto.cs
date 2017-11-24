using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManageYourBudget.Dtos.Expenditure;

namespace ManageYourBudget.Dtos.Statistics
{
    public class StatisticsDto
    {
        public decimal SumOfExpenditures { get; set; }
        public decimal ExpidituresCount { get; set; }
        public IList<ExpenditureDto> MostExpensiveExpenditures { get; set; }
    }
}
