using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Atividade_05_09.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string txtLogin, string txtSenha)
        {
            if (string.IsNullOrEmpty(txtLogin))
            {
                ModelState.AddModelError("", "O campo Login é obrigatório");
            }
            if (string.IsNullOrEmpty(txtSenha))
            {
                ModelState.AddModelError("", "O campo Senha é obrigatório");
            }

            if (txtLogin.Equals("admin") && txtSenha.Equals("admin")){
                Session["Logado"] = "admin";
                return View("~/Views/Noticia/Cadastrar.cshtml");
            }
            else if (txtLogin.Equals("usuario") && txtSenha.Equals("usuario")){
                Session["Logado"] = "usuario";
                return RedirectToAction("Cadastrar", "Noticia");
            }
            else
            {
                ModelState.AddModelError("", "Login ou senha inválidos");
                Session["Logado"] = "";
                return View();
            }
        }
    }
}