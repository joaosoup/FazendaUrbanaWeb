using Microsoft.AspNetCore.Mvc;
using TesteHortoInova.Services;
using TesteHortoInova.Models;
using System.Linq;

namespace TesteHortoInova.Controllers
{
    public class InicialController : Controller
    {
        private readonly AuthService _authService;
        private readonly EstoqueContext _context;

        public InicialController(AuthService authService, EstoqueContext context)
        {
            _authService = authService;
            _context = context;
        }

        [HttpPost]
        public IActionResult Entrar(string email, string senha)
        {
            Console.WriteLine($"Entrou no método Entrar. Email: {email}, Senha: {senha}");

            if (_authService.Authenticate(email, senha))
            {
                TempData["AlertMessage"] = "Login realizado com sucesso!";
                // Redireciona para a página de Carrinho/Index após o login bem-sucedido
                return RedirectToAction("Index", "Carrinho"); // Certifique-se de que o controlador Carrinho está correto
            }
            else
            {
                TempData["AlertMessage"] = "Credenciais inválidas!";
                // Exibe mensagem de erro na tela de login
                ModelState.AddModelError(string.Empty, "Credenciais inválidas");
                return View("Index");
            }
        }



        public IActionResult Index()
        {
            // Verificando e passando a mensagem de alerta, se houver
            if (TempData["AlertMessage"] != null)
            {
                ViewBag.AlertMessage = TempData["AlertMessage"];
            }

            return View();
        }
    }
}
