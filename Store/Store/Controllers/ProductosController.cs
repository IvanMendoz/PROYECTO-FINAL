using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Store.Models;

namespace Store.Controllers
{
    public class ProductosController : Controller
    {
        private Data db = new Data();

        // GET: Productos
        public ActionResult Index()
        {
            var productos = db.Productos.Include(p => p.Categorias).Include(p => p.Proveedor);
            return View(productos.ToList());
        }

        // GET: Productos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Productos productos = db.Productos.Find(id);
            if (productos == null)
            {
                return HttpNotFound();
            }
            return View(productos);
        }

        // GET: Productos/Create
        public ActionResult Create()
        {
            ViewBag.Idcategoria = new SelectList(db.Categorias, "Idcategoria", "NombreCate");
            ViewBag.Idproveedor = new SelectList(db.Proveedor, "Idproveedor", "NombreProveedor");
            return View();
        }

        // POST: Productos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Idproducto,NombreProducto,Precio_venta,Descripcion,Presentacion,Cantidad,Estado,Idproveedor,Idcategoria")] Productos productos)
        {
            if (ModelState.IsValid)
            {
                db.Productos.Add(productos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Idcategoria = new SelectList(db.Categorias, "Idcategoria", "NombreCate", productos.Idcategoria);
            ViewBag.Idproveedor = new SelectList(db.Proveedor, "Idproveedor", "NombreProveedor", productos.Idproveedor);
            return View(productos);
        }

        // GET: Productos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Productos productos = db.Productos.Find(id);
            if (productos == null)
            {
                return HttpNotFound();
            }
            ViewBag.Idcategoria = new SelectList(db.Categorias, "Idcategoria", "NombreCate", productos.Idcategoria);
            ViewBag.Idproveedor = new SelectList(db.Proveedor, "Idproveedor", "NombreProveedor", productos.Idproveedor);
            return View(productos);
        }

        // POST: Productos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Idproducto,NombreProducto,Precio_venta,Descripcion,Presentacion,Cantidad,Estado,Idproveedor,Idcategoria")] Productos productos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Idcategoria = new SelectList(db.Categorias, "Idcategoria", "NombreCate", productos.Idcategoria);
            ViewBag.Idproveedor = new SelectList(db.Proveedor, "Idproveedor", "NombreProveedor", productos.Idproveedor);
            return View(productos);
        }

        // GET: Productos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Productos productos = db.Productos.Find(id);
            if (productos == null)
            {
                return HttpNotFound();
            }
            return View(productos);
        }

        // POST: Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Productos productos = db.Productos.Find(id);
            db.Productos.Remove(productos);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
