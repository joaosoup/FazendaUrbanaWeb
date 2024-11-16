using Microsoft.AspNetCore.Mvc;
using TesteHortoInova.Models;
using System.Linq;
using System.Collections.Generic;

public class CarrinhoController : Controller
{
    private readonly EstoqueContext _context;

    public static Carrinho _carrinho = new Carrinho();
    public static List<Produto> _produtos = new List<Produto>();

    public CarrinhoController(EstoqueContext context)
    {
        _context = context;

        if (!_produtos.Any())
        {
            _produtos = _context.Produtos.ToList();  
        }
    }

    public ActionResult Index()
    {
        _produtos = _context.Produtos.ToList();

        return View(_carrinho);
    }

    public ActionResult Adicionar(int id, int quantidade = 1)
    {
        var produto = _produtos.FirstOrDefault(p => p.IdProduto == id);
        if (produto != null)
        {
            if (quantidade > 0)
            {
                _carrinho.AdicionarItem(produto, quantidade); 
            }
            else if (quantidade < 0)
            {
                _carrinho.RemoverItem(produto.IdProduto, 1); 
            }
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

    //Botão Registrar (OK)
    //Fazer um "Sobre" bonito (ok)
    //Fazer Modal de pagamento concluido quando o pedido for criado (OK)
    //Fazer tela de Registrar (Modal) (OK)
    //Criar lógica para remover quantidade do estoque quando comprar (OK)
    //Criar botão de adicionar, remover e excluir da tabela (OK)

    public ActionResult CriarPedido()
    {
        if (_carrinho.Itens.Any())
        {
            // Adiciona um pedido encerrado
            var pedidoEncerrado = new pedidos_encerrados
            {
                Estado = "Finalizado",
                Produto = string.Join(", ", _carrinho.Itens.Select(i => i.Produto.NomeProduto)),
                Quantidade = _carrinho.Itens.Sum(i => i.Quantidade),
                ValorUnitario = _carrinho.Itens.First().Produto.Preco,
                Comprador = "Cliente Físico", 
                Plataforma = "Site",
                FormaPgt = "Cartão",
                Desconto = 0,
                ValorTotal = _carrinho.TotalCarrinho,
                Marketplace = "Horto Inova",
                DataPedido = DateTime.Now
            };

            foreach (var item in _carrinho.Itens)
            {
                var produtoNoEstoque = _context.Produtos.FirstOrDefault(p => p.IdProduto == item.Produto.IdProduto);
                if (produtoNoEstoque != null)
                {
                    produtoNoEstoque.Quantidade -= item.Quantidade;

                    if (produtoNoEstoque.Quantidade < 0)
                    {
                        produtoNoEstoque.Quantidade = 0;
                    }

                    _context.Produtos.Update(produtoNoEstoque);
                }
            }

            _context.pedidos_encerrados.Add(pedidoEncerrado);
            _context.SaveChanges();

            _carrinho.LimparCarrinho();

            TempData["MensagemPedido"] = "Seu pedido foi criado com sucesso! Obrigado pela compra!";
        }
        else
        {
            TempData["MensagemPedido"] = "Seu carrinho está vazio. Não foi possível criar o pedido.";
        }

        return RedirectToAction("Index");
    }


}
