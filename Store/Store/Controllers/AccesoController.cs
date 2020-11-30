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
    public class AccesoController : Controller
    {
        private Data db = new Data();
        // GET: Acceso

        public ActionResult Login(string User, string Pass)
        {
            Variables ob = new Variables();
            
            try
            {
                using (Models.Data db = new Models.Data())
                {
                    var oUser = (from d in db.Usuario
                                 where d.Nickusuario == User.Trim() && d.Contra == Pass.Trim()
                                 select d).FirstOrDefault();
                    
                    if (oUser == null)
                    {
                        
                        return View();
                    }



                    Session["User"] = oUser;
                }
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }
        public ActionResult Register()
        {
            return View();
        }

        // POST: Usuarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "NombresUsuario,Nickusuario,Fecha_nacimiento,Genero,email,Direccion,Telefono,Contra")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Usuario.Add(usuario);
                db.SaveChanges();
                return RedirectToAction("Index","Home");
            }

            return View(usuario);
        }




    }  
}