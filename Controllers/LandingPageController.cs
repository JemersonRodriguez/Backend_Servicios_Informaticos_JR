using System.Diagnostics;
using Backend_SSR_Servicios_Informaticos_JR.Dtos;
using Backend_SSR_Servicios_Informaticos_JR.Models;
using Backend_SSR_Servicios_Informaticos_JR.Response;
using Backend_SSR_Servicios_Informaticos_JR.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Backend_SSR_Servicios_Informaticos_JR.Controllers
{
    public class LandingPageController : Controller
    {
        private readonly ILogger<LandingPageController> _logger;
        private readonly IEnviarCorreoService _enviarCorreoService;

        public LandingPageController(ILogger<LandingPageController> logger, IEnviarCorreoService enviarCorreoService)
        {
            _logger = logger;
            _enviarCorreoService = enviarCorreoService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Servicios()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Contacto()
        {
            return View();
        }
        [HttpGet]
        public IActionResult SobreNosotros() { 
            return View();
        }
        [HttpGet]
        public IActionResult Privacy()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EnviarCorreo(EnvioCorreoDto request) {
            if (!ModelState.IsValid) {
                return BadRequest();
            }
            try {
                ResponseData response = await _enviarCorreoService.EnviarCorreoAsync(request);
                if (response.Exito) {
                    return Ok(response);
                }
                return BadRequest(response);
            } catch (Exception) { 
                _logger.LogError("Error al procesar la solicitud de envio de correo.");
                return StatusCode(500, "Error interno del servidor.");
            } 
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
