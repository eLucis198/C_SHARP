using AvalicaoParcial1.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace AvalicaoParcial1.Controllers
{
    public class AnotacaoController : Controller
    {
        AGENDAEntities db = new AGENDAEntities();

        // GET: Anotacao
        public ActionResult Index()
        {
            return View();
        }

        // Metodos Jquery

        public JsonResult CreateAnotacao(FormCollection form)
        {
            if (Session["Editando"] == null)
            {
                DateTime dataTemp = DateTime.ParseExact(form["txtData"], "yyyy-MM-dd", CultureInfo.InvariantCulture);
                Anotacao a = new Anotacao();
                a.data_ = dataTemp;
                a.anotacao1 = form["txtAnotacao"];
                db.Anotacao.Add(a);
                db.SaveChanges();
            }
            else
            {
                int id = (int)Session["Editando"];
                Anotacao a = new Anotacao();
                a = db.Anotacao.Find(id);
                DateTime dataTemp = DateTime.ParseExact(form["txtData"], "yyyy-MM-dd", CultureInfo.InvariantCulture);
                a.data_ = dataTemp;
                a.anotacao1 = form["txtAnotacao"];
                db.SaveChanges();
                Session.Remove("Editando");
            }

            return Json(new
            {
                TabelaAnotacao = criaTabela()
            }, JsonRequestBehavior.AllowGet); ;
        }

        public JsonResult SelecionarAnotacao(int id)
        {
            Session["Editando"] = id;
            Anotacao a = new Anotacao();;
            a = db.Anotacao.Find(id);
            string Data = TransformaData(a.data_.ToString());
            string Anotacao = a.anotacao1;
            return Json(new
            {
                TabelaAnotacao = criaTabela(id),
                Data,
                Anotacao
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteAnotacao(int id)
        {
            Anotacao a = new Anotacao();
            a = db.Anotacao.Find(id);
            db.Anotacao.Remove(a);
            db.SaveChanges();
            return Json(new
            {
                TabelaAnotacao = criaTabela()
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CarregaAnotacao()
        {
            return Json(new
            {
                TabelaAnotacao = criaTabela()
            }, JsonRequestBehavior.AllowGet); ;
        }

        public string criaTabela()
        {
            IList<Anotacao> listaDeAnotacao = new List<Anotacao>();
            listaDeAnotacao = db.Anotacao.OrderBy(x => x.data_).ToList();

            StringBuilder str = new StringBuilder();

            str.Append("<table class=\"table table-bordered table-striped\">");
            str.Append("<tr><td>DATA</td><td>ANOTAÇÃO</td><td>ALTERAR</td><td>EXCLUIR</td></tr>");
            foreach (var item in listaDeAnotacao)
            {
                str.Append("<tr><td>" + item.data_ + "</td><td>" + item.anotacao1 + "</td><td><a onclick=\"SelecionarAnotacao(" + item.IdAnotacao + ")\">Alterar</a></td><td><a onclick=\"DeleteAnotacao(" + item.IdAnotacao + ")\">Excluir</a></td></tr>");
            }
            str.Append("</table>");

            return str.ToString();
        }

        public string criaTabela(int id)
        {
            IList<Anotacao> listaDeAnotacao = new List<Anotacao>();
            listaDeAnotacao = db.Anotacao.OrderBy(x => x.data_).ToList();

            StringBuilder str = new StringBuilder();

            str.Append("<table class=\"table table-bordered table-striped\">");
            str.Append("<tr><td>DATA</td><td>ANOTAÇÃO</td><td>ALTERAR</td><td>EXCLUIR</td></tr>");
            foreach (var item in listaDeAnotacao)
            {
                if (item.IdAnotacao == id)
                    str.Append("<tr style=\"background-color:green\"><td>" + item.data_ + "</td><td>" + item.anotacao1 + "</td><td>alterar</td><td><a onclick=\"DeleteAnotacao(" + item.IdAnotacao + ")\">Excluir</a></td></tr>");
                else
                    str.Append("<tr><td>" + item.data_ + "</td><td>" + item.anotacao1 + "</td><td>alterar</td><td><a onclick=\"DeleteAnotacao(" + item.IdAnotacao + ")\">Excluir</a></td></tr>");
            }
            str.Append("</table>");

            return str.ToString();
        }

        public string TransformaData(string data)
        {
            string resultado = "";
            string yyyy = "";
            string MM = "";
            string dd = "";
            for (int i = 0; i < data.Length; i++)
            {
                if (i == 0 || i == 1)
                    dd += data[i];
                if (i == 3 || i == 4)
                    MM += data[i];
                if (i >= 6 && i <= 9)
                    yyyy += data[i];
            }
            resultado = yyyy + "-" + MM + "-" + dd;
            return resultado;
        }

    }
}