using portafolio.Models;

namespace portafolio.Servicios
{
    public class RepositorioProyectos : IRepositorioProyectos
    {
        public List<ProyectoModel> getData()
        {
            return new List<ProyectoModel>{
                new ProyectoModel
                    {
                       Titulo = "Proyecto 1",
                       Descripcion = "Este es el proyecto uno",
                       ImagenURL = "/img/backgroubd.jpg",
                       Link = "url"
                    },
                new ProyectoModel
                    {
                       Titulo = "Proyecto 2",
                       Descripcion = "Este es el proyecto dos",
                       ImagenURL = "/img/backgroubd.jpg",
                       Link = "url"
                    },
                };
        }
    }
}
