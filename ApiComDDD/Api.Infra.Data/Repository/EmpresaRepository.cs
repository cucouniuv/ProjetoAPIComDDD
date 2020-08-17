using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Infra.Data.Context;

namespace Api.Infra.Data.Repository
{
    public class EmpresaRepository : RepositoryBase<Empresa>, IEmpresaRepository
    {
        public EmpresaRepository(ContextInMemory contextInMemory) : base(contextInMemory)
        {
        }
    }
}
