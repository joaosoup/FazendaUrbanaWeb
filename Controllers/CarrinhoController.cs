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

         //Carregar produtos uma vez, se ainda não carregado
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
}
