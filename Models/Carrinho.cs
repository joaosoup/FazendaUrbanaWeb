namespace TesteHortoInova.Models
{
    public class Carrinho
    {
        public List<CarrinhoItem> Itens { get; set; } = new List<CarrinhoItem>();

        public decimal TotalCarrinho => Itens.Sum(item => item.Total);

        public void AdicionarItem(Produto produto, int quantidade)
        {
            var item = Itens.FirstOrDefault(i => i.Produto.IdProduto == produto.IdProduto);
            if (item != null)
            {
                item.Quantidade += quantidade;
            }
            else
            {
                Itens.Add(new CarrinhoItem { Produto = produto, Quantidade = quantidade });
            }
        }

        public void RemoverItem(int idProduto)
        {
            var item = Itens.FirstOrDefault(i => i.Produto.IdProduto == idProduto);

            if (item != null)
            {
                Itens.Remove(item);
            }
        }


        public void RemoverItem(int idProduto, int quantidade = 1)
        {
            var item = Itens.FirstOrDefault(i => i.Produto.IdProduto == idProduto);
            if (item != null)
            {
                if (quantidade >= item.Quantidade)
                {
                    Itens.Remove(item);  
                }
                else
                {
                    item.Quantidade -= quantidade;
                }
            }
        }

        public void LimparCarrinho()
        {
            Itens.Clear();
        }
    }

}
