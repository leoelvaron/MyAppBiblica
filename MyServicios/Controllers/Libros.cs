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
        public List<VM_Libros> MiLista = new();


      // Obtener todos los libros de la biblia
        [Route("Libros")]
        [HttpGet]
        public List<VM_Libros> Lista_De_Libros()
        {
            MiLista.Add(new VM_Libros() { Nombre = "Genesis", Descripcion = "La creacion", Capitulos = 50, Id = 1 });
            MiLista.Add(new VM_Libros() { Nombre = "Exodo", Descripcion = "El pueblo de Israel", Capitulos = 40, Id = 2 });
            MiLista.Add(new VM_Libros() { Nombre = "Levitico", Descripcion = "Las leyes 1", Capitulos = 27, Id = 3 });
            MiLista.Add(new VM_Libros() { Nombre = "Numeros", Descripcion = "Leyes para el pueblo", Capitulos = 36, Id = 4 });
            MiLista.Add(new VM_Libros() { Nombre = "Deuteronomio", Descripcion = "Las leyes", Capitulos = 34, Id = 5 });

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
