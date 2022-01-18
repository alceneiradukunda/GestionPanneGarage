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
    public class VehiculesController : Controller
    {
        private GestionEntities4 db = new GestionEntities4();

        //
        // GET: /Vehicules/

        public ActionResult Index()
        {
            return View(db.Vehicules.ToList());
        }

        //
        // GET: /Vehicules/Details/5

        public ActionResult Details(int id = 0)
        {
            Vehicule vehicule = db.Vehicules.Find(id);
            if (vehicule == null)
            {
                return HttpNotFound();
            }
            return View(vehicule);
        }

        //
        // GET: /Vehicules/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Vehicules/Create

        [HttpPost]
        public ActionResult Create(Vehicule vehicule)
        {
            if (ModelState.IsValid)
            {
                db.Vehicules.Add(vehicule);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vehicule);
        }

        //
        // GET: /Vehicules/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Vehicule vehicule = db.Vehicules.Find(id);
            if (vehicule == null)
            {
                return HttpNotFound();
            }
            return View(vehicule);
        }

        //
        // POST: /Vehicules/Edit/5

        [HttpPost]
        public ActionResult Edit(Vehicule vehicule)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehicule).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vehicule);
        }

        //
        // GET: /Vehicules/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Vehicule vehicule = db.Vehicules.Find(id);
            if (vehicule == null)
            {
                return HttpNotFound();
            }
            return View(vehicule);
        }

        //
        // POST: /Vehicules/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Vehicule vehicule = db.Vehicules.Find(id);
            db.Vehicules.Remove(vehicule);
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