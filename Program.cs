using ConsoleApp1.Entidades;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    public class Program
    {
        private static int globalIdCounter = 1;
        private static readonly string padraoTelefone = @"^\d{8,9}$";
        public static readonly Dictionary<int, Cliente> clientes = [];
        public static readonly Dictionary<int, Vendedor> vendedores = [];
        public static readonly Dictionary<int, Produto> produtos = [];
        public static readonly Dictionary<int, Venda> vendas = [];
       

        public static void CadastroCliente()
        {
            Console.WriteLine("Insira o Nome: ");
            string? nome = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(nome))
            {
                Console.WriteLine("Nome não pode ser nulo ou vazio. Por favor, insira um nome válido");
                nome = Console.ReadLine();
            }
            Console.WriteLine("Insira o Ano de Nascimento: ");
            string? entrada = Console.ReadLine();
            _ = int.TryParse(entrada, out int _anoNascimento);
            while (_anoNascimento < 1 || _anoNascimento >= DateTime.Now.Year)
            {
                Console.WriteLine("Ano de Nascimento deve ser anterior ao atual. Por favor, insira um ano de nascimento válido");
                entrada = Console.ReadLine();
                _ = int.TryParse(entrada, out _anoNascimento);
            }
            Console.WriteLine("Insira o E-mail: ");
            string? email = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(email) || !email.Contains('@'))
            {
                Console.WriteLine("E-mail inválido. Por favor, insira um e-mail válido");
                email = Console.ReadLine();
            }
            Console.WriteLine("Insira o Telefone: ");
            string? telefone = Console.ReadLine();
            string padraoTelefone = @"^\d{8,9}$";
            while (string.IsNullOrWhiteSpace(telefone) || !Regex.IsMatch(telefone, padraoTelefone))
            {
                Console.WriteLine("Telefone inválido, o telefone deve conter apenas os dígitos. Por favor, insira um telefone válido");
                telefone = Console.ReadLine();
            }
            Console.WriteLine("Insira o Endereço: ");
            string? endereco = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(endereco) || endereco.Length < 5)
            {
                Console.WriteLine("Endereço inválido, o endereço deve conter pelo menos 5 caracteres. Por favor, insira um Endereço válido");
                endereco = Console.ReadLine();
            }
            Cliente cliente = new(nome, _anoNascimento, email, telefone, endereco);
            clientes.Add(globalIdCounter++, cliente);
            Console.WriteLine("Cliente " + nome + "cadastrado com sucesso!");
            Console.WriteLine("Pressione qualquer tecla para voltar");
            Console.ReadKey();
            // nome, anoNascimento, email, telefone, endereco
        }
        public static void RemoverCliente()
        {
            Console.WriteLine("Insira o Id do Cliente que deseja remover");
            string? entrada = Console.ReadLine();
            if (int.TryParse(entrada, out int _id))
            {
                if (clientes.TryGetValue(_id, out var cliente))
                {
                    Console.WriteLine("O cliente:" + _id + ". Nome: " + cliente.Nome + " - E-mail: " + cliente.Email + "será excluído!");
                    clientes.Remove(_id);
                    Console.WriteLine("Pressione qualquer tecla para voltar");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Cliente não encontrado!");
                    Console.WriteLine("Pressione qualquer tecla para voltar");
                    Console.ReadKey();
                }
            }
            
        }

        public static void CadastroVendedor()
        {
            Console.WriteLine("Insira o Nome: ");
            string? nome = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(nome))
            {
                Console.WriteLine("Nome não pode ser nulo ou vazio. Por favor, insira um nome válido");
                nome = Console.ReadLine();
            }
            Console.WriteLine("Insira o Ano de Nascimento: ");
            string? entrada = Console.ReadLine();
            _ = int.TryParse(entrada, out int _anoNascimento);
            while (_anoNascimento < 1 || _anoNascimento >= DateTime.Now.Year)
            {
                Console.WriteLine("Ano de Nascimento deve ser anterior ao atual. Por favor, insira um ano de nascimento válido");
                entrada = Console.ReadLine();
                _ = int.TryParse(entrada, out _anoNascimento);
            }
            Console.WriteLine("Insira o E-mail: ");
            string? email = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(email) || !email.Contains('@'))
            {
                Console.WriteLine("E-mail inválido. Por favor, insira um e-mail válido");
                email = Console.ReadLine();
            }
            Console.WriteLine("Insira o Telefone: ");
            string? telefone = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(telefone) || !Regex.IsMatch(telefone, pattern: padraoTelefone))
            {
                Console.WriteLine("Telefone inválido, o telefone deve conter apenas os dígitos. Por favor, insira um telefone válido");
                telefone = Console.ReadLine();
            }
            Console.WriteLine("Insira o Endereço: ");
            string? endereco = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(endereco) || endereco.Length < 5)
            {
                Console.WriteLine("Endereço inválido, o endereço deve conter pelo menos 5 caracteres. Por favor, insira um Endereço válido");
                endereco = Console.ReadLine();
            }
            Vendedor vendedor = new(nome, _anoNascimento, email, telefone, endereco);
            vendedores.Add(globalIdCounter++, vendedor);
            Console.WriteLine("Vendedor" + nome + "cadastrado com sucesso!");
            Console.WriteLine("Pressione qualquer tecla para voltar");
            Console.ReadKey();
            // nome, anoNascimento, email, telefone, endereco
        }
        public static void RemoverVendedor()
        {
            Console.WriteLine("Insira o Id do Vendedor que deseja remover");
            string? entrada = Console.ReadLine();
            _ = int.TryParse(entrada, out int _id);
            if (vendedores.TryGetValue(_id, out var vendedor))
            {
                Console.WriteLine("O Vendedor:" + _id + ". Nome: " + vendedor.Nome + " - E-mail: " + vendedor.Email + "será excluído!");
                clientes.Remove(_id);
                Console.WriteLine("Pressione qualquer tecla para voltar");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Vendedor não encontrado!");
                Console.WriteLine("Pressione qualquer tecla para voltar");
                Console.ReadKey();
            }
        }

        public static void CadastroProduto()
        {
            Console.WriteLine("Insira o Nome do Produto: ");
            string? nome = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(nome))
            {
                Console.WriteLine("Nome não pode ser nulo ou vazio. Por favor, insira um nome válido");
                nome = Console.ReadLine();
            }
            Console.WriteLine("Insira o nome do Grupo do Produto: ");
            string? produtoGrupo = Console.ReadLine();            
            Console.WriteLine("Insira a quantidade: ");
            string? entrada = Console.ReadLine();
            //_ = int.TryParse(entrada, out int _quantidade);
            int _quantidade;
            while (!int.TryParse(entrada, out _quantidade) || _quantidade < 0)
            {
                Console.WriteLine("Quantidade inválida. Por favor, insira uma quantidade válida");
                entrada = Console.ReadLine();
                _ = int.TryParse(entrada, out _quantidade);
            }
            Produto produto = new(produtoGrupo, nome, _quantidade);
            produtos.Add(globalIdCounter++, produto);
            Console.WriteLine("Produto" + nome + "cadastrado com sucesso!");
            Console.WriteLine("Pressione qualquer tecla para voltar");
            Console.ReadKey();
            // string? produtoGrupo, string? nome, int quantidade
        }
        public static void RemoverProduto()
        {
            Console.WriteLine("Insira o Id do Produto que deseja remover");
            string? entrada = Console.ReadLine();
            _ = int.TryParse(entrada, out int _id);
            if (produtos.TryGetValue(_id, out var produto))
            {
                Console.WriteLine("O produto:" + _id + ". Nome: " + produto.Nome + "será excluído!");
                clientes.Remove(_id);
                Console.WriteLine("Pressione qualquer tecla para voltar");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Produto não encontrado!");
                Console.WriteLine("Pressione qualquer tecla para voltar");
                Console.ReadKey();
            }
        }

        public static void ExecutarVenda()
        {
            Console.WriteLine("Insira o Id do vendedor: ");
            string? entrada = Console.ReadLine();
            _ = int.TryParse(entrada, out int _vendedorId);
            Console.WriteLine("Insira o Id do cliente: ");
            entrada = Console.ReadLine();
            _ = int.TryParse(entrada, out int _clienteId);
            Console.WriteLine("Insira o Id do produto: ");
            entrada = Console.ReadLine();
            _ = int.TryParse(entrada, out int _produtoId);
            Venda venda = new(_produtoId, _clienteId, _vendedorId);
            
            //pedir quantidade do produto
            //ListaProduto[_produtoId].Quantidade--;
            //produtos(_produtoId).Value.Quantidade--;
            produtos.TryGetValue(_produtoId, out var produto);
            produtos.Remove(_produtoId);
            produtos.TryAdd(_produtoId, produto);
            vendas.Add(globalIdCounter++, venda);
            Console.WriteLine("Venda " + "" + " criada com sucesso! O vendedor " + "" + " vendeu um " + "" + " para o cliente " + "");
            Console.WriteLine("Pressione qualquer tecla para voltar");
            Console.ReadKey();
        }
        public static void RemoverVenda()
        {
            Console.WriteLine("Insira o Id da Venda que deseja remover");
            string? entrada = Console.ReadLine();
            _ = int.TryParse(entrada, out int _id);
            if (vendas.TryGetValue(_id, out var venda))
            {
                string clienteNome = "Não Encontrado"; //definido antes
                if (clientes.TryGetValue(venda.ClienteId, out var cliente))
                {
                    clienteNome = cliente.Nome;
                }
                Console.WriteLine("A venda:" + _id + "para o cliente" + clienteNome + "será excluída!");
                vendas.Remove(_id);
                Console.WriteLine("Pressione qualquer tecla para voltar");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Venda não encontrada!");
                Console.WriteLine("Pressione qualquer tecla para voltar");
                Console.ReadKey();
            }
        }

        private static void CreateDeafault()
        {
            Cliente cliente1 = new("LUCAS AMORIM", 1994, "lucas.amorim.18@gmail.com", "996199322", "Rua Luverci");
            clientes.Add(globalIdCounter++, cliente1);

            Cliente cliente2 = new("ARNALDO DA SILVA", 2002, "arnaldo.silva@gmail.com", "996199322", "Alameda Abrolhos");
            clientes.Add(globalIdCounter++, cliente2);

            Cliente cliente3 = new("BERNARDO COSTA", 2003, "bernardo.costa@gmail.com", "996199322", "Avenida Bertollini");
            clientes.Add(globalIdCounter++, cliente3);

            Vendedor vendedor1 = new("TIAGO RODRIGUES", 1994, "tiago.rodr@gmail.com", "996199322", "Rua Tamandaré");
            vendedores.Add(globalIdCounter++, vendedor1); //instancia antes do metodo

            Vendedor vendedor2 = new("CELIO SANTOS", 2002, "celio.santos@gmail.com", "996199322", "Alameda Corvinal");
            vendedores.Add(globalIdCounter++, vendedor2);

            Vendedor vendedor3 = new("DANILO OLIVEIRA", 2003, "danilo.oliv@gmail.com", "996199322", "Avenida Diamantina");
            vendedores.Add(globalIdCounter++, vendedor3);


            Produto produto1 = new("Carro", "Civic", 11);
            produtos.Add(globalIdCounter++, produto1); //instancia antes do metodo

            Produto produto2 = new("Carro", "Passat", 8);
            produtos.Add(globalIdCounter++, produto2);

            Produto produto3 = new("Carro", "Omega", 4);
            produtos.Add(globalIdCounter++, produto3);

            //imprimi a lista para testar
            
            
            
        }
        public static void Main()
        {
            CreateDeafault();
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
                                    foreach (var client in clientes)
                                    {
                                        Console.WriteLine(client.Key + ". Nome: " + client.Value.Nome + " - Idade: " + (DateTime.Now.Year - client.Value.AnoNascimento).ToString() + " - E-mail: " + client.Value.Email);
                                    }
                                    Console.WriteLine("\n");
                                    Console.WriteLine("Pressione qualquer tecla para voltar");
                                    Console.ReadKey();
                                    break;
                                case 2:
                                    CadastroCliente();
                                    break;
                                case 3:
                                    Console.WriteLine("Atualização de clientes em implementação");
                                    Console.WriteLine("Pressione qualquer tecla para voltar");
                                    Console.ReadKey();
                                    break;
                                case 4:
                                    RemoverCliente();
                                    Console.WriteLine("Pressione qualquer tecla para voltar");
                                    Console.ReadKey();
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
                                    foreach (var seller in vendedores)
                                    {
                                        Console.WriteLine(seller.Key + ". Nome: " + seller.Value.Nome + " - Idade: " + (DateTime.Now.Year - seller.Value.AnoNascimento).ToString() + " - E-mail: " + seller.Value.Email);
                                    }
                                    Console.WriteLine("\n");
                                    Console.WriteLine("Pressione qualquer tecla para voltar");
                                    Console.ReadKey();
                                    break;
                                case 2:
                                    CadastroVendedor();
                                    break;
                                case 3:
                                    Console.WriteLine("Atualização de vendedores em implementação");
                                    Console.WriteLine("Pressione qualquer tecla para voltar");
                                    Console.ReadKey();
                                    break;
                                case 4:
                                    RemoverVendedor();
                                    Console.WriteLine("Pressione qualquer tecla para voltar");
                                    Console.ReadKey();
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
                                    foreach (var product in produtos)
                                    {
                                        Console.WriteLine(product.Key + ". Produto: " + product.Value.ProdutoGrupo + " - Nome: " + product.Value.Nome + " - Quantidade: " + product.Value.Quantidade);
                                    }
                                    Console.WriteLine("\n");
                                    Console.WriteLine("Pressione qualquer tecla para voltar");
                                    Console.ReadKey();
                                    break;
                                case 2:
                                    CadastroProduto();
                                    break;
                                case 3:
                                    Console.WriteLine("Atualização de produtos em implementação");
                                    Console.WriteLine("Pressione qualquer tecla para voltar");
                                    Console.ReadKey();
                                    break;
                                case 4:
                                    RemoverProduto();
                                    Console.WriteLine("Pressione qualquer tecla para voltar");
                                    Console.ReadKey();
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
                                    foreach (var sale in vendas)
                                    {
                                        Console.WriteLine(sale.Key + ". Produto: " + sale.Value.ProdutoId + " - Cliente: " + sale.Value.ClienteId + " - Vendedor: " + sale.Value.VendedorId);
                                    }
                                    Console.WriteLine("\n");
                                    Console.WriteLine("Pressione qualquer tecla para voltar");
                                    Console.ReadKey();
                                    break;
                                case 2:
                                    ExecutarVenda();
                                    break;
                                case 3:
                                    Console.WriteLine("Atualização de vendas em implementação");
                                    Console.WriteLine("Pressione qualquer tecla para voltar");
                                    Console.ReadKey();
                                    break;
                                case 4:
                                    RemoverVenda();
                                    Console.WriteLine("Pressione qualquer tecla para voltar");
                                    Console.ReadKey();
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