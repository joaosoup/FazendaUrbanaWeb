using Microsoft.EntityFrameworkCore;
using TesteHortoInova.Models;

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
            // Verificar se o usuário existe e a senha está correta
            var user = _context.salvar_dados.FirstOrDefault(u => u.Email == email && u.Senha == senha);

            if (user == null)
            {
                Console.WriteLine("Usuário não encontrado no banco");
            }
            else
            {
                Console.WriteLine("Usuário encontrado: " + user.Email);
            }

            // Retorna true se encontrar um usuário com as credenciais corretas, caso contrário, false
            return user != null;
        }
    }
}
