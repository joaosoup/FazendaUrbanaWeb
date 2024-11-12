namespace TesteHortoInova.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string NomeProduto { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoVenda { get; set; }
        public decimal CustoMarketplace { get; set; }
    }
}
