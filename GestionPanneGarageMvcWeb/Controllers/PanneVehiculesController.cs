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
    public class PanneVehiculesController : Controller
    {
        private GestionPanneGarageEntities db = new GestionPanneGarageEntities();
        // GET: /PanneVehicules/

        public ActionResult Index1()
        {
            ViewBag.msg = TempData["msg"] as string;
            var pannevehicules = db.PanneVehicules.Include(p => p.Client);
            return View(pannevehicules.ToList());
        }
        public ActionResult Index4()
        {
           
            var pannevehicules = db.PanneVehicules.Include(p => p.Client);
            return View(pannevehicules.ToList());
        }
        [HttpPost]
        public ActionResult Index4(DateTime? startDate, DateTime? endDate)
        {
            ViewBag.rapport = "Rapport Du" + startDate + "Au" + endDate;
            var PanneVehicules = db.PanneVehicules.Where(x => x.DateEnregistrement >= startDate && x.DateEnregistrement <= endDate).ToList();
            return View(PanneVehicules);
        }
        //
        // GET: /PanneVehicules/Details/5

        public ActionResult Details(int id = 0)
        {
            PanneVehicule pannevehicule = db.PanneVehicules.Find(id);
            if (pannevehicule == null)
            {
                return HttpNotFound();
            }
            return View(pannevehicule);
        }
        //Affichage des vehicules en cours de reparation
        public ActionResult Index()
        {

            var PannesVehicules = db.PanneVehicules.Where(x => x.EtatVehicule == "Encours").ToList();
       
            return View(PannesVehicules);
        }
         [HttpPost]
        public ActionResult Index(DateTime? startDate,DateTime? endDate)
        {
            ViewBag.rapport = "Rapport Du" + startDate + "Au" + endDate;
            var PanneVehicules = db.PanneVehicules.Where(x => x.DateEnregistrement >= startDate && x.DateEnregistrement <= endDate).ToList();
            return View(PanneVehicules);
        }
        //Affichage des vehicules en cours de reparation dans mecaniciens
         
         public ActionResult ListesVehiculesEncours()
         {

             var PannesVehicules = db.PanneVehicules.Where(x => x.EtatVehicule == "Encours").ToList();
          
             return View(PannesVehicules);
         }
         [HttpPost]
         public ActionResult ListesVehiculesEncours(DateTime? startDate, DateTime? endDate)
         {
             var PanneVehicules = db.PanneVehicules.Where(x => x.DateEnregistrement >= startDate && x.DateEnregistrement <= endDate).ToList();
             return View(PanneVehicules);
         }
        // GET: /PanneVehicules/Create
        public ActionResult Create()
        {
            List<PanneVehiculeModel> model = (from C in db.Clients
                                              join P in db.PanneVehicules on C.Id equals P.ClientsId
                                              select new PanneVehiculeModel
                                              {
                                                  Nom = C.NomClient,
                                                  Prenom = C.Prenomclient,
                                                  Telephone = C.Telephone,
                                                  Plaque = P.Plaque,
                                                  CLIENTSID = C.Id
                                              }).ToList();
            //ViewBag.ClientsId = new SelectList(db.Clients, "Id", "NomClient");
            return View(model);
        }

        //
        // POST: /PanneVehicules/Create

        [HttpPost]
        public ActionResult Create(PanneVehicule pannevehicule)
        {
            if (ModelState.IsValid)
            {
                db.PanneVehicules.Add(pannevehicule);
                db.SaveChanges();
                TempData["msg"] = "Vous venez Inserer avec Succes";
                return RedirectToAction("Index1");
            }

            ViewBag.ClientsId = new SelectList(db.Clients, "Id", "NomClient", pannevehicule.ClientsId);
            return View(pannevehicule);
        }

        //
        // GET: /PanneVehicules/Edit/5

        public ActionResult Edit(int id = 0)
        {
            PanneVehicule pannevehicule = db.PanneVehicules.Find(id);
            if (pannevehicule == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientsId = new SelectList(db.Clients, "Id", "NomClient", pannevehicule.ClientsId);
            return View(pannevehicule);
        }

        //
        // POST: /PanneVehicules/Edit/5

        [HttpPost]
        public ActionResult Edit(PanneVehicule pannevehicule)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pannevehicule).State = EntityState.Modified;
                db.SaveChanges();
                TempData["msg"] = "Vous venez de modifier avec succes";
                return RedirectToAction("Index1");
            }
            ViewBag.ClientsId = new SelectList(db.Clients, "Id", "NomClient", pannevehicule.ClientsId);
            return View(pannevehicule);
        }

        //
        // GET: /PanneVehicules/Delete/5

        public ActionResult Delete(int id = 0)
        {
            PanneVehicule pannevehicule = db.PanneVehicules.Find(id);
            if (pannevehicule == null)
            {
                return HttpNotFound();
            }
            return View(pannevehicule);
        }

        //
        // POST: /PanneVehicules/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            PanneVehicule pannevehicule = db.PanneVehicules.Find(id);
            db.PanneVehicules.Remove(pannevehicule);
            TempData["msg"] = "<script>alert('La suppression reusie avec succes');</script>";
            db.SaveChanges();
           
            return RedirectToAction("Index1");
        }
        //Mecanicien
        public ActionResult Index2()
        {
            var pannevehicules = db.PanneVehicules.Include(p => p.Client);
            return View(pannevehicules.ToList());
        }
        public ActionResult Details1(int id = 0)
        {
            PanneVehicule pannevehicule = db.PanneVehicules.Find(id);
            if (pannevehicule == null)
            {
                return HttpNotFound();
            }
            return View(pannevehicule);
        }
        public ActionResult Create1()
        {
            List<PanneVehiculeModel> model = (from C in db.Clients
                                              join P in db.PanneVehicules on C.Id equals P.ClientsId
                                              select new PanneVehiculeModel
                                              {
                                                  Nom = C.NomClient,
                                                  Prenom = C.Prenomclient,
                                                  Telephone = C.Telephone,
                                                  Plaque = P.Plaque,
                                                  CLIENTSID = C.Id
                                              }).ToList();
            //ViewBag.ClientsId = new SelectList(db.Clients, "Id", "NomClient");
            return View(model);
        }

        //
        // POST: /PanneVehicules/Create

        [HttpPost]
        public ActionResult Create1(PanneVehicule pannevehicule)
        {
            if (ModelState.IsValid)
            {
                db.PanneVehicules.Add(pannevehicule);
                db.SaveChanges();
                TempData["msg"] = "Vous venez Inserer avec Succes";
                return RedirectToAction("Index2");
            }

            ViewBag.ClientsId = new SelectList(db.Clients, "Id", "NomClient", pannevehicule.ClientsId);
            return View(pannevehicule);
        }

        //
        // GET: /PanneVehicules/Edit/5

        public ActionResult Edit1(int id = 0)
        {
            PanneVehicule pannevehicule = db.PanneVehicules.Find(id);
            if (pannevehicule == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientsId = new SelectList(db.Clients, "Id", "NomClient", pannevehicule.ClientsId);
            return View(pannevehicule);
        }

        //
        // POST: /PanneVehicules/Edit/5

        [HttpPost]
        public ActionResult Edit1(PanneVehicule pannevehicule)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pannevehicule).State = EntityState.Modified;
                db.SaveChanges();
                TempData["msg"] = "Vous venez de modifier avec succes";
                return RedirectToAction("Index2");
            }
            ViewBag.ClientsId = new SelectList(db.Clients, "Id", "NomClient", pannevehicule.ClientsId);
            return View(pannevehicule);
        }

        //
        // GET: /PanneVehicules/Delete/5

        public ActionResult Delete1(int id = 0)
        {
            PanneVehicule pannevehicule = db.PanneVehicules.Find(id);
            if (pannevehicule == null)
            {
                return HttpNotFound();
            }
            return View(pannevehicule);
        }

        //
        // POST: /PanneVehicules/Delete/5

        [HttpPost, ActionName("Delete1")]
        public ActionResult DeleteConfirmed1(int id)
        {
            PanneVehicule pannevehicule = db.PanneVehicules.Find(id);
            db.PanneVehicules.Remove(pannevehicule);
            TempData["msg"] = "<script>alert('La suppression reusie avec succes');</script>";
            db.SaveChanges();
         
            return RedirectToAction("Index2");
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}