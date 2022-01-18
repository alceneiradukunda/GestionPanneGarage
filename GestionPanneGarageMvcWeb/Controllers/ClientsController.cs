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
    public class ClientsController : Controller
    {
        private GestionPanneGarageEntities db = new GestionPanneGarageEntities();








        //
        // GET: /Clients/

        public ActionResult Index()
        {
            ViewBag.msg = TempData["msg"] as string;
            return View(db.Clients.ToList());
        }

        //
        // GET: /Clients/Details/5

        public ActionResult Details(int id = 0)
        {
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        //
        // GET: /Clients/Create

        public ActionResult Create()
        {
            var client = db.Clients;
            ViewData["client"] = client.ToList();
            return View();
        }
        

        [HttpPost]
        public ActionResult Create(Client client, PanneVehicule panneVehicule)
        {
            if (ModelState.IsValid)
            {
                db.Clients.Add(client);
                db.PanneVehicules.Add(panneVehicule);
                db.SaveChanges();
                TempData["msg"] = "Vous venez Inserer avec Succes";
                return RedirectToAction("Index");
            }

            return View(client);
        }

        //
        // GET: /Clients/Edit/5

        public ActionResult Edit(int id = 0)
        { 
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        //
        // POST: /Clients/Edit/5

        [HttpPost]
        public ActionResult Edit(Client client)
        {
            if (ModelState.IsValid)
            {
                db.Entry(client).State = EntityState.Modified;
                db.SaveChanges();
                TempData["msg"] = "Vous venez de modifier avec succes";
                return RedirectToAction("Index");
            }
            return View(client);
        }

        //
        // GET: /Clients/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        //
        // POST: /Clients/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Client client = db.Clients.Find(id);
            db.Clients.Remove(client);
            TempData["msg"] = "<script>alert('La suppression reusie avec succes');</script>";
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //Mecanicien
        //
        // GET: /Clients/

        public ActionResult Index1()
        {
            return View(db.Clients.ToList());
        }

        //
        // GET: /Clients/Details/5

        public ActionResult Details1(int id = 0)
        {
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        //
        // GET: /Clients/Create

        public ActionResult Create1()
        {
            var client = db.Clients;
            ViewData["client"] = client.ToList();
            return View();
        }


        [HttpPost]
        public ActionResult Create1(Client client, PanneVehicule panneVehicule)
        {
            if (ModelState.IsValid) 
            {
                db.Clients.Add(client);
                db.PanneVehicules.Add(panneVehicule);
                
                db.SaveChanges();
                TempData["msg"] = "Vous venez Inserer avec succes";
                return RedirectToAction("Index1");
            }

            return View(client);
        }

        //
        // GET: /Clients/Edit/5

        public ActionResult Edit1(int id = 0)
        {
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        //
        // POST: /Clients/Edit/5

        [HttpPost]
        public ActionResult Edit1(Client client)
        {
            if (ModelState.IsValid)
            {
                db.Entry(client).State = EntityState.Modified;
                db.SaveChanges();
                TempData["msg"] = "Vous venez de modifier avec succes";
                return RedirectToAction("Index1");
            }
            return View(client);
        }

        //
        // GET: /Clients/Delete/5

        public ActionResult Delete1(int id = 0)
        {
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        //
        // POST: /Clients/Delete/5

        [HttpPost, ActionName("Delete1")]
        public ActionResult DeleteConfirmed1(int id)
        {
            Client client = db.Clients.Find(id);
            db.Clients.Remove(client);
            TempData["msg"] = "<script>alert('La suppression reusie avec succes');</script>";
            db.SaveChanges();
            return RedirectToAction("Index1");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}