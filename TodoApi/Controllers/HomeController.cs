using Microsoft.AspNetCore.Mvc;

namespace TodoApi.Controllers;

[Route("/")]
public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}