using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Entidades
{
    public class Cliente(int id, string nome, int anoNascimento, string email, string telefone, string endereco, string genero, string rg, string cpf) : Pessoa(id, nome, anoNascimento, email, telefone, endereco)
    {
        public string Genero { get; set; } = genero;
        public string RG { get; set; } = rg;
        public string CPF { get; set; } = cpf;
    }
}
