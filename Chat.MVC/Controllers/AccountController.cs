using Buisness.Interop;
using Buisness.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Repository.Data;
using System.Security.Claims;

namespace Chat.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly Context _context;
        private readonly IUserService _userService;

        public AccountController(Context context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if(ModelState.IsValid)
            {
                var user = _userService.IsRegistered(model);
                if (user != null)
                {
                    await Authenticate(user.UserName);
                    return RedirectToAction("Index", "Chat");
                }
                ModelState.AddModelError("Error", "Неверный логин и(или) пароль");
                return View(model);
            }
            return View(model);
        }
        private async Task Authenticate(string userName)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if(ModelState.IsValid)
            {
                if (_userService.IsRegistered(new LoginModel() { Login = model.UserName, Password = model.Password }) == null)
                {
                    if (_userService.IsRegistered(new LoginModel() { Login = model.PhoneNumber, Password = model.Password }) == null)
                    {
                        _userService.CreateUser(model);
                        await Authenticate(model.UserName);
                        return RedirectToAction("Index", "Chat");
                    }
                    else
                        ModelState.AddModelError("Error", "Пользователь с таким номером телефона уже существует");
                }
                else
                    ModelState.AddModelError("Error", "Пользователь с таким логином уже существует");
            }
            return View(model);
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}
