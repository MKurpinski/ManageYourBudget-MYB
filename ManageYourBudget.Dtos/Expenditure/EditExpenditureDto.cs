using System;

namespace ManageYourBudget.Dtos.Expenditure
{
    public class EditExpenditureDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public int CategoryId { get; set; }
        public DateTime Date { get; set; }
        public string UserId { get; set; }
    }
}
