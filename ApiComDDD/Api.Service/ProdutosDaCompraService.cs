using Api.Domain.DTO;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using System.Threading.Tasks;

namespace Api.Service
{
    public class ProdutosDaCompraService : ServiceBase<ProdutosDaCompra>, IProdutosDaCompraService
    {
        private readonly IProdutosDaCompraRepository _produtosDaCompraRepository;

        public ProdutosDaCompraService(IProdutosDaCompraRepository produtosDaCompraRepository)
            : base(produtosDaCompraRepository)
        {
            _produtosDaCompraRepository = produtosDaCompraRepository;
        }
    }
}
