using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using ManageYourBudget.BusinessLogicLayer.Interfaces;
using ManageYourBudget.DataAccessLayer.Interfaces;
using ManageYourBudget.DataAccessLayer.Models;
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

        public IList<ExpenditureCategoryDto> GetCategories(string userId)
        {
            var categories = _categoryRepository.GetCategories(userId);
            return _mapper.Map<IList<ExpenditureCategoryDto>>(categories);
        }

        public void AddDefaultCategories(string userId)
        {
            var defaultCategories = DefaultCategories.GetDefaultCategories();
            defaultCategories = defaultCategories.Select(category =>
            {
                category.UserId = userId;
                return category;
            }).ToList();
            _categoryRepository.AddRange(defaultCategories);
        }

        public void Edit(ExpenditureCategoryDto categoryDto)
        {
            var category = _mapper.Map<ExpenditureCategory>(categoryDto);
            _categoryRepository.Update(category);
        }

        public ExpenditureCategoryDto Add(ExpenditureCategoryDto categoryDto, string userId)
        {
            var category = _mapper.Map<ExpenditureCategory>(categoryDto);
            category.UserId = userId;
            var addedCategory = _categoryRepository.Add(category);
            return _mapper.Map<ExpenditureCategoryDto>(addedCategory);
        }
    }
}
