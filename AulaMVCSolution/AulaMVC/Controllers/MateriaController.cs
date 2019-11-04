using AulaMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AulaMVC.Controllers
{
    public class MateriaController : Controller
    {
        // GET: Materia
        FACEAR_2019Entities2 db = new FACEAR_2019Entities2();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            ViewBag.Academicos = new SelectList(db.Academico.ToList(), "Id_Academico", "Nome");
            return View();
        }

        public ActionResult Edit()
        {
            var materia = db.Materia.FirstOrDefault();
            ViewBag.Academicos = new SelectList(db.Academico.ToList(), "Id_Academico", "Nome", 2);
            return View();
        }

        public ActionResult OutrosComandosJquery()
        {
            return View();
        }


        public JsonResult RetornaHora()
        {
            DateTime horaAtual = DateTime.Now;
            string nomeAutor = "Professor";

            return Json(new
            {
                horaAtual = horaAtual.ToString("HH:mm:ss")
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult RetornaQtdLetras(string nome, string sobrenome)
        {
            int qtd = nome.Length + sobrenome.Length;

            return Json(new
            {
                qtd
            }, JsonRequestBehavior.AllowGet);
        }


    }
}