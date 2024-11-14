using Microsoft.AspNetCore.Mvc;
using TesteHortoInova.Models;
using System.Linq;

namespace TesteHortoInova.Controllers
{
    public class LoginController : Controller
    {
        private readonly EstoqueContext _context;

        public LoginController(EstoqueContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View(); // Exibe a página de login
        }

        [HttpPost]
        public IActionResult Entrar(string email, string senha)
        {
            var usuario = _context.SalvarDados.SingleOrDefault(u => u.Email == email && u.Senha == senha);
            if (usuario != null)
            {
                // Redireciona para o carrinho após o login bem-sucedido
                return RedirectToAction("Index", "Carrinho"); // Substitua "Index" pela ação que exibe a página de carrinho
            }

            TempData["Error"] = "Credenciais inválidas.";
            return RedirectToAction("Login"); // Redireciona de volta para o login caso falhe
        }

        [HttpGet]
        public IActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registrar(string email, string senha)
        {
            var usuarioExistente = _context.SalvarDados.SingleOrDefault(u => u.Email == email);
            if (usuarioExistente != null)
            {
                TempData["Error"] = "Este e-mail já está cadastrado.";
                return RedirectToAction("Registrar");
            }

            var novoUsuario = new SalvarDados { Email = email, Senha = senha, Salvar = 1 };
            _context.SalvarDados.Add(novoUsuario);
            _context.SaveChanges();

            TempData["Success"] = "Cadastro realizado com sucesso!";
            return RedirectToAction("Login");
        }
    }
}
