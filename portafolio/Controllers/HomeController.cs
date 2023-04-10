using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using portafolio.Models;
using portafolio.Servicios;

namespace portafolio.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IRepositorioProyectos repositorioProyectos;

    public HomeController(ILogger<HomeController> logger, IRepositorioProyectos repositorioProyectos)
    {
        _logger = logger;
        this.repositorioProyectos = repositorioProyectos;
    }

    public IActionResult Index()
    {
        ViewBag.Nombre = "Josue Reyes P";
        ViewData["Nombre"] = "Josué Isaac Reyes Pérez";
        Person person = new Person();
        person.Name = "Josué Reyes";
        person.Edad = 23;

        HomeIndex proyectos = new HomeIndex(){ Proyectos = repositorioProyectos.getData() };
        return View(proyectos);
    }

    public IActionResult Privacy()
    {
        return View();
        //return View("NamePage"); indicar una vista en especidico 
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
