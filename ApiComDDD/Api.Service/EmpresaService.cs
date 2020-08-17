using Api.Domain.Entities;
using Api.Domain.Interfaces;

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
    }
}
