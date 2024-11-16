namespace TesteHortoInova.Models
{
    public class Pedido
    {
        public int IdPedido { get; set; }
        public decimal ValorTotal { get; set; }
        public int Quantidade { get; set; } // Adicione isso na classe Pedido

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
