using Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using System.Net;

namespace Store.Controllers
{
    public class HomeController : Controller
    {
        private Data db = new Data();
        // GET: Home
        public ActionResult Index()
        {
                return View();
        }

        public ActionResult MI(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }


    }
}