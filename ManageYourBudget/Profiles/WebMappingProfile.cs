using AutoMapper;
using ManageYourBudget.DataAccessLayer.Models;
using ManageYourBudget.Dtos.Auth;
using ManageYourBudget.Models;

namespace ManageYourBudget.Profiles
{
    public class WebMappingProfile: Profile
    {
        public WebMappingProfile()
        {
            CreateMap<RegisterViewModel, RegisterUserDto>();
        }
    }
}