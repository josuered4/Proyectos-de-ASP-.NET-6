using Microsoft.VisualBasic;
using portafolio.Models;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace portafolio.Servicios.Email
{
    public class EmailService : IEmailService
    {
        public readonly IConfiguration configuration;

        public EmailService(IConfiguration configuration) => this.configuration = configuration;

        public async Task Enviar(Contacto contacto)
        {
            var apiKey = configuration.GetValue<string>("SENDGRID_API_KEY");
            var email = configuration.GetValue<string>("SENDGRID_FROM");
            var nombre = configuration.GetValue<string>("SENDGRID_NOMBRE");

            var cliente = new SendGridClient(apiKey);
            var from = new EmailAddress(email, nombre);
            var subject = $"El cliente {contacto.Email} necesita contactarte";
            var to = new EmailAddress(email, nombre);
            var mensaje = contacto.Mensaje;
            var contentHTML = @$"De: {contacto.Nombre} -
                Email: {contacto.Email}
                Mensaje: {contacto.Mensaje}";
            var singleEmail = MailHelper.CreateSingleEmail(from, to, subject, mensaje, contentHTML);
            var response = await cliente.SendEmailAsync(singleEmail);
        }
    }
}
