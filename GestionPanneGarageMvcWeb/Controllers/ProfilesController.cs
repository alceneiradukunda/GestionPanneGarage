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
    public class ProfilesController : Controller
    {
        private GestionPanneGarageEntities db = new GestionPanneGarageEntities();

        //
        // GET: /Profiles/

        public ActionResult Index()
        {
            ViewBag.msg = TempData["msg"] as string;
            return View(db.Profiles.ToList());
        }

        //
        // GET: /Profiles/Details/5

        public ActionResult Details(int id = 0)
        {
            Profile profile = db.Profiles.Find(id);
            if (profile == null)
            {
                return HttpNotFound();
            }
            return View(profile);
        }
        //create1
        //
        // GET: /Profiles/Create

        public ActionResult Create1()
        {
            ViewBag.msg = TempData["msg"] as string;
            return View();
        }

        //
        // POST: /Profiles/Create

        [HttpPost]
        public ActionResult Create1(Profile profile)
        {
            if (ModelState.IsValid)
            {
                db.Profiles.Add(profile);
                db.SaveChanges();
                TempData["msg"]="Vous venez Insert avec Succes";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["msg"] = "impossible Insert Erreur!!!";
                RedirectToAction("Create1");
            }


            return View(profile);
        }
        //create1
        //
        // GET: /Profiles/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Profiles/Create

        [HttpPost]
        public ActionResult Create(Profile profile)
        {
            if (ModelState.IsValid)
            {
                db.Profiles.Add(profile);
                db.SaveChanges();
                TempData["msg"] = "Vous venez Insert avec Succes";
                return RedirectToAction("Index");
            }
            else
            {
                RedirectToAction("Create");
            }
          

            return View(profile);
        }

        //
        // GET: /Profiles/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Profile profile = db.Profiles.Find(id);
            if (profile == null)
            {
                return HttpNotFound();
            }
            return View(profile);
        }

        //
        // POST: /Profiles/Edit/5

        [HttpPost]
        public ActionResult Edit(Profile profile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(profile).State = EntityState.Modified;
                db.SaveChanges();
                TempData["msg"] = "Vous venez de modifier avec succes";
                return RedirectToAction("Index");
            }
            return View(profile);
        }

        //
        // GET: /Profiles/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Profile profile = db.Profiles.Find(id);
            if (profile == null)
            {
                return HttpNotFound();
            }
            return View(profile);
        }

        //
        // POST: /Profiles/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Profile profile = db.Profiles.Find(id);
            db.Profiles.Remove(profile);
            TempData["msg"] = "<script>alert('La suppression reusie avec succes');</script>";
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