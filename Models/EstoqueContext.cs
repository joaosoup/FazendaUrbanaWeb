using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace TesteHortoInova.Models
{
    public class EstoqueContext : DbContext
    {
        public EstoqueContext(DbContextOptions<EstoqueContext> options) : base(options) { }

        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Garantir que ProdutoId é definido como chave primária, se não seguir o padrão de nomenclatura
            modelBuilder.Entity<Produto>().HasKey(p => p.IdProduto); // ou p.ProdutoId, conforme o nome
        }

    }
}
