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
    public class ReparationsController : Controller
    {
        private GestionPanneGarageEntities db = new GestionPanneGarageEntities();
        // GET: /Reparations/
        //MECANICIEN
        public ActionResult IndexReparation()
        {
            ViewBag.msg = TempData["msg"] as string;
            var reparations = db.Reparations.Include(r => r.Article).Include(r => r.PanneVehicule);
            return View(reparations.ToList());
        }
        public ActionResult Details1(int id = 0)
        {
            Reparation reparation = db.Reparations.Find(id);
            if (reparation == null)
            {
                return HttpNotFound();
            }
            return View(reparation);
        }

        public ActionResult Create1()
        {
            List<ReparationModel> model = (from C in db.Clients
                                           join P in db.PanneVehicules on C.Id equals P.ClientsId
                                           where P.EtatVehicule.Equals("Encours")
                                           select new ReparationModel
                                           {
                                               Nom = C.NomClient,
                                               Prenom = C.Prenomclient,
                                               Telephone = C.Telephone,
                                               Plaque = P.Plaque,
                                               Marque = P.Marque,
                                               Modele = P.Modele,
                                               PanneId = (C.Id),
                                               PannevehiculeId = P.Id,
                                           }).Distinct().ToList();
            ViewBag.CategoriesArticlesId = new SelectList(db.CategoriesArticles, "Id", "NomCategorieArticle");
            //ViewBag.PanneVehiculesId = new SelectList(db.PanneVehicules, "Id", "Plaque");
            return View(model);
        }
        //
        // POST: /Reparations/Create


        [HttpPost]
        public ActionResult Create1(Reparation reparation)
        {
            if (ModelState.IsValid)
            {
                db.Reparations.Add(reparation);
                
                db.SaveChanges();
                TempData["msg"] = "Vous venez de termine la reparation avec Succes";
                var persons = (from p in db.PanneVehicules
                               join R in db.Reparations on p.Id equals R.PanneVehiculesId
                               where p.EtatVehicule == "Encours"
                               select p);
                //TO update using foreach

                foreach (var person in persons)
                {
                    person.EtatVehicule = "Terminer";
                }
                db.SaveChanges();
                return RedirectToAction("IndexReparation");
            }

            ViewBag.ArticlesId = new SelectList(db.Articles, "Id", "NomArticle", reparation.ArticlesId);
            ViewBag.PanneVehiculesId = new SelectList(db.PanneVehicules, "Id", "Plaque", reparation.PanneVehiculesId);
            return View(reparation);
        }

        public ActionResult Edit1(int id = 0)
        {
            Reparation reparation = db.Reparations.Find(id);
            if (reparation == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArticlesId = new SelectList(db.Articles, "Id", "NomArticle", reparation.ArticlesId);
            ViewBag.PanneVehiculesId = new SelectList(db.PanneVehicules, "Id", "Plaque", reparation.PanneVehiculesId);
            return View(reparation);
        }

        //
        // POST: /Reparations/Edit/5

        [HttpPost]
        public ActionResult Edit1(Reparation reparation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reparation).State = EntityState.Modified;
                db.SaveChanges();
                TempData["msg"] = "Vous venez de modifier avec succes";
                return RedirectToAction("IndexReparation");
            }
            ViewBag.ArticlesId = new SelectList(db.Articles, "Id", "NomArticle", reparation.ArticlesId);
            ViewBag.PanneVehiculesId = new SelectList(db.PanneVehicules, "Id", "Plaque", reparation.PanneVehiculesId);
            return View(reparation);
        }

        public ActionResult Delete1(int id = 0)
        {
            Reparation reparation = db.Reparations.Find(id);
            if (reparation == null)
            {
                return HttpNotFound();
            }
            return View(reparation);
        }

        //
        // POST: /Reparations/Delete/5

        [HttpPost, ActionName("Delete1")]
        public ActionResult DeleteConfirmed1(int id)
        {
            Reparation reparation = db.Reparations.Find(id);
            db.Reparations.Remove(reparation);
            TempData["msg"] = "<script>alert('La suppression reusie avec succes');</script>";
            db.SaveChanges();
            return RedirectToAction("IndexReparation");
        }


        //Json Function
        public JsonResult getProducts(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            //List<Article> products = db.Articles.Where(m => m.CategoriesArticlesId == id).ToList();
            List<ArticleModel> products = (from A in db.Articles
                                      join T in db.TypesVehicules on A.TypesVehiculesId equals T.Id
                                      join C in db.CategoriesArticles on A.CategoriesArticlesId equals C.Id
                                      where A.CategoriesArticlesId==id 
                                       select new ArticleModel
                                      {
                                          ArticleName=A.NomArticle,
                                          Description=A.TypesVehicule.DescriptionsVehicules,
                                          Identification = A.Id,
                                      }).ToList();
            return Json(products, JsonRequestBehavior.AllowGet);
        }
        public JsonResult getPlaques(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            //List<PanneVehicule> products = db.PanneVehicules.Where(m => m.ClientsId == id).ToList();
            List<ReparationModel> products = (from C in db.Clients
                                           join P in db.PanneVehicules on C.Id equals P.ClientsId
                                              where P.ClientsId == id && P.EtatVehicule.Equals("Encours")
                                           select new ReparationModel
                                           {
                                               Plaque = P.Plaque,
                                               PannevehiculeId = P.Id,
                                               PanneId = P.ClientsId
                                           }).ToList();
                
            return Json(products, JsonRequestBehavior.AllowGet);
        }
        public JsonResult getUnitPrice(int product_id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var product = db.Articles.Where(p => p.Id == product_id).ToList().FirstOrDefault();
            return Json(product, JsonRequestBehavior.AllowGet);
        }
        //
        // GET: /Reparations/Details/5

        public ActionResult Details(int id = 0)
        {
            Reparation reparation = db.Reparations.Find(id);
            if (reparation == null)
            {
                return HttpNotFound();
            }
            return View(reparation);
        }
        
        //Affichage des vehicules et des clients1
        public ActionResult Listes_Clients_leurs_Vehicules()
        {
            ViewBag.msSg = TempData["mssg"] as string;
            var reparations = db.Reparations.Include(r => r.Article).Include(r => r.PanneVehicule);
            return View(reparations);
            
        }
        [HttpPost]
        public ActionResult Listes_Clients_leurs_Vehicules(DateTime? startDate, DateTime? endDate)
        {
            ViewBag.msSg = TempData["mssg"] as string;
            ViewBag.rapport = "Rapport Du" + startDate + "Au" + endDate;
            var reparations = db.Reparations.Where(x => x.DateReparation >= startDate && x.DateReparation <= endDate).ToList();
            return View(reparations);
        }
        //Affichage des vehicules et des clients2
        public ActionResult Listesdesclientsetleursvehicules()
        {
            ViewBag.msSg = TempData["mssg"] as string;
            var reparations = db.Reparations.Include(r => r.Article).Include(r => r.PanneVehicule);
            return View(reparations);
            
        }
        [HttpPost]
        public ActionResult Listesdesclientsetleursvehicules(DateTime? startDate, DateTime? endDate)
        {
            ViewBag.rapport = "Rapport Du" + startDate + "Au" + endDate;
            var reparations = db.Reparations.Where(x => x.DateReparation >= startDate && x.DateReparation <= endDate).ToList();
            return View(reparations);
        }
        //Affichage par date des vehicules repareres avec la somme d'argent
        public ActionResult Listespardates()
        {

            using (GestionPanneGarageEntities entites = new GestionPanneGarageEntities())
            {
                List<ReparationModelDate> model = (from R in entites.Reparations
                                                   select new { R.DateReparation, R.MontantTotal, R.Id } into x
                                                   group x by
                                                       new { x.DateReparation } into g
                                                   select new ReparationModelDate
                                                   {
                                                       DateReparation = (g.Key.DateReparation),
                                                       SomeMontantTotal = (g.Select(x => x.MontantTotal).Sum()),
                                                   }).ToList();   
                                               
                return View(model);
            }
        }
        //Affichage de montant total par dates
        public ActionResult ListesArgentParDates()
        {

            using (GestionPanneGarageEntities entites = new GestionPanneGarageEntities())
            {
                List<ReparationModelDate> model = (from R in entites.Reparations
                                                   select new { R.DateReparation, R.MontantTotal, R.Id } into x
                                                   group x by
                                                       new { x.DateReparation } into g
                                                   select new ReparationModelDate
                                                   {
                                                       DateReparation = (g.Key.DateReparation),
                                                       SomeMontantTotal = (g.Select(x => x.MontantTotal).Sum()),
                                                   }).ToList();

                return View(model);
            }
        }
        //search base de donnee en se basant sur les dates
        public ActionResult Index()
        {
            return View(db.Reparations.ToList());
        }
        [HttpPost]
        public ActionResult Index(DateTime? startDate, DateTime? endDate)
        {
            ViewBag.rapport = "Rapport du " + startDate + " "+"Au"+" " + endDate;
            var reparations = db.Reparations.Where(x => x.DateReparation >= startDate && x.DateReparation <= endDate).ToList();
            return View(reparations);
        }
        //lISTES DES VEHICULES TERMINENT LA REPARATION DANS Mecanicien
        public ActionResult ListesVehiculesTerminer()
        {
            return View(db.Reparations.ToList());
        }
        [HttpPost]
        public ActionResult ListesVehiculesTerminer(DateTime? startDate, DateTime? endDate)
        {
            var reparations = db.Reparations.Where(x => x.DateReparation >= startDate && x.DateReparation <= endDate).ToList();
            return View(reparations);
        }
        //Affichafage des vehicules terminent de reparer 
        public ActionResult Index2()
        {

            using (GestionPanneGarageEntities entites = new GestionPanneGarageEntities())
            {
                List<ReparationModel> model = (from C in entites.Clients
                                             join P in entites.PanneVehicules on C.Id equals P.ClientsId
                                             join R in entites.Reparations on P.Id equals R.PanneVehiculesId
                                             where P.EtatVehicule.Equals("Terminer")
                                               select new ReparationModel
                                             {
                                                 Nom =C.NomClient,Prenom=C.Prenomclient,Telephone=C.Telephone,
                                                 Plaque=P.Plaque,Marque=P.Marque,Modele=P.Modele,MontantTotal=(R.MontantTotal),DateReparation=(R.DateReparation),
                                                 EtatReparation = R.EtatReparation,
                                                 EtatVehicule = P.EtatVehicule,
                                                 Quantite = (R.Quantite),
                                                 PanneId=C.Id
                                             }). ToList();
                return View(model);
            }
        }
        //
        // GET: /Reparations/Create
        public ActionResult Index1()
        {
            ViewBag.msg = TempData["msg"] as string;
            return View(db.Reparations.ToList());
        }
        public ActionResult Create()
        {
                List<ReparationModel> model = (from C in db.Clients
                                               join P in db.PanneVehicules on C.Id equals P.ClientsId
                                               where P.EtatVehicule.Equals("Encours")
                                               select new ReparationModel
                                               {
                                                   Nom = C.NomClient,
                                                   Prenom = C.Prenomclient,
                                                   Telephone = C.Telephone,
                                                   Plaque = P.Plaque,
                                                   Marque = P.Marque,
                                                   Modele = P.Modele,
                                                   PanneId = (C.Id),
                                                   PannevehiculeId = P.Id,
                                               }).Distinct().ToList();
                
           
            //var PanneVehicule = db.PanneVehicules;
            //ViewData["PanneVehicule"] = PanneVehicule.ToList() ;
            //var Client = db.Clients;
            //ViewData["Client"] = Client.ToList();
                ViewBag.CategoriesArticlesId = new SelectList(db.CategoriesArticles, "Id", "NomCategorieArticle");
            //ViewBag.PanneVehiculesId = new SelectList(db.PanneVehicules, "Id", "Plaque");
            return View(model);
        }


        //
        // POST: /Reparations/Create


        [HttpPost]
        public ActionResult Create(Reparation reparation)
        {
            if (ModelState.IsValid)
            {
                db.Reparations.Add(reparation);
                db.SaveChanges();
                TempData["msg"] = "Vous venez de termine la reparation avec Succes";
                var persons = (from p in db.PanneVehicules
                               join R in db.Reparations on p.Id equals R.PanneVehiculesId
                               where p.EtatVehicule == "Encours"
                               select p);
                //TO update using foreach
                foreach (var person in persons)
                {
                    person.EtatVehicule = "Terminer";
                }
                db.SaveChanges();
                return RedirectToAction("Index1");
            }

            ViewBag.ArticlesId = new SelectList(db.Articles, "Id", "NomArticle", reparation.ArticlesId);
            ViewBag.PanneVehiculesId = new SelectList(db.PanneVehicules, "Id", "Plaque", reparation.PanneVehiculesId);
            return View(reparation);
        }

        //
        // GET: /Reparations/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Reparation reparation = db.Reparations.Find(id);
            if (reparation == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArticlesId = new SelectList(db.Articles, "Id", "NomArticle", reparation.ArticlesId);
            ViewBag.PanneVehiculesId = new SelectList(db.PanneVehicules, "Id", "Plaque", reparation.PanneVehiculesId);
            return View(reparation);
        }

        //
        // POST: /Reparations/Edit/5

        [HttpPost]
        public ActionResult Edit(Reparation reparation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reparation).State = EntityState.Modified;
                db.SaveChanges();
                TempData["msg"] = "Vous venez de modifier avec succes";
                return RedirectToAction("Index1");
            }
            ViewBag.ArticlesId = new SelectList(db.Articles, "Id", "NomArticle", reparation.ArticlesId);
            ViewBag.PanneVehiculesId = new SelectList(db.PanneVehicules, "Id", "Plaque", reparation.PanneVehiculesId);
            return View(reparation);
        }

        //
        // GET: /Reparations/Delete/5

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
        // POST: /Reparations/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Reparation reparation = db.Reparations.Find(id);
            db.Reparations.Remove(reparation);
            TempData["msg"] = "<script>alert('La modification reusie avec succes');</script>";
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