using System.Diagnostics;
using Backend_SSR_Servicios_Informaticos_JR.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend_SSR_Servicios_Informaticos_JR.Controllers
{
    public class LandingPageController : Controller
    {
        private readonly ILogger<LandingPageController> _logger;

        public LandingPageController(ILogger<LandingPageController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Servicios()
        {
            return View();
        }   
        public IActionResult Contacto()
        {
            return View();
        }
        public IActionResult SobreNosotros() { 
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
