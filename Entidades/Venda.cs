using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Entidades
{
    public class Venda(int produtoId, int clienteId, int vendedorId)
    {
        private static int vendaIdCounter = 0;
        public int Id { get; set; } = vendaIdCounter++;
        public int ProdutoId { get; set; } = produtoId;
        public int ClienteId { get; set; } = clienteId;
        public int VendedorId { get; set; } = vendedorId;
    }
}
