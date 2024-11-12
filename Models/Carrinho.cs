namespace TesteHortoInova.Models
{
    public class Carrinho
    {
        public List<CarrinhoItem> Itens { get; set; } = new List<CarrinhoItem>();

        public decimal TotalCarrinho => Itens.Sum(item => item.Total);

        public void AdicionarItem(Produto produto, int quantidade)
        {
            var item = Itens.FirstOrDefault(i => i.Produto.Id == produto.Id);
            if (item != null)
            {
                item.Quantidade += quantidade;
            }
            else
            {
                Itens.Add(new CarrinhoItem { Produto = produto, Quantidade = quantidade });
            }
        }

        public void RemoverItem(int produtoId)
        {
            var item = Itens.FirstOrDefault(i => i.Produto.Id == produtoId);
            if (item != null)
            {
                Itens.Remove(item);
            }
        }

        public void LimparCarrinho()
        {
            Itens.Clear();
        }
    }

}
