using ProvaBimestral2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace ProvaBimestral2.Controllers
{
    public class ProdutoController : Controller
    {
        NotaEntities db = new NotaEntities();
        // GET: Produto
        public ActionResult Cadastrar()
        {
            return View();
        }

        public JsonResult CadastrarProduto(FormCollection form)
        {
            Produto p = new Produto();
            p.Descricao = form["txtDescricaoProduto"];
            p.Valor = Convert.ToDecimal(form["txtValorProduto"]);
            db.Produto.Add(p);
            db.SaveChanges();

            return Json(new { }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult PesquisarProduto()
        {
            StringBuilder str = new StringBuilder();

            str.Append("<table class=\"table table-bordered\">");

            str.Append("<tr> <td>ID</td> <td>DESCRICAO</td> <td>VALOR</td> </tr>");

            foreach (var item in ListarProdutos())
            {
                str.Append("<tr> <td>" + item.ID_Produto + "</td> <td>" + item.Descricao + "</td> <td>" + item.Valor + "</td> </tr>");
            }

            str.Append("</table>");

            return Json(new
            {
                ListaProdutos = str.ToString()
            }, JsonRequestBehavior.AllowGet);
        }

        public IList<Produto> ListarProdutos()
        {
            IList<Produto> listaProdutos = new List<Produto>();
            listaProdutos = db.Produto.ToList();
            return listaProdutos;
        }
    }
}