namespace ConsoleApp1.Entidades
{
    public class GerVenda
    {

        private int IdCounter = 0;
        public readonly Dictionary<int, Venda> vendas = [];
        private static readonly GerCliente gerCliente = new();
        private static readonly GerProduto gerProduto = new();
        public void ExecutarVenda()
        {
            //Cliente
            Console.WriteLine("Insira o Id do cliente: ");
            string? entrada = Console.ReadLine();
            bool entradaValida = int.TryParse(entrada, out int _clienteId);
            while (!entradaValida || gerCliente.EncontrarPeloId(_clienteId) == null)
            {
                Console.WriteLine("Cliente não encontrado. Por favor, insira um id válido ou digite sair para cancelar");
                entrada = Console.ReadLine();
                if (entrada == "sair")
                {
                    return;
                }
                entradaValida = int.TryParse(entrada, out _clienteId);
            }
            Cliente? cliente = gerCliente.EncontrarPeloId(_clienteId);
            //Produto
            Console.WriteLine("Insira o Id do produto: ");
            entrada = Console.ReadLine();
            entradaValida = int.TryParse(entrada, out int _produtoId);
            int estoque = 0;
            Produto? produto = gerProduto.EncontrarPeloId(_produtoId);
            while (!entradaValida || produto == null)
            {
                Console.WriteLine("Produto não encontrado. Por favor, insira um id válido ou digite sair para cancelar");
                entrada = Console.ReadLine();
                if (entrada == "sair")
                {
                    return;
                }
                entradaValida = int.TryParse(entrada, out _produtoId);
                produto = gerProduto.EncontrarPeloId(_produtoId);
                if (produto != null)
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
            estoque = produto.Quantidade;
            int quantidade;
            while (true)
            {
                Console.WriteLine("Insira a quantidade do prduto: ");
                entrada = Console.ReadLine();
                if(int.TryParse(entrada, out quantidade))
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
                        return;
                    }
                }
                
            }
            /* while (!int.TryParse(entrada, out quantidade) || quantidade < 0 || quantidade > estoque)
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
            } */
            if (AdicionarItem(_clienteId, _produtoId, quantidade, Program.Vendedor!.Id))
            {
                Console.WriteLine("Venda criada com sucesso! O vendedor " + Program.Vendedor.Nome + " vendeu " + quantidade + " " + produto.Nome + " para o cliente " + cliente!.Nome);
            }
            else
            {
                Console.WriteLine("Não foi possível criar a venda, verifique o estoque");
            }
            Interface.PressioneParaSair();
        }
        public void Remover()
        {
            Console.WriteLine("Insira o Id da Venda que deseja remover");
            string? entrada = Console.ReadLine();
            _ = int.TryParse(entrada, out int _id);
            if (vendas.TryGetValue(_id, out var venda))
            {
                string clienteNome = "Não Encontrado"; //definido antes
                if (gerCliente.EncontrarPeloId(venda.ClienteId) != null)
                {
                    clienteNome = gerCliente.EncontrarPeloId(venda.ClienteId)!.Nome;
                }
                Console.WriteLine("A venda:" + _id + "para o cliente" + clienteNome + "será excluída!");
                if (Interface.Confirmar())
                {
                    vendas.Remove(_id);
                    Console.WriteLine("Venda removida!");
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
        public bool AdicionarItem(int clienteId, int produtoId, int quantidade,int vendedorId)
        {
            if (gerProduto.AtualizarEstoqueProduto(produtoId, -quantidade))
            {
                IdCounter++;
                Venda venda = new(IdCounter, clienteId, vendedorId);
                vendas.Add(IdCounter, venda);
                return true;
            }
            return false;

        }
    }
}
