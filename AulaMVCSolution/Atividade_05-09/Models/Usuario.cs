using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Atividade_05_09.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo login é obrigatório")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Campo senha é obrigatório")]
        public string Senha{ get; set; }

    }
}