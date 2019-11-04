using AulaMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace AulaMVC.Controllers
{
    public class AcademicoController : Controller
    {
        // GET: Academico
        FACEAR_2019Entities2 db = new FACEAR_2019Entities2();

        public ActionResult List()
        {
            return View();
        }

        public ActionResult Create2()
        {
            return View();
        }

        public JsonResult AddMateriaSessao(string txtNomeMateria, int txtNota1, int txtNota2, int txtNota3, int txtNota4)
        {
            IList<NOTA> listaNotas = new List<NOTA>();
            if (Session["notas"] != null)
            {
                listaNotas = (IList<NOTA>)Session["notas"];
            }
            NOTA n = new NOTA();
            n.NomeMateria = txtNomeMateria;
            n.NotaI = txtNota1;
            n.NotaII = txtNota2;
            n.NotaIII = txtNota3;
            n.NotaIIII = txtNota4;
            listaNotas.Add(n);

            Session["notas"] = listaNotas;

            return Json(new
            {
                listaNotas
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult buscaAcademico(string txtNome, string txtSexo)
        {
            IList<Academico> lista = new List<Academico>();
            lista = db.Academico.Where(x => x.Nome.Contains(txtNome) && x.Sexo.Contains(txtSexo)).ToList();
            //lista = db.Academico.ToList();

            StringBuilder str = new StringBuilder();

            str.Append("<table class=\"table\">");
            str.Append("<tr><td>Nome</td><td>Sexo</td></tr>");

            foreach (var item in lista)
            {
                str.Append("<tr><td>" + item.Nome + "</td><td>" + item.Sexo + "</td></tr>");
            }

            str.Append("</table>");

            return Json(new
            {
                tabela_de_alunos = str.ToString()
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult buscaAcademico2(string txtNome, string txtSexo)
        {
            IList<Academico> aux = new List<Academico>();
            IList<Academico> lista = new List<Academico>();
            aux = db.Academico.Where(x => x.Nome.Contains(txtNome) && x.Sexo.Contains(txtSexo)).ToList();


            foreach (var item in aux)
            {
                Academico ac = new Academico();
                ac.Nome = item.Nome;
                lista.Add(ac);
            }
            return Json(new
            {
                lista
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index()
        {
            //var lista = db.Academico.ToList();
            var lista = db.Academico.Where(x => x.Nome.Contains("Le"));

            return View(lista);
        }

        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            string Nome = (string)form["txtNome"];
            string Sexo = (string)form["txtSexo"];
            string Order = (string)form["txtOrder"];
            var lista = db.Academico.Where(x => x.Nome.Contains(Nome) && x.Sexo.Contains(Sexo));
            //var lista = db.Academico.ToList();

            return View(lista);
        }


        public ActionResult Create()
        {
            /*if (db.Academico.Any(x => x.Nome == "Fabiano"))
            {
                var ac = db.Academico.FirstOrDefault(x=>x.Nome == "Fabiano");
                ac.Nome = "Fabiano Nezello";
                var nota = ac.NOTA.First();
                nota.NomeMateria = "PHP";
                nota.NotaI = 10;
                db.Entry(ac).State = EntityState.Modified;
                db.SaveChanges();
            }
            else {
                Academico ac = new Academico();
                ac.Nome = "Fabiano";
                ac.Sexo = "M";

                NOTA nota = new NOTA();
                nota.NomeMateria = "POO";
                nota.NotaI = 3;
                nota.NotaII = 7.6m;
                nota.NotaIII = 9.0m;
                nota.NotaIIII = 4.5m;
                ac.NOTA.Add(nota);

                NOTA nota_ = new NOTA();
                nota_.NomeMateria = "Java";
                nota_.NotaI = 9;
                nota_.NotaII = 7.6m;
                nota_.NotaIII = 9.0m;
                nota_.NotaIIII = 4.5m;
                ac.NOTA.Add(nota_);

                db.Academico.Add(ac);
                db.SaveChanges();
            }

            return View();*/

            return View();
        }

        [HttpPost]
        public ActionResult Create(Academico academico, FormCollection form)
        {

            return View();
        }
    }
}