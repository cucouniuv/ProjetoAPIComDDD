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

        public DbSet<Empresa> Empresa { get; set; }
    }
}
