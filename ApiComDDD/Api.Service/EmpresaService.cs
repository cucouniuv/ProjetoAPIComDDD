using Api.Domain.DTO;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using System.Threading.Tasks;

namespace Api.Service
{
    public class EmpresaService : ServiceBase<Empresa>, IEmpresaService
    {
        private readonly IEmpresaRepository _empresaRepository;

        public EmpresaService(IEmpresaRepository empresaRepository)
            : base(empresaRepository)
        {
            _empresaRepository = empresaRepository;
        }

        public async Task AddEmpresaAsync(EmpresaDTO obj)
        {
            Empresa emp = new Empresa(obj.Nome, obj.Cnpj);

            await _empresaRepository.AddAsync(emp);
        }
    }
}
