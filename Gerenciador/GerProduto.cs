using System.Text.RegularExpressions;

namespace ConsoleApp1.Entidades
{
    public class GerProduto
    {
        public GerProduto()
        {
            IdCounter++;
            Produto produto1 = new(IdCounter, "Carro", "Civic", 11, 10.00m);
            produtos.Add(IdCounter, produto1); //instancia antes do metodo

            IdCounter++;
            Produto produto2 = new(IdCounter, "Carro", "Passat", 8, 20.00m);
            produtos.Add(IdCounter, produto2);

            IdCounter++;
            Produto produto3 = new(IdCounter, "Carro", "Omega", 4, 30.00m);
            produtos.Add(IdCounter, produto3);

        }
        private int IdCounter = 0;
        
        private  readonly Dictionary<int, Produto> produtos = [];
        public Produto? GetById(int id) => produtos.TryGetValue(id, out var produto) ? produto : null;
        public int? Cadastro(string? produtoGrupo, string? nome, int quantidade, decimal preco)
        {
            IdCounter++;
            Produto produto = new(IdCounter, produtoGrupo, nome, quantidade, preco);
            if (produtos.TryAdd(IdCounter, produto))
            {
                return IdCounter;
            }
            return null;
        }
        public bool Remover(int id) => produtos.Remove(id);
        
        public bool AtualizarEstoqueProduto(int produtoId, int quantidade)
        {
            if (produtos.TryGetValue(produtoId, out var produto)) return produto.AtualizarEstoque(quantidade);
            return false;
        }
        public Dictionary<int, Produto> GetAll() => produtos;
    }
}
