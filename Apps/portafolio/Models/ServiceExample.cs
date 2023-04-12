namespace portafolio.Models
{
    public class ServiceExample
    {
        public Guid ServiceTransient { get; set; }
        public Guid ServiceScoped { get; set; }
        public Guid ServiceSingleTon { get; set; }
    }
}
