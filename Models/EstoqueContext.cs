using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace TesteHortoInova.Models
{
    public class EstoqueContext : DbContext
    {
        public EstoqueContext(DbContextOptions<EstoqueContext> options) : base(options) { }

        public DbSet<Produto> Produtos { get; set; }


    }
}
