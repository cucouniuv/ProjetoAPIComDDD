using Api.Domain.Entities;
using Api.Infra.Data.Context;
using System;
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
            if (_context.Empresa.Any())
            {
                return;
            }

            Empresa e1 = new Empresa
            {
                Id = 1,
                Nome = "DB1",
                Cnpj = "123456789",
                DataFundacao = new DateTime(1992, 4, 21)
            };

            Empresa e2 = new Empresa
            {
                Id = 1,
                Nome = "Softplan",
                Cnpj = "123456789",
                DataFundacao = new DateTime(1900, 9, 1)
            };

            _context.Empresa.AddRange(e1, e2);

            _context.SaveChanges();
        }
    }
}
