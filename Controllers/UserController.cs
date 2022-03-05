using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EntityLayer;

public class UserController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public UserController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }



    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }


    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }



    public IActionResult Privacy()
    {
        return View();
    }

}
