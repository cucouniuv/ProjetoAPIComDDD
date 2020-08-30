using Api.Domain.DTO;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using System.Threading.Tasks;

namespace Api.Service
{
    public class ClienteService : ServiceBase<Cliente>, IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
            : base(clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        /*public async Task AddEmpresaAsync(EmpresaDTO obj)
        {
            Empresa emp = new Empresa(obj.Nome, obj.Cnpj);

            await _compraRepository.AddAsync(emp);
        }*/
    }
}
