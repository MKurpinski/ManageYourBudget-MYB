using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ManageYourBudget.Dtos.Expenditure;

namespace ManageYourBudget.Models
{
    public class EditExpenditureViewModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public string Title { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than 0")]
        public decimal Amount { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public string UserId { get; set; }
        public IList<ExpenditureCategoryDto> Categories { get; set; }
    }
}