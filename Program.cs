using ConsoleApp1.Entidades;
using System.Diagnostics.Metrics;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    public class Program
    {
        public static readonly string padraoTelefone = @"^\d{8,9}$";
        private static string? vendedorNome;
        private static int? vendedorId;
        private static Vendedor? vendedor;
        private static object? produtos;
        private static int produtoVendaIdCounter;
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
                (vendedorId, vendedorNome) = gerVendedor.EncontrarVendedorPorUsuario(usuario, senha);
                if (vendedorId != null)
                {
                    Console.WriteLine("Login do vendedor " + vendedorNome + " realizado!");
                    return;
                }
                else
                {
                    Console.WriteLine("Usuário e senha inválidos!");
                }
            }

        }
        public static void CadastroCliente()
        {
            Console.WriteLine("Insira o Nome: ");
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
            Console.WriteLine("Insira o Ano de Nascimento: ");
            string? entrada = Console.ReadLine();
            _ = int.TryParse(entrada, out int _anoNascimento);
            while (_anoNascimento < 1 || _anoNascimento >= DateTime.Now.Year)
            {
                Console.WriteLine("Ano de Nascimento deve ser anterior ao atual. Por favor, insira um ano de nascimento válido ou digite sair para cancelar");
                entrada = Console.ReadLine();
                if (entrada == "sair")
                {
                    return;
                }
                _ = int.TryParse(entrada, out _anoNascimento);
            }
            Console.WriteLine("Insira o E-mail: ");
            string? email = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(email) || !email.Contains('@'))
            {
                Console.WriteLine("E-mail inválido. Por favor, insira um e-mail válido ou digite sair para cancelar");
                email = Console.ReadLine();
                if (email == "sair")
                {
                    return;
                }
            }
            Console.WriteLine("Insira o Telefone: ");
            string? telefone = Console.ReadLine();
            string padraoTelefone = @"^\d{8,9}$";
            while (string.IsNullOrWhiteSpace(telefone) || !Regex.IsMatch(telefone, padraoTelefone))
            {
                Console.WriteLine("Telefone inválido, o telefone deve conter apenas os dígitos. Por favor, insira um telefone válido ou digite sair para cancelar");
                telefone = Console.ReadLine();
                if (telefone == "sair")
                {
                    return;
                }
            }
            Console.WriteLine("Insira o Endereço: ");
            string? endereco = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(endereco) || endereco.Length < 5)
            {
                Console.WriteLine("Endereço inválido, o endereço deve conter pelo menos 5 caracteres. Por favor, insira um Endereço válido ou digite sair para cancelar");
                endereco = Console.ReadLine();
                if (endereco == "sair")
                {
                    return;
                }
            }
            string genero = "";
            string rg = "";
            string cpf = "";
            if (gerCliente.Cadastro(nome, _anoNascimento, email, telefone, endereco, genero, rg, cpf) != null)
            {
                Console.WriteLine("Cliente " + nome + "cadastrado com sucesso!");
            }
            else
            {
                Console.WriteLine("Ocorreu um erro ao cadastrar o cliente");
            }
            return;
        }
        public static void RemoverCliente()
        {
            Console.WriteLine("Insira o Id do Cliente que deseja remover");
            string? entrada = Console.ReadLine();
            if (int.TryParse(entrada, out int _id))
            {
                Cliente? cliente = gerCliente.GetById(_id);
                if (cliente != null)
                {
                    Console.WriteLine("O cliente:" + _id + ". Nome: " + cliente.Nome + " - E-mail: " + cliente.Email + "será excluído!");
                    if (Interface.Confirmar())
                    {
                        if (gerCliente.Remover(_id))
                        {
                            Console.WriteLine("Cliente removido!");
                        }
                        else
                        {
                            Console.WriteLine("Ocorreu um erro ao remover o cliente!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Operação cancelada");
                    }
                    Interface.PressioneParaSair();
                }
                else
                {
                    Console.WriteLine("Cliente não encontrado!");
                    Interface.PressioneParaSair();
                }
            }

        }
        public static void CadastroVendedor()
        {
            Console.WriteLine("Insira o Nome: ");
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
            Console.WriteLine("Insira o Ano de Nascimento: ");
            string? entrada = Console.ReadLine();
            _ = int.TryParse(entrada, out int _anoNascimento);
            while (_anoNascimento < 1 || _anoNascimento >= DateTime.Now.Year)
            {
                Console.WriteLine("Ano de Nascimento deve ser anterior ao atual. Por favor, insira um ano de nascimento válido ou digite sair para cancelar");
                entrada = Console.ReadLine();
                if (entrada == "sair")
                {
                    return;
                }
                _ = int.TryParse(entrada, out _anoNascimento);
            }
            Console.WriteLine("Insira o E-mail: ");
            string? email = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(email) || !email.Contains('@'))
            {
                Console.WriteLine("E-mail inválido. Por favor, insira um e-mail válido ou digite sair para cancelar");
                email = Console.ReadLine();
                if (email == "sair")
                {
                    return;
                }
            }
            Console.WriteLine("Insira o Telefone: ");
            string? telefone = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(telefone) || !Regex.IsMatch(telefone, pattern: Program.padraoTelefone))
            {
                Console.WriteLine("Telefone inválido, o telefone deve conter apenas os dígitos. Por favor, insira um telefone válido ou digite sair para cancelar");
                telefone = Console.ReadLine();
                if (telefone == "sair")
                {
                    return;
                }
            }
            Console.WriteLine("Insira o Endereço: ");
            string? endereco = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(endereco) || endereco.Length < 5)
            {
                Console.WriteLine("Endereço inválido, o endereço deve conter pelo menos 5 caracteres. Por favor, insira um Endereço válido ou digite sair para cancelar");
                endereco = Console.ReadLine();
                if (endereco == "sair")
                {
                    return;
                }
            }
            Console.WriteLine("Insira um Nome para o vendedor executar  login: ");
            string? usuario = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(usuario))
            {
                Console.WriteLine("Usuário não pode ser nulo ou vazio. Por favor, insira um nome de usuário válido ou digite sair para cancelar");
                usuario = Console.ReadLine();
                if (usuario == "sair")
                {
                    return;
                }
            }
            Console.WriteLine("Crie uma senha: ");
            string? senha = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(senha) || senha.Length < 4 || senha.Length > 10)
            {
                Console.WriteLine("A senha deve conter ao menos 4 caracteres e no máximo 10. Por favor, crie uma senha válida ou digite sair para cancelar");
                senha = Console.ReadLine();
                if (senha == "sair")
                {
                    return;
                }
            }
            int? vendedorId = gerVendedor.Cadastro(nome, _anoNascimento, email, telefone, endereco, usuario, senha);
            if (vendedorId != null)
            {
                Console.WriteLine("Vendedor" + nome + "cadastrado com sucesso!");
            } else
            {
                Console.WriteLine("Ocorreu um erro noc adastro do vendedor");
            }
            Interface.PressioneParaSair();
        }
        public static void RemoverVendedor()
        {
            Console.WriteLine("Insira o Id do Vendedor que deseja remover");
            string? entrada = Console.ReadLine();
            _ = int.TryParse(entrada, out int _id);
            Vendedor? vendedorRemover = gerVendedor.GetById(_id);
            if (vendedorRemover != null)
            {

                Console.WriteLine("O Vendedor:" + _id + ". Nome: " + vendedorRemover.Nome + " - E-mail: " + vendedorRemover.Email + "será excluído!");
                if (Interface.Confirmar())
                {
                    gerVendedor.Remover(_id);
                    Console.WriteLine("Vendedor removido!");
                }
                else
                {
                    Console.WriteLine("Operação cancelada");
                }
                Interface.PressioneParaSair();
            }
            else
            {
                Console.WriteLine("Vendedor não encontrado!");
                Interface.PressioneParaSair();
            }
        }
        public static void CadastroVenda()
        {
            Console.WriteLine("Insira o Id do cliente: ");
            string? entrada = Console.ReadLine();
            bool entradaValida = int.TryParse(entrada, out int _clienteId);
            Cliente? clienteVenda = gerCliente.GetById(_clienteId);
            while (!entradaValida || clienteVenda == null)
            {
                Console.WriteLine("Cliente não encontrado. Por favor, insira um id válido ou digite sair para cancelar");
                entrada = Console.ReadLine();
                if (entrada == "sair")
                {
                    return;
                }
                entradaValida = int.TryParse(entrada, out _clienteId);
                if (entradaValida)
                {
                    clienteVenda = gerCliente.GetById(_clienteId);
                }

            }
            produtoVendaIdCounter = 0;
            Dictionary<int, ProdutoVenda>? produtos = CadastroPrimeiroProdutoVenda();
            if (produtos == null)
            {
                Console.WriteLine("Criação da venda cancelada!");
            }
            else
            {
                while (true)
                {
                    Console.WriteLine("Você gostaria de adicionar mais produtos? Caso deseje adicionar mais produtos digite y");
                    string? entrada2 = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(entrada2) == false && entrada2.Trim().Equals("y", StringComparison.CurrentCultureIgnoreCase))
                    {
                        CadastroProdutoVenda(produtos);
                    }
                    else
                    {
                        break;
                    }
                }
                /* if (produtos != null)
                {
                    int? vendaId = gerVenda.Cadastro(produtos, _clienteId, vendedorId!.Value);
                    if (vendaId != null)
                    {
                        Console.WriteLine("Venda criada com sucesso!");
                    }
                    else
                    {
                        Console.WriteLine("Ocorreu um erro ao criar a venda");
                    }
                }
                Interface.PressioneParaSair();*/
            }

            if (produtos != null)
            {
                int? vendaId = gerVenda.Cadastro(produtos, _clienteId, vendedorId!.Value);
                if (vendaId != null)
                {
                    //CadastroProdutoVenda(vendaId.Value);
                    Console.WriteLine("Venda criada com sucesso!");
                }
                else
                {
                    Console.WriteLine("Ocorreu um erro ao criar a venda");
                }

                Interface.PressioneParaSair();
            }
               
        }
        public static void RemoverVenda()
        {
            Console.WriteLine("Insira o Id da Venda que deseja remover");
            string? entrada = Console.ReadLine();
            _ = int.TryParse(entrada, out int _id);
            Venda? vendaRemover = gerVenda.GetById(_id);
            if (vendaRemover != null)
            {
                string clienteNome = "Não Encontrado"; //definido antes
                Cliente? clienteVenda = gerCliente.GetById(vendaRemover.ClienteId);
                if (clienteVenda != null)
                {
                    clienteNome = clienteVenda.Nome;
                }
                Console.WriteLine("A venda:" + _id + "para o cliente" + clienteNome + "será excluída!");
                if (Interface.Confirmar())
                {
                    if (gerVenda.Remover(_id))
                    {
                        Console.WriteLine("Venda removida!");
                    }
                    else
                    {
                        Console.WriteLine("Ocorreu um erro");
                    }
                }
                else
                {
                    Console.WriteLine("Operação cancelada");
                }
                Interface.PressioneParaSair();
            }
            else
            {
                Console.WriteLine("Venda não encontrada!");
                Interface.PressioneParaSair();
            }
        }
        public static void CadastroProdutoVenda(Dictionary<int, ProdutoVenda> produtos)
        {
            (Produto? produto, int? quantidade) = CadastroProdutoVenda2();
            if (produto != null && quantidade != null)
            {
                ProdutoVenda produtoVenda = new(produto, (int)quantidade);
                produtoVendaIdCounter++;
                if (produtos.TryAdd(produtoVendaIdCounter, produtoVenda))
                {
                    Console.WriteLine("Produto adicionado com sucesso!");
                }
                else
                {
                    Console.WriteLine("Não foi possível adicionar o produto, verifique o estoque");
                }
            }

        }
        public static Dictionary<int, ProdutoVenda>? CadastroPrimeiroProdutoVenda()
        {
            (Produto? produto, int? quantidade) = CadastroProdutoVenda2();
            if(produto != null && quantidade != null)
            {
                ProdutoVenda produtoVenda = new(produto, (int)quantidade!);
                produtoVendaIdCounter++;
                produtos = new Dictionary<int, ProdutoVenda>()
                {
                    {produtoVendaIdCounter, produtoVenda}
                };
                return (Dictionary<int, ProdutoVenda>?)produtos;
            }
            return null;
        }
        public static (Produto?, int?) CadastroProdutoVenda2()
        {
            Console.WriteLine("Insira o Id do produto: ");
            string? entrada = Console.ReadLine();
            bool entradaValida = int.TryParse(entrada, out int _produtoId);
            Produto? produto = gerProduto.GetById(_produtoId);
            int estoque;
            while (!entradaValida || produto == null)
            {
                Console.WriteLine("Produto não encontrado. Por favor, insira um id válido ou digite sair para cancelar");
                entrada = Console.ReadLine();
                if (entrada == "sair")
                {
                    return (null, null);
                }
                entradaValida = int.TryParse(entrada, out _produtoId);
                produto = gerProduto.GetById(_produtoId);
                if (produto != null)
                {
                    estoque = produto.Quantidade;
                    if (estoque < 1)
                    {
                        Console.WriteLine("Produto indisponível para venda! Por favor, insira o id de outro produto ou digite sair para cancelar\"");
                        entrada = Console.ReadLine();
                        if (entrada == "sair")
                        {
                            return (null, null);
                        }
                    }
                }
            }
            estoque = produto.Quantidade;
            int quantidade;
            while (true)
            {
                Console.WriteLine("Insira a quantidade do prduto: ");
                entrada = Console.ReadLine();
                if (int.TryParse(entrada, out quantidade))
                {
                    if (quantidade > 0 && quantidade <= estoque)
                    {
                        break;
                    }
                    else if (quantidade > estoque)
                    {
                        Console.WriteLine("Estoque atual: " + estoque + "! Por favor, insira uma quantidade válida ou digite sair para cancelar");
                    }
                    else
                    {
                        Console.WriteLine("Quantidade inválida. Por favor, insira uma quantidade válida ou digite sair para cancelar");
                    }
                }
                else
                {
                    Console.WriteLine("Entrada inválida. Por favor, insira uma quantidade válida ou digite sair para cancelar");
                    entrada = Console.ReadLine();
                    if (entrada == "sair")
                    {
                        return (null, null);
                    }
                }

            }
            if (gerProduto.AtualizarEstoqueProduto(_produtoId, -quantidade))
            {
                return (produto, quantidade);
            }
            else
                Console.WriteLine("Não foi possível adicionar o produto, verifique o estoque");
                return (null, null);
            }
        
        public static void RemoverProdutoVenda()
        {

        }
        public static void CadastroProduto()
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
            if (gerProduto.Cadastro(produtoGrupo, nome, _quantidade, preco) != null)
            {
                Console.WriteLine("Produto" + nome + "cadastrado com sucesso!");
            } else
            {
                Console.WriteLine("Ocorreu um erro");
            }
            
            
            
        }
        public static void RemoverProduto()
        {
            Console.WriteLine("Insira o Id do Produto que deseja remover");
            string? entrada = Console.ReadLine();
            if (int.TryParse(entrada, out int _id))
            {
                Produto? produtoRemover = gerProduto.GetById(_id);
                if (produtoRemover != null)
                {
                    Console.WriteLine("O produto:" + _id + ". Nome: " + produtoRemover.Nome + "será excluído!");
                    if (Interface.Confirmar())
                    {
                        if (gerProduto.Remover(_id))
                        {
                            Console.WriteLine("Produto removido!");
                        }
                        else
                        {
                            Console.WriteLine("Ocorreu um erro ao remover o produto!");
                        }
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
                                    break;
                                case 2:
                                    CadastroCliente();
                                    Interface.PressioneParaSair();
                                    break;
                                case 3:
                                    Console.WriteLine("Atualização de clientes em implementação");
                                    Interface.PressioneParaSair();
                                    break;
                                case 4:
                                    RemoverCliente();
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
                                    foreach (var seller in gerVendedor.GetAll())
                                    {
                                        Console.WriteLine(seller.Key + ". Nome: " + seller.Value.Nome + " - Idade: " + (DateTime.Now.Year - seller.Value.AnoNascimento).ToString() + " - E-mail: " + seller.Value.Email);
                                    }
                                    Console.WriteLine("\n");
                                    Interface.PressioneParaSair();
                                    break;
                                case 2:
                                    CadastroVendedor();
                                    break;
                                case 3:
                                    Console.WriteLine("Atualização de vendedores em implementação");
                                    Interface.PressioneParaSair();
                                    break;
                                case 4:
                                    RemoverVendedor();
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
                                    foreach (var product in gerProduto.GetAll())
                                    {
                                        Console.WriteLine(product.Key + ". Produto: " + product.Value.ProdutoGrupo + " - Nome: " + product.Value.Nome + " - Quantidade: " + product.Value.Quantidade);
                                    }
                                    Console.WriteLine("\n");
                                    Interface.PressioneParaSair();
                                    break;
                                case 2:
                                    CadastroProduto();
                                    Interface.PressioneParaSair();
                                    break;
                                case 3:
                                    Console.WriteLine("Atualização de produtos em implementação");
                                    Interface.PressioneParaSair();
                                    break;
                                case 4:
                                    RemoverProduto();
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
                                    foreach (var sale in gerVenda.GetAll())
                                    {
                                        Console.WriteLine(sale.Key + ". Cliente: " + sale.Value.ClienteId + " - Vendedor: " + sale.Value.VendedorId);
                                        foreach (var product in sale.Value.Produtos)
                                        {
                                            //Console.WriteLine("   " + product.Key + ". " + product.Value.Produto.Nome + " - Quantidade: " + product.Value.Quantidade);
                                            Console.WriteLine($"    {product.Key}. {product.Value.Produto.Nome} - Quantidade: {product.Value.Quantidade}");
                                        }
                                    }
                                    Console.WriteLine("\n");
                                    Interface.PressioneParaSair();
                                    break;
                                case 2:
                                    CadastroVenda();

                                    break;
                                case 3:
                                    Console.WriteLine("Atualização de vendas em implementação");
                                    Interface.PressioneParaSair();
                                    break;
                                case 4:
                                    RemoverVenda();
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