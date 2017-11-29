using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Build.Framework;

namespace ManageYourBudget.Dtos.Expenditure
{
    public class ExpenditureCategoryDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string UserId { get; set; }
        public string ChartColor { get; set; }
    }
}
