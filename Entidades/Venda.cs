namespace ConsoleApp1.Entidades
{
    public class Venda(int id, int clienteId, int vendedorId)
    {

        public int Id { get; set; } = id;
        public List<ProdutoVenda> Produtos = new List<ProdutoVenda>();
        public int ClienteId { get; set; } = clienteId;
        public int VendedorId { get; set; } = vendedorId;
        public decimal Total => CalculaTotal();
        private decimal CalculaTotal()
        {
            return Produtos.Sum(produtos => produtos.SubTotal);
        }
        
    }
}
