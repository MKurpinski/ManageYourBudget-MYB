using AutoMapper;
using ManageYourBudget.BusinessLogicLayer.Profiles;
using ManageYourBudget.Profiles;

namespace ManageYourBudget
{
    public static class MappingConfiguration
    {
        public static MapperConfiguration InitializeAutoMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new WebMappingProfile());
                cfg.AddProfile(new BusinessLogicProfile());
            });

            return config;
        }
    }
}