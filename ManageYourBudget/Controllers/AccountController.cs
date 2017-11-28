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
            return View();
        }

        [HttpPost]
        [AnonymousOnly]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await _authService.PasswordSignInAsync(model.Email, model.Password, model.RememberMe);

            if (result == SignInStatus.Success)
            {
                return RedirectToLocal(returnUrl);
            }

            ModelState.AddModelError("", @"Invalid login attempt.");
            return View(model);
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AnonymousOnly]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = _mapper.Map<RegisterUserDto>(model);
            var result = await _authService.CreateUserWithPasswordAsync(user, model.Password);

            if (!result.Succeeded)
            {
                return View(model);
            }

            return RedirectToAction("Login");
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