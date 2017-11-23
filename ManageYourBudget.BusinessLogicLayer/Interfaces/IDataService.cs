using System;
using ManageYourBudget.Dtos;

namespace ManageYourBudget.BusinessLogicLayer.Interfaces
{
    public interface IDataService: IService
    {
        DateRangeDto CalculateDateRange(DateTime? from, DateTime? to);
    }
}
