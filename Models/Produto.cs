using System.ComponentModel.DataAnnotations;

namespace TesteHortoInova.Models
{
    public class Produto
    {
        [Key] // Necessário se o nome não segue o padrão
        public int IdProduto { get; set; }  // ou public int ProdutoId { get; set; } (sem o [Key])
        public string NomeProduto { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
   
    }
}
