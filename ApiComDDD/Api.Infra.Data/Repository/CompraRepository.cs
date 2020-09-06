using Api.Domain.DTO;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Infra.Data.Repository
{
    public class CompraRepository : RepositoryBase<Compra>, ICompraRepository
    {
        public CompraRepository(ContextInMemory contextInMemory) : base(contextInMemory)
        {
        }

        public async Task<Compra> ConsultarCompraComProdutosAsync(int id)
        {
            // Não utilizado mais, só como exemplo
            return await Db.Set<Compra>()
                .Include(compra => compra.ListaDeProdutosDaCompra)
                    .ThenInclude(listaProduto => listaProduto.Produto)
                .Include(compra => compra.Cliente)
                    .ThenInclude(cliente => cliente.Endereco)
                .Include(compra => compra.Cliente)
                    .ThenInclude(cliente => cliente.ListaDeComprasDoCliente)
                .Where(compra => compra.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<DadosDeUmaCompraDTO> ConsultarDadosDeUmaCompra(int id)
        {
            return await Db.Set<Compra>()
                .Include(compra => compra.ListaDeProdutosDaCompra)
                    .ThenInclude(listaProduto => listaProduto.Produto)
                .Include(compra => compra.Cliente)
                    .ThenInclude(cliente => cliente.Endereco)
                .Include(compra => compra.Cliente)
                    .ThenInclude(cliente => cliente.ListaDeComprasDoCliente)
                .Where(compra => compra.Id == id)
                .Select(campos => new DadosDeUmaCompraDTO
                {
                    IdDaCompra = campos.Id,
                    DataDaCompra = campos.Data,
                    EnderecoDeEntrega = campos.Endereco,
                    NomeDoCliente = campos.Cliente.Nome,
                    EnderecoDoCliente = campos.Endereco,
                    ListaDeProdutosDaCompra = campos.ListaDeProdutosDaCompra,
                    ValorTotalDaCompra = campos.CalcularValorTotalDaCompra()
                })
                .FirstOrDefaultAsync();
        }
    }
}
