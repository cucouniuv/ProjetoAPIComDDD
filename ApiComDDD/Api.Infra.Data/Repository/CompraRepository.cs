using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Infra.Data.Repository
{
    public class CompraRepository : RepositoryBase<Compra>, ICompraRepository
    {
        public CompraRepository(ContextInMemory contextInMemory) : base(contextInMemory)
        {
        }

        public async Task<Compra> ConsultarCompraComProdutosAsync(int id)
        {
            //TODO: Fazer filtro para não fazer select *
            return await Db.Set<Compra>()
                .Include(compra => compra.ListaDeProdutosDaCompra)
                .Include(compra => compra.Cliente)
                    .ThenInclude(cliente => cliente.Endereco)
                .Include(compra => compra.Cliente.ListaDeComprasDoCliente)
                .Where(compra => compra.Id == id)
                .FirstOrDefaultAsync();
        }
    }
}
