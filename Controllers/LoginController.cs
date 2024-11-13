using Microsoft.AspNetCore.Mvc;
using TesteHortoInova.Models;

namespace TesteHortoInova.Controllers
{
    public class LoginController : Controller
    {
        private readonly EstoqueContext _context;

        public LoginController(EstoqueContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Entrar(string email, string senha)
        {
            var usuario = _context.SalvarDados.SingleOrDefault(u => u.Email == email && u.Senha == senha);
            if (usuario != null)
            {
                // Lógica para redirecionar o usuário após login bem-sucedido
                return RedirectToAction("Index", "Home");
            }

            TempData["Error"] = "Credenciais inválidas.";
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registrar(string email, string senha)
        {
            var usuario = new SalvarDados { Email = email, Senha = senha };
            _context.SalvarDados.Add(usuario);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }