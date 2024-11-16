using System.ComponentModel.DataAnnotations;

namespace TesteHortoInova.Models
{
    public class Produto
    {
        [Key]
        public int IdProduto { get; set; }  
        public string NomeProduto { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
   
    }
}
