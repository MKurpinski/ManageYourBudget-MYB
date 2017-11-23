﻿using System.Collections.Generic;
using ManageYourBudget.Dtos.Expenditure;

namespace ManageYourBudget.BusinessLogicLayer.Interfaces
{
    public interface ICategoryService: IService
    {
        IList<ExpenditureCategoryDto> GetCategories();
    }
}
