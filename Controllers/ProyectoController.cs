using Microsoft.AspNetCore.Mvc;

namespace Portafolio.Controllers
{
    public class ProyectoController : Controller
    {   [Route("Proyectos")]    
        public IActionResult Proyectos()
        {
            return View();
        }
    } 
} 