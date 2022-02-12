using Portafolio.Data;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Portafolio.Models
{
    public class EnviarMail : IData
    {
        private readonly AppDbContext context;
        public EnviarMail( AppDbContext appDb)
        {
                context = appDb;
        }
        public Emaildata guardar(Emaildata emaildata)
        {
            ENCRYPTMD5 enc = new ENCRYPTMD5();
            var mail = enc.Encrypt(emaildata.Email);
            var pass = enc.Encrypt(emaildata.Password);
            context.Emaildata1.Add(new Emaildata {Email = mail, Password = pass,Id = emaildata.Id });
            context.SaveChanges();
            return emaildata;
        }

        public async Task validar( Contact contact)
        {
            ENCRYPTMD5 enc = new ENCRYPTMD5();
            var data = context.Emaildata1.Find(1);
            var data2 = context.Emaildata1.Find(2);
            var email = enc.Descrypt(data.Email);
            var email2 = enc.Descrypt(data2.Email);
            var pass = enc.Descrypt(data.Password);
            var Asunto = contact.Asunto;
            var mensaje = 
               " ID del mensaje = "+ Convert.ToString(contact.IdMensaje) +
               "<br/> Nombre del Cliente = "+ contact.Nombre +
               "<br/> Correo del Cliente = " + contact.Email +
               "<br/> Mensaje del Cliente " + contact.Mensaje;
          
            string respuestaautomatica = 
                "Estimados señoras y señores: "+ contact.Nombre +
                "&nbsp;-&nbsp;" + contact.Email + 
                "<br/> Muchas gracias por su mensaje, me estare contactando con ustedes tan pronto sea posible." +
                " <br/> Pasen buenas y muchas gracias por su correo.";
            string asuntorespuesta = "Luis Felipe - Luisdeveloper2000 (respuesta automática)";
          
            MailMessage mail = new MailMessage(email,email + ","+ email2, Asunto,mensaje);
            MailMessage respuesta = new MailMessage(email,contact.Email, asuntorespuesta,respuestaautomatica);
            respuesta.IsBodyHtml = true;
            mail.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.EnableSsl = true;
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 25;
            smtp.Credentials = new NetworkCredential(email, pass);

            try
            {
              smtp.Send(mail);
                smtp.Send(respuesta);
            }
            catch (Exception ex)
            {
                throw new Exception("No se ha podido enviar el email", ex.InnerException);
            }
            finally
            {
                smtp.Dispose();
            }

           



      }
    }
}
