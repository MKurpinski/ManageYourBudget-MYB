using System;
using ManageYourBudget.BusinessLogicLayer.Interfaces;
using ManageYourBudget.Dtos;

namespace ManageYourBudget.BusinessLogicLayer.Concrete
{
    public class DataService: IDataService
    {
        public DateRangeDto CalculateDateRange(DateTime? @from, DateTime? to)
        {
            var todayDate = DateTime.Today.Date;
            if (!from.HasValue)
            {
                from = new DateTime(todayDate.Year, todayDate.Month, 1);
            }
            if (!to.HasValue)
            {
                to = new DateTime(from.Value.Year, from.Value.Month, DateTime.DaysInMonth(todayDate.Year, todayDate.Month));
            }

            return new DateRangeDto
            {
                From = from.Value.Date,
                To = to.Value.Date
            };
        }
    }
}
