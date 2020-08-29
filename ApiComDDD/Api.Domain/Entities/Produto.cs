namespace Api.Domain.Entities
{
    public class Produto: Entity
    {
        public int Id { get; private set; }

        public string Descricao { get; private set; }

        public Produto(string descricao)
        {
            Descricao = descricao;
        }

        public double PegarValorTotalDoProdutoDaCompra(double preco, double desconto, double descontoCliente)
        {
            return (preco - desconto - descontoCliente);
        }
    }
}
