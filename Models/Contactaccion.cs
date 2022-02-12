using Portafolio.Data;
using System.Threading.Tasks;

namespace Portafolio.Models
{
    public class Contactaccion : IForm
    {
        private readonly AppDbContext context;
        public Contactaccion(AppDbContext appDbContext)
        {
            this.context = appDbContext;
        }
        public async Task<Contact> nuevomensaje1(Contact contact)
        {
            ENCRYPTMD5 enc = new ENCRYPTMD5();
            var email = enc.Encrypt(contact.Email);
            var mensaje = enc.Encrypt(contact.Mensaje);
            var nombre = enc.Encrypt(contact.Nombre);
            var asunto = enc.Encrypt(contact.Asunto);
            context.Contactos.Add(new Contact {IdMensaje = contact.IdMensaje, Nombre = nombre,Email = email, Asunto = asunto,Mensaje =mensaje });
            context.SaveChanges();
            return contact;
        }

        Contact IForm.nuevomensaje(Contact contact)
        {
            throw new System.NotImplementedException();
        }
    }
}
