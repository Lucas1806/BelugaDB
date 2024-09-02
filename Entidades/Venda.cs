using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Entidades
{
    public class Venda(int id, int produtoId, int quantidade, int clienteId, int vendedorId)
    {
        public int Id { get; set; } = id;
        public int ProdutoId { get; set; } = produtoId;
        public int Quantidade { get; set; } = quantidade;
        public int ClienteId { get; set; } = clienteId;
        public int VendedorId { get; set; } = vendedorId;
    }
}
