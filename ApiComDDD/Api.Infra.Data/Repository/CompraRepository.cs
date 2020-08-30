using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Infra.Data.Context;

namespace Api.Infra.Data.Repository
{
    public class CompraRepository : RepositoryBase<Compra>, ICompraRepository
    {
        public CompraRepository(ContextInMemory contextInMemory) : base(contextInMemory)
        {
        }
    }
}
