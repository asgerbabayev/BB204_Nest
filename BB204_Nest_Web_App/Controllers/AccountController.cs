using BB204_Nest_Web_App.Models;
using BB204_Nest_Web_App.ViewModels.AccountVms;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;

namespace BB204_Nest_Web_App.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid) return View();
            ApplicationUser newUser = new ApplicationUser()
            {
                Name = registerVM.Name,
                Surname = registerVM.Surname,
                Email = registerVM.Email,
                UserName = registerVM.UserName,
            };
            IdentityResult result = await _userManager.CreateAsync(newUser, registerVM.Password);
            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View();
            }
            await _userManager.AddToRoleAsync(newUser, "Admin");

            var token = await _userManager.GenerateEmailConfirmationTokenAsync(newUser);
            var confirmationUrl = Url.Action("ConfirmEmail", "Account",
                new { userId = newUser.Id, token = token }, Request.Scheme);
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("asgar.babayev@code.edu.az", "uqqbynlzcgukvtkh"),
                EnableSsl = true,
            };
            MailMessage mailMessage = new MailMessage("asgar.babayev@code.edu.az", newUser.Email, "Email Confirmation", $@"
<a href={confirmationUrl}>Verify Email</a>
");
            mailMessage.IsBodyHtml = true;

            smtpClient.Send(mailMessage);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid) return View();

            if (loginVM.UserNameOrEmail.Contains("@"))
            {
                ApplicationUser user = await _userManager.FindByEmailAsync(loginVM.UserNameOrEmail);
                if (user != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, loginVM.RememberMe, true);
                    if (result.IsLockedOut)
                    {
                        ModelState.AddModelError("", "Please wait");
                        return View();
                    }
                    if (!user.EmailConfirmed)
                    {
                        ModelState.AddModelError("", "Please confirm your email");
                        return View();
                    }
                    if (!result.Succeeded)
                    {
                        ModelState.AddModelError("", "Invalid Credentials");
                        return View();
                    }

                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ApplicationUser user = await _userManager.FindByNameAsync(loginVM.UserNameOrEmail);
                if (user != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, loginVM.RememberMe, true);
                    if (result.IsLockedOut)
                    {
                        ModelState.AddModelError("", "Please wait");
                        return View();
                    }
                    if (!user.EmailConfirmed)
                    {
                        ModelState.AddModelError("", "Please confirm your email");
                        return View();
                    }
                    if (!result.Succeeded)
                    {
                        ModelState.AddModelError("", "Invalid Credentials");
                        return View();
                    }

                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> CreateRole()
        {
            await _roleManager.CreateAsync(new IdentityRole { Name = "Admin" });
            await _roleManager.CreateAsync(new IdentityRole { Name = "Member" });
            return NoContent();
        }

        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return NotFound();

            var confirm = await _userManager.ConfirmEmailAsync(user, token);
            if (confirm.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}
