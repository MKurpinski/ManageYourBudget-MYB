using System.Collections.Generic;
using ManageYourBudget.Dtos.Expenditure;

namespace ManageYourBudget.BusinessLogicLayer.Interfaces
{
    public interface ICategoryService: IService
    {
        IList<ExpenditureCategoryDto> GetCategories(string userId);
        void AddDefaultCategories(string userId);
        void Edit(ExpenditureCategoryDto categoryDto);
        ExpenditureCategoryDto Add(ExpenditureCategoryDto category, string userId);
    }
}
