using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Infra.Data.Repository
{
    public class ProdutosDaCompraRepository : RepositoryBase<ProdutosDaCompra>, IProdutosDaCompraRepository
    {
        public ProdutosDaCompraRepository(ContextInMemory contextInMemory) : base(contextInMemory)
        {
        }

        public async Task<List<ProdutosDaCompra>> ConsultarProdutosDaCompraAsync(int compraId)
        {
            return await Db.Set<ProdutosDaCompra>()
                .Where(x => x.CompraId == compraId).ToListAsync();
        }
    }
}
