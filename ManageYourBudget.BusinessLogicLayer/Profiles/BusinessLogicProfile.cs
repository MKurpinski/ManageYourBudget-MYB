using AutoMapper;
using ManageYourBudget.DataAccessLayer.Models;
using ManageYourBudget.Dtos.Auth;

namespace ManageYourBudget.BusinessLogicLayer.Profiles
{
    public class BusinessLogicProfile: Profile
    {
        public BusinessLogicProfile()
        {
            CreateMap<RegisterUserDto, User>().ForMember(dest => dest.UserName, opts => opts.MapFrom(src => src.Email));
        }
    }
}
