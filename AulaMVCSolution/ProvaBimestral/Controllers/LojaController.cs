using ProvaBimestral.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProvaBimestral.Controllers
{
    public class LojaController : Controller
    {
        // GET: Loja
        // GET: Loja
        public ActionResult Index()
        {
            if (Session["Logado"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                IList<Produto> listaDeProduto = new List<Produto>();
                if (Session["Produtos"] != null)
                {
                    listaDeProduto = (List<Produto>)Session["Produtos"];
                }
                else
                {
                    //IdCategoria: 1-Celular, 2-Tablet, 3-Notebook, 4-Carregadores

                    // CELULARES
                    Produto p1 = new Produto();
                    p1.Id = 1;
                    p1.IdCategoria = 1;
                    p1.Nome = "Samsung Galaxy S10+";
                    p1.Descricao = "Armazenamento: 1TB, Memória: 12GB, Tela: 6.4 pol";
                    p1.Marca = "Samsung";
                    p1.Modelo = "Galaxy S10+";
                    p1.Preco = "R$ 8.000,00";
                    listaDeProduto.Add(p1);
                    Produto p2 = new Produto();
                    p2.Id = 2;
                    p2.IdCategoria = 1;
                    p2.Nome = "iPhone XS Max";
                    p2.Descricao = "Armazenamento: 512GB, Memória: 4GB, Tela: 6.5 pol";
                    p2.Marca = "Apple";
                    p2.Modelo = "XS Max";
                    p2.Preco = "R$ 6.000,00";
                    listaDeProduto.Add(p2);

                    // TABLETES
                    Produto p3 = new Produto();
                    p3.Id = 3;
                    p3.IdCategoria = 2;
                    p3.Nome = "Tablet 1";
                    p3.Descricao = "Armazenamento: 1TB, Memória: 8GB, Tela: 15.6 pol";
                    p3.Marca = "Samsung";
                    p3.Modelo = "Galaxy Tab 2";
                    p3.Preco = "R$ 2.000,00";
                    listaDeProduto.Add(p3);
                    Produto p4 = new Produto();
                    p4.Id = 4;
                    p4.IdCategoria = 2;
                    p4.Nome = "Tablet 2";
                    p4.Descricao = "Armazenamento: 1TB, Memória: 16GB, Tela: 15.6 pol";
                    p4.Marca = "Apple";
                    p4.Modelo = "Ipad 2 Pro";
                    p4.Preco = "R$ 3.500,00";
                    listaDeProduto.Add(p4);

                    // NOTEBOOKS
                    Produto p5 = new Produto();
                    p5.Id = 5;
                    p5.IdCategoria = 3;
                    p5.Nome = "Notebook Dell";
                    p5.Descricao = "Armazenamento: 1TB, Memória: 16GB, Tela: 15.6 pol";
                    p5.Marca = "Dell";
                    p5.Modelo = "Inspiron 7460";
                    p5.Preco = "R$ 4.500,00";
                    listaDeProduto.Add(p5);
                    Produto p6 = new Produto();
                    p6.Id = 6;
                    p6.IdCategoria = 3;
                    p6.Nome = "Notebook Acer";
                    p6.Descricao = "Armazenamento: 1TB, Memória: 8GB, Tela: 17.5 pol";
                    p6.Marca = "Acer";
                    p6.Modelo = "RX 3300";
                    p6.Preco = "R$ 4.200,00";
                    listaDeProduto.Add(p6);

                    // CARREGADORES
                    Produto p7 = new Produto();
                    p7.Id = 7;
                    p7.IdCategoria = 4;
                    p7.Nome = "Carregador Sem Fio";
                    p7.Descricao = "Velocidade: 30 Watts";
                    p7.Marca = "Samsung";
                    p7.Modelo = "Stand+";
                    p7.Preco = "R$ 1.100,00";
                    listaDeProduto.Add(p7);
                    Produto p8 = new Produto();
                    p8.Id = 8;
                    p8.IdCategoria = 4;
                    p8.Nome = "Carregador Razer II";
                    p8.Descricao = "Velocidade: 25 Watts";
                    p8.Marca = "Razer";
                    p8.Modelo = "Pro Stand";
                    p8.Preco = "R$ 800,00";
                    listaDeProduto.Add(p8);

                    Session["Produtos"] = listaDeProduto;
                }
                return View(listaDeProduto);
            }
        }

        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            Session.Remove("Logado");
            return RedirectToAction("Index", "Login");
        }

        public ActionResult Novo()
        {
            if (Session["Logado"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else if (!Session["Logado"].Equals("admin"))
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult Novo(Produto produto)
        {
            if (Session["Logado"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else if (!Session["Logado"].Equals("admin"))
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(produto);
                }
                else
                {
                    IList<Produto> listaDeProduto = new List<Produto>();
                    listaDeProduto = (List<Produto>)Session["Produtos"];
                    listaDeProduto.Add(produto);
                    Session["Produtos"] = listaDeProduto;
                    Response.Write("<script>alert('Produto criado com sucesso!');</script>");
                    return View();
                }
            }
        }

        public ActionResult Edit(int id)
        {
            if (Session["Logado"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else if (!Session["Logado"].Equals("admin"))
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                List<Produto> listaDeProduto = new List<Produto>();
                if (Session["Produtos"] != null)
                {
                    listaDeProduto = (List<Produto>)Session["Produtos"];
                }
                var p1 = (Produto)listaDeProduto.Find(x => x.Id == id);
                return View(p1);
            }
        }
        [HttpPost]
        public ActionResult Edit(Produto produto)
        {
            if (Session["Logado"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else if (!Session["Logado"].Equals("admin"))
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(produto);
                }
                else
                {
                    IList<Produto> listaDeProduto = new List<Produto>();
                    listaDeProduto = (List<Produto>)Session["Produtos"];
                    for (int i = 0; i < listaDeProduto.Count; i++)
                    {
                        if (listaDeProduto[i].Id == produto.Id)
                        {
                            listaDeProduto[i].IdCategoria = produto.IdCategoria;
                            listaDeProduto[i].Nome = produto.Nome;
                            listaDeProduto[i].Descricao = produto.Descricao;
                            listaDeProduto[i].Marca = produto.Marca;
                            listaDeProduto[i].Modelo = produto.Modelo;
                            listaDeProduto[i].Preco = produto.Preco;
                        }
                    }
                    listaDeProduto = listaDeProduto.OrderBy(p => p.Id).ToList();
                    Session["Produtos"] = listaDeProduto;
                    Response.Write("<script>alert('Produto atualizado com sucesso!');</script>");
                    return View();
                }
            }
        }

        public ActionResult Delete(int id)
        {
            if (Session["Logado"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else if (!Session["Logado"].Equals("admin"))
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                List<Produto> listaDeProduto = new List<Produto>();
                if (Session["Produtos"] != null)
                {
                    listaDeProduto = (List<Produto>)Session["Produtos"];
                }
                for (int i = 0; i < listaDeProduto.Count; i++)
                {
                    if (listaDeProduto[i].Id == id)
                    {
                        listaDeProduto.RemoveAt(i);
                    }
                }
                listaDeProduto = listaDeProduto.OrderBy(p => p.Id).ToList();
                Session["Produtos"] = listaDeProduto;
                return RedirectToAction("Index", "Loja");
            }
        }

        public ActionResult Celular()
        {
            if (Session["Logado"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                IList<Produto> listaDeProduto = new List<Produto>();
                listaDeProduto = (List<Produto>)Session["Produtos"];
                return View(listaDeProduto);
            }
        }

        public ActionResult Notebook()
        {
            if (Session["Logado"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                IList<Produto> listaDeProduto = new List<Produto>();
                listaDeProduto = (List<Produto>)Session["Produtos"];
                return View(listaDeProduto);
            }
        }

        public ActionResult Tablet()
        {
            if (Session["Logado"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                IList<Produto> listaDeProduto = new List<Produto>();
                listaDeProduto = (List<Produto>)Session["Produtos"];
                return View(listaDeProduto);
            }
        }

        public ActionResult Carregador()
        {
            if (Session["Logado"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                IList<Produto> listaDeProduto = new List<Produto>();
                listaDeProduto = (List<Produto>)Session["Produtos"];
                return View(listaDeProduto);
            }
        }

        public ActionResult Dados(int id)
        {
            if (Session["Logado"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                List<Produto> listaDeProduto = new List<Produto>();
                if (Session["Produtos"] != null)
                {
                    listaDeProduto = (List<Produto>)Session["Produtos"];
                }
                var p1 = (Produto)listaDeProduto.Find(x => x.Id == id);
                return View(p1);
            }
        }
    }
}