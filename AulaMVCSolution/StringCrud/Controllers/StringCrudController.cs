using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StringCrud.Controllers
{
    public class StringCrudController : Controller
    {
        // GET: StringCrud
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(FormCollection form)
        {
            return View();
        }

        public ActionResult Update()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Update(FormCollection form)
        {
            return View();
        }

        public ActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(FormCollection form)
        {
            return View();
        }

        public ActionResult Read()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Read(FormCollection form)
        {
            return View();
        }
    }
}