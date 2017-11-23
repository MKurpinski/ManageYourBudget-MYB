using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ManageYourBudget.Dtos.Expenditure
{
    public class ExpendituresDto
    {
        public IList<ExpenditureDto> Expenditures { get; set; }
        [DataType(DataType.Date)]
        public DateTime From { get; set; }
        [DataType(DataType.Date)]
        public DateTime To { get; set; }
    }
}
