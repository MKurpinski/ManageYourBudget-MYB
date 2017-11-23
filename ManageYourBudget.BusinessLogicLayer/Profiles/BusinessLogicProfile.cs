using AutoMapper;
using ManageYourBudget.DataAccessLayer.Models;
using ManageYourBudget.Dtos.Auth;
using ManageYourBudget.Dtos.Expenditure;

namespace ManageYourBudget.BusinessLogicLayer.Profiles
{
    public class BusinessLogicProfile: Profile
    {
        public BusinessLogicProfile()
        {
            CreateMap<RegisterUserDto, User>().ForMember(dest => dest.UserName, opts => opts.MapFrom(src => src.Email));
            CreateMap<Expenditure, ExpenditureDto>();
            CreateMap<ExpenditureCategory, ExpenditureCategoryDto>();
            CreateMap<AddExpenditureDto, Expenditure>();
            CreateMap<Expenditure, EditExpenditureDto>();
            CreateMap<EditExpenditureDto, Expenditure>();
        }
    }
}
