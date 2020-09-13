using Api.Domain.DTO;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.ValueObjects;
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

        public async Task AdicionarClienteAsync(AdicionarUmClienteDTO obj)
        {
            Endereco endereco = new Endereco(
                obj.Rua,
                obj.Cidade,
                obj.Estado,
                obj.CEP
            );

            Cliente cliente = new Cliente(obj.NomeDoCliente, endereco);
            
            if (cliente.Invalid)
            {
                //TODO: Arrumar como pegar a validação do Fluent
                throw new System.Exception(cliente.ValidationResult.RuleSetsExecuted.ToString());
            }

            await _clienteRepository.AddAsync(cliente);

            _clienteRepository.SaveAsync();
        }

    }
}
