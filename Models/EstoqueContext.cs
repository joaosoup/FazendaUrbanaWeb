using Microsoft.EntityFrameworkCore;

namespace TesteHortoInova.Models
{
    public class EstoqueContext : DbContext
    {
        public EstoqueContext(DbContextOptions<EstoqueContext> options) : base(options) { }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<ItemPedido> ItensPedido { get; set; }
        public DbSet<salvar_dados> salvar_dados { get; set; }
        public DbSet<PedidosEncerrados> PedidosEncerrados { get; set; } // Verifique essa linha

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Garantir que ProdutoId é definido como chave primária, se não seguir o padrão de nomenclatura
            modelBuilder.Entity<Produto>().HasKey(p => p.IdProduto); // ou p.ProdutoId, conforme o nome
            modelBuilder.Entity<ItemPedido>().HasKey(ip => ip.IdItemPedido);
            modelBuilder.Entity<Pedido>().HasKey(p => p.IdPedido);
            modelBuilder.Entity<salvar_dados>().HasKey(sd => sd.Id);
            modelBuilder.Entity<PedidosEncerrados>().HasKey(pe => pe.IdPedido);

        }
    }
}
