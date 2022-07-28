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
            var Url = "https://localhost:7150/api/Libros/Libros";

            using (var client = new HttpClient())
            {
                var respuesta = await client.GetAsync(Url);

                switch (respuesta.StatusCode)
                {
                    case System.Net.HttpStatusCode.OK:

                        var myData = await respuesta.Content.ReadAsStringAsync();

                        return Json(new {result = myData});

                    case System.Net.HttpStatusCode.Created:
                        break;
                    case System.Net.HttpStatusCode.Accepted:
                        break;
                    case System.Net.HttpStatusCode.Found:
                        break;

                    case System.Net.HttpStatusCode.BadRequest:
                        break;

                    case System.Net.HttpStatusCode.NotFound:
                        break;

                }

                return null;
            }
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