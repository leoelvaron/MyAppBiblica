using Microsoft.AspNetCore.Mvc;
using MyBiblia.Models;
using MyServicios.ViewModels;
using System.Diagnostics;


namespace MyBiblia.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // ACCIONES
        [HttpGet]
        public async Task<IActionResult> Lista_De_Libros()
        {
            try
            {
                var Url = "https://localhost:7150/api/Libros/Libros";

                using (var client = new HttpClient())
                {
                    var respuesta = await client.GetAsync(Url);

                    switch (respuesta.StatusCode)
                    {
                        case System.Net.HttpStatusCode.OK:

                            var myData = await respuesta.Content.ReadAsStringAsync();

                            return Json(new { result = myData });
                        case System.Net.HttpStatusCode.Accepted:
                            break;
                        case System.Net.HttpStatusCode.Found:
                            break;
                        case System.Net.HttpStatusCode.BadRequest:

                            return BadRequest();
                        case System.Net.HttpStatusCode.NotFound:
                            return NotFound();

                    }

                    return NotFound();
                }
            }
            catch (Exception err)
            {
                return NotFound(err.Message);
            }
        }

        // Eliminar
        [HttpDelete]
        public async Task<IActionResult> Eliminar(int id)
        {
            string Url = $"https://localhost:7150/api/Libros/Eliminar/{id}";

            using (var client = new HttpClient())
            {
               var res = await client.DeleteAsync(Url);

                if (res.IsSuccessStatusCode)
                {
                  var contenString = await res.Content.ReadAsStringAsync();

                    return Json(new { result = contenString });
                }
            }

            return Json(new { result = NotFound()});
        }

        // VISTAS
        public IActionResult Index()
        {
           
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}