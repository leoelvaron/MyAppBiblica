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
      // Obtener todos los libros de la biblia
        [Route("Libros")]
        [HttpGet]
        public List<VM_Libros> Lista_De_Libros()
        {
            // Lista de libros biblicos
            List<VM_Libros> lista = new() {
                new VM_Libros(){ Id = 1, Nombre = "Genesis",      Descripcion = "Creacion del mundo", Capitulos = 50 },
                new VM_Libros(){ Id = 2, Nombre = "Exodo",        Descripcion = "Israel en Egipto",   Capitulos = 40 },
                new VM_Libros(){ Id = 3, Nombre = "Leviticos",    Descripcion = "Las leyes",          Capitulos = 27 },
                new VM_Libros(){ Id = 4, Nombre = "Numeros",      Descripcion = "Segunda leyes",      Capitulos = 36 },
                new VM_Libros(){ Id = 5, Nombre = "Deuteronomio", Descripcion = "Mandamientos",       Capitulos = 34 },
            };

          return lista;
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
            return $"Se ha eliminado el libro de ID: {id}";
        }
    }
}
