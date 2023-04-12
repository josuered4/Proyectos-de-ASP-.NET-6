using portafolio.Models;

namespace portafolio.Servicios.Email
{
    public interface IEmailService
    {
        Task Enviar(Contacto contacto);
    }
}
