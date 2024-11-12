namespace TesteHortoInova.Models
{
    public class CarrinhoItem
    {
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }

        public decimal Total => Produto.Preco * Quantidade;
    }

}
