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

    // Nova ação para criar pedido, limpar o carrinho e salvar no banco
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
                Comprador = "Cliente Físico", // Substitua com o nome do cliente real, se aplicável
                Plataforma = "Site",  
                FormaPgt = "Cartão",
                Desconto = 0,
                ValorTotal = _carrinho.TotalCarrinho,
                Marketplace = "Horto Inova",
                DataPedido = DateTime.Now
            };

            //Fazer Modal de pagamento concluido quando o pedido for criado
            //Botão Registrar
            //Fazer tela de Registrar (Modal)
            //Fazer um "Sobre" bonito

            //SE DER TEMPO
            //Criar lógica para remover quantidade do estoque quando comprar
            //Lógica de mostrar mensagem de credencial errada (SEM REINICIAR A TELA)

            // Adiciona ao banco de dados
            _context.pedidos_encerrados.Add(pedidoEncerrado);
            _context.SaveChanges();

            // Limpa o carrinho
            _carrinho.LimparCarrinho();
        }

        return RedirectToAction("Index");
    }

}
