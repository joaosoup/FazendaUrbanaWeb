using System.Linq;
using TesteHortoInova.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace TesteHortoInova.Services
{
    public class AuthService
    {
        private readonly EstoqueContext _context;

        public AuthService(EstoqueContext context)
        {
            _context = context;
        }

        public bool Authenticate(string email, string senha)
        {
            return _context.SalvarDados.Any(user => user.Email == email && user.Senha == senha);
        }
    }
}
