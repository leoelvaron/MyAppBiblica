using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyServicios.ViewModels;
using System.Net;

namespace MyServicios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Libros : ControllerBase
    {
        public List<VM_Libros> MiLista { get; set; }


      // Obtener todos los libros de la biblia
        [Route("Libros")]
        [HttpGet]
        public List<VM_Libros> Lista_De_Libros()
        {
            this.MiLista = new List<VM_Libros>() { new VM_Libros() {Id = 1, Nombre = "juan" ,Descripcion = "libro", Capitulos = 3 } };   
            //MiLista.Add(new VM_Libros() { Id = 1, Nombre = "Genesis", Descripcion = "Creacion del mundo", Capitulos = 50 });
            //MiLista.Add(new VM_Libros() { Id = 2, Nombre = "Exodo", Descripcion = "Israel en Egipto", Capitulos = 40 });
            //MiLista.Add(new VM_Libros() { Id = 3, Nombre = "Leviticos", Descripcion = "Las leyes", Capitulos = 27 });
            //MiLista.Add(new VM_Libros() { Id = 4, Nombre = "Numeros", Descripcion = "Segunda leyes", Capitulos = 36 });
            //MiLista.Add(new VM_Libros() { Id = 5, Nombre = "Deuteronomio", Descripcion = "Mandamientos", Capitulos = 34 });
            
            return MiLista;
        }

        // Agregar Libro, ojo tomando en cuenta que a la biblia no se le agrega libros, aqui solo agregue 5.
        [Route("Agregar")]
        [HttpPost]
        public VM_Libros AgregarLibros(VM_Libros libro)
        {    
            return libro;
        }

        [Route("Buscar_ID/{id}")]
        [HttpGet]
        public VM_Libros AgregarLibros(int id)
        {
            VM_Libros libro = new()
            {
                Id = id,
                Nombre = "Titulo del libro",
                Descripcion = "Descripcion",
                Capitulos = id + 3
            };
            return libro;
        }

        [Route("Editar/{id}")]
        [HttpPut] 
        public VM_Libros Editar(int id)
        {
            VM_Libros libro = new()
            {
                Id = id,
                Nombre = "Ejemplo se edito el titulo",
                Descripcion = "Ejemplo se edito la descripcion",
                Capitulos = id + 3
            };

            return libro;
        }

        [Route("Eliminar/{id}")]
        [HttpDelete]
        public string Eliminar(int id)
        {

             MiLista.Remove(new VM_Libros() { Id = id});

            return $"Se ha eliminado el libro de ID: {id}";
        }
    }
}
