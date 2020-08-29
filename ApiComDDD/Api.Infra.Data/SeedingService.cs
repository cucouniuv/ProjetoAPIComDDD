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

            Empresa e1 = new Empresa("DB1", "123456789");
            Empresa e2 = new Empresa("Softplan", "987654321");

            _context.Empresa.AddRange(e1, e2);

            _context.SaveChanges();
        }
    }
}
