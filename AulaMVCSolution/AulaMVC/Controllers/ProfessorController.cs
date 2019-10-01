using AulaMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AulaMVC.Controllers
{
    public class ProfessorController : Controller
    {
        // GET: Professor
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            Session["lista"] = "";
            return View();
        }

        [HttpPost]
        public ActionResult Create(Professor professor)
        {
            if (!ModelState.IsValid)
            {
                return View(professor);
            }
            else{
                Session["lista"] += professor.Cpf + ";";
                return View(professor);
            }
        }

        public ActionResult Validacao(string sexo)
        {
            if (sexo.ToLower() == "m" || sexo.ToLower() == "f")
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult ValidacaoCpf(string cpf)
        {
            if (cpf.Length==11)
            {
                string[] listaAux = Session["lista"].ToString().Split(';');
                for (int i = 0; i < listaAux.Length; i++)
                {
                    if (listaAux[i].Equals(cpf))
                    {
                        return Json(false, JsonRequestBehavior.AllowGet);
                    }
                }
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
    }
}