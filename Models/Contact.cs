using System.ComponentModel.DataAnnotations;

namespace Portafolio.Models
{
    public class Contact
    {
        [Key]
        public int IdMensaje { get; set; }
        [Display(Name ="Nombre"), Required(ErrorMessage ="Debe Escribir un Nombre."),StringLength(50,ErrorMessage = "Debe escribir al menos 3 caracteres.  ",MinimumLength =3)]

        public string Nombre { get; set; }
        [Display(Name = "Email"), Required(ErrorMessage = "Debe Escribir un Correo Electronico."),DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Display(Name = "Asunto"), Required(ErrorMessage = "Debe Escribir un Asunto."), StringLength(50, ErrorMessage = "Debe escribir al menos 3 caracteres. ", MinimumLength = 3)]
        public string Asunto { get; set; }
        [Display(Name = "Mensaje"), Required(ErrorMessage = "Debe Escribir un Mensaje."), StringLength(50, ErrorMessage = "Debe escribir al menos 5 caracteres.", MinimumLength = 5)]
        public string Mensaje { get; set; }
    }
}
