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
    public class TypesVehiculesController : Controller
    {
        private GestionPanneGarageEntities db = new GestionPanneGarageEntities();

        //
        // GET: /TypesVehicules/

        public ActionResult Index()
        {
            ViewBag.msg = TempData["msg"] as string;
            return View(db.TypesVehicules.ToList());
        }

        //
        // GET: /TypesVehicules/Details/5

        public ActionResult Details(int id = 0)
        {
            TypesVehicule typesvehicule = db.TypesVehicules.Find(id);
            if (typesvehicule == null)
            {
                return HttpNotFound();
            }
            return View(typesvehicule);
        }

        //
        // GET: /TypesVehicules/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /TypesVehicules/Create

        [HttpPost]
        public ActionResult Create(TypesVehicule typesvehicule)
        {
            if (ModelState.IsValid)
            {
                db.TypesVehicules.Add(typesvehicule);
                db.SaveChanges();
                TempData["msg"] = "Vous venez Inserer avec Succes";
                
                return RedirectToAction("Index");
            }

            return View(typesvehicule);
        }

        //
        // GET: /TypesVehicules/Edit/5

        public ActionResult Edit(int id = 0)
        {
            TypesVehicule typesvehicule = db.TypesVehicules.Find(id);
            if (typesvehicule == null)
            {
                return HttpNotFound();
            }
            return View(typesvehicule);
        }

        //
        // POST: /TypesVehicules/Edit/5

        [HttpPost]
        public ActionResult Edit(TypesVehicule typesvehicule)
        {
            if (ModelState.IsValid)
            {
                db.Entry(typesvehicule).State = EntityState.Modified;
                db.SaveChanges();
                TempData["msg"] = "Vous venez de modifier avec succes";
                return RedirectToAction("Index");
            }
            return View(typesvehicule);
        }

        //
        // GET: /TypesVehicules/Delete/5

        public ActionResult Delete(int id = 0)
        {
            TypesVehicule typesvehicule = db.TypesVehicules.Find(id);
            if (typesvehicule == null)
            {
                return HttpNotFound();
            }
            return View(typesvehicule);
        }

        //
        // POST: /TypesVehicules/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            TypesVehicule typesvehicule = db.TypesVehicules.Find(id);
            db.TypesVehicules.Remove(typesvehicule);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //mecanicien

        public ActionResult Index1()
        {
            return View(db.TypesVehicules.ToList());
        }

        //
        // GET: /TypesVehicules/Details/5

        public ActionResult Details1(int id = 0)
        {
            TypesVehicule typesvehicule = db.TypesVehicules.Find(id);
            if (typesvehicule == null)
            {
                return HttpNotFound();
            }
            return View(typesvehicule);
        }

        //
        // GET: /TypesVehicules/Create

        public ActionResult Create1()
        {
            return View();
        }

        //
        // POST: /TypesVehicules/Create

        [HttpPost]
        public ActionResult Create1(TypesVehicule typesvehicule)
        {
            if (ModelState.IsValid)
            {
                db.TypesVehicules.Add(typesvehicule);
                db.SaveChanges();
                TempData["msg"] = "Vous venez Inserer avec Succes";
                return RedirectToAction("Index1");
            }

            return View(typesvehicule);
        }

        //
        // GET: /TypesVehicules/Edit/5

        public ActionResult Edit1(int id = 0)
        {
            TypesVehicule typesvehicule = db.TypesVehicules.Find(id);
            if (typesvehicule == null)
            {
                return HttpNotFound();
            }
            return View(typesvehicule);
        }

        //
        // POST: /TypesVehicules/Edit/5

        [HttpPost]
        public ActionResult Edit1(TypesVehicule typesvehicule)
        {
            if (ModelState.IsValid)
            {
                db.Entry(typesvehicule).State = EntityState.Modified;
                db.SaveChanges();
                TempData["msg"] = "Vous venez de modifier avec succes";
                return RedirectToAction("Index1");
            }
            return View(typesvehicule);
        }

        //
        // GET: /TypesVehicules/Delete/5

        public ActionResult Delete1(int id = 0)
        {
            TypesVehicule typesvehicule = db.TypesVehicules.Find(id);
            if (typesvehicule == null)
            {
                return HttpNotFound();
            }
            return View(typesvehicule);
        }

        //
        // POST: /TypesVehicules/Delete/5

        [HttpPost, ActionName("Delete1")]
        public ActionResult DeleteConfirmed1(int id)
        {
            TypesVehicule typesvehicule = db.TypesVehicules.Find(id);
            db.TypesVehicules.Remove(typesvehicule);
            db.SaveChanges();
            TempData["msg"] = "Vous venez de modifier avec succes";
            return RedirectToAction("Index1");
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}