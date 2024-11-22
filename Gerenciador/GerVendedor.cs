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
        private int IdCounter = 0;
        private readonly Dictionary<int, Vendedor> vendedores = [];
        public int ? Cadastro(string nome, int _anoNascimento, string email, string telefone, string endereco, string usuario, string senha)
        {
            IdCounter++;
            Vendedor vendedor = new(IdCounter, nome, _anoNascimento, email, telefone, endereco, usuario, senha);
            if (vendedores.TryAdd(IdCounter, vendedor))
            {
                return IdCounter;
            }
            return null;
        }
        public bool Remover(int id) => vendedores.Remove(id);
        public (int?, string?) EncontrarVendedorPorUsuario(string usuario, string? senha)
        {
            if (vendedores != null)
            {
                Vendedor? vendedor = vendedores.Values.FirstOrDefault(v => v.Usuario.Equals(usuario, StringComparison.InvariantCultureIgnoreCase) && v.Senha.Equals(senha));
                if (vendedor != null)
                {
                    return (vendedor.Id, vendedor.Nome);
                }
            }
            return (null, null);
        }

        public Vendedor? GetById(int id) => vendedores.TryGetValue(id, out Vendedor? vendedor) ? vendedor : null;

        public Dictionary<int, Vendedor> GetAll() => vendedores;
        

    }
}
