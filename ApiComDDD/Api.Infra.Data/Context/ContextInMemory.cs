using Api.Domain.Entities;
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
        public DbSet<Produto> Produto { get; set; }
        public DbSet<ProdutosDaCompra> ProdutosDaCompra { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Feito para os objetos de valor que não possuem Id
            modelBuilder.Entity<Cliente>().OwnsOne(
                o => o.Endereco);

            modelBuilder.Entity<Cliente>().HasMany(
                o => o.ListaDeComprasDoCliente).WithOne(o => o.Cliente);


            modelBuilder.Entity<Compra>().OwnsOne(
                o => o.Endereco);

            modelBuilder.Entity<Compra>().HasMany(
                o => o.ListaDeProdutosDaCompra).WithOne(o => o.Compra);

            modelBuilder.Entity<Compra>().HasOne(
                o => o.Cliente).WithOne();


            modelBuilder.Entity<ProdutosDaCompra>().HasOne(
                o => o.Produto).WithOne(); // conferir
        }

    }
}
