using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Model;

namespace MiPrimerProyectoMVC.Controllers
{
    public class BloquesController : Controller
    {
        private TestContext db = new TestContext();

        // GET: Bloques
        public ActionResult Index()
        {
            return View(db.Bloques.ToList());
        }

        // GET: Bloques/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bloque bloque = db.Bloques.Find(id);
            if (bloque == null)
            {
                return HttpNotFound();
            }
            return View(bloque);
        }

        // GET: Bloques/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bloques/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PisoId,Nombre")] Bloque bloque)
        {
            if (ModelState.IsValid)
            {
                db.Bloques.Add(bloque);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bloque);
        }

        // GET: Bloques/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bloque bloque = db.Bloques.Find(id);
            if (bloque == null)
            {
                return HttpNotFound();
            }
            return View(bloque);
        }

        // POST: Bloques/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PisoId,Nombre")] Bloque bloque)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bloque).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bloque);
        }

        // GET: Bloques/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bloque bloque = db.Bloques.Find(id);
            if (bloque == null)
            {
                return HttpNotFound();
            }
            return View(bloque);
        }

        // POST: Bloques/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bloque bloque = db.Bloques.Find(id);
            db.Bloques.Remove(bloque);
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
