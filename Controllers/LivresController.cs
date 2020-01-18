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
    public class LivresController : Controller
    {
        private BiblioDC db = new BiblioDC();

        // GET: Livres
        public ActionResult Index(String ThemeId)
        {
            ViewBag.ThemeId = new SelectList(db.themes, "ThemeId", "titre");
            if (ThemeId != null)
            {
                Int32 id = Int32.Parse(ThemeId);
                var et = db.livres.Where(e => e.theme.ThemeId==id).ToList();
                return View(et);
            }
            var livres = db.livres.Include(l => l.auteur).Include(l => l.theme);
            return View(livres.ToList());
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
            ViewBag.AuteurId = new SelectList(db.auteurs, "AuteurId", "nom");
            ViewBag.ThemeId = new SelectList(db.themes, "ThemeId", "titre");
            return View();
        }

        // POST: Livres/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LivreId,titre,description,prix,quantite,poids,langue,datepublication,AuteurId,ThemeId")] Livre livre)
        {
            if (ModelState.IsValid)
            {
                db.livres.Add(livre);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AuteurId = new SelectList(db.auteurs, "AuteurId", "nom", livre.AuteurId);
            ViewBag.ThemeId = new SelectList(db.themes, "ThemeId", "titre", livre.ThemeId);
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
            ViewBag.AuteurId = new SelectList(db.auteurs, "AuteurId", "nom", livre.AuteurId);
            ViewBag.ThemeId = new SelectList(db.themes, "ThemeId", "titre", livre.ThemeId);
            return View(livre);
        }

        // POST: Livres/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LivreId,titre,description,prix,quantite,poids,langue,datepublication,AuteurId,ThemeId")] Livre livre)
        {
            if (ModelState.IsValid)
            {
                db.Entry(livre).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AuteurId = new SelectList(db.auteurs, "AuteurId", "nom", livre.AuteurId);
            ViewBag.ThemeId = new SelectList(db.themes, "ThemeId", "titre", livre.ThemeId);
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
