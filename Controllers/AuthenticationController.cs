
using System.Security.Claims;
using EntityLayer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

public class AuthenticationController : Controller
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;

    public AuthenticationController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }
    public IActionResult Index()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Register(User user)
    {
        var identityUser = new IdentityUser
        {
            UserName = user.FirstName + user.LastName,
            Email = user.Email,
        };
        var result = await _userManager.CreateAsync(identityUser, user.Password);
        if (result.Succeeded)
        {
            return RedirectToAction("Login", "User");
        }

        return RedirectToAction("Register", "User", user);
    }
    [HttpPost]
    public async Task<IActionResult> Login(string email, string password)
    {
        var user = await _userManager.FindByEmailAsync(email);
        if (user != null)
        {
            //sign in
            var resultSignIn = await _signInManager.PasswordSignInAsync(user, password, false, false);
            if (resultSignIn.Succeeded)
            {
                //successfull login
                return RedirectToAction("Index", "User");
            }
            else
            {
                return View();
            }
            //sign in
        }
        return View();
    }
    public async Task<IActionResult> LogOut()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index");
    }
    [Authorize]
    public async Task<IActionResult> Secret()
    {
        var user = await _userManager.GetUserAsync(HttpContext.User);
        return View(user);
    }
}