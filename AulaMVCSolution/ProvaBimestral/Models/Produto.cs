using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProvaBimestral.Models
{
    public class Produto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Categoria é um campo obrigatório")]
        public int IdCategoria { get; set; }
        [Required(ErrorMessage = "Nome é um campo obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Descrição é um campo obrigatório")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "Preço é um campo obrigatório")]
        public string Preco { get; set; }
        [Required(ErrorMessage = "Marca é um campo obrigatório")]
        public string Marca { get; set; }
        [Required(ErrorMessage = "Modelo é um campo obrigatório")]
        public string Modelo { get; set; }
    }
}