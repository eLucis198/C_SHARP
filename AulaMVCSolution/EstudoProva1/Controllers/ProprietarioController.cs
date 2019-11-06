using EstudoProva1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace EstudoProva1.Controllers
{
    public class ProprietarioController : Controller
    {
        EstudoProva1Entities db = new EstudoProva1Entities();

        public JsonResult PesquisarProprietario(FormCollection form)
        {
            bool ativo;
            if (!string.IsNullOrEmpty(form["cbxAtivoProprietario"]))
            {
                ativo = true;
            }
            else
            {
                ativo = false;
            }

            string nome = form["txtNomeProprietario"];
            string cpf = form["txtCpfProprietario"];
            string sexo = form["selectSexoProprietario"];

            IList<Proprietario> lista = new List<Proprietario>();
            if (sexo == "T")
            {
                lista = db.Proprietario.Where(x => x.Nome.Contains(nome) && x.Cpf.Contains(cpf) && (x.Ativo == ativo)).ToList();
            }
            else
            {
                lista = db.Proprietario.Where(x => x.Nome.Contains(nome) && x.Cpf.Contains(cpf) && x.Sexo.Contains(sexo) && (x.Ativo == ativo)).ToList();
            }

            StringBuilder str = new StringBuilder();

            str.Append("<table class=\"table table-bordered table-striped\">");
            str.Append("<tr><td>Nome</td><td>Cpf</td><td>Sexo</td><td>Ativo</td><td>#</td><td>#</td></tr>");

            foreach (var item in lista)
            {
                str.Append("<tr><td>"+item.Nome+ "</td><td>" + item.Cpf + "</td><td>" + item.Sexo+ "</td><td>" + item.Ativo + "</td><td><input type=\"button\" id=\"btnEdit\" value=\"Editar\" onclick=\"Edit(" + item.Id_Proprietario + ")\"/></td><td><input type=\"button\" id=\"btnDelete\" value=\"Deletar\" onclick=\"Delete(" + item.Id_Proprietario + ")\"/></td></tr>");
            }

            str.Append("</table>");

            return Json(new
            {
                tabelaDeProprietarios = str.ToString()
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete(int id)
        {
            Proprietario p = new Proprietario();
            p = db.Proprietario.Find(id);
            p.Ativo = false;
            db.SaveChanges();
            return Json(new { }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Listar()
        {
            return View();
        }

        public JsonResult CadastrarProprietario(FormCollection form)
        {
            bool ativo;
            if (!string.IsNullOrEmpty(form["cbxAtivoProprietario"]))
                ativo = true;
            else
                ativo = false;

            Proprietario p = new Proprietario();
            p.Nome = form["txtNomeProprietario"];
            p.Cpf = form["txtCpfProprietario"];
            p.Sexo = form["selectSexoProprietario"];
            p.Ativo = ativo;

            db.Proprietario.Add(p);
            db.SaveChanges();

            return Json(new
            {
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AdicionarCarroTemp(FormCollection form)
        {
            IList<Carro> listaDeCarro = new List<Carro>();
            if ( !(Session["Carros"] == null) )
            {
                listaDeCarro = (List<Carro>)Session["Carros"];
            }
            int idAux = (int)Session["IdEditar"];
            Proprietario p = new Proprietario();
            p = db.Proprietario.Find(idAux);
            Carro c = new Carro();
            c.Montadora = form["txtMontadora"];
            c.Modelo = form["txtModelo"];
            c.Ano = form["txtAno"];
            c.Cor = form["txtCor"];
            c.Placa = form["txtPlaca"];
            c.Proprietario = p;
            listaDeCarro.Add(c);

            StringBuilder str = new StringBuilder();

            str.Append("<table class=\"table table-bordered table-striped\">");
            str.Append("<tr><td>Montador</td><td>Modelo</td><td>Ano</td><td>Cor</td><td>Placa</td></tr>");

            foreach (var item in listaDeCarro)
            {
                str.Append("<tr><td>" + item.Montadora + "</td><td>" + item.Modelo + "</td><td>" + item.Ano + "</td><td>" + item.Cor + "</td><td>" + item.Placa + "</td></tr>");
            }

            str.Append("</table>");
            Session["Carros"] = listaDeCarro;
            return Json(new
            {
                ListaCarro = str.ToString()
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CarregaCarrosDoCliente()
        {
            var p = new Proprietario();
            if (!(Session["IdEditar"] == null))
            {
                int idAux = (int)Session["IdEditar"];
                p = db.Proprietario.Find(idAux);
            }

            StringBuilder str = new StringBuilder();

            str.Append("<table class=\"table table-bordered table-striped\">");
            str.Append("<tr><td>Montador</td><td>Modelo</td><td>Ano</td><td>Cor</td><td>Placa</td></tr>");

            foreach (var item in p.Carro)
            {
                str.Append("<tr><td>" + item.Montadora + "</td><td>" + item.Modelo+ "</td><td>" + item.Ano + "</td><td>" + item.Cor + "</td><td>" + item.Placa + "</td></tr>");
            }

            str.Append("</table>");

            return Json(new
            {
                ListaCarro = str.ToString()
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        public JsonResult SetarViewBag(int id)
        {
            Session["IdEditar"] = id;
            return Json(new { }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CarregaProprietario()
        {
            int id = (int)Session["IdEditar"];
            Proprietario p = new Proprietario();
            p = db.Proprietario.Find(id);
            string nome = p.Nome;
            string cpf = p.Cpf;
            string sexo = p.Sexo;
            bool ativo = (bool)p.Ativo;
            return Json(new
            {
                nome, cpf, sexo, ativo
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AtualizarProprietario(FormCollection form)
        {
            int id = (int)Session["IdEditar"];
            Proprietario p = new Proprietario();
            p = db.Proprietario.Find(id);
            bool ativo;
            if (!string.IsNullOrEmpty(form["cbxAtivoProprietario"]))
                ativo = true;
            else
                ativo = false;
            p.Nome = form["txtNomeProprietario"];
            p.Cpf = form["txtCpfProprietario"];
            p.Sexo = form["selectSexoProprietario"];
            p.Ativo = ativo;
            db.SaveChanges();
            return Json(new
            { }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Editar()
        {
            if (Session["IdEditar"] == null)
            {
                return RedirectToAction("Listar", "Proprietario");
            }
            return View();
        }
    }
}