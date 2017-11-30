using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageYourBudget.DataAccessLayer.Models
{
    public class Expenditure
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public User User { get; set; }
        public ExpenditureCategory Category { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public string UserId { get; set; }
    }
}
