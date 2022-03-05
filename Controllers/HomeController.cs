using System.Diagnostics;
using DataAccessLayer;
using EntityLayer;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IdentityDbContext _identiyContext;


    public HomeController(ILogger<HomeController> logger, IdentityDbContext identityDbContext)
    {
        _identiyContext = identityDbContext;
        _logger = logger;
    }

    public IActionResult Index()
    {

        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }


}
