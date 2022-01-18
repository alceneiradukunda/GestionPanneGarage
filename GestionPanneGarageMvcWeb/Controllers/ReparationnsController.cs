using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GestionPanneGarageMvcWeb.Models;

namespace GestionPanneGarageMvcWeb.Controllers
{
    public class ReparationnsController : Controller
    {
        private GestionEntities4 db = new GestionEntities4();

        //
        // GET: /Reparationns/

        public ActionResult Index()
        {
            var reparations = db.Reparations.Include(r => r.Article).Include(r => r.PanneVehicule);
            return View(reparations.ToList());
        }

        //
        // GET: /Reparationns/Details/5

        public ActionResult Details(int id = 0)
        {
            Reparation reparation = db.Reparations.Find(id);
            if (reparation == null)
            {
                return HttpNotFound();
            }
            return View(reparation);
        }

        //
        // GET: /Reparationns/Create

        public ActionResult Create()
        {
            ViewBag.ArticlesId = new SelectList(db.Articles, "Id", "NomArticle");
            ViewBag.PanneVehiculesId = new SelectList(db.PanneVehicules, "Id", "DateEnregistrement");
            return View();
        }

        //
        // POST: /Reparationns/Create

        [HttpPost]
        public ActionResult Create(Reparation reparation)
        {
            if (ModelState.IsValid)
            {
                db.Reparations.Add(reparation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ArticlesId = new SelectList(db.Articles, "Id", "NomArticle", reparation.ArticlesId);
            ViewBag.PanneVehiculesId = new SelectList(db.PanneVehicules, "Id", "DateEnregistrement", reparation.PanneVehiculesId);
            return View(reparation);
        }

        //
        // GET: /Reparationns/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Reparation reparation = db.Reparations.Find(id);
            if (reparation == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArticlesId = new SelectList(db.Articles, "Id", "NomArticle", reparation.ArticlesId);
            ViewBag.PanneVehiculesId = new SelectList(db.PanneVehicules, "Id", "DateEnregistrement", reparation.PanneVehiculesId);
            return View(reparation);
        }

        //
        // POST: /Reparationns/Edit/5

        [HttpPost]
        public ActionResult Edit(Reparation reparation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reparation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ArticlesId = new SelectList(db.Articles, "Id", "NomArticle", reparation.ArticlesId);
            ViewBag.PanneVehiculesId = new SelectList(db.PanneVehicules, "Id", "DateEnregistrement", reparation.PanneVehiculesId);
            return View(reparation);
        }

        //
        // GET: /Reparationns/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Reparation reparation = db.Reparations.Find(id);
            if (reparation == null)
            {
                return HttpNotFound();
            }
            return View(reparation);
        }

        //
        // POST: /Reparationns/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Reparation reparation = db.Reparations.Find(id);
            db.Reparations.Remove(reparation);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}