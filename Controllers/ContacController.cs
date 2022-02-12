
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using Portafolio.Models;
using System.Threading.Tasks;

namespace Portafolio.Controllers
{
 [Route("Contactos")]
    public class ContacController : Controller
    {
        private  Contactaccion accion;
        private EnviarMail _EnviarMail;
        private readonly IToastNotification _toas;

        // private readonly IToastNotification _toastNotification;
      
        public ContacController(Contactaccion contactaccion, IToastNotification notifier,EnviarMail enviarMail )
        {
            _EnviarMail = enviarMail;
            _toas = notifier;
            this.accion = contactaccion;
        }
       
         [Route("/Contactos")]
        public IActionResult Form()
        {
         
            return View();
        }
      
                [HttpPost]
        public async Task < ActionResult> Form(Contact contact)
        {
           
            if (ModelState.IsValid)
            {
           var usuario = await accion.nuevomensaje1(contact);
                          await _EnviarMail.validar(contact); 
                _toas.AddSuccessToastMessage("Mensaje enviado!");
                return RedirectToAction("Form", "Contac");
              
            }
            else {
                _toas.AddErrorToastMessage("No fue Posible enviar el mensaje!");
                   }
            return View();
        }  
        
    }
}
