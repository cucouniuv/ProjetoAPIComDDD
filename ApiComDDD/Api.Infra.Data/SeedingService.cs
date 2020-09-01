using Api.Domain.Entities;
using Api.Domain.ValueObjects;
using Api.Infra.Data.Context;
using System.Linq;

namespace Api.Infra.Data
{
    public class SeedingService
    {
        private readonly ContextInMemory _context;

        public SeedingService(ContextInMemory context)
        {
            _context = context;
        }

        public void Seed()
        {
            SeedCliente();
            SeedProduto();
        }

        private void SeedProduto()
        {
            if (_context.Produto.Any())
                return;

            Produto p1 = new Produto("Geladeira");
            Produto p2 = new Produto("Fogão");
            Produto p3 = new Produto("Mesa com 4 cadeiras");
            Produto p4 = new Produto("Sofá");
            Produto p5 = new Produto("Cama de casal");

            _context.Produto.AddRange(p1, p2, p3, p4, p5);
            _context.SaveChanges();
        }

        private void SeedCliente()
        {
            if (_context.Cliente.Any())
                return;

            Endereco end1 = new Endereco("Rua Prof. Juvenal", "Cascavel", "PR", "88000000");
            Endereco end2 = new Endereco("Rua da esquina", "Cascavel", "PR", "88000000");

            Cliente c1 = new Cliente("Agustinho", end1);
            Cliente c2 = new Cliente("José", end1);
            Cliente c3 = new Cliente("Maria", end2);

            _context.Cliente.AddRange(c1, c2, c3);
            _context.SaveChanges();
        }
    }
}
