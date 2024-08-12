namespace ConsoleApp1.Entidades
{
    public class Pessoa(string nome, int anoNascimento, string email, string telefone, string endereco)
    {
        
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Nome { get; set; } = nome;
        public int AnoNascimento { get; set; } = anoNascimento;
        public string Email { get; set; } = email;
        public string Telefone { get; set; } = telefone;
        public string Endereco { get; set; } = endereco;
        
    }

}
