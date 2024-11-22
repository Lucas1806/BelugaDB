namespace ConsoleApp1.Entidades
{
    public class Venda(int id, Dictionary<int, ProdutoVenda> produtos,int clienteId, int vendedorId)
    {

        public int Id { get; set; } = id;
        public Dictionary<int, ProdutoVenda> Produtos = produtos;
        public int ClienteId { get; set; } = clienteId;
        public int VendedorId { get; set; } = vendedorId;
        public decimal Total => CalculaTotal();
        private readonly int IdCounter = 0;
        private decimal CalculaTotal()
        {
            return Produtos.Sum(produtos => produtos.Value.SubTotal);
        }
        public bool AicionarProduto(ProdutoVenda produto) => Produtos.TryAdd(IdCounter, produto);

    }
}
