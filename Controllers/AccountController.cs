using RecordingOfViolations.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace RecordingOfViolations.Controllers
{
    public class AccountController : Controller
    {
        private readonly ViolationContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(ViolationContext context, UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [AllowAnonymous]
        public ActionResult Login(string? returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginModel model, string? returnUrl)
        {
            if (ModelState.IsValid)
            {
                Microsoft.AspNetCore.Identity.SignInResult result =
                    await _signInManager.PasswordSignInAsync(model.UserName, model.Password,
                        false, false);

                if (result.Succeeded)
                {
                    return Redirect(returnUrl ?? "/");
                }
                ModelState.AddModelError("", "Invalid username or password");
            }
            return View();
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user =
                    new IdentityUser { UserName = model.UserName, Email = model.Email };
                IdentityResult result =
                    await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    return RedirectToPage("/");
                }
                foreach (IdentityError err in result.Errors)
                {
                    ModelState.AddModelError("", err.Description);
                }
            }
            return View();
        }

        public async Task<ActionResult> LogOff()
        {
            ViewBag.ReturnUrl = null;
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
    }
}
