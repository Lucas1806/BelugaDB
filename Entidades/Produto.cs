using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Entidades
{
    public class Produto(int id, string? produtoGrupo, string? nome, int quantidade)
    {
        public int Id { get; set; } = id;
        public string? ProdutoGrupo { get; set; } = produtoGrupo;
        public string? Nome { get; set; } = nome;
        public int Quantidade { get; set; } = quantidade;
    }
}
