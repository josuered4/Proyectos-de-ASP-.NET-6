using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using portafolio.Models;
using portafolio.Servicios;
using portafolio.Servicios.Email;

namespace portafolio.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IRepositorioProyectos repositorioProyectos;

    //Eyectamos los servicios
    private readonly ServiceTransient serviceTransient;
    private readonly ServiceScoped serviceScoped;
    private readonly ServiceSingleTon serviceSingleTon;

    private readonly ServiceTransient serviceTransient2;
    private readonly ServiceScoped serviceScoped2;
    private readonly ServiceSingleTon serviceSingleTon2; 

    private readonly IConfiguration configuration;
    private readonly IEmailService emailService;

    public HomeController(
        ILogger<HomeController> logger, 
        IRepositorioProyectos repositorioProyectos, 
        ServiceTransient serviceTransient,
        ServiceScoped serviceScoped, 
        ServiceSingleTon serviceSingleTon,
        ServiceTransient serviceTransient2,
        ServiceScoped serviceScoped2,
        ServiceSingleTon serviceSingleTon2, 
        IConfiguration configuration,
        IEmailService emailService
        )
    {
        _logger = logger;
        this.repositorioProyectos = repositorioProyectos;
        this.serviceTransient = serviceTransient;
        this.serviceScoped = serviceScoped;
        this.serviceSingleTon = serviceSingleTon;
        this.serviceTransient2 = serviceTransient2;
        this.serviceScoped2 = serviceScoped2;
        this.serviceSingleTon2 = serviceSingleTon2;

        this.configuration = configuration;
        this.emailService = emailService;
    }

    public IActionResult Index()
    {
        
        ServiceExample example = new ServiceExample()
        {
            ServiceTransient = serviceTransient.GetGuid,
            ServiceScoped = serviceScoped.GetGuid,
            ServiceSingleTon = serviceSingleTon.GetGuid
        };
        ServiceExample example2 = new ServiceExample()
        {
            ServiceTransient = serviceTransient2.GetGuid,
            ServiceScoped = serviceScoped2.GetGuid,
            ServiceSingleTon = serviceSingleTon2.GetGuid
        };


        HomeIndex proyectos = new HomeIndex() 
        { 
            Proyectos = repositorioProyectos.getData(), 
            serviceExample = example,
            serviceExample2 = example2
        };

        return View(proyectos);
    }

    public IActionResult Privacy()
    {

        var developer = configuration.GetValue<string>("Developer");

        _logger.LogTrace("Este es un mensaje de LogTrace");
        _logger.LogDebug("Este es un mensaje de LogDebug");
        _logger.LogInformation("Este es un mensaje de LogInformation");
        _logger.LogWarning("Este es un mensaje de LogWarning");
        _logger.LogError("Este es un mensaje de LogError");
        _logger.LogCritical("Este es un mensaje de LogCritical");
        _logger.LogCritical("...............................................................");
        _logger.LogCritical(developer);
        return View();
        //return View("NamePage"); indicar una vista en especidico 
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public IActionResult Proyectos()
    {
        var proyectos = repositorioProyectos.getData();
        return View(proyectos);
    }

    [HttpGet]
    public IActionResult Contacto()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Contacto(Contacto contacto)
    {
        await emailService.Enviar(contacto);
        return RedirectToAction("Gracias");
    }

    public IActionResult Gracias()
    {
        return View();
    }
}
