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
        private static int globalIdCounter = 1;
        private static readonly string padraoTelefone = @"^\d{8,9}$";
        private static Vendedor? vendedor;
        public static readonly Dictionary<int, Cliente> clientes = [];
        public static readonly Dictionary<int, Vendedor> vendedores = [];
        public static readonly Dictionary<int, Produto> produtos = [];
        public static readonly Dictionary<int, Venda> vendas = [];
       
        public static void PressioneParaSair()
        {
            PressioneParaSair();
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
            string cpf = "";
            string rg = "";
            globalIdCounter++;
            Cliente cliente = new(globalIdCounter, nome, _anoNascimento, email, telefone, endereco, genero, rg, cpf);
            clientes.Add(globalIdCounter, cliente);
            Console.WriteLine("Cliente " + nome + "cadastrado com sucesso!");
            PressioneParaSair();
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
                    if (Confirmar())
                    {
                        clientes.Remove(_id);
                        Console.WriteLine("Cliente removido!");
                    }
                    else
                    {
                        Console.WriteLine("Operação cancelada");
                    }
                    PressioneParaSair();
                }
                else
                {
                    Console.WriteLine("Cliente não encontrado!");
                    PressioneParaSair();
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
            while (string.IsNullOrWhiteSpace(telefone) || !Regex.IsMatch(telefone, pattern: padraoTelefone))
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
            globalIdCounter++;
            Vendedor vendedor = new(globalIdCounter, nome, _anoNascimento, email, telefone, endereco, usuario, senha);
            vendedores.Add(globalIdCounter, vendedor);
            Console.WriteLine("Vendedor" + nome + "cadastrado com sucesso!");
            PressioneParaSair();
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
                if (Confirmar())
                {
                    vendedores.Remove(_id);
                    Console.WriteLine("Vendedor removido!");
                }
                else
                {
                    Console.WriteLine("Operação cancelada");
                }
                PressioneParaSair();
            }
            else
            {
                Console.WriteLine("Vendedor não encontrado!");
                PressioneParaSair();
            }
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
            globalIdCounter++;
            Produto produto = new(globalIdCounter, produtoGrupo, nome, _quantidade);
            produtos.Add(globalIdCounter, produto);
            Console.WriteLine("Produto" + nome + "cadastrado com sucesso!");
            PressioneParaSair();
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

        public static void ExecutarVenda()
        {
            //Cliente
            Console.WriteLine("Insira o Id do cliente: ");
            string? entrada = Console.ReadLine();
            bool v = int.TryParse(entrada, out int _clienteId);
            Cliente? cliente;
            while (!v || !clientes.TryGetValue(_clienteId, out cliente))
            {
                Console.WriteLine("Cliente não encontrado. Por favor, insira um id válido ou digite sair para cancelar");
                entrada = Console.ReadLine();
                if (entrada == "sair")
                {
                    return;
                }
                v = int.TryParse(entrada, out _clienteId);
            }
            /*{
                if (clientes.TryGetValue(_id, out var cliente))
                {
                    Console.WriteLine("O cliente:" + _id + ". Nome: " + cliente.Nome + " - E-mail: " + cliente.Email + "será excluído!");
                    clientes.Remove(_id);
                    PressioneParaSair();
                }
                else
                {
                    Console.WriteLine("Cliente não encontrado!");
                    PressioneParaSair();
                }
            }*/
            //Produto
            Console.WriteLine("Insira o Id do produto: ");
            entrada = Console.ReadLine();
            v = int.TryParse(entrada, out int _produtoId);
            int estoque = 0;
            Produto? produto;
            while (!v || !produtos.TryGetValue(_produtoId, out produto))
            {
                Console.WriteLine("Produto não encontrado. Por favor, insira um id válido ou digite sair para cancelar");
                entrada = Console.ReadLine();
                if (entrada == "sair")
                {
                    return;
                }
                v = int.TryParse(entrada, out _produtoId);
                if (produtos.TryGetValue(_produtoId, out produto))
                {
                    estoque = produto.Quantidade;
                    if (estoque < 1)
                    {
                        Console.WriteLine("Produto indisponível para venda! Por favor, insira o id de outro produto ou digite sair para cancelar\"");
                        entrada = Console.ReadLine();
                        if (entrada == "sair")
                        {
                            return;
                        }
                    }
                }
            }
            int quantidade;
            while (!int.TryParse(entrada, out quantidade) || quantidade < 0 || quantidade > estoque)
            {
                if (quantidade > estoque)
                {
                    Console.WriteLine("Estoque atual: " + estoque + "! Por favor, insira uma quantidade válida ou digite sair para cancelar");
                }
                else
                {
                    Console.WriteLine("Quantidade inválida. Por favor, insira uma quantidade válida ou digite sair para cancelar");
                }
                entrada = Console.ReadLine();
                if (entrada == "sair")
                {
                    return;
                }
            }
            produto.Quantidade = estoque - quantidade;
            globalIdCounter++;
            Venda venda = new(globalIdCounter, _produtoId, quantidade, _clienteId, vendedor!.Id);
            
            //ListaProduto[_produtoId].Quantidade--;
            //produtos(_produtoId).Value.Quantidade--;
            //produtos.Remove(_produtoId);
            //produtos.TryAdd(_produtoId, produto);
            vendas.Add(globalIdCounter++, venda);
            Console.WriteLine("Venda criada com sucesso! O vendedor " + "vendedor.Nome" + " vendeu um " + produto.Nome + " para o cliente " + cliente.Nome);
            PressioneParaSair();
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
                if (Confirmar())
                {
                    vendas.Remove(_id);
                    Console.WriteLine("Venda removida!");
                }
                else
                {
                    Console.WriteLine("Operação cancelada");
                }
                PressioneParaSair();
            }
            else
            {
                Console.WriteLine("Venda não encontrada!");
                PressioneParaSair();
            }
        }

        private static void CreateDeafault()
        {
            globalIdCounter++;
            Cliente cliente1 = new(globalIdCounter, "CELIO SANTOS", 2002, "celio.santos@gmail.com", "996199322", "Alameda Corvinal", "", "", "");
            clientes.Add(globalIdCounter, cliente1);

            globalIdCounter++;
            Cliente cliente2 = new(globalIdCounter, "ARNALDO DA SILVA", 2002, "arnaldo.silva@gmail.com", "996199322", "Alameda Abrolhos", "", "", "");
            clientes.Add(globalIdCounter, cliente2);

            globalIdCounter++;
            Cliente cliente3 = new(globalIdCounter, "BERNARDO COSTA", 2003, "bernardo.costa@gmail.com", "996199322", "Avenida Bertollini", "", "", "");
            clientes.Add(globalIdCounter, cliente3);

            globalIdCounter++;
            Vendedor vendedor1 = new(globalIdCounter, "TIAGO RODRIGUES", 1998, "tiago.rodr@gmail.com", "996199322", "Rua Tamandaré", "tiago", "1234");
            vendedores.Add(globalIdCounter, vendedor1); //instancia antes do metodo

            globalIdCounter++;
            Vendedor vendedor2 = new(globalIdCounter, "LUCAS AMORIM", 1994, "lucas.amorim.18@gmail.com", "996199322", "Rua Luverci", "lucas", "1234");
            vendedores.Add(globalIdCounter, vendedor2);

            globalIdCounter++;
            Vendedor vendedor3 = new(globalIdCounter,  "CAIO CAMBOIM", 2003, "caio.c@gmail.com", "996199322", "Avenida Diamantina", "caio", "1234");
            vendedores.Add(globalIdCounter, vendedor3);

            globalIdCounter++;
            Produto produto1 = new(globalIdCounter, "Carro", "Civic", 11);
            produtos.Add(globalIdCounter, produto1); //instancia antes do metodo

            globalIdCounter++;
            Produto produto2 = new(globalIdCounter, "Carro", "Passat", 8);
            produtos.Add(globalIdCounter, produto2);

            globalIdCounter++;
            Produto produto3 = new(globalIdCounter, "Carro", "Omega", 4);
            produtos.Add(globalIdCounter, produto3);

        }

        public static Vendedor? EncontrarVendedorPorUsuario(string usuario, string senha)
        {
            if (vendedores != null)
            {
                return vendedores.Values.FirstOrDefault(v => v.Usuario.Equals(usuario, StringComparison.InvariantCultureIgnoreCase) && v.Senha.Equals(senha));
            }
            return null;
        }
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
                vendedor = EncontrarVendedorPorUsuario(usuario, senha);
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
            CreateDeafault();
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
                                    foreach (var client in clientes)
                                    {
                                        Console.WriteLine(client.Key + ". Nome: " + client.Value.Nome + " - Idade: " + (DateTime.Now.Year - client.Value.AnoNascimento).ToString() + " - E-mail: " + client.Value.Email);
                                    }
                                    Console.WriteLine("\n");
                                    PressioneParaSair();
                                    Console.ReadKey();
                                    break;
                                case 2:
                                    CadastroCliente();
                                    break;
                                case 3:
                                    Console.WriteLine("Atualização de clientes em implementação");
                                    PressioneParaSair();
                                    break;
                                case 4:
                                    RemoverCliente();
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
                                    foreach (var seller in vendedores)
                                    {
                                        Console.WriteLine(seller.Key + ". Nome: " + seller.Value.Nome + " - Idade: " + (DateTime.Now.Year - seller.Value.AnoNascimento).ToString() + " - E-mail: " + seller.Value.Email);
                                    }
                                    Console.WriteLine("\n");
                                    PressioneParaSair();
                                    break;
                                case 2:
                                    CadastroVendedor();
                                    break;
                                case 3:
                                    Console.WriteLine("Atualização de vendedores em implementação");
                                    PressioneParaSair();
                                    break;
                                case 4:
                                    RemoverVendedor();
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
                                    foreach (var product in produtos)
                                    {
                                        Console.WriteLine(product.Key + ". Produto: " + product.Value.ProdutoGrupo + " - Nome: " + product.Value.Nome + " - Quantidade: " + product.Value.Quantidade);
                                    }
                                    Console.WriteLine("\n");
                                    PressioneParaSair();
                                    Console.ReadKey();
                                    break;
                                case 2:
                                    CadastroProduto();
                                    break;
                                case 3:
                                    Console.WriteLine("Atualização de produtos em implementação");
                                    PressioneParaSair();
                                    Console.ReadKey();
                                    break;
                                case 4:
                                    RemoverProduto();
                                    PressioneParaSair();
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
                                    PressioneParaSair();
                                    break;
                                case 2:
                                    ExecutarVenda();
                                    break;
                                case 3:
                                    Console.WriteLine("Atualização de vendas em implementação");
                                    PressioneParaSair();
                                    break;
                                case 4:
                                    RemoverVenda();
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