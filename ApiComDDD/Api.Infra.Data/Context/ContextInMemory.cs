using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Logging;
//using Microsoft.Extensions.Logging.Console;

namespace Api.Infra.Data.Context
{
    public class ContextInMemory : DbContext
    {
        public ContextInMemory(DbContextOptions<ContextInMemory> options)
            : base(options)
        {
        }

        //public static readonly ILoggerFactory loggerFactory = new LoggerFactory(new[] {
        //      new ConsoleLoggerProvider((_, __) => true, true)
        //});

        //var loggerFactory = LoggerFactory.Create(builder => {
        //    builder.
        //           .AddConsole();
        //}
        //);



        //public static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(); });

        //public static readonly LoggerFactory DbCommandConsoleLoggerFactory
        //    = new LoggerFactory(new[] {
        //        new ConsoleLoggerProvider ((category, level) =>
        //            category == DbLoggerCategory.Database.Command.Name &&
        //            level == LogLevel.Information, true)
        //    });

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseLoggerFactory(MyLoggerFactory)  //tie-up DbContext with LoggerFactory object
        //        .EnableSensitiveDataLogging();
        //}

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


            modelBuilder.Entity<ProdutosDaCompra>().HasOne(
                o => o.Produto).WithOne();
        }

    }
}
