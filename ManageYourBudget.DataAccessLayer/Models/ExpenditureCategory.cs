using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageYourBudget.DataAccessLayer.Models
{
    public class ExpenditureCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ChartColor { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
