using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AulaMVC.Models
{
    public class Pessoa
    {
        public int IdPessoa { get; set; }
        public string Nome { get; set; }
        public int? Idade { get; set; }
        public string Sexo { get; set; }
        public int? Peso { get; set; }
    }
}