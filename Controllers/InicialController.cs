using Microsoft.AspNetCore.Mvc;
using TesteHortoInova.Services;
using TesteHortoInova.Models;
using System.Linq;
using System;

namespace TesteHortoInova.Controllers
{
    public class InicialController : Controller
    {
        private readonly AuthService _authService;
        private readonly EstoqueContext _context;
        public Boolean mensagemOn = false;

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
                return RedirectToAction("Index", "Carrinho");
            }
            else
            {
                TempData["AlertMessage"] = "Credenciais inválidas!";
                mensagemOn = true;
                ModelState.AddModelError(string.Empty, "Credenciais inválidas");
                return View(false);
            }
        }



        public IActionResult Index()
        {
            if (TempData["AlertMessage"] != null)
            {
                ViewBag.AlertMessage = TempData["AlertMessage"];
            }

            return View();
        }
        [HttpPost]
        public IActionResult Registrar(
    string email,
    string senha,
    string nome,
    DateTime datanascimento,
    string telefone,
    string celular,
    string rg,
    string cpf,
    string endereco,
    string observacoes)
        {
            // Verifica se o email já existe na tabela salvar_dados
            var usuarioExistente = _context.salvar_dados.FirstOrDefault(u => u.Email == email);
            if (usuarioExistente != null)
            {
                ViewBag.ErrorMessage = "Este email já está registrado.";
                return View();
            }

            // Salvar dados na tabela salvar_dados
            var novoUsuario = new salvar_dados
            {
                Email = email,
                Senha = senha,
                Salvar = 1
            };
            _context.salvar_dados.Add(novoUsuario);

            // Salvar dados na tabela clientefisico
            var novoCliente = new clientefisico
            {
                Nome = nome,
                DataNascimento = datanascimento,
                Telefone = telefone,
                Celular = celular,
                RG = rg,
                CPF = cpf,
                Endereco = endereco,
                Email = email,
                Observacoes = observacoes
            };
            _context.clientefisico.Add(novoCliente);

            // Salvar no banco de dados
            _context.SaveChanges();

            TempData["SuccessMessage"] = "Usuário registrado com sucesso! Agora você pode fazer login.";
            return RedirectToAction("Index", "Inicial");
        }
    }
}
