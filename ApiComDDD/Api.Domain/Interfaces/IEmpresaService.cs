using Api.Domain.DTO;
using Api.Domain.Entities;
using System.Threading.Tasks;

namespace Api.Domain.Interfaces
{
    public interface IEmpresaService : IServiceBase<Empresa>
    {
        Task AddEmpresaAsync(EmpresaDTO obj);
    }
}
