using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Entidades
{
    public class Produto(string? produtoGrupo, string? nome, int quantidade)
    {
        private static int produtoIdCounter = 0;
        public int Id { get; set; } = produtoIdCounter++;
        public string? ProdutoGrupo { get; set; } = produtoGrupo;
        public string? Nome { get; set; } = nome;
        public int Quantidade { get; set; } = quantidade;
    }
}
