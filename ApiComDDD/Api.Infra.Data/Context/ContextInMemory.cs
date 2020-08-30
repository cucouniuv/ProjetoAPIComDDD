using Api.Domain.Entities;
using Api.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Api.Infra.Data.Context
{
    public class ContextInMemory : DbContext
    {
        public ContextInMemory(DbContextOptions<ContextInMemory> options)
            : base(options)
        {
        }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Compra> Compra { get; set; }
        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<ProdutosDaCompra> ProdutosDaCompra { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Feito para os objetos de valor que não possuem Id
            modelBuilder.Entity<Cliente>().OwnsOne(
                o => o.Endereco);

            modelBuilder.Entity<Compra>().OwnsOne(
                o => o.Endereco);
        }

    }
}
