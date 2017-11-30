using System.Threading.Tasks;
using System.Web.Mvc;
using AutoMapper;
using ManageYourBudget.Attributes;
using ManageYourBudget.BusinessLogicLayer.Interfaces;
using ManageYourBudget.Dtos.Auth;
using ManageYourBudget.ExternalLogins;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using ManageYourBudget.Models;

namespace ManageYourBudget.Controllers
{

    public class AccountController : Controller
    {
        private readonly IAuthService _authService;
        private readonly IAuthenticationManager _authenticationManager;
        private readonly IMapper _mapper;
        private const string LOGIN_KEY = "login_key";
        private const string LOGIN_ERROR_KEY = "login_key_error";
        private const string REGISTER_KEY = "register_key";

        public AccountController(IAuthService authService, IMapper mapper, IAuthenticationManager authenticationManager)
        {
            _authService = authService;
            _mapper = mapper;
            _authenticationManager = authenticationManager;
        }

        [AnonymousOnly]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            var loginViewModel = TempData[LOGIN_KEY] as LoginViewModel;
            ViewBag.Error = TempData[LOGIN_ERROR_KEY] as string;
            return View(loginViewModel);
        }

        [HttpPost]
        [AnonymousOnly]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return RedirectInvalidLoginAttempt(model, returnUrl);
            }

            var result = await _authService.PasswordSignInAsync(model.Email, model.Password, model.RememberMe);

            if (result == SignInStatus.Success)
            {
                return RedirectToLocal(returnUrl);
            }

            return RedirectInvalidLoginAttempt(model, returnUrl);
        }

        public ActionResult Register()
        {
            var registerViewModel = TempData[REGISTER_KEY] as RegisterViewModel;
            return View(registerViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AnonymousOnly]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToRegisterInvalidAttempt(model);
            }

            var user = _mapper.Map<RegisterUserDto>(model);
            var result = await _authService.CreateUserWithPasswordAsync(user, model.Password);

            if (result.Succeeded)
            {
                return RedirectToAction("Login");
            }

            TempData[REGISTER_KEY] = model;
            return RedirectToAction("Register");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AnonymousOnly]
        public ActionResult ExternalLogin(string provider, string returnUrl)
        {
            return new ChallengeResult(provider, Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl }));
        }

        [AnonymousOnly]
        public async Task<ActionResult> ExternalLoginCallback(string returnUrl)
        {
            var loginInfo = await _authenticationManager.GetExternalLoginInfoAsync();

            if (loginInfo == null)
            {
                return RedirectToAction("Login");
            }

            var result = await _authService.ExternalSignInAsync(loginInfo);

            if (result == SignInStatus.Success)
            {
                return RedirectToLocal(returnUrl);
            }

            await _authService.LogInOrRegisterUserAsync(loginInfo);

            return RedirectToAction("Index", "Expenditure");
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            _authenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Expenditure");
        }

        public JsonResult IsEmailAvailable(string email)
        {
            var isAvailable = _authService.IsEmailAvailable(email);
            return Json(isAvailable, JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        [ChildActionOnly]
        public ActionResult GetUserInfo()
        {
            var userDto = _authService.GetUserData(User.Identity.GetUserId());
            var viewModel = _mapper.Map<UserInfoViewModel>(userDto);
            return PartialView("_UserInfoPartial", viewModel);
        }

        private ActionResult RedirectToRegisterInvalidAttempt(RegisterViewModel model)
        {
            TempData[REGISTER_KEY] = model;
            return RedirectToAction("Register");
        }

        private ActionResult RedirectInvalidLoginAttempt(LoginViewModel model, string returnUrl)
        {
            TempData[LOGIN_KEY] = model;
            TempData[LOGIN_ERROR_KEY] = "Email or password provided is incorrect!";
            return RedirectToAction("Login", new { returnUrl });
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Expenditure");
        }
    }
}