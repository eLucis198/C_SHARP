using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _1_SomarNumero.Controllers
{
    public class SomarController : Controller
    {
        // GET: Somar
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Somar()
        {
            ViewBag.Valor = 0;
            ViewBag.Total = 0;
            return View();
        }

        [HttpPost]
        public ActionResult Somar(int txtValor, int Total)
        {
            ViewBag.Valor = txtValor;
            ViewBag.Total = Total + txtValor;
            return View();
        }
    }
}