using ProvaBimestral2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace ProvaBimestral2.Controllers
{
    public class ClienteController : Controller
    {
        NotaEntities db = new NotaEntities();
        // GET: Cliente
        public ActionResult Cadastrar()
        {
            return View();
        }

        public JsonResult CadastrarCliente(FormCollection form)
        {
            Cliente c = new Cliente();
            c.Nome = form["txtNomeCliente"];
            c.CPF = form["txtCpfCliente"];
            db.Cliente.Add(c);
            db.SaveChanges();

            return Json(new { }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult PesquisarCliente()
        {
            StringBuilder str = new StringBuilder();

            str.Append("<table class=\"table table-bordered\">");

            str.Append("<tr> <td>ID</td> <td>NOME</td> <td>CPF</td> </tr>");

            foreach (var item in ListarClientes())
            {
                str.Append("<tr> <td>" + item.ID_Cliente + "</td> <td>" + item.Nome + "</td> <td>" + item.CPF + "</td> </tr>");
            }

            str.Append("</table>");

            return Json(new
            {
                ListaClientes = str.ToString()
            }, JsonRequestBehavior.AllowGet);
        }

        public IList<Cliente> ListarClientes()
        {
            IList<Cliente> listaClientes = new List<Cliente>();
            listaClientes = db.Cliente.ToList();
            return listaClientes;
        }
    }
}