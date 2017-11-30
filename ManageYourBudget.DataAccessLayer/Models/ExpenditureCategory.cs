using System.ComponentModel.DataAnnotations;

namespace ManageYourBudget.DataAccessLayer.Models
{
    public class ExpenditureCategory
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        [Required]
        public string ChartColor { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
