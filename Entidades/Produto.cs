using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Entidades
{
    public class Produto(int id, string? produtoGrupo, string? nome, int quantidade)
    {
        
        private static int IdCounter = 1;
        public int Id { get; set; } = id;
        public string? ProdutoGrupo { get; set; } = produtoGrupo;
        public string? Nome { get; set; } = nome;
        public int Quantidade { get; set; } = quantidade;
        public static readonly Dictionary<int, Produto> produtos = [];
        public static Produto? EncontrarPeloId(int id)
        {
            if (produtos.TryGetValue(id, out var produto))
            {
                return produto;
            }
            return null;
        }
        public static void Cadastro()
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
            IdCounter++;
            Produto produto = new(IdCounter, produtoGrupo, nome, _quantidade);
            produtos.Add(IdCounter, produto);
            Console.WriteLine("Produto" + nome + "cadastrado com sucesso!");
            // string? produtoGrupo, string? nome, int quantidade
        }
        public static void Remover()
        {
            Console.WriteLine("Insira o Id do Produto que deseja remover");
            string? entrada = Console.ReadLine();
            _ = int.TryParse(entrada, out int _id);
            if (produtos.TryGetValue(_id, out var produto))
            {
                Console.WriteLine("O produto:" + _id + ". Nome: " + produto.Nome + "será excluído!");
                if (Confirmar())
                {
                    produtos.Remove(_id);
                    Console.WriteLine("Produto removido!");
                }
                else
                {
                    Console.WriteLine("Operação cancelada");
                }
                PressioneParaSair();
            }
            else
            {
                Console.WriteLine("Produto não encontrado!");
                PressioneParaSair();
                Console.ReadKey();
            }
        }
        public static bool Confirmar()
        {
            Console.WriteLine("Você tem certeza que deseja fazer isso? Tecle Y para confirmar");
            string? entrada = Console.ReadLine();
            return string.IsNullOrWhiteSpace(entrada) == false && entrada.Trim().ToLower() == "y";
        }
        public static void PressioneParaSair()
        {
            Console.WriteLine("Aperte qualquer tecla para sair");
            Console.ReadKey();
        }
        public static void CreateDeafault()
        {
            IdCounter++;
            Produto produto1 = new(IdCounter, "Carro", "Civic", 11);
            produtos.Add(IdCounter, produto1); //instancia antes do metodo

            IdCounter++;
            Produto produto2 = new(IdCounter, "Carro", "Passat", 8);
            produtos.Add(IdCounter, produto2);

            IdCounter++;
            Produto produto3 = new(IdCounter, "Carro", "Omega", 4);
            produtos.Add(IdCounter, produto3);

        }
    }
}
