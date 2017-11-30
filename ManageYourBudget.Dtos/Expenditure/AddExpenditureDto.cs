using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ManageYourBudget.Dtos.Expenditure
{
    public class AddExpenditureDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public int CategoryId { get; set; }
        public DateTime Date { get; set; }
    }
}
