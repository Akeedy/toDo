using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EntityLayer;

namespace start.Controllers;

public class MyTaskController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public MyTaskController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }


    [HttpPost]
    public IActionResult Index(MyTask myTask)
    {

        myTask.TaskStatus = false;
        myTask.DeadLine = DateTime.SpecifyKind(myTask.DeadLine, DateTimeKind.Utc);
        Console.Write(myTask.DeadLine);

        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
}
