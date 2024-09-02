﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Entidades
{
    public class Vendedor(int id, string nome, int anoNascimento, string email, string telefone, string endereco, string usuario, string senha) : Pessoa(id, nome, anoNascimento, email, telefone, endereco)
    {
        public string Usuario { get; set; } = usuario;
        public string Senha { get; set; } = senha;
    }
}
