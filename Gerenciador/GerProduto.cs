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
        
        public  readonly Dictionary<int, Produto> produtos = [];
        public Produto? EncontrarPeloId(int id)
        {
            if (produtos.TryGetValue(id, out var produto))
            {
                return produto;
            }
            return null;
        }
        public void Cadastro()
        {
            Console.WriteLine("Insira o Nome do Produto: ");
            string? nome = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(nome))
            {
                Console.WriteLine("Nome não pode ser nulo ou vazio. Por favor, insira um nome válido ou digite sair para cancelar");
                nome = Console.ReadLine();
                if (nome == "sair")
                {
                    return;
                }
            }
            Console.WriteLine("Insira o nome do Grupo do Produto: ");
            string? produtoGrupo = Console.ReadLine();
            Console.WriteLine("Insira a quantidade: ");
            string? entrada = Console.ReadLine();
            //_ = int.TryParse(entrada, out int _quantidade);
            int _quantidade;
            while (!int.TryParse(entrada, out _quantidade) || _quantidade < 0)
            {
                Console.WriteLine("Quantidade inválida. Por favor, insira uma quantidade válida ou digite sair para cancelar");
                entrada = Console.ReadLine();
                if (entrada == "sair")
                {
                    return;
                }
                _ = int.TryParse(entrada, out _quantidade);
            }
            //insira o preco
            decimal preco;
            while (!decimal.TryParse(entrada, out preco) || preco < 0)
            {
                Console.WriteLine("Preço inválido. Por favor, insira um preço válido ou digite sair para cancelar");
                entrada = Console.ReadLine();
                if (entrada == "sair")
                {
                    return;
                }
                _ = decimal.TryParse(entrada, out preco);
            }
            IdCounter++;
            Produto produto = new(IdCounter, produtoGrupo, nome, _quantidade, preco);
            produtos.Add(IdCounter, produto);
            Console.WriteLine("Produto" + nome + "cadastrado com sucesso!");
            // string? produtoGrupo, string? nome, int quantidade
        }
        public void Remover()
        {
            Console.WriteLine("Insira o Id do Produto que deseja remover");
            string? entrada = Console.ReadLine();
            _ = int.TryParse(entrada, out int _id);
            if (produtos.TryGetValue(_id, out var produto))
            {
                Console.WriteLine("O produto:" + _id + ". Nome: " + produto.Nome + "será excluído!");
                if (Interface.Confirmar())
                {
                    produtos.Remove(_id);
                    Console.WriteLine("Produto removido!");
                }
                else
                {
                    Console.WriteLine("Operação cancelada");
                }
                Interface.PressioneParaSair();
            }
            else
            {
                Console.WriteLine("Produto não encontrado!");
                Interface.PressioneParaSair();
                Console.ReadKey();
            }
        }
        public bool AtualizarEstoqueProduto(int produtoId, int quantidade)
        {
            if (produtos.TryGetValue(produtoId, out var produto)) return produto.AtualizarEstoque(quantidade);
            return false;
        }
    }
}
