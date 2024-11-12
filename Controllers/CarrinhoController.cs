using Microsoft.AspNetCore.Mvc;
using TesteHortoInova.Models;

public class CarrinhoController : Controller
{
    public static Carrinho _carrinho = new Carrinho();
    public static List<Produto> _produtos = new List<Produto>
    {
    };

    public ActionResult Index()
    {
        return View(_carrinho);
    }

    public ActionResult Adicionar(int id, int quantidade = 1)
    {
        var produto = _produtos.FirstOrDefault(p => p.Id == id);
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
