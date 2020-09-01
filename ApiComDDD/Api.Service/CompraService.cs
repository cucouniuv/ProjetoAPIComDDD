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

        private readonly IClienteRepository _clienteRepository;

        public CompraService(
            ICompraRepository compraRepository, 
            IProdutoRepository produtoRepository,
            IClienteRepository clienteRepository)
            : base(compraRepository)
        {
            _compraRepository = compraRepository;
            _produtoRepository = produtoRepository;
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

            List<ProdutosDaCompra> listaDeProdutosDaCompra = new List<ProdutosDaCompra>();

            Compra compra = new Compra(obj.DataDaCompra, endereco, cliente, listaDeProdutosDaCompra);

            foreach (var x in obj.ListaDeProdutosDaCompra)
            {
                Produto produto = await _produtoRepository.GetByIdAsync(x.IdDoProduto);

                ProdutosDaCompra produtosDaCompra = 
                    new ProdutosDaCompra(produto, x.Preco, x.Desconto, compra);

                listaDeProdutosDaCompra.Add(produtosDaCompra);
            }

            await _compraRepository.AddAsync(compra);
            _compraRepository.Save();
        }

        public async Task<DadosDeUmaCompraDTO> PegarDadosDeUmaCompraPorId(int id)
        {
            //TODO: Fazer validações

            var compra = await _compraRepository.ConsultarCompraComProdutosAsync(id);

            double valorTotalDaCompra = compra.CalcularValorTotalDaCompra();

            var dadosDTO = new DadosDeUmaCompraDTO
            {
                IdDaCompra = compra.Id,
                DataDaCompra = compra.Data,
                EnderecoDeEntrega = compra.Endereco,
                ListaDeProdutosDaCompra = compra.ListaDeProdutosDaCompra,
                NomeDoCliente = compra.Cliente.Nome,
                EnderecoDoCliente = compra.Cliente.Endereco,
                ValorTotalDaCompra = valorTotalDaCompra
            };

            return dadosDTO;
        }
    }
}
