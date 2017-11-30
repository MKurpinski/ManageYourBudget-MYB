using Microsoft.Build.Framework;

namespace ManageYourBudget.Dtos.Expenditure
{ 
    public class ExpenditureCategoryDto
    {
        private const string BLUE_COLOR = "#2b42ef";
        public ExpenditureCategoryDto()
        {
            ChartColor = BLUE_COLOR;
        }
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string UserId { get; set; }
        public string ChartColor { get; set; }
    }
}
