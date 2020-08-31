using Api.Domain.Entities;
using Api.Domain.Interfaces.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Domain.Interfaces
{
    public interface IProdutosDaCompraRepository : IRepositoryBase<ProdutosDaCompra>
    {
        public Task<List<ProdutosDaCompra>> ConsultarProdutosDaCompraAsync(int compraId);
    }
}
