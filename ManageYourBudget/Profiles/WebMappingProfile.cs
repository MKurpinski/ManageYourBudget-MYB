﻿using AutoMapper;
using ManageYourBudget.Dtos.Auth;
using ManageYourBudget.Dtos.Expenditure;
using ManageYourBudget.Models;

namespace ManageYourBudget.Profiles
{
    public class WebMappingProfile: Profile
    {
        public WebMappingProfile()
        {
            CreateMap<RegisterViewModel, RegisterUserDto>();
            CreateMap<AddExpenditureViewModel, AddExpenditureDto>();
            CreateMap<EditExpenditureViewModel, EditExpenditureDto>();
            CreateMap<EditExpenditureDto, EditExpenditureViewModel>();
        }
    }
}