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

        public CompraService(ICompraRepository compraRepository, IProdutoRepository produtoRepository)
            : base(compraRepository)
        {
            _compraRepository = compraRepository;
            _produtoRepository = produtoRepository;
        }

        public async Task AdicionarUmaCompraAsync(AdicionarUmaCompraDTO obj)
        {
            Endereco endereco = new Endereco(
                obj.RuaDeEntrega, 
                obj.CidadeDeEntrega,
                obj.EstadoDeEntrega,
                obj.CEPDeEntrega
                );

            List<ProdutosDaCompra> ListaDeProdutosDaCompra = new List<ProdutosDaCompra>();

            foreach (var x in obj.ListaDeProdutosDaCompra)
            {
                Produto produto = _produtoRepository.GetById(x.IdDoProduto);

                //TODO: Ver como posso pegar o Id da compra
                ProdutosDaCompra produtosDaCompra = 
                    new ProdutosDaCompra(produto, x.Preco, x.Desconto, 0);

                ListaDeProdutosDaCompra.Add(produtosDaCompra);
            } 

            Compra compra = new Compra(obj.DataDaCompra, endereco, ListaDeProdutosDaCompra);

            //compra.AdicionarCodidoDaCompraNaListaDeProdutos(compra.Id);

            await _compraRepository.AddAsync(compra);
        }
    }
}
