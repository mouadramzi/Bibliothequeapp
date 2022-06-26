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
    public class LivresController : Controller
    {
        private context db = new context();

        // GET: Livres
        public ActionResult Index()
        {
            return View(db.livres.ToList());
        }
        public ActionResult recherchelivre(string titre, string auteur, string cat)
        {
            var search = from d in db.livres
                         where d.titre == titre || d.auteur == auteur || d.categorie == cat

                         select d;

            return View("recherchelivre", search.ToList());

        }
        // GET: Livres/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Livre livre = db.livres.Find(id);
            if (livre == null)
            {
                return HttpNotFound();
            }
            return View(livre);
        }

        // GET: Livres/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Livres/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,titre,date,auteur,categorie")] Livre livre)
        {
            if (ModelState.IsValid)
            {
                db.livres.Add(livre);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(livre);
        }

        // GET: Livres/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Livre livre = db.livres.Find(id);
            if (livre == null)
            {
                return HttpNotFound();
            }
            return View(livre);
        }

        // POST: Livres/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,titre,date,auteur,categorie")] Livre livre)
        {
            if (ModelState.IsValid)
            {
                db.Entry(livre).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(livre);
        }

        // GET: Livres/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Livre livre = db.livres.Find(id);
            if (livre == null)
            {
                return HttpNotFound();
            }
            return View(livre);
        }

        // POST: Livres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Livre livre = db.livres.Find(id);
            db.livres.Remove(livre);
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
