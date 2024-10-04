using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Entidades
{
    public class ProdutoVenda (Produto produto, int quantidade)
    {
        public Produto Produto { get; set; } = produto;
        public int Quantidade { get; set; } = quantidade;
        public decimal SubTotal => Produto.Preco * Quantidade;
    }
}
