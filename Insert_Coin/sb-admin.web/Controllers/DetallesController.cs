using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using sb_admin.web.Models;

namespace sb_admin.web.Controllers
{
    public class DetallesController : Controller
    {
        private InsertCoinDBEntities db = new InsertCoinDBEntities();

        // GET: Detalles
        public ActionResult Index()
        {
            var detalle = db.Detalle.Include(d => d.Pedido);
            return View(detalle.ToList());
        }

        // GET: Detalles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detalle detalle = db.Detalle.Find(id);
            if (detalle == null)
            {
                return HttpNotFound();
            }
            return View(detalle);
        }

        // GET: Detalles/Create
        public ActionResult Create()
        {
            ViewBag.idPedido = new SelectList(db.Pedido, "idPedido", "idPedido");
            return View();
        }

        // POST: Detalles/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idDetalle,idPedido,nombreConsumo,estado,costo")] Detalle detalle)
        {
            if (ModelState.IsValid)
            {
                db.Detalle.Add(detalle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idPedido = new SelectList(db.Pedido, "idPedido", "idPedido", detalle.idPedido);
            return View(detalle);
        }

        // GET: Detalles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detalle detalle = db.Detalle.Find(id);
            if (detalle == null)
            {
                return HttpNotFound();
            }
            ViewBag.idPedido = new SelectList(db.Pedido, "idPedido", "idPedido", detalle.idPedido);
            return View(detalle);
        }

        // POST: Detalles/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idDetalle,idPedido,nombreConsumo,estado,costo")] Detalle detalle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detalle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idPedido = new SelectList(db.Pedido, "idPedido", "idPedido", detalle.idPedido);
            return View(detalle);
        }

        // GET: Detalles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detalle detalle = db.Detalle.Find(id);
            if (detalle == null)
            {
                return HttpNotFound();
            }
            return View(detalle);
        }

        // POST: Detalles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Detalle detalle = db.Detalle.Find(id);
            db.Detalle.Remove(detalle);
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
