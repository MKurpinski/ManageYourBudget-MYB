using System.Collections.Generic;
using AutoMapper;
using ManageYourBudget.BusinessLogicLayer.Interfaces;
using ManageYourBudget.DataAccessLayer.Interfaces;
using ManageYourBudget.Dtos.Expenditure;

namespace ManageYourBudget.BusinessLogicLayer.Concrete
{
    public class CategoryService: ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public IList<ExpenditureCategoryDto> GetCategories()
        {
            var categories = _categoryRepository.GetCategories();
            return _mapper.Map<IList<ExpenditureCategoryDto>>(categories);
        }
    }
}
