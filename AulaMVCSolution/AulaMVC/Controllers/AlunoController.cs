using AulaMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AulaMVC.Controllers
{
    public class AlunoController : Controller
    {
        // GET: Aluno
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            Aluno a1 = new Aluno();
            return View(a1);
        }

        [HttpPost]
        public ActionResult Create(int txtId, string txtNome, int txtIdade, string listaDeAlunos)
        {
            if (txtIdade < 18)
            {
                ViewBag.Erro = "A idade mínima não pode ser menor que 18";
                ViewBag.IdAluno = txtId;
                ViewBag.Nome = txtNome;
                ViewBag.Idade = txtIdade;
            }
            else
            {
                Aluno a1 = new Aluno();
                a1.IdPessoa = txtId;
                a1.Nome = txtNome;
                a1.Idade = txtIdade;

                listaDeAlunos += "ID: " + txtId + " NOME: " + txtNome + " IDADE: " + txtIdade;
                ViewData["listaDeAlunos"] = listaDeAlunos;
                ViewBag.Erro = "Sucesso";
                ViewBag.IdAluno = "";
                ViewBag.Nome = "";
                ViewBag.Idade = "";
            }

            return View();
        }

        public ActionResult New_Aluno()
        {
            return View();
        }
        [HttpPost]
        public ActionResult New_Aluno(FormCollection form)
        {
            Pessoa p1 = new Pessoa();
            p1.Nome = form["txtNome"];
            p1.Idade = Convert.ToInt32(form["txtIdade"]);




            return View();
        }

        //#####################################3

        public ActionResult NovoAluno()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NovoAluno(Aluno a1, FormCollection form)
        {
            if (string.IsNullOrEmpty(a1.Nome))
            {
                ModelState.AddModelError("","O campo nome não pode ser nulo");
            }
            if (!a1.Idade.HasValue)
            {
                ModelState.AddModelError("", "O campo idade não pode ser nulo");
            }

            if (string.IsNullOrEmpty(a1.Sexo))
            {
                ModelState.AddModelError("Sexo", "O campo sexo não pode ser nulo");
            }
            else if (a1.Sexo != "M" && a1.Sexo != "F")
            {
                ModelState.AddModelError("Sexo", "O campo sexo deve ser M ou F");
            }


            if (!a1.Peso.HasValue)
            {
                ModelState.AddModelError("Peso", "O campo peso não pode ser nulo");
            }
            if ( a1.Peso > 300)
            {
                ModelState.AddModelError("Peso", "O campo não pode ser maior que 300");
            }
            if (a1.Peso < 0)
            {
                ModelState.AddModelError("Peso", "O campo não pode ser menor que 0");
            }





            return View();
        }
    }
}