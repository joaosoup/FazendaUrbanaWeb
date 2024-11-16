using System.ComponentModel.DataAnnotations.Schema;

namespace TesteHortoInova.Models
{
    public class salvar_dados
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int? Salvar { get; set; }
    }
}
