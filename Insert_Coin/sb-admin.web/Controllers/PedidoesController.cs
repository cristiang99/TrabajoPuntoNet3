﻿using System;
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
    public class PedidoesController : Controller
    {
        private InsertCoinDBEntities db = new InsertCoinDBEntities();

        // GET: Pedidoes
        public ActionResult Index()
        {
            var pedido = db.Pedido.Include(p => p.Mesa);
            return View(pedido.ToList());
        }

        // GET: Pedidoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedido pedido = db.Pedido.Find(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            return View(pedido);
        }

        // GET: Pedidoes/Create
        public ActionResult Create()
        {
            //ViewBag.numeroMesa = new SelectListItem();
            var modelo = from p in db.Mesa where p.estado == 0 select p;
            ViewBag.numeroMesa = new MultiSelectList(modelo, "numeroMesa", "numeroMesa");

            return View();
        }

        // POST: Pedidoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idPedido,fecha,numeroMesa,total")] Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                db.Pedido.Add(pedido);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            ViewBag.numeroMesa = new SelectList(db.Mesa, "numeroMesa", "numeroMesa", pedido.numeroMesa);
            return View(pedido);
        }

        // GET: Pedidoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedido pedido = db.Pedido.Find(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            var modelo = from p in db.Mesa where p.estado == 0 select p;
            ViewBag.numeroMesa = new SelectList(modelo, "numeroMesa", "numeroMesa", pedido.numeroMesa);
            ViewBag.cocktails = new SelectList(db.Cocktail, "idCocktail", "nombre");
            return View(pedido);
        }

        // POST: Pedidoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idPedido,fecha,numeroMesa,total")] Pedido pedido)
        {
            Detalle det = new Detalle();
            
            string  id_producto =""+ Request.Form.GetValues("idPedido");
            string nombre_produco = "" + Request.Form.GetValues("nombre");
            var modelo = from p in db.Cocktail where p.nombre == nombre_produco select p.precio_v;
            det.nombreConsumo = nombre_produco;
            det.estado = "no pago";
       
            if (ModelState.IsValid)
            {
                db.Entry(pedido).State = EntityState.Modified;
                db.SaveChanges();
                db.Detalle.Add(det);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.numeroMesa = new SelectList(db.Mesa, "numeroMesa", "numeroMesa", pedido.numeroMesa);
            return View(pedido);
        }

        // GET: Pedidoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedido pedido = db.Pedido.Find(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            return View(pedido);
        }

        // POST: Pedidoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pedido pedido = db.Pedido.Find(id);
            db.Pedido.Remove(pedido);
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
