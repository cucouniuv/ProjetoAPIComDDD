namespace Api.Domain.Entities
{
    public class ProdutosDaCompra: Entity
    {
        public int Id { get; private set; }

        public int IdDaCompra { get; private set; }

        public Produto Produto { get; private set; }

        public double Preco { get; private set; }

        public double Desconto { get; private set; }

        public ProdutosDaCompra() { }

        public ProdutosDaCompra(Produto produto, double preco, double desconto, int idDaCompra)
        {
            Produto = produto;
            Preco = preco;
            Desconto = desconto;
            IdDaCompra = idDaCompra;
        }

        public void AtualizarCodigoDaCompra(int codigo)
        {
            IdDaCompra = codigo;
        }
    }
}
