using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Crud;

namespace Crud.Controllers
{
    public class RevistasController : Controller
    {
        private ExamenEntities db = new ExamenEntities();

        // GET: Revistas
        public ActionResult Index()
        {
            return View(db.Revistas.ToList());
        }

        // GET: Revistas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Revistas revistas = db.Revistas.Find(id);
            if (revistas == null)
            {
                return HttpNotFound();
            }
            return View(revistas);
        }

        // GET: Revistas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Revistas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Titulo,CodigoBarra,FechaCirculacion,Precio")] Revistas revistas)
        {
            if (ModelState.IsValid)
            {
                db.Revistas.Add(revistas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(revistas);
        }

        // GET: Revistas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Revistas revistas = db.Revistas.Find(id);
            if (revistas == null)
            {
                return HttpNotFound();
            }
            return View(revistas);
        }

        // POST: Revistas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Titulo,CodigoBarra,FechaCirculacion,Precio")] Revistas revistas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(revistas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(revistas);
        }

        // GET: Revistas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Revistas revistas = db.Revistas.Find(id);
            if (revistas == null)
            {
                return HttpNotFound();
            }
            return View(revistas);
        }

        // POST: Revistas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Revistas revistas = db.Revistas.Find(id);
            db.Revistas.Remove(revistas);
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
