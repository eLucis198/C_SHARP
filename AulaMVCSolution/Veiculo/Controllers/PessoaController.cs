using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Veiculo.Models;

namespace Veiculo.Controllers
{
    public class PessoaController : Controller
    {
        DB_VeiculoEntities db = new DB_VeiculoEntities();
        // GET: Pessoa
        public ActionResult Index()
        { 
            return View();
        }
    }
}