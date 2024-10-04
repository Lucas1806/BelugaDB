namespace ConsoleApp1.Entidades
{
    public class Produto(int id, string? produtoGrupo, string? nome, int quantidade, decimal preco)
    {

        public int Id { get; set; } = id;
        public string? ProdutoGrupo { get; set; } = produtoGrupo;
        public string? Nome { get; set; } = nome;
        public int Quantidade { get; set; } = quantidade;
        public decimal Preco {  get; set; } = preco;

        public bool AtualizarEstoque(int quantidade)
        {
            if (Quantidade + quantidade < 0) return false;
            Quantidade += quantidade;
            return true;
        }
    }
}
