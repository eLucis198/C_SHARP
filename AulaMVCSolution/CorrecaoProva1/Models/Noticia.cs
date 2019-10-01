using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CorrecaoProva1.Models
{
    public class Noticia
    {
        public int Id { get; set; }
        public int IdTopico { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }

    }
}