using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageYourBudget.DataAccessLayer.Models
{
    public class Expenditure
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public User User { get; set; }
        public ExpenditureCategory Category { get; set; }
        public int CategoryId { get; set; }
        public string UserId { get; set; }
    }
}
