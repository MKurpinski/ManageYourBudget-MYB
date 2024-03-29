﻿using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Facebook;
using ManageYourBudget.BusinessLogicLayer.Enums;
using ManageYourBudget.BusinessLogicLayer.IdentityWrappers;
using ManageYourBudget.BusinessLogicLayer.Interfaces;
using ManageYourBudget.BusinessLogicLayer.Settings;
using ManageYourBudget.DataAccessLayer.Models;
using ManageYourBudget.Dtos.Auth;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace ManageYourBudget.BusinessLogicLayer.Concrete
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationSignInManager _signInManager;
        private readonly ApplicationUserManager _userManager;
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;
        private const string EMAIL_KEY = "email";
        private const string FIRSTNAME_KEY = "first_name";
        private const string LASTNAME_KEY = "last_name";

        public AuthService(ApplicationSignInManager signInManager, ApplicationUserManager userManager, IMapper mapper, ICategoryService categoryService)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _mapper = mapper;
            _categoryService = categoryService;
        }

        public async Task<SignInStatus> PasswordSignInAsync(string email, string password, bool rememberMe)
        {
            return await _signInManager.PasswordSignInAsync(email, password, rememberMe, false);
        }

        public async Task<SignInStatus> ExternalSignInAsync(ExternalLoginInfo loginInfo)
        {
            return await _signInManager.ExternalSignInAsync(loginInfo, false);
        }

        public async Task SignUserAsync(RegisterUserDto registerUserDto)
        {
            var user = _mapper.Map<User>(registerUserDto);
            await SignUserAsync(user);
        }

        public async Task SignUserAsync(User user)
        {
            await _signInManager.SignInAsync(user, false, false);
        }

        public async Task<IdentityResult> CreateUserWithPasswordAsync(RegisterUserDto registerUserDto, string password)
        {
            var user = _mapper.Map<User>(registerUserDto);
            var result = await _userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                _categoryService.AddDefaultCategories(user.Id);
            }
            return result;
        }

        public async Task LogInOrRegisterUserAsync(ExternalLoginInfo loginInfo)
        {
            var user = GetUserData(loginInfo);

            var userFromDb = GetUserByEmail(user.Email);

            if (userFromDb == null)
            {
                await CreateExternalUser(loginInfo, user);
            }
            else
            {
                await SignInExternalUser(loginInfo, userFromDb);
            }
        }

        private User GetUserData(ExternalLoginInfo loginInfo)
        {
            User user = null;

            if(!Enum.TryParse<LoginProvider>(loginInfo.Login.LoginProvider, out var providerEnum))
            {
                return null;
            }

            switch (providerEnum)
            {
                case LoginProvider.Facebook:
                {
                    user = GetUserDataFromFacebook(loginInfo, FacebookSettings.FacebookTokenClaim, FacebookSettings.FacebookQuery);
                    break;
                }
                case LoginProvider.Google:
                {
                    user = GetUserDataFromGoogle(loginInfo);
                    break;
                }
            }
            return user;
        }

        private User GetUserDataFromGoogle(ExternalLoginInfo loginInfo)
        {
            var firstName = loginInfo.ExternalIdentity.Claims.First(x => x.Type == ClaimTypes.GivenName);
            var lastName = loginInfo.ExternalIdentity.Claims.First(x => x.Type == ClaimTypes.Surname);
            var emailAdress = loginInfo.ExternalIdentity.Claims.First(x => x.Type == ClaimTypes.Email);
            var user = new User
            {
                FirstName = firstName?.Value,
                Email = emailAdress?.Value,
                LastName = lastName?.Value,
                UserName = emailAdress?.Value
            };
            return user;
        }

        public UserDto GetUserData(string id)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.Id == id);
            var userDto = _mapper.Map<UserDto>(user);
            return userDto;
        }

        public bool IsEmailAvailable(string email)
        {
            return GetUserByEmail(email) == null;
        }

        private async Task SignInExternalUser(ExternalLoginInfo loginInfo, User userFromDb)
        {
            await SignUserAsync(userFromDb);
            await _userManager.AddLoginAsync(userFromDb.Id, loginInfo.Login);
        }

        private async Task CreateExternalUser(ExternalLoginInfo loginInfo, User user)
        {
            await _userManager.CreateAsync(user);
            await _userManager.AddLoginAsync(user.Id, loginInfo.Login);
            _categoryService.AddDefaultCategories(user.Id);
            await SignUserAsync(user);
        }

        private static User GetUserDataFromFacebook(ExternalLoginInfo loginInfo, string facebookTokenClaim,
            string facebookQuery)
        {
            var accessToken = loginInfo.ExternalIdentity.FindFirstValue(facebookTokenClaim);
            var fbClient = new FacebookClient(accessToken);
            var userInfo = fbClient.Get(facebookQuery) as dynamic;

            var user = new User
            {
                FirstName = userInfo[FIRSTNAME_KEY],
                Email = userInfo[EMAIL_KEY],
                LastName = userInfo[LASTNAME_KEY],
                UserName = userInfo[EMAIL_KEY]
            };
            return user;
        }

        public User GetUserByEmail(string email)
        {
            return _userManager.Users.FirstOrDefault(x => x.Email == email);
        }
    }
}
