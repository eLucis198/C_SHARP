using ProvaBimestral.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProvaBimestral.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            if (Session["Logado"] != null)
            {
                if (Session["Logado"].Equals("admin") || Session["Logado"].Equals("usuario"))
                {
                    return RedirectToAction("Index", "Loja");
                }
            }
            if (Request.Cookies["cookieLogin"] != null)
            {
                ViewBag.Login = Request.Cookies["cookieLogin"]["Login"];
                ViewBag.Senha = Request.Cookies["cookieLogin"]["Senha"];
            }
            return View();
        }

        [HttpPost]
        public ActionResult Index(string txtLogin, string txtSenha, bool cbxLembrar)
        {
            if (string.IsNullOrEmpty(txtLogin))
            {
                ModelState.AddModelError("", "O campo Login é obrigatório");
            }
            if (string.IsNullOrEmpty(txtSenha))
            {
                ModelState.AddModelError("", "O campo Senha é obrigatório");
            }

            if (txtLogin.Equals("adm") && txtSenha.Equals("123"))
            {
                Session["Logado"] = "admin";
                if (cbxLembrar == true)
                {
                    HttpCookie cookie = new HttpCookie("cookieLogin");
                    cookie.Values.Add("Login", "adm");
                    cookie.Values.Add("Senha", "123");
                    cookie.Expires = DateTime.Now.AddDays(7);
                    Response.AppendCookie(cookie);
                }
                else if (cbxLembrar == false)
                {
                    HttpCookie cookie = new HttpCookie("cookieLogin");
                    cookie.Values.Add("Login", "");
                    cookie.Values.Add("Senha", "");
                    cookie.Expires = DateTime.Now.AddDays(7);
                    Response.AppendCookie(cookie);
                }
                return RedirectToAction("Index", "Loja");
            }
            else if (txtLogin.Equals("guilherme") && txtSenha.Equals("guilherme"))
            {
                Session["Logado"] = "usuario";
                if (cbxLembrar == true)
                {
                    HttpCookie cookie = new HttpCookie("cookieLogin");
                    cookie.Values.Add("Login", "guilherme");
                    cookie.Values.Add("Senha", "guilherme");
                    cookie.Expires = DateTime.Now.AddDays(7);
                    Response.AppendCookie(cookie);
                }
                else if (cbxLembrar == false)
                {
                    HttpCookie cookie = new HttpCookie("cookieLogin");
                    cookie.Values.Add("Login", "");
                    cookie.Values.Add("Senha", "");
                    cookie.Expires = DateTime.Now.AddDays(7);
                    Response.AppendCookie(cookie);
                }
                return RedirectToAction("Index", "Loja");
            }
            else if (txtLogin.Equals("carlos") && txtSenha.Equals("carlos"))
            {
                Session["Logado"] = "usuario";
                if (cbxLembrar == true)
                {
                    HttpCookie cookie = new HttpCookie("cookieLogin");
                    cookie.Values.Add("Login", "carlos");
                    cookie.Values.Add("Senha", "carlos");
                    cookie.Expires = DateTime.Now.AddDays(7);
                    Response.AppendCookie(cookie);
                }
                else if (cbxLembrar == false)
                {
                    HttpCookie cookie = new HttpCookie("cookieLogin");
                    cookie.Values.Add("Login", "");
                    cookie.Values.Add("Senha", "");
                    cookie.Expires = DateTime.Now.AddDays(7);
                    Response.AppendCookie(cookie);
                }
                return RedirectToAction("Index", "Loja");
            }
            else
            {
                ModelState.AddModelError("", "Login ou Senha inválidos");
                Session["Logado"] = "";
                return View();
            }
        }
    }
}