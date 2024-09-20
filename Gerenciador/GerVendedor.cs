using System.Text.RegularExpressions;

namespace ConsoleApp1.Entidades
{
    public class GerVendedor
    {
        public GerVendedor()
        {
            IdCounter++;
            Vendedor vendedor1 = new(IdCounter, "TIAGO RODRIGUES", 1998, "tiago.rodr@gmail.com", "996199322", "Rua Tamandaré", "tiago", "1234");
            vendedores.Add(IdCounter, vendedor1); //instancia antes do metodo

            IdCounter++;
            Vendedor vendedor2 = new(IdCounter, "LUCAS AMORIM", 1994, "lucas.amorim.18@gmail.com", "996199322", "Rua Luverci", "lucas", "1234");
            vendedores.Add(IdCounter, vendedor2);

            IdCounter++;
            Vendedor vendedor3 = new(IdCounter, "CAIO CAMBOIM", 2003, "caio.c@gmail.com", "996199322", "Avenida Diamantina", "caio", "1234");
            vendedores.Add(IdCounter, vendedor3);
        }
        private int IdCounter = 1;
        public readonly Dictionary<int, Vendedor> vendedores = [];
        public void Cadastro()
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
            IdCounter++;
            Vendedor vendedor = new(IdCounter, nome, _anoNascimento, email, telefone, endereco, usuario, senha);
            vendedores.Add(IdCounter, vendedor);
            Console.WriteLine("Vendedor" + nome + "cadastrado com sucesso!");
            Interface.PressioneParaSair();
            // nome, anoNascimento, email, telefone, endereco
        }
        public void Remover()
        {
            Console.WriteLine("Insira o Id do Vendedor que deseja remover");
            string? entrada = Console.ReadLine();
            _ = int.TryParse(entrada, out int _id);
            if (vendedores.TryGetValue(_id, out var vendedor))
            {
                Console.WriteLine("O Vendedor:" + _id + ". Nome: " + vendedor.Nome + " - E-mail: " + vendedor.Email + "será excluído!");
                if (Interface.Confirmar())
                {
                    vendedores.Remove(_id);
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
        public Vendedor? EncontrarVendedorPorUsuario(string usuario, string? senha)
        {
            if (vendedores != null)
            {
                return vendedores.Values.FirstOrDefault(v => v.Usuario.Equals(usuario, StringComparison.InvariantCultureIgnoreCase) && v.Senha.Equals(senha));
            }
            return null;
        }
        
        
    }
}
