using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ManageYourBudget.Dtos.Expenditure;

namespace ManageYourBudget.Models
{
    public class ExpendituresViewModel
    {
        public ExpendituresDto ExpendituresDto { get; set; }
        public IList<ExpenditureCategoryDto> AvailableCategories { get; set; }
    }
}