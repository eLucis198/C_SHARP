using ProvaBimestral2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace ProvaBimestral2.Controllers
{
    public class NotaController : Controller
    {
        NotaEntities db = new NotaEntities();
        // GET: Nota
        public ActionResult Cadastrar()
        {
            return View();
        }


        public ActionResult Listar()
        {
            return View();
        }

        public void SetaIdDetalhes(int id)
        {
            Session["IdDetalhes"] = id;
        }

        public ActionResult Detalhes()
        {
            int id = 0;
            if (Session["IdDetalhes"] != null)
            {
                id = (int)Session["IdDetalhes"];
            }
            else
            {
                return RedirectToAction("Listar", "Nota");
            }
            Nota n = new Nota();
            n = db.Nota.Find(id);
            return View(n);
        }

        public JsonResult ListaNotas()
        {
            IList<Nota> listaNotas = new List<Nota>();
            listaNotas = db.Nota.ToList();

            StringBuilder str = new StringBuilder();

            str.Append("<table class=\"table table-bordered\">");

            str.Append("<tr> <td>Numero</td> <td>Data</td> <td>Nome</td> <td>Valor</td> </tr>");

            foreach (var item in listaNotas)
            {
                str.Append("<tr> <td>" + item.ID_Nota + "</td> <td>" + item.DataNota.Value.ToShortDateString() + "</td> <td>" + item.Cliente.Nome + "</td> <td>" + item.ValorNota + "</td> <td><a onclick=\"MostraDetalhes("+item.ID_Nota+")\">DETALHES</a></td></tr>");
            }

            str.Append("</table>");

            return Json(new
            {
                ListaNotas = str.ToString()
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult PesquisarClientes()
        {
            IList<Cliente> listaClientes = new List<Cliente>();
            listaClientes = db.Cliente.ToList();

            StringBuilder str = new StringBuilder();

            foreach (var item in listaClientes)
            {
                str.Append("<option value=\"" + item.ID_Cliente + "\">" + item.Nome + "</option>");
            }

            return Json(new
            {
                ListaClientes = str.ToString()
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult PesquisarProdutos()
        {
            IList<Produto> listaProdutos = new List<Produto>();
            listaProdutos = db.Produto.ToList();

            StringBuilder str = new StringBuilder();
            //str.Append("<option value=\"\"></option>");

            foreach (var item in listaProdutos)
            {
                str.Append("<option value=\"" + item.ID_Produto + "\">" + item.Descricao + "</option>");
            }

            return Json(new
            {
                ListaProdutos = str.ToString()
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DadosProduto(int id)
        {
            Produto p = new Produto();
            p = db.Produto.Find(id);
            return Json(new
            {
                valor = p.Valor.ToString()
            }, JsonRequestBehavior.AllowGet);
        }

        

    }
}