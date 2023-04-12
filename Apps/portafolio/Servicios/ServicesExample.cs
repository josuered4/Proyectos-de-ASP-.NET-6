namespace portafolio.Servicios
{
    public class ServiceSingleTon
    {
        public ServiceSingleTon()
        {
            GetGuid = Guid.NewGuid(); //Guid genera un string aleatorio
        }

        public Guid GetGuid { get; private set; }
    }

    public class ServiceScoped
    {
        public ServiceScoped()
        {
            GetGuid = Guid.NewGuid(); //Guid genera un string aleatorio
        }

        public Guid GetGuid { get; private set; }
    }

    public class ServiceTransient
    {
        public ServiceTransient()
        {
            GetGuid = Guid.NewGuid(); //Guid genera un string aleatorio
        }

        public Guid GetGuid { get; private set; }
    }

    //Estos seran servicos o un ejemplo de los tipos de servicos 
    //que podemos poner en nuestro inyertor de dependencias 
    // que es mejor poner con interfaces pero en este caso seran 
    //con clases
}
