using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Biblio;

namespace MvcBiblio.Controllers
{
    public class AuteursController : Controller
    {
        private BiblioDC db = new BiblioDC();

        // GET: Auteurs
        public ActionResult Index()
        {
            return View(db.auteurs.ToList());
        }

        // GET: Auteurs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auteur auteur = db.auteurs.Find(id);
            if (auteur == null)
            {
                return HttpNotFound();
            }
            return View(auteur);
        }

        // GET: Auteurs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Auteurs/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AuteurId,nom,prenom,nationalite")] Auteur auteur)
        {
            if (ModelState.IsValid)
            {
                db.auteurs.Add(auteur);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(auteur);
        }

        // GET: Auteurs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auteur auteur = db.auteurs.Find(id);
            if (auteur == null)
            {
                return HttpNotFound();
            }
            return View(auteur);
        }

        // POST: Auteurs/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AuteurId,nom,prenom,nationalite")] Auteur auteur)
        {
            if (ModelState.IsValid)
            {
                db.Entry(auteur).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(auteur);
        }

        // GET: Auteurs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auteur auteur = db.auteurs.Find(id);
            if (auteur == null)
            {
                return HttpNotFound();
            }
            return View(auteur);
        }

        // POST: Auteurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Auteur auteur = db.auteurs.Find(id);
            db.auteurs.Remove(auteur);
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
