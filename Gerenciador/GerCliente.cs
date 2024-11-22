using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace ConsoleApp1.Entidades
{

    public class GerCliente
    {
        public GerCliente()
        {
            IdCounter++;
            Cliente cliente1 = new(IdCounter, "CELIO SANTOS", 2002, "celio.santos@gmail.com", "996199322", "Alameda Corvinal", "", "", "");
            clientes.Add(IdCounter, cliente1);

            IdCounter++;
            Cliente cliente2 = new(IdCounter, "ARNALDO DA SILVA", 2002, "arnaldo.silva@gmail.com", "996199322", "Alameda Abrolhos", "", "", "");
            clientes.Add(IdCounter, cliente2);

            IdCounter++;
            Cliente cliente3 = new(IdCounter, "BERNARDO COSTA", 2003, "bernardo.costa@gmail.com", "996199322", "Avenida Bertollini", "", "", "");
            clientes.Add(IdCounter, cliente3);
        }
        private int IdCounter = 0;
        private readonly Dictionary<int, Cliente> clientes = [];
        public Cliente? Cadastro(string nome, int anoNascimento, string email, string telefone, string endereco, string genero, string rg, string cpf)
        {
            IdCounter++;
            Cliente cliente = new(IdCounter, nome, anoNascimento, email, telefone, endereco, genero, rg, cpf);
            clientes.Add(IdCounter, cliente);
            return cliente;
        }
        public bool Remover(int id) => clientes.Remove(id);
        public void Atualizar()
        {
            Console.WriteLine("Insira o Id do Cliente que deseja alterar");
            string? entrada = Console.ReadLine();
            if (int.TryParse(entrada, out int _id))
            {
                if (clientes.TryGetValue(_id, out var cliente))
                {
                    //retornar dados do cliente
                    //(int id, string nome, int anoNascimento, string email, string telefone, string endereco, string genero, string rg, string cpf)
                    Console.WriteLine("Cliente de id: " + cliente.Id + " encontardo!");
                    Console.WriteLine("1. Nome: " + cliente.Nome);
                    Console.WriteLine("2. Ano de Nascimento: " + cliente.AnoNascimento);
                    Console.WriteLine("3. E-mail: " + cliente.Email);
                    Console.WriteLine("4. Telefone: " + cliente.Nome);
                    Console.WriteLine("5. Endereço: " + cliente.Nome);
                    Console.WriteLine("6. Gênero: " + cliente.Nome);
                    Console.WriteLine("7. RG: " + cliente.Nome);
                    Console.WriteLine("8. CPF: " + cliente.Nome);
                    Console.WriteLine("Escolha que dado deseja atualizar ou digite 0 para sair");
                    entrada = Console.ReadLine();
                    _ = int.TryParse(entrada, out int opcao);
                    switch (opcao)
                    {
                        case 0:
                            // exitLoop = true;
                            break;
                        case 1:
                            Console.WriteLine("Nome atual: " + cliente.Nome);
                            Console.WriteLine("Insira o novo nome");
                            string? novoNome = Console.ReadLine();
                            while (string.IsNullOrWhiteSpace(novoNome))
                            {
                                Console.WriteLine("Nome não pode ser nulo ou vazio. Por favor, insira um nome válido ou digite sair para cancelar");
                                novoNome = Console.ReadLine();
                                if (novoNome == "sair")
                                {
                                    return;
                                }
                            }
                            break;
                        case 2:
                            Console.WriteLine("Ano de Nascimento atual: " + cliente.AnoNascimento);
                            Console.WriteLine("Insira o Ano de Nascimento: ");
                            string? entradaAno = Console.ReadLine();
                            _ = int.TryParse(entradaAno, out int novoAnoNascimento);
                            while (novoAnoNascimento < 1 || novoAnoNascimento >= DateTime.Now.Year)
                            {
                                Console.WriteLine("Ano de Nascimento deve ser anterior ao atual. Por favor, insira um ano de nascimento válido ou digite sair para cancelar");
                                entrada = Console.ReadLine();
                                if (entrada == "sair")
                                {
                                    return;
                                }
                                _ = int.TryParse(entrada, out novoAnoNascimento);
                            }
                            break;
                        case 3:
                            Console.WriteLine("E-mail atual: " + cliente.Email);
                            Console.WriteLine("Insira o novo e-mail: ");
                            string? novoEmail = Console.ReadLine();
                            while (string.IsNullOrWhiteSpace(novoEmail) || !novoEmail.Contains('@'))
                            {
                                Console.WriteLine("E-mail inválido. Por favor, insira um e-mail válido ou digite sair para cancelar");
                                novoEmail = Console.ReadLine();
                                if (novoEmail == "sair")
                                {
                                    return;
                                }
                            }
                            break;
                        case 4:
                            Console.WriteLine("Telefone atual:" + cliente.Telefone);
                            Console.WriteLine("Insira o novo telefone: ");
                            string? novoTelefone = Console.ReadLine();
                            string padraoTelefone = @"^\d{8,9}$";
                            while (string.IsNullOrWhiteSpace(novoTelefone) || !Regex.IsMatch(novoTelefone, padraoTelefone))
                            {
                                Console.WriteLine("Telefone inválido, o telefone deve conter apenas os dígitos. Por favor, insira um telefone válido ou digite sair para cancelar");
                                novoTelefone = Console.ReadLine();
                                if (novoTelefone == "sair")
                                {
                                    return;
                                }
                            }
                            break;
                        case 5:
                            Console.WriteLine("Endereço atual:" + cliente.Endereco);
                            Console.WriteLine("Insira o novo endereço: ");
                            string? novoEndereco = Console.ReadLine();
                            while (string.IsNullOrWhiteSpace(novoEndereco) || novoEndereco.Length < 5)
                            {
                                Console.WriteLine("Endereço inválido, o endereço deve conter pelo menos 5 caracteres. Por favor, insira um Endereço válido ou digite sair para cancelar");
                                novoEndereco = Console.ReadLine();
                                if (novoEndereco == "sair")
                                {
                                    return;
                                }
                            }
                            break;
                        case 6: //Gênero
                            Console.WriteLine("Gênero atual:" + cliente.Genero);
                            Console.WriteLine("Insira o novo endereço: ");
                            break;
                        case 7: //RG
                            break;
                        case 8: //CPF
                            break;
                        default:
                            Console.WriteLine("Ação inválida");
                            Console.ReadKey();
                            break;
                    }

                    if (Interface.Confirmar())
                    {
                        clientes.Remove(_id);
                        Console.WriteLine("Cliente removido!");
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
        public Dictionary<int, Cliente> GetAll() => clientes;
        public Cliente? GetById(int id) => clientes.TryGetValue(id, out Cliente? cliente) ? cliente : null;
    }
}

