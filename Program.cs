using ConsoleApp1.Entidades;
using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    //subir no git (colocar gitIgnore)
    //deixar public


    public class Program
    {
        public static void ExecutarVenda(List<Venda> listaVendas, List<Vendedor> listaVendedor, List<Produto> listaProduto, List<Cliente> listaCliente)
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
            listaVendas.Add(venda);
            Console.WriteLine("Venda " + venda.Id + " criada com sucesso! O vendedor " + listaVendedor[venda.VendedorId].Nome + " vendeu um " + listaProduto[venda.ProdutoId].Nome + " para o cliente " + listaCliente[venda.ClienteId].Nome);
        }

        public static void Main()
        {

            //passo 6: criar lista das intancias a cima
            //public Cliente(string nome, int anoNascimento, string email, int telefone, string endereco) : base(nome, anoNascimento, email, telefone, endereco)
            List<Cliente> listaCliente = [];

            Cliente cliente1 = new("LUCAS AMORIM", 1994, "lucas.amorim.18@gmail.com", "996199322", "Rua Luverci");
            listaCliente.Add(cliente1); //instancia antes do metodo

            Cliente cliente2 = new("ARNALDO DA SILVA", 2002, "arnaldo.silva@gmail.com", "996199322", "Alameda Abrolhos");
            listaCliente.Add(cliente2);

            Cliente cliente3 = new("BERNARDO COSTA", 2003, "bernardo.costa@gmail.com", "996199322", "Avenida Bertollini");
            listaCliente.Add(cliente3);

            List<Vendedor> listaVendedor = [];

            Vendedor vendedor1 = new("TIAGO RODRIGUES", 1994, "tiago.rodr@gmail.com", "996199322", "Rua Tamandaré");
            listaVendedor.Add(vendedor1); //instancia antes do metodo

            Vendedor vendedor2 = new("CELIO SANTOS", 2002, "celio.santos@gmail.com", "996199322", "Alameda Corvinal");
            listaVendedor.Add(vendedor2);

            Vendedor vendedor3 = new("DANILO OLIVEIRA", 2003, "danilo.oliv@gmail.com", "996199322", "Avenida Diamantina");
            listaVendedor.Add(vendedor3);


            List<Produto> listaProduto = [];

            Produto produto1 = new("Carro", "Civic", 11);
            listaProduto.Add(produto1); //instancia antes do metodo

            Produto produto2 = new("Carro", "Passat", 8);
            listaProduto.Add(produto2);

            Produto produto3 = new("Carro", "Omega", 4);
            listaProduto.Add(produto3);

            List<Venda> listaVendas = [];

            //imprimi a lista para testar
            Console.WriteLine("Lista de Clientes");
            foreach (var client in listaCliente)
            {
                Console.WriteLine(client.Id + ". Nome: " + client.Nome + " - Idade: " + (DateTime.Now.Year - client.AnoNascimento).ToString() + " - E-mail: " + client.Email);
            }
            Console.WriteLine("\n");
            Console.WriteLine("Lista de Vendedores");
            foreach (var seller in listaVendedor)
            {
                Console.WriteLine(seller.Id + ". Nome: " + seller.Nome + " - Idade: " + (DateTime.Now.Year - seller.AnoNascimento).ToString() + " - E-mail: " + seller.Email);
            }
            Console.WriteLine("\n");
            Console.WriteLine("Lista de Produtos");
            foreach (var product in listaProduto)
            {
                Console.WriteLine(product.Id + ". Produto: " + product.ProdutoGrupo + " - Nome: " + product.Nome + " - Quantidade: " + product.Quantidade);
            }
            Console.WriteLine("\n");

            ExecutarVenda(listaVendas, listaVendedor, listaProduto, listaCliente);


        }
    }
}