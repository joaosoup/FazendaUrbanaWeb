using Microsoft.AspNetCore.Mvc;
using TesteHortoInova.Services;

namespace TesteHortoInova.Controllers
{
    public class InicialController : Controller
    {
        private readonly AuthService _authService;

        public InicialController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public IActionResult Entrar(string email, string senha)
        {
            if (_authService.Authenticate(email, senha))
            {
                return RedirectToAction("Carrinho", "Carrinho"); // Redireciona para a página do Carrinho
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Credenciais inválidas");
                return View("Index"); // Volta para a tela de login se falhar
            }
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
