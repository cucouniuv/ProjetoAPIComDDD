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

        public CompraService(
            ICompraRepository compraRepository, 
            IProdutoRepository produtoRepository,
            IProdutosDaCompraRepository produtosDaCompraRepository)
            : base(compraRepository)
        {
            _compraRepository = compraRepository;
            _produtoRepository = produtoRepository;
            _produtosDaCompraRepository = produtosDaCompraRepository;
        }

        public async Task AdicionarUmaCompraAsync(AdicionarUmaCompraDTO obj)
        {
            Endereco endereco = new Endereco(
                obj.RuaDeEntrega, 
                obj.CidadeDeEntrega,
                obj.EstadoDeEntrega,
                obj.CEPDeEntrega
                );

            Compra compra = new Compra(obj.DataDaCompra, endereco);
            await _compraRepository.AddAsync(compra);


            List<ProdutosDaCompra> ListaDeProdutosDaCompra = new List<ProdutosDaCompra>();

            foreach (var x in obj.ListaDeProdutosDaCompra)
            {
                Produto produto = _produtoRepository.GetById(x.IdDoProduto);

                //TODO: Ver como posso pegar o Id da compra
                ProdutosDaCompra produtosDaCompra = 
                    new ProdutosDaCompra(produto, x.Preco, x.Desconto, compra);

                ListaDeProdutosDaCompra.Add(produtosDaCompra);

                //TODO: muito errado
                await _produtosDaCompraRepository.AddAsync(produtosDaCompra);
            }

            compra.AtribuirListaDeProdutosDaCompra(ListaDeProdutosDaCompra);
            await _compraRepository.UpdateAsync(compra);
        }

        public async Task<DadosDeUmaCompraDTO> PegarDadosDeUmaCompraPorId(int id)
        {
            var dados = await _compraRepository.GetByIdAsync(id);

            var dadosDTO = new DadosDeUmaCompraDTO
            {
                Id = dados.Id,
                Data = dados.Data,
                Endereco = dados.Endereco,
                ListaDeProdutosDaCompra = dados.ListaDeProdutosDaCompra
            };

            return dadosDTO;
        }
    }
}
