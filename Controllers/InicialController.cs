using Microsoft.AspNetCore.Mvc;

namespace TesteHortoInova.Controllers
{
    public class InicialController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
