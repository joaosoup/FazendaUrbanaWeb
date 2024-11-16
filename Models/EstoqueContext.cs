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
        public DbSet<pedidos_encerrados> pedidos_encerrados { get; set; } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>().HasKey(p => p.IdProduto);
            modelBuilder.Entity<ItemPedido>().HasKey(ip => ip.IdItemPedido);
            modelBuilder.Entity<Pedido>().HasKey(p => p.IdPedido);
            modelBuilder.Entity<salvar_dados>().HasKey(sd => sd.Id);
            modelBuilder.Entity<pedidos_encerrados>().HasKey(pe => pe.IdPedido);


        }
    }
}
