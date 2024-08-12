using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Entidades
{
    public class Cliente(string nome, int anoNascimento, string email, string telefone, string endereco) : Pessoa(nome, anoNascimento, email, telefone, endereco)
    {
    }
}
