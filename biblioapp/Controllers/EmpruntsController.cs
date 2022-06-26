using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using biblioapp.Models;

namespace biblioapp.Models
{
    public class EmpruntsController : Controller
    {
        private context db = new context();

        // GET: Emprunts
        public ActionResult Index()
        {
            return View(db.emprunts.ToList());
        }
        public ActionResult empruntlivre(int codelivre=0, int codeetudiant=0   , int idu= 0 )
        {
            var search = from d in db.emprunts
                         where d.Matricule == codeetudiant || d.codelivre == codelivre  ||d.id==idu

                         select d;

            return View("empruntlivre", search.ToList());

        }
        // GET: Emprunts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emprunt emprunt = db.emprunts.Find(id);
            if (emprunt == null)
            {
                return HttpNotFound();
            }
            return View(emprunt);
        }

        // GET: Emprunts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Emprunts/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Matricule,codelivre")] Emprunt emprunt)
        {
            if (ModelState.IsValid)
            {
                db.emprunts.Add(emprunt);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(emprunt);
        }

        // GET: Emprunts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emprunt emprunt = db.emprunts.Find(id);
            if (emprunt == null)
            {
                return HttpNotFound();
            }
            return View(emprunt);
        }

        // POST: Emprunts/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Matricule,codelivre")] Emprunt emprunt)
        {
            if (ModelState.IsValid)
            {
                db.Entry(emprunt).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(emprunt);
        }

        // GET: Emprunts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emprunt emprunt = db.emprunts.Find(id);
            if (emprunt == null)
            {
                return HttpNotFound();
            }
            return View(emprunt);
        }

        // POST: Emprunts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Emprunt emprunt = db.emprunts.Find(id);
            db.emprunts.Remove(emprunt);
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
