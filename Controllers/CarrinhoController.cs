using Microsoft.AspNetCore.Mvc;
using TesteHortoInova.Models;
using System.Linq;
using System.Collections.Generic;

public class CarrinhoController : Controller
{
    private readonly EstoqueContext _context;  // Instância do contexto do banco

    public static Carrinho _carrinho = new Carrinho();
    public static List<Produto> _produtos = new List<Produto>();

    public CarrinhoController(EstoqueContext context)
    {
        _context = context;

        // Carregar produtos uma vez, se ainda não carregado
        if (!_produtos.Any())
        {
            _produtos = _context.Produtos.ToList();  // Carrega os produtos do banco
        }
    }

    public ActionResult Index()
    {
        return View(_carrinho);
    }

    public ActionResult Adicionar(int id, int quantidade = 1)
    {
        var produto = _produtos.FirstOrDefault(p => p.IdProduto == id);
        if (produto != null)
        {
            _carrinho.AdicionarItem(produto, quantidade);
        }
        return RedirectToAction("Index");
    }

    public ActionResult Remover(int id)
    {
        _carrinho.RemoverItem(id);
        return RedirectToAction("Index");
    }

    public ActionResult Limpar()
    {
        _carrinho.LimparCarrinho();
        return RedirectToAction("Index");
    }

    // Nova ação para criar pedido e limpar o carrinho
    public ActionResult Comprar()
    {
        if (_carrinho.Itens.Any())
        {
            // Cria um novo pedido
            var pedido = new Pedido
            {
                Total = _carrinho.TotalCarrinho,
                Itens = _carrinho.Itens.Select(item => new ItemPedido
                {
                    IdProduto = item.Produto.IdProduto,
                    NomeProduto = item.Produto.NomeProduto,
                    Preco = item.Produto.Preco,
                    Quantidade = item.Quantidade
                }).ToList()
            };

            // Adiciona o pedido ao banco de dados
            _context.Pedidos.Add(pedido);
            _context.SaveChanges();

            // Limpa o carrinho
            _carrinho.LimparCarrinho();
        }

        return RedirectToAction("Index");
    }
}
