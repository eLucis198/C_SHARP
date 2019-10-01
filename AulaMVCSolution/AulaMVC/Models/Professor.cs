using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AulaMVC.Models
{
    public class Professor
    {
        [Required(ErrorMessage="Este campo é obrigatório")]
        public string Nome { get; set; }

        [StringLength(10,MinimumLength=3, ErrorMessage ="O sobrenome não pode ter mais de 10 letras, nem menor q 3")]
        public string Sobrenome { get; set; }

        [Range(18,50, ErrorMessage ="A idade não pode ser menor que 18 nem maior que 50")]
        public int Idade { get; set; }
        public string Senha{ get; set; }
        [Compare("Senha", ErrorMessage ="Senha não confere")]
        public string ConfirmaSenha{ get; set; }

        [System.Web.Mvc.Remote("validacao", "Professor", ErrorMessage = "Sexo Inválido")]
        public string Sexo { get; set; }
        //[System.Web.Mvc.Remote("validacaoCpf", "Professor", AdditionalFields="Email", ErrorMessage = "Cpf Já Cadastrado")]
        [System.Web.Mvc.Remote("validacaoCpf", "Professor", ErrorMessage = "Cpf Já Cadastrado")]
        public string Cpf { get; set; }
    }
}