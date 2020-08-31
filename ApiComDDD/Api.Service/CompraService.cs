using Api.Domain.DTO;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.ValueObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Service
{
    public class CompraService : ServiceBase<Compra>, ICompraService
    {
        private readonly ICompraRepository _compraRepository;

        private readonly IProdutoRepository _produtoRepository;

        private readonly IProdutosDaCompraRepository _produtosDaCompraRepository;

        private readonly IClienteRepository _clienteRepository;

        public CompraService(
            ICompraRepository compraRepository, 
            IProdutoRepository produtoRepository,
            IProdutosDaCompraRepository produtosDaCompraRepository,
            IClienteRepository clienteRepository)
            : base(compraRepository)
        {
            _compraRepository = compraRepository;
            _produtoRepository = produtoRepository;
            _produtosDaCompraRepository = produtosDaCompraRepository;
            _clienteRepository = clienteRepository;
        }

        public async Task AdicionarUmaCompraAsync(AdicionarUmaCompraDTO obj)
        {
            Cliente cliente = _clienteRepository.GetById(obj.ClienteId);

            Endereco endereco = new Endereco(
                obj.RuaDeEntrega, 
                obj.CidadeDeEntrega,
                obj.EstadoDeEntrega,
                obj.CEPDeEntrega
                );

            Compra compra = new Compra(obj.DataDaCompra, endereco, cliente);

            List<ProdutosDaCompra> ListaDeProdutosDaCompra = new List<ProdutosDaCompra>();

            foreach (var x in obj.ListaDeProdutosDaCompra)
            {
                Produto produto = _produtoRepository.GetById(x.IdDoProduto);

                ProdutosDaCompra produtosDaCompra = 
                    new ProdutosDaCompra(produto, x.Preco, x.Desconto, compra);

                ListaDeProdutosDaCompra.Add(produtosDaCompra);

                //TODO: Buscar outra forma
                await _produtosDaCompraRepository.AddAsync(produtosDaCompra);
            }

            compra.AtribuirListaDeProdutosDaCompra(ListaDeProdutosDaCompra);

            await _compraRepository.AddAsync(compra);
            _compraRepository.Save();
        }

        public async Task<DadosDeUmaCompraDTO> PegarDadosDeUmaCompraPorId(int id)
        {
            var compra = await _compraRepository.GetByIdAsync(id);

            var listaProdutosDaCompra = 
                await _produtosDaCompraRepository.ConsultarProdutosDaCompraAsync(compra.Id);

            //TODO: Devo atribuir produtosDaCompra com compra?

            compra.AtribuirListaDeProdutosDaCompra(listaProdutosDaCompra);
            double valorTotalDaCompra = compra.CalcularValorTotalDaCompra();

            //TODO: Fazer validações 

            var cliente = await _clienteRepository.GetByIdAsync(compra.ClienteId);

            var dadosDTO = new DadosDeUmaCompraDTO
            {
                IdDaCompra = compra.Id,
                DataDaCompra = compra.Data,
                EnderecoDeEntrega = compra.Endereco,
                ListaDeProdutosDaCompra = compra.ListaDeProdutosDaCompra,
                NomeDoCliente = cliente.Nome,
                EnderecoDoCliente = cliente.Endereco,
                ValorTotalDaCompra = valorTotalDaCompra
            };

            return dadosDTO;
        }
    }
}
