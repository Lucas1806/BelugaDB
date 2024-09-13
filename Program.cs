using ConsoleApp1.Entidades;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Linq;

namespace ConsoleApp1
{
    public class Program
    {
        public static readonly string padraoTelefone = @"^\d{8,9}$";
        public static Vendedor? vendedor;

        //var cliente = new Cliente(int id, int anoNascimento,);
        public static void PressioneParaSair()
        {
            Console.WriteLine("Aperte qualquer tecla para sair");
            Console.ReadKey();
        }
        public static bool Confirmar()
        {
            Console.WriteLine("Você tem certeza que deseja fazer isso? Tecle Y para confirmar");
            string? entrada = Console.ReadLine();
            return string.IsNullOrWhiteSpace(entrada) == false && entrada.Trim().ToLower() == "y";
        }
        /* public static void Acao(bool confirmar)
        {
            if (confirmar)
            {
                Console.WriteLine("Operação realizada!");
            }
            else
            {
                Console.WriteLine("Operação cancelada!");
            }
        }*/
        
        public static void Login()
        {
            while (true)
            {
                Console.Write("Digite seu nome de usuário: ");
                string? usuario = Console.ReadLine();
                while (string.IsNullOrWhiteSpace(usuario))
                {
                    Console.WriteLine("Usuario não pode ser nulo ou vazio. Por favor, insira um usuário válido");
                    usuario = Console.ReadLine();
                }
                Console.Write("Digite sua senha: ");
                string? senha = Console.ReadLine();
                vendedor = Vendedor.EncontrarVendedorPorUsuario(usuario, senha);
                if (vendedor != null)
                {
                    Console.WriteLine("Login do vendedor " + vendedor.Nome + " realizado!");
                    return;
                }
                else
                {
                    Console.WriteLine("Usuário e senha inválidos!");
                }
            }
            
        }
        public static void Main()
        {
            Vendedor.CreateDefualt();
            Cliente.CreateDefault();
            Produto.CreateDeafault();
            Login();
            bool exitLoop;

            while (true)
            {
                exitLoop = false;
                Console.Clear();
                Console.WriteLine("Bem-vindo! Escolha um módulo:");
                Console.WriteLine("1. Clientes");
                Console.WriteLine("2. Vendedores");
                Console.WriteLine("3. Produtos");
                Console.WriteLine("4. Vendas");
                Console.WriteLine("5. Sair do programa");
                string? entrada = Console.ReadLine();
                _ = int.TryParse(entrada, out int opcao);

                switch (opcao)
                {
                    case 1: //clientes
                        while (!exitLoop)
                        {
                            Console.Clear();
                            Console.WriteLine("Módulo de Clientes. Escolha uma ação");
                            Console.WriteLine("1. Visualizar clientes");
                            Console.WriteLine("2. Cadastrar cliente");
                            Console.WriteLine("3. Atualizar cliente");
                            Console.WriteLine("4. Excluir cliente");
                            Console.WriteLine("5. Sair do módulo de Clientes");
                            entrada = Console.ReadLine();
                            _ = int.TryParse(entrada, out opcao);

                            switch (opcao)
                            {
                                case 1:
                                    Console.WriteLine("Lista de Clientes");
                                    foreach (var client in Cliente.clientes)
                                    {
                                        Console.WriteLine(client.Key + ". Nome: " + client.Value.Nome + " - Idade: " + (DateTime.Now.Year - client.Value.AnoNascimento).ToString() + " - E-mail: " + client.Value.Email);
                                    }
                                    Console.WriteLine("\n");
                                    PressioneParaSair();
                                    Console.ReadKey();
                                    break;
                                case 2:
                                    Cliente.Cadastro();
                                    PressioneParaSair();
                                    break;
                                case 3:
                                    Console.WriteLine("Atualização de clientes em implementação");
                                    PressioneParaSair();
                                    break;
                                case 4:
                                    Cliente.Remover();
                                    PressioneParaSair();
                                    break;
                                case 5:
                                    exitLoop = true;
                                    break;
                                default:
                                    Console.WriteLine("Ação inválida");
                                    Console.ReadKey();
                                    break;
                            }
                        }
                        break;
                    case 2: //vendedores
                        while (!exitLoop)
                        {
                            Console.Clear();
                            Console.WriteLine("Módulo de Vendedores. Escolha uma ação");
                            Console.WriteLine("1. Visualizar vendedores");
                            Console.WriteLine("2. Cadastrar vendedor");
                            Console.WriteLine("3. Atualizar vendedor");
                            Console.WriteLine("4. Excluir vendedor");
                            Console.WriteLine("5. Sair do módulo de Vendedores");
                            entrada = Console.ReadLine();
                            _ = int.TryParse(entrada, out opcao);

                            switch (opcao)
                            {
                                case 1:
                                    foreach (var seller in Vendedor.vendedores)
                                    {
                                        Console.WriteLine(seller.Key + ". Nome: " + seller.Value.Nome + " - Idade: " + (DateTime.Now.Year - seller.Value.AnoNascimento).ToString() + " - E-mail: " + seller.Value.Email);
                                    }
                                    Console.WriteLine("\n");
                                    PressioneParaSair();
                                    break;
                                case 2:
                                    Vendedor.CadastroVendedor();
                                    break;
                                case 3:
                                    Console.WriteLine("Atualização de vendedores em implementação");
                                    PressioneParaSair();
                                    break;
                                case 4:
                                    Vendedor.RemoverVendedor();
                                    PressioneParaSair();
                                    break;
                                case 5:
                                    exitLoop = true;
                                    break;
                                default:
                                    Console.WriteLine("Ação inválida");
                                    Console.ReadKey();
                                    break;
                            }
                        }
                        break;
                    case 3: //produtos
                        while (!exitLoop)
                        {
                            Console.Clear();
                            Console.WriteLine("Módulo de Produtos. Escolha uma ação");
                            Console.WriteLine("1. Visualizar produtos");
                            Console.WriteLine("2. Cadastrar produto");
                            Console.WriteLine("3. Atualizar produto");
                            Console.WriteLine("4. Excluir produto");
                            Console.WriteLine("5. Sair do módulo de Produtos");
                            entrada = Console.ReadLine();
                            _ = int.TryParse(entrada, out opcao);

                            switch (opcao)
                            {
                                case 1:
                                    Console.WriteLine("Lista de Produtos");
                                    foreach (var product in Produto.produtos)
                                    {
                                        Console.WriteLine(product.Key + ". Produto: " + product.Value.ProdutoGrupo + " - Nome: " + product.Value.Nome + " - Quantidade: " + product.Value.Quantidade);
                                    }
                                    Console.WriteLine("\n");
                                    PressioneParaSair();
                                    break;
                                case 2:
                                    Produto.Cadastro();
                                    PressioneParaSair();
                                    break;
                                case 3:
                                    Console.WriteLine("Atualização de produtos em implementação");
                                    PressioneParaSair();
                                    break;
                                case 4:
                                    Produto.Remover();
                                    PressioneParaSair();
                                    break;
                                case 5:
                                    exitLoop = true;
                                    break;
                                default:
                                    Console.WriteLine("Ação inválida");
                                    PressioneParaSair();
                                    break;
                            }
                        }
                        break;
                    case 4:
                        while (!exitLoop)
                        {
                            Console.Clear();
                            Console.WriteLine("Módulo de Vendas. Escolha uma ação");
                            Console.WriteLine("1. Visualizar vendas");
                            Console.WriteLine("2. Cadastrar venda");
                            Console.WriteLine("3. Atualizar venda");
                            Console.WriteLine("4. Excluir venda");
                            Console.WriteLine("5. Sair do módulo de Vendas");
                            entrada = Console.ReadLine();
                            _ = int.TryParse(entrada, out opcao);

                            switch (opcao)
                            {
                                case 1:
                                    Console.WriteLine("Lista de Vendas");
                                    foreach (var sale in Venda.vendas)
                                    {
                                        Console.WriteLine(sale.Key + ". Produto: " + sale.Value.ProdutoId + " - Cliente: " + sale.Value.ClienteId + " - Vendedor: " + sale.Value.VendedorId);
                                    }
                                    Console.WriteLine("\n");
                                    PressioneParaSair();
                                    break;
                                case 2:
                                    Venda.ExecutarVenda();
                                    break;
                                case 3:
                                    Console.WriteLine("Atualização de vendas em implementação");
                                    PressioneParaSair();
                                    break;
                                case 4:
                                    Venda.Remover();
                                    PressioneParaSair();
                                    break;
                                case 5:
                                    exitLoop = true;
                                    break;
                                default:
                                    Console.WriteLine("Ação inválida");
                                    Console.ReadKey();
                                    break;
                            }
                        }
                        break;
                    case 5: return;
                    default:
                        Console.WriteLine("Ação inválida");
                        Console.ReadKey();
                        break;
                }
            }



        }
    }
}