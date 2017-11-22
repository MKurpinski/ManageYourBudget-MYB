using AutoMapper;
using ManageYourBudget.DataAccessLayer.Models;
using ManageYourBudget.Dtos.Auth;

namespace ManageYourBudget.BusinessLogicLayer.Profiles
{
    public class BusinessLogicProfile: Profile
    {
        public BusinessLogicProfile()
        {
            CreateMap<RegisterUserDto, User>();
            CreateMap<User, RegisterUserDto>();
        }
    }
}
