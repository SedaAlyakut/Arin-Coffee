using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WEBUI.Entities;
using WEBUI.LoginModels;

namespace WEBUI.Controllers
{
    public class AdminLoginController : Controller
    {

        private UserManager<CustomIdentityUser> _userManager;
        private RoleManager<CustomIdentityRole> _roleManager;
        private SignInManager<CustomIdentityUser> _signInManager;

        public AdminLoginController(SignInManager<CustomIdentityUser> signInManager, RoleManager<CustomIdentityRole> roleManager, UserManager<CustomIdentityUser> userManager)
        {
            _signInManager = signInManager;
            _roleManager = roleManager;
            _userManager = userManager;
        }


        public ActionResult Index()
        {
            return RedirectToAction("Login", "AdminLogin");
        }
        //[Authorize(Roles = "Admin")]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        //[Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                CustomIdentityUser user = new CustomIdentityUser
                {
                    UserName = registerViewModel.UserName,
                    Email = registerViewModel.Email,
                    IpAdress = Request.HttpContext.Connection.RemoteIpAddress.ToString(),
                };
                IdentityResult result = _userManager.CreateAsync(user, registerViewModel.Password).Result;
                if (result.Succeeded)
                {
                    var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var confirmationLink = Url.Action("ConfirmEmail", "Email", new { token, email = user.Email }, Request.Scheme);
                    bool emailResponse = Helpers.SendMailService.sendMail(user.Email, confirmationLink, "Confirm Your Mail For Sugomi Account");
                    if (!_roleManager.RoleExistsAsync("Admin").Result)
                    {
                        CustomIdentityRole role = new CustomIdentityRole
                        {
                            Name = "Admin",
                            OlusturulmaTarihi = System.DateTime.Now
                    };
                        IdentityResult roleResult = _roleManager.CreateAsync(role).Result;
                        if (!roleResult.Succeeded)
                        {
                            ModelState.AddModelError("", "We can't add the role!");
                            return View(registerViewModel);
                        }
                    }
                    _userManager.AddToRoleAsync(user, "Admin").Wait();
                    return RedirectToAction("Login", "AdminLogin");
                }

            }
            return View(registerViewModel);
        }

        public ActionResult Login()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                CustomIdentityUser appUser = await _userManager.FindByEmailAsync(loginViewModel.Email);

                if (appUser != null)
                {
                    await _signInManager.SignOutAsync();
                    var result = _signInManager.PasswordSignInAsync(appUser, loginViewModel.Password, loginViewModel.RememberMe, false).Result;

                    if (result.Succeeded)
                        return RedirectToAction("Index", "Admin");

                    bool emailStatus = await _userManager.IsEmailConfirmedAsync(appUser);
                    if (emailStatus == false)
                    {
                        ModelState.AddModelError(nameof(loginViewModel.Email), "Email is unconfirmed, please confirm it first");
                    }
                }
                ModelState.AddModelError(nameof(loginViewModel.Email), "Login Failed: Invalid Email or password");
            }

            return View(loginViewModel);
        }


        public ActionResult LogOff()
        {
            _signInManager.SignOutAsync().Wait();
            return RedirectToAction("Index", "Home");
        }

    }
}
