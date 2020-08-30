using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Infra.Data.Context;

namespace Api.Infra.Data.Repository
{
    public class ProdutosDaCompraRepository : RepositoryBase<ProdutosDaCompra>, IProdutosDaCompraRepository
    {
        public ProdutosDaCompraRepository(ContextInMemory contextInMemory) : base(contextInMemory)
        {
        }
    }
}
