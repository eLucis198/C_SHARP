using ProvaBimestral2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
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

        public JsonResult SalvarNota(FormCollection form)
        {
            IList<ItemNota> itensNota = new List<ItemNota>();
            if (Session["ItensNota"] != null)
            {
                itensNota = (List<ItemNota>)Session["itensNota"];
            }


            Nota nota = new Nota();
            nota.Cliente = db.Cliente.Find(Convert.ToInt32(form["selectCliente"]));
            nota.DataNota = DateTime.Now;
            nota.ValorNota = Convert.ToDecimal(form["txtTotalNota"], CultureInfo.InvariantCulture);
            nota.ItemNota = itensNota;
            db.Nota.Add(nota);
            db.SaveChanges();

            Session.Remove("ItensNota");

            return Json(new
            {

            } ,JsonRequestBehavior.AllowGet);
        }

        public JsonResult PegaNumeroNota()
        {
            Nota n = db.Nota.ToList().LastOrDefault();
            int x;

            if (n==null)
            {
                x = 1;
            }
            else {
                x = n.ID_Nota + 1;
            
            }
            return Json(new
            {
                NumeroNota = x
            },JsonRequestBehavior.AllowGet);
        }

        public JsonResult AdicionarProdutoNota(FormCollection form)
        {
            IList<ItemNota> itensNota = new List<ItemNota>();
            if (Session["ItensNota"] != null)
            {
                itensNota = (List<ItemNota>)Session["ItensNota"];
            }

            ItemNota item = new ItemNota();
            item.ID_Produto = Convert.ToInt32(form["selectProduto"]);
            item.Quantidade = Convert.ToInt32(form["txtQuantidade"]);
            item.Valor = Convert.ToDecimal(form["txtValorUnitario"], CultureInfo.InvariantCulture);
            item.ValorTotal = Convert.ToDecimal(form["txtValorTotal"], CultureInfo.InvariantCulture);

            itensNota.Add(item);

            Session["ItensNota"] = itensNota;

            decimal x=0.00M;

            for (int i = 0; i < itensNota.Count; i++)
            {
                x += (decimal)itensNota[i].ValorTotal;
            }

            return Json(new
            {
                ValorNota = x,
                ListaItensNota = CriaTabelaItens(itensNota)
            }, JsonRequestBehavior.AllowGet);
        }

        public string CriaTabelaItens(IList<ItemNota> itensNota)
        {
            StringBuilder str = new StringBuilder();

            str.Append("<table class=\"table table-bordered\">");
            str.Append("<tr> <td>PRODUTO</td> <td>QTD</td> <td>VALOR UNI</td> <td>VALOR TOTAL</td> </tr>");

            foreach (var item in itensNota)
            {
                Produto p = db.Produto.Find(item.ID_Produto);
                str.Append("<tr> <td>"+p.Descricao+"</td> <td>"+item.Quantidade+"</td> <td>"+item.Valor+"</td> <td>"+item.ValorTotal+"</td> </tr>");
            }

            str.Append("</table>");

            return str.ToString();
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