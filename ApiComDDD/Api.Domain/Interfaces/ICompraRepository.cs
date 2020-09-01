using Api.Domain.Entities;
using Api.Domain.Interfaces.Base;
using System.Threading.Tasks;

namespace Api.Domain.Interfaces
{
    public interface ICompraRepository : IRepositoryBase<Compra>
    {
        Task<Compra> ConsultarCompraComProdutosAsync(int id);
    }
}
