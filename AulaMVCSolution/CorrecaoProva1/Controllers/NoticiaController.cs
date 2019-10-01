using CorrecaoProva1.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CorrecaoProva1.Controllers
{
    public class NoticiaController : Controller
    {

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            List<Noticia> listaDeNoticias = new List<Noticia>();
            if (Session["Noticia"] != null)
            {
                listaDeNoticias = (List<Noticia>)Session["Noticia"];
            }

            var n1 = (Noticia)listaDeNoticias.Find(x=> x.Id == id);
            return View(n1);
        }
        // GET: Noticia
        public ActionResult Index()
        {
            IList<Noticia> listaDeNoticias = new List<Noticia>();
            if (Session["Noticia"] != null)
            {
                listaDeNoticias = (List<Noticia>)Session["Noticia"];
            }
            else {
                Noticia n1 = new Noticia();
                n1.Id = 1;
                n1.IdTopico = 1; //Esportes
                n1.Titulo = "Neymar";
                n1.Descricao = "Neymar faz mais 3 jogos pela seleção";
                listaDeNoticias.Add(n1);

                Noticia n2 = new Noticia();
                n2.Id = 2;
                n2.IdTopico = 2; //Jornalismo
                n2.Titulo = "Lula continua na cadeia";
                n2.Descricao = "STF nega pedido de soltura de Lula";
                listaDeNoticias.Add(n2);

                Noticia n3 = new Noticia();
                n3.Id = 3;
                n3.IdTopico = 2; //Jornalismo
                n3.Titulo = "Criança some em Araucária";
                n3.Descricao = "Mais uma criança some em araucaria no meio da fumaça";
                listaDeNoticias.Add(n3);

                Session["Noticia"] = listaDeNoticias;
            }
            return View(listaDeNoticias);
        }

    }
}