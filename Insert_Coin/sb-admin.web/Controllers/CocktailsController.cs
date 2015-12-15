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
    public class CocktailsController : Controller
    {
        private InsertCoinDBEntities db = new InsertCoinDBEntities();

        // GET: Cocktails
        public ActionResult Index()
        {
            return View(db.Cocktail.ToList());
        }

        // GET: Cocktails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cocktail cocktail = db.Cocktail.Find(id);
            if (cocktail == null)
            {
                return HttpNotFound();
            }
            return View(cocktail);
        }

        // GET: Cocktails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cocktails/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idCocktail,nombre,precio_v,ing1,ing2,ing3,ing4,ing5,descripcion")] Cocktail cocktail)
        {
            if (ModelState.IsValid)
            {
                db.Cocktail.Add(cocktail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cocktail);
        }

        // GET: Cocktails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cocktail cocktail = db.Cocktail.Find(id);
            if (cocktail == null)
            {
                return HttpNotFound();
            }
            return View(cocktail);
        }

        // POST: Cocktails/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idCocktail,nombre,precio_v,ing1,ing2,ing3,ing4,ing5,descripcion")] Cocktail cocktail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cocktail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cocktail);
        }

        // GET: Cocktails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cocktail cocktail = db.Cocktail.Find(id);
            if (cocktail == null)
            {
                return HttpNotFound();
            }
            return View(cocktail);
        }

        // POST: Cocktails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cocktail cocktail = db.Cocktail.Find(id);
            db.Cocktail.Remove(cocktail);
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
