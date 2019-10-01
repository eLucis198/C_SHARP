using Atividade_05_09.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Atividade_05_09.Controllers
{
    public class NoticiaController : Controller
    {
        // GET: Noticia
        public ActionResult Cadastrar()
        {
            if (Session["Logado"] == null)
            {
                return View("~/Views/Login/Index.cshtml");
            }
            else
            {
                if (Session["Logado"].ToString() != "admin" && (string)Session["Logado"].ToString() != "usuario")
                {
                    return View("~/Views/Login/Index.cshtml");
                }
                else
                {
                    ViewBag.Logado = Session["Logado"];
                    return View();
                }
            }
        }

        [HttpPost]
        public ActionResult Cadastrar(FormCollection form)
        {
            return View();
        }

        public ActionResult Visualizar()
        {
            IList<Noticia> lista = new List<Noticia>();
            Noticia n = new Noticia();
            lista = n.Read();
            ViewBag.Lista = lista;
            return View();
        }
    }
}