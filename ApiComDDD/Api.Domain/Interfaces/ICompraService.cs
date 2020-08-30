using Api.Domain.DTO;
using Api.Domain.Entities;
using System.Threading.Tasks;

namespace Api.Domain.Interfaces
{
    public interface ICompraService : IServiceBase<Compra>
    {
        Task AdicionarUmaCompraAsync(AdicionarUmaCompraDTO obj);

        Task<DadosDeUmaCompraDTO> PegarDadosDeUmaCompraPorId(int id);
    }
}
