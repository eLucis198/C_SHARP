using AulaMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AulaMVC.Controllers
{
    public class PessoaController : Controller
    {
        // GET: Pessoa
        public ActionResult Index()
        {
            ViewData["IdPessoa"] = 1;
            ViewData["Nome"] = "Fabiano";
            ViewData["Idade"] = 32;

            Pessoa p1 = new Pessoa();
            p1.IdPessoa = 2;
            p1.Nome = "Marcão";
            p1.Idade = 52;

            ViewBag._IdPessoa = p1.IdPessoa;
            ViewBag._Nome = p1.Nome;
            ViewBag._Idade = p1.Idade;

            return View(p1);
        }

        public ActionResult Details()
        {
            Pessoa p1 = new Pessoa();
            p1.IdPessoa = 3;
            p1.Nome = "Hellen";
            p1.Idade = 52;

            return View(p1);
        }
    }
}