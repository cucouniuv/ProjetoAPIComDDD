using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Infra.Data.Context;

namespace Api.Infra.Data.Repository
{
    public class ClienteRepository : RepositoryBase<Cliente>, IClienteRepository
    {
        public ClienteRepository(ContextInMemory contextInMemory) : base(contextInMemory)
        {
        }
    }
}
