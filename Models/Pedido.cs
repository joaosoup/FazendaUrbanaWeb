namespace TesteHortoInova.Models
{
    public class Pedido
    {
        public int IdPedido { get; set; }
        public DateTime DataPedido { get; set; } = DateTime.Now;
        public decimal Total { get; set; }
        public List<ItemPedido> Itens { get; set; } = new List<ItemPedido>();
    }

    public class ItemPedido
    {
        public int IdItemPedido { get; set; }
        public int IdProduto { get; set; }
        public string NomeProduto { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
        public decimal Total => Preco * Quantidade;
    }
}
