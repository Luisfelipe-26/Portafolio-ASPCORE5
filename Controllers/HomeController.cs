
using Microsoft.AspNetCore.Mvc;

namespace Portafolio.Controllers
{

    public class HomeController : Controller
    {
        [Route("")]   
        [Route("Inicio")]
        public IActionResult Index()
        {
     
            return View();
        }
        public IActionResult about()
        {
            return View();   
        }

        public IActionResult Services()
        {
            return View();
        }

    }
}
