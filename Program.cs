using ConsoleApp1.Entidades;

namespace ConsoleApp1
{
    public class Program
    {
        public static readonly string padraoTelefone = @"^\d{8,9}$";
        private static Vendedor? vendedor;
        private static readonly GerCliente gerCliente = new();
        private static readonly GerVendedor gerVendedor = new();
        private static readonly GerProduto gerProduto = new();
        private static readonly GerVenda gerVenda = new();

        public static Vendedor? Vendedor { get => vendedor; set => vendedor = value; }

        //var cliente = new Cliente(int id, int anoNascimento,);
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
                Vendedor = gerVendedor.EncontrarVendedorPorUsuario(usuario, senha);
                if (Vendedor != null)
                {
                    Console.WriteLine("Login do vendedor " + Vendedor.Nome + " realizado!");
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
                                    foreach (var client in gerCliente.GetAll())
                                    {
                                        Console.WriteLine(client.Key + ". Nome: " + client.Value.Nome + " - Idade: " + (DateTime.Now.Year - client.Value.AnoNascimento).ToString() + " - E-mail: " + client.Value.Email);
                                    }
                                    Console.WriteLine("\n");
                                    Interface.PressioneParaSair();
                                    Console.ReadKey();
                                    break;
                                case 2:
                                    gerCliente.Cadastro();
                                    Interface.PressioneParaSair();
                                    break;
                                case 3:
                                    Console.WriteLine("Atualização de clientes em implementação");
                                    Interface.PressioneParaSair();
                                    break;
                                case 4:
                                    gerCliente.Remover();
                                    Interface.PressioneParaSair();
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
                                    foreach (var seller in gerVendedor.vendedores)
                                    {
                                        Console.WriteLine(seller.Key + ". Nome: " + seller.Value.Nome + " - Idade: " + (DateTime.Now.Year - seller.Value.AnoNascimento).ToString() + " - E-mail: " + seller.Value.Email);
                                    }
                                    Console.WriteLine("\n");
                                    Interface.PressioneParaSair();
                                    break;
                                case 2:
                                    gerVendedor.Cadastro();
                                    break;
                                case 3:
                                    Console.WriteLine("Atualização de vendedores em implementação");
                                    Interface.PressioneParaSair();
                                    break;
                                case 4:
                                    gerVendedor.Remover();
                                    Interface.PressioneParaSair();
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
                                    foreach (var product in gerProduto.produtos)
                                    {
                                        Console.WriteLine(product.Key + ". Produto: " + product.Value.ProdutoGrupo + " - Nome: " + product.Value.Nome + " - Quantidade: " + product.Value.Quantidade);
                                    }
                                    Console.WriteLine("\n");
                                    Interface.PressioneParaSair();
                                    break;
                                case 2:
                                    gerProduto.Cadastro();
                                    Interface.PressioneParaSair();
                                    break;
                                case 3:
                                    Console.WriteLine("Atualização de produtos em implementação");
                                    Interface.PressioneParaSair();
                                    break;
                                case 4:
                                    gerProduto.Remover();
                                    Interface.PressioneParaSair();
                                    break;
                                case 5:
                                    exitLoop = true;
                                    break;
                                default:
                                    Console.WriteLine("Ação inválida");
                                    Interface.PressioneParaSair();
                                    break;
                            }
                        }
                        break;
                    case 4://vendas
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
                                    foreach (var sale in gerVenda.vendas)
                                    {
                                        Console.WriteLine(sale.Key + ". Cliente: " + sale.Value.ClienteId + " - Vendedor: " + sale.Value.VendedorId);
                                        foreach(var product in sale.Value.Produtos)
                                        {
                                            Console.WriteLine("  " + product.Produto.Id + ". " + product.Produto.Nome + " - Quantidade: " + product.Quantidade);
                                        }
                                    }
                                    Console.WriteLine("\n");
                                    Interface.PressioneParaSair();
                                    break;
                                case 2:
                                    gerVenda.ExecutarVenda();
                                    break;
                                case 3:
                                    Console.WriteLine("Atualização de vendas em implementação");
                                    Interface.PressioneParaSair();
                                    break;
                                case 4:
                                    gerVenda.Remover();
                                    Interface.PressioneParaSair();
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