namespace ConsoleApp1.Entidades
{
    public class Pessoa(int id, string nome, int anoNascimento, string email, string telefone, string endereco)
    {

        public int Id { get; set; } = id;
        public string Nome { get; set; } = nome;
        public int AnoNascimento { get; set; } = anoNascimento;
        public string Email { get; set; } = email;
        public string Telefone { get; set; } = telefone;
        public string Endereco { get; set; } = endereco;

    }

}
